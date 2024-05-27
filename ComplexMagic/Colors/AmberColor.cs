using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class AmberColor : AColor
    {
        public override string Name => "Amber";
        public override string Description => "The color attribute of Amber";

        public override Color MainColor(projSpell spell)
        {
            return new Color(1f, 0.75f, 0.1f, 0f); //Amber
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(2.2f, ModifierApplication.Multiply) },
            { Modifiers.Damage, new Modifier(2.1f, ModifierApplication.Multiply) }
        };
    }
}
