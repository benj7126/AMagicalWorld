using AMagicalWorld.ComplexMagic;
using MonoMod.Core.Platforms;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace AMagicalWorld
{
    public class KeybindCastPlayer : ModPlayer
    {

        public override void PreUpdate()
        {
            if (Keybindings.Cast.JustPressed) // cast and scroll equipped book? or maby just scroll and let cast be click...
            {
                Spell testSpell = new Spell(new AttributeSet(2, 3, 1, 4, 5, new List<int> { }));
                Spell.CastSpell(Player, testSpell);
            }
        }
    }
}
