using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace AMagicalWorld.ComplexMagic.Others.Debuffs
{
    public class OnFire : AStatusEffect
    {
        public override string Name => "Weak OnFire! Debuff";
        public override string Description => "Adds a chance to apply the [OnFire!] debuff\nlasting for ~1 to 3 seconds to the spell";
        public override void ApplyStatusEffect(NPC npc, projSpell spell)
        {
            int effectDuration = spell.Attributes.GetIValues(Modifiers.EffectDuration);
            npc.AddBuff(BuffID.OnFire, effectDuration);
        }
        public override Dictionary<Modifiers, Modifier> AModifiers => new Dictionary<Modifiers, Modifier> {
            { Modifiers.EffectDuration, new Modifier(() =>
            {
                if (Main.rand.NextBool() == true)
                    return 0f;

                if (Main.rand.NextFloat() < 2f/3f)
                    return Main.rand.NextFloat(0.5f, 2f) * 60f;

                return Main.rand.NextFloat(1f, 3f) * 60f;
            }, ModifierApplication.Add) },
        };
    }
}
