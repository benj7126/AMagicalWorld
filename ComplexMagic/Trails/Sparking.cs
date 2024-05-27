using AMagicalWorld.Dusts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AMagicalWorld.ComplexMagic.Trails
{
    public class Sparking : ATrail
    {
        public override string Name => "Sparking";
        public override string Description => "Adds a fading spark trail";

        public override void TrailAI(projSpell spell)
        {
            Projectile projectile = spell.Projectile;

            AColor TargetColor = Attribute.Get(spell.Attributes.Color) as AColor;
            for (int i = 0; i < Main.rand.Next(1, 3); i++)
            {
                Color c = TargetColor.SubColor(spell);
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<SparkDust>(), projectile.velocity.X, projectile.velocity.Y, 0, c, 1.2f);
            }
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.Usetime, new Modifier(1.3f, ModifierApplication.Multiply) },
            { Modifiers.RecastDelay, new Modifier(0f, ModifierApplication.Multiply) },
        };
    }
}
