using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class SapphireColor : AColor
    {
        public override string Name => "Sapphire Color";
        public override string Description => "The color attribute of Sapphire";

        public override Color MainColor(projSpell spell)
        {
            return new Color(0.4f, 0.7f, 1f); //Sapphire
        }

        public override Color SubColor(projSpell spell)
        {
            return MainColor(spell);
        }

        public override Dictionary<Modifiers, modifier> AModifiers => new Dictionary<Modifiers, modifier> {
            { Modifiers.ProjSpeed, new modifier(1.85f, false) }
        };
    }
}
