using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class RubyColor : AColor
    {
        public override string Name => "Ruby Color";
        public override string Description => "The color attribute of Ruby";

        public override Color MainColor(projSpell spell)
        {
            return new Color(0.9f, 0.6f, 0.6f); //Ruby
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
