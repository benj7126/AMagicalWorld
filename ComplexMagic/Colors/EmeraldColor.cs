using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class EmeraldColor : AColor
    {
        public override string Name => "Emerald Color";
        public override string Description => "The color attribute of Emerald";

        public override Color MainColor(projSpell spell)
        {
            return new Color(0.6f, 1f, 0.8f);
        }

        public override Color SubColor(projSpell spell)
        {
            return MainColor(spell);
        }

        public override Dictionary<Modifiers, modifier> AModifiers => new Dictionary<Modifiers, modifier> {
            { Modifiers.ProjSpeed, new modifier(2f, false) }
        };
    }
}
