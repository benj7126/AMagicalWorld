using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class AmberColor : AColor
    {
        public override string Name => "Amber Color";
        public override string Description => "The color attribute of Amber";

        public override Color MainColor(projSpell spell)
        {
            return new Color(1f, 0.75f, 0.1f); //Amber
        }

        public override Color SubColor(projSpell spell)
        {
            return MainColor(spell);
        }

        public override Dictionary<Modifiers, modifier> AModifiers => new Dictionary<Modifiers, modifier> {
            { Modifiers.ProjSpeed, new modifier(2.2f, false) }
        };
    }
}
