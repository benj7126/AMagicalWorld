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
    public class SparkDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;

            dust.velocity = dust.velocity * 0.4f + (dust.velocity * 0.2f).RotatedByRandom(MathF.PI * 2f);

            int frame = (int)MathF.Floor(Main.rand.NextFloat() * 3);
            dust.frame = new Rectangle(0, 10 * frame, 10, 10);

            dust.scale *= 0.5f;
        }

        public override bool Update(Dust dust)
        {
            //Console.WriteLine(dust.velocity);
            dust.position += dust.velocity;

            dust.scale *= 0.95f;
            dust.rotation += 0.1f;

            if (dust.scale < 0.2f)
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
