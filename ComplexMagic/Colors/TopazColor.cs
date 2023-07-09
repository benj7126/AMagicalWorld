using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class TopazColor : AColor
    {
        public override string Name => "Topaz Color";
        public override string Description => "The color attribute of Topaz";

        public override Color MainColor(projSpell spell)
        {
            return new Color(1f, 0.9f, 0.6f); //Topaz
        }

        public override Color SubColor(projSpell spell)
        {
            return MainColor(spell);
        }

        public override Dictionary<Modifiers, modifier> AModifiers => new Dictionary<Modifiers, modifier> {
            { Modifiers.ProjSpeed, new modifier(1.6f, false) }
        };
    }
}
