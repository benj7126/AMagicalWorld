using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AMagicalWorld.Dusts
{
    public class GlimmerDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;

            dust.velocity *= 0.3f;

            int frame = (int)MathF.Floor(Main.rand.NextFloat() * 3);
            dust.frame = new Rectangle(0, 10 * frame, 10, 10);
        }

        public override bool Update(Dust dust)
        {
            //Console.WriteLine(dust.velocity);
            dust.position += dust.velocity;

            dust.scale *= 0.96f;
            dust.rotation += 0.1f;

            if (dust.scale < 0.5f)
                dust.active = false;
            else
            {
                float lightPower = dust.scale / 255f;
                Lighting.AddLight(dust.position, lightPower * dust.color.R, lightPower * dust.color.G, lightPower * dust.color.B);
            }

            return false;
        }
    }
}
