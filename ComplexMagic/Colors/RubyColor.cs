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
        public override string Name => "Ruby";
        public override string Description => "The color attribute of Ruby";

        public override Color MainColor(projSpell spell)
        {
            return new Color(1f, 0.1f, 0.1f, 0f); //Ruby
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(2.2f, ModifierApplication.Multiply) },
            { Modifiers.Damage, new Modifier(2.1f, ModifierApplication.Multiply) }
        };
    }
}
