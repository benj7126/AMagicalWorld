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
    public class Glimmer : ATrail
    {
        public override string Name => "Glimmer";
        public override string Description => "Adds a glimmering trail";

        public override void TrailAI(projSpell spell)
        {
            Projectile projectile = spell.Projectile;

            AColor TargetColor = Attribute.Get(spell.Attributes.Color) as AColor;
            for (int i = 0; i < 2; i++)
            {
                Color c = TargetColor.SubColor(spell);
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<GlimmerDust>(), projectile.velocity.X, projectile.velocity.Y, 0, c, 1.2f);
            }
        }
    }
}
