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
        public override string Name => "Emerald";
        public override string Description => "The color attribute of Emerald";

        public override Color MainColor(projSpell spell)
        {
            return new Color(0.3f, 1f, 0.3f, 0.4f);
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(1.98f, ModifierApplication.Multiply) },
            { Modifiers.Damage, new Modifier(1.9f, ModifierApplication.Multiply) }
        };
    }
}
