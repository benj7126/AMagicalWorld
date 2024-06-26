﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Colors
{
    public class AmethystColor : AColor
    {
        public override string Name => "Amethyst";
        public override string Description => "The color attribute of Amethyst";

        public override Color MainColor(projSpell spell)
        {

            return new Color(1f, 0.1f, 1f, 0f); //Amethyst
        }

        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.ProjSpeed, new Modifier(1.45f, ModifierApplication.Multiply) },
            { Modifiers.Damage, new Modifier(1.5f, ModifierApplication.Multiply) }
        };
    }
}
