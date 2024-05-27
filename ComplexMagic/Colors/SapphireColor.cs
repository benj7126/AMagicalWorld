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
        public override string Name => "Sapphire";
        public override string Description => "The color attribute of Sapphire";

        public override Color MainColor(projSpell spell)
        {
            return new Color(0.1f, 0.3f, 1f, 0f); //Sapphire
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(1.85f, ModifierApplication.Multiply) },
            { Modifiers.Damage, new Modifier(1.8f, ModifierApplication.Multiply) }
        };
    }
}
