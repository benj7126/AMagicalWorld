using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class DiamondColor : AColor
    {
        public override string Name => "Diamond";
        public override string Description => "The color attribute of Diamond";

        public override Color MainColor(projSpell spell)
        {
            return new Color(0.9f, 0.9f, 0.9f, 0f); //Diamond
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(2.35f, ModifierApplication.Multiply) },
            { Modifiers.Damage, new Modifier(2.3f, ModifierApplication.Multiply) }
        };
    }
}
