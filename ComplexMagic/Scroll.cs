using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace AMagicalWorld.ComplexMagic
{
    public class Scroll : ModItem
    {
        public int AttributeType = 0;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Clear();
            tooltips.Add(new TooltipLine(Mod, "itemName", Attribute.Get(AttributeType).Name));
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", Attribute.Get(AttributeType).Description));
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("Type", AttributeType);
        }
        public override void LoadData(TagCompound tag)
        {
            AttributeType = tag.GetAsInt("Type");
        }
    }
}
