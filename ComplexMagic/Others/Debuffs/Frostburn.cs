using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Others.Debuffs
{
    public class Frostburn : AStatusEffect
    {
        public override string Name => "Weak Frostburn Debuff";
        public override string Description => "Adds a chance to apply the [Frostburn] debuff\nlasting for 2 to 3 seconds to the target";
        public override void ApplyStatusEffect(NPC npc, projSpell spell)
        {
            int effectDuration = spell.Attributes.GetIValues(Modifiers.EffectDuration);
            npc.AddBuff(BuffID.Frostburn, effectDuration);
        }
        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.EffectDuration, new Modifier(() =>
            {
                if (Main.rand.NextBool() == true)
                    return 0f;

                if (Main.rand.NextFloat() < 2f/3f)
                    return 2f * 60f;

                return 3f * 60f;
            }, ModifierApplication.Add) },
        };
    }
}
