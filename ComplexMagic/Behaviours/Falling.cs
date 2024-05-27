using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Behaviours
{
    public class Falling : ABehaviour
    {
        public override string Name => "Falling";
        public override string Description => "Projectile flies forward while falling...";

        public override void PostSetup(projSpell spell)
        {

        }

        public override bool Update(projSpell spell)
        {
            Projectile projectile = spell.Projectile;
            if (spell.lifetime > 22)
            {
                projectile.velocity.Y += 0.13f;
                projectile.velocity.X *= 0.985f;
            }

            if (spell.lifetime > 55)
                projectile.Kill();

            return true;
        }
        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(7f, ModifierApplication.Add) },
        };
    }
}
