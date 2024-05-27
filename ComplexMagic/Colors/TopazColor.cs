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
        public override string Name => "Topaz";
        public override string Description => "The color attribute of Topaz";

        public override Color MainColor(projSpell spell)
        {
            return new Color(1f, 0.6f, 0.1f, 0f); //Topaz
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(1.6f, ModifierApplication.Multiply) },
            { Modifiers.Damage, new Modifier(1.6f, ModifierApplication.Multiply) }
        };
    }
}
