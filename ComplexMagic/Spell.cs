using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace AMagicalWorld.ComplexMagic
{
    public class Spell
    {
        public string name = "";
        public static void CastSpell(Player player, Spell spell)
        {
            spell.Cast(player);
        }

        public void Cast(Player player)
        {
            AForm Form = Attribute.Get(Attributes.Form) as AForm;
            ACast Cast = Attribute.Get(Attributes.Cast) as ACast;
            ABehaviour Behaviour = Attribute.Get(Attributes.Behaviour) as ABehaviour;

            Vector2 CastPosition = Cast.Position(player);
            Vector2 Direction = Cast.Direction(player);

            Direction.Normalize();
            Direction *= Attributes.GetValues(Modifiers.ProjSpeed);

            int projectileIDX = Projectile.NewProjectile(player.GetSource_FromAI(), CastPosition, Direction, ModContent.ProjectileType<projSpell>(), 0, 0, player.whoAmI);

            Projectile proj = Main.projectile[projectileIDX];
            projSpell pSpell = proj.ModProjectile as projSpell;
            pSpell.Attributes = Attributes;

            Form.Setup(pSpell);
            Behaviour.PostSetup(pSpell);

            proj.penetrate = Attributes.GetIValues(Modifiers.Penetrate);
            proj.damage = Attributes.GetIValues(Modifiers.Damage);

            Console.WriteLine(Attributes.GetValues(Modifiers.ProjSpeed) + " - " + Attributes.GetIValues(Modifiers.Penetrate));
        }


        public AttributeSet Attributes;

        public Spell(AttributeSet Attributes, string name = "")
        {
            this.Attributes = Attributes;
            this.name = name;
        }

        public static Spell loadSpell(TagCompound tag)
        {
            Spell spell = new Spell(new AttributeSet(
                tag.GetInt("Cast"),
                tag.GetInt("Form"),
                tag.GetInt("Behaviour"),
                tag.GetInt("Trail"),
                tag.GetInt("Color"),
                tag.Get<List<int>>("AE")),
                name: tag.GetString("Name"));

            return spell;
        }

        public void save(TagCompound tag)
        {
            tag.Add("Cast", Attributes.Cast);
            tag.Add("Form", Attributes.Form);
            tag.Add("Behaviour", Attributes.Behaviour);
            tag.Add("Trail", Attributes.Trail);
            tag.Add("Color", Attributes.Color);
            tag.Add("AE", Attributes.AdditionalEffects);
            tag.Add("Name", name);
        }
    }

    public enum AttributeTypes
    {
        // Needed
        Cast,
        Form,
        Behaviour,
        Trail,
        Color, // (yeah... its just the color, make it looks pretty if you want :middle_finger: (to player))

        // Other effects...
        PreCast,
        StatusEffect,
        HitTile,
        Timed,
        ConstApplication,

        Other, // every attribute can have multipliers, this only has multipliers (is the idea)
    }

    public enum Modifiers
    {
        Damage,
        ManaCost,
        ProjSpeed,
        Penetrate,
        Usetime,
        RecastDelay,
        EffectDuration,
        EffectRange, //(?) - only if its used ofc
    }

    public enum ModifierApplication
    {
        Multiply,
        Add,
        Set,
    }

    public class Modifier
    {
        public ModifierApplication application; // if true + if false *
        private float _value;
        private Func<float> _funcValue = null;

        public float value
        {
            get
            {
                if (_funcValue == null)
                    return _value;

                return _funcValue();
            }
        }

        public Modifier(float value, ModifierApplication application)
        {
            _value = value; this.application = application;
        }
        public Modifier(Func<float> func, ModifierApplication application)
        {
            this._funcValue = func; this.application = application;
        }

    }

    public class AttributeSet
    {
        public int Cast;
        public int Form;
        public int Behaviour;
        public int Trail;
        public int Color;

        public List<int> AllEffects = new List<int>();

        public List<int> AdditionalEffects;

        public AttributeSet(int Cast, int Form, int Behaviour, int Trail, int Color, List<int> AdditionalEffects)
        {
            // no need to check if they are the right type,
            // totally gonna make this program perfectly,
            // so theres no chance for it to fuck up EZ

            this.AdditionalEffects = AdditionalEffects;

            AllEffects.Add(Cast);
            AllEffects.Add(Form);
            AllEffects.Add(Behaviour);
            AllEffects.Add(Trail);
            AllEffects.Add(Color);
            foreach (int affect in AdditionalEffects)
            {
                AllEffects.Add(affect);
            }

            this.Cast = Cast;
            this.Form = Form;
            this.Behaviour = Behaviour;
            this.Trail = Trail;
            this.Color = Color;

        }
        public int GetIValues(Modifiers Modifier)
        {
            return (int)MathF.Round(GetValues(Modifier));
        }

        public float GetValues(Modifiers Modifier)
        {
            float multiplier = 1;

            float res = 0;
            Modifier mod;
            foreach (int atribute in AllEffects)
            {
                bool found = Attribute.Get(atribute).AModifiers.TryGetValue(Modifier, out mod);

                if (found)
                {
                    switch (mod.application)
                    {
                        case ModifierApplication.Multiply:
                            multiplier *= mod.value;
                            break;
                        case ModifierApplication.Add:
                            res += mod.value;
                            break;
                        case ModifierApplication.Set:
                            return mod.value;
                    }
                }
            }

            return res * multiplier;
        }
    }

    // spell also needs an item to hold the spell in it...

    public class projSpell : ModProjectile
    {
        public int lifetime = -1;
        public AttributeSet Attributes;
        public Player player => Main.player[Projectile.owner];
        public override void AutoStaticDefaults()
        {
            TextureAssets.Projectile[Projectile.type] = ModContent.Request<Texture2D>("AMagicalWorld/icon");
        }
        public override void SetStaticDefaults()
        {
            //.setdefault("skill issue");
            //Main.projFrames[Projectile.type] = 1;
            //ProjectileID.Sets.TrailCacheLength[Projectile.type] = 25; // in SetStaticDefaults()
            //ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
        }

        public override bool PreAI()
        {
            lifetime++;
            ABehaviour Behaviour = Attribute.Get(Attributes.Behaviour) as ABehaviour;

            bool vanilaAI = Behaviour.Update(this);

            if (!vanilaAI)
            {
                ATrail Trail = Attribute.Get(Attributes.Trail) as ATrail;
                Trail.TrailAI(this);
            }

            return vanilaAI;
        }

        public override void AI()
        {
            ATrail Trail = Attribute.Get(Attributes.Trail) as ATrail;

            Trail.TrailAI(this);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            AForm Form = Attribute.Get(Attributes.Form) as AForm;
            ATrail Trail = Attribute.Get(Attributes.Trail) as ATrail;

            Form.Draw(this, ref lightColor);
            Trail.DrawTrail(this, ref lightColor);

            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            foreach (int atribute in Attributes.AdditionalEffects)
            {
                if (Attribute.Get(atribute).AttributeType == AttributeTypes.StatusEffect)
                {
                    Console.WriteLine("a");
                    (Attribute.Get(atribute) as AStatusEffect).ApplyStatusEffect(target, this);
                }
            }

            base.OnHitNPC(target, hit, damageDone);
        }
    }
}
