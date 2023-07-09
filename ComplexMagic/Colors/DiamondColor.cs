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
        public override string Name => "Diamond Color";
        public override string Description => "The color attribute of Diamond";

        public override Color MainColor(projSpell spell)
        {

            //return new Color(1f, 0.7f, 1f); //Amethyst
            //return new Color(1f, 0.9f, 0.6f); //Topaz
            //return new Color(0.4f, 0.7f, 1f); //Sapphire
            //return new Color(1f, 0.75f, 0.1f); //Amber
            //return new Color(0.9f, 0.6f, 0.6f); //Ruby
            return new Color(0.95f, 0.95f, 1f); //Diamond
        }

        public override Color SubColor(projSpell spell)
        {
            return MainColor(spell);
        }

        public override Dictionary<Modifiers, modifier> AModifiers => new Dictionary<Modifiers, modifier> {
            { Modifiers.ProjSpeed, new modifier(2.35f, false) }
        };
    }
}
