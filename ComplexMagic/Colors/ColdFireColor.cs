using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class ColdFireColor : AColor
    {
        public override string Name => "Cold fire";
        public override string Description => "The color attribute of Cold fire";

        public override Color MainColor(projSpell spell)
        {
            return new Color(0.125f, 0.81f, 0.77f, 0f);
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.Damage, new Modifier(1f, ModifierApplication.Multiply) }
        };
    }
}
