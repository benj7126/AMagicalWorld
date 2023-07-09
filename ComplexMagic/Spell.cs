using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
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

namespace AMagicalWorld.ComplexMagic
{
    public class Spell
    {
        public static void CastSpell(Player player, Spell spell)
        {
            spell.Cast(player);
        }

        public void Cast(Player player)
        {
            AForm Form = Attribute.Get(Attributes.Form) as AForm;
            ACast Cast = Attribute.Get(Attributes.Cast) as ACast;

            Vector2 CastPosition = Cast.Position(player);
            Vector2 Direction = Cast.Direction(player);

            Direction.Normalize();
            Direction *= Attributes.GetValues(Modifiers.ProjSpeed, 1f);

            int projectileIDX = Projectile.NewProjectile(player.GetSource_FromAI(), CastPosition, Direction, ModContent.ProjectileType<projSpell>(), 0, 0, player.whoAmI);

            Projectile proj = Main.projectile[projectileIDX];
            projSpell pSpell = proj.ModProjectile as projSpell;
            pSpell.Attributes = Attributes;

            proj.penetrate = Attributes.GetIValues(Modifiers.Penetrate, 0f);

            Form.Setup(pSpell);
        }


        public AttributeSet Attributes;

        public Spell(AttributeSet Attributes)
        {
            this.Attributes = Attributes;
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
        RecastDelay,
        EffectRange, //(?) - only if its used ofc
    }

    public class modifier
    {
        public bool additive; // if true + if false *
        public float value;
        public modifier(float value, bool additive)
        {
            this.value = value; this.additive = additive;
        }
    }

    public class AttributeSet
    {
        public int Cast;
        public int Form;
        public int Behaviour;
        public int Trail;
        public int Color;

        public List<int> AdditionalEffects;

        public AttributeSet(int Cast, int Form, int Behaviour, int Trail, int Color, List<int> AdditionalEffects)
        {
            // no need to check if they are the right type,
            // totally gonna make this program perfectly,
            // so theres no chance for it to fuck up EZ

            this.AdditionalEffects = AdditionalEffects;
            AdditionalEffects.Add(Cast);
            AdditionalEffects.Add(Form);
            AdditionalEffects.Add(Behaviour);
            AdditionalEffects.Add(Trail);
            AdditionalEffects.Add(Color);

            this.Cast = Cast;
            this.Form = Form;
            this.Behaviour = Behaviour;
            this.Trail = Trail;
            this.Color = Color;

        }
        public int GetIValues(Modifiers Modifier, float baseValue)
        {
            return (int)MathF.Round(GetValues(Modifier, baseValue));
        }

        public float GetValues(Modifiers Modifier, float baseValue)
        {
            float multiplier = 1;

            float res;
            modifier mod;
            foreach (int atribute in AdditionalEffects)
            {
                bool found = Attribute.Get(atribute).AModifiers.TryGetValue(Modifier, out mod);

                if (found)
                {
                    if (mod.additive) // is additive
                        baseValue += mod.value;
                    else
                        multiplier *= mod.value;
                }
            }

            return baseValue * multiplier;
        }
    }

    // spell also needs an item to hold the spell in it...

    public class projSpell : ModProjectile
    {
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

            Form.Draw(this, ref lightColor);

            return false;
        }
    }
}
