using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Behaviours
{
    public class Forward : ABehaviour
    {
        public override string Name => "Forward";
        public override string Description => "Projectile flies forward";

        public override bool Update(projSpell spell)
        {
            //Projectile projectile = spell.Projectile;

            return true;
        }
    }
}
