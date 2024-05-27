using AMagicalWorld.ComplexMagic;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AMagicalWorld.MagicBooks
{
    public class BeginnerMagicBook : ModItem
    {
        private const int pageCount = 3;

        private List<Spell> spells = new List<Spell>();

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Clear();
            tooltips.Add(new TooltipLine(Mod, "itemName", "Beginner magic book"));
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", "A magic book..."));

            if (spells.Count != 0)
                return;

            tooltips.Add(new TooltipLine(Mod, "Tooltip1", "[Spells]:"));
            for (int i = 0; i < spells.Count; i++)
            {
                tooltips.Add(new TooltipLine(Mod, "Tooltip0" + (i+2), spells[i].name));
            }

            /*
            tooltips.Add(new TooltipLine(Mod, "itemName", Attribute.Get(AttributeType).Name));
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", Attribute.Get(AttributeType).Description));
            */
        }

        public override bool? UseItem(Player player)
        {
            foreach (Spell s in spells)
            {
                s.Cast(player);
            }

            return base.UseItem(player);
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("SpellCount", spells.Count);

            for (int i = 0; i < spells.Count; i++)
            {
                TagCompound spellAsTag = new TagCompound();
                spells[i].save(spellAsTag);
                tag.Add("Spell" + i, spellAsTag);
            }
        }

        public override void LoadData(TagCompound tag)
        {
            int spellCount = tag.GetInt("SpellCount");

            for (int i = 0; i < spells.Count; i++)
            {
                TagCompound spellAsTag = tag.Get<TagCompound>("Spell" + i);
                spells[i] =  Spell.loadSpell(spellAsTag);
            }
        }
    }
}
