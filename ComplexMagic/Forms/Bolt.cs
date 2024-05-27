using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace AMagicalWorld.ComplexMagic.Forms
{
    public class Bolt : AForm
    {
        public override string Name => "Bolt";
        public override string Description => "Casts a bolt";

        public override void Setup(projSpell spell)
        {
            Projectile projectile = spell.Projectile;

            projectile.width = 10;
            projectile.height = 10;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;
        }

        public override void Draw(projSpell spell, ref Color color)
        {
            // for some reason, it dosent look like the vanilla has a sprite...
            /*
            Projectile projectile = spell.Projectile;
            Texture2D texture = ModContent.Request<Texture2D>("AMagicalWorld/Assets/Bolt").Value;

            AColor TargetColor = Attribute.Get(spell.Attributes.Color) as AColor;
            Main.EntitySpriteDraw(texture, projectile.Center - Main.screenPosition, null, TargetColor.MainColor(spell), 0, new Vector2(projectile.width, projectile.height) / 2f, 1f, SpriteEffects.None);
            */
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.Damage, new Modifier(10f, ModifierApplication.Add) },
            { Modifiers.ManaCost, new Modifier(5f, ModifierApplication.Add) },
            { Modifiers.Penetrate, new Modifier(1f, ModifierApplication.Add) },
            { Modifiers.Usetime, new Modifier(20f, ModifierApplication.Add) },
            { Modifiers.RecastDelay, new Modifier(10f, ModifierApplication.Add) },
        };
    }
}
