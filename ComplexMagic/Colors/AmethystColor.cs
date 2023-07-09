using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class AmethystColor : AColor
    {
        public override string Name => "Amethyst Color";
        public override string Description => "The color attribute of Amethyst";

        public override Color MainColor(projSpell spell)
        {

            return new Color(1f, 0.7f, 1f); //Amethyst
        }

        public override Color SubColor(projSpell spell)
        {
            return MainColor(spell);
        }

        public override Dictionary<Modifiers, modifier> AModifiers => new Dictionary<Modifiers, modifier> {
            { Modifiers.ProjSpeed, new modifier(1.45f, false) }
        };
    }
}
