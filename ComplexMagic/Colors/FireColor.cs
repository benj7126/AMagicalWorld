using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class FireColor : AColor
    {
        public override string Name => "Fire";
        public override string Description => "The color attribute of Fire";

        public override Color MainColor(projSpell spell)
        {
            switch (Main.rand.Next(0, 6))
            {
                case 0:
                    return new Color(1f, 0f, 0f, 0f);
                case 1:
                    return new Color(1f, 0.3f, 0f, 0f);
                case 2:
                    return new Color(1f, 0.6f, 0f, 0f);
                case 3:
                    return new Color(1f, 0.8f, 0f, 0f);
                case 4:
                    return new Color(1f, 0.9f, 0.1f, 0f);
            }
            return Color.White;
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.Damage, new Modifier(1f, ModifierApplication.Multiply) }
        };
    }
}
