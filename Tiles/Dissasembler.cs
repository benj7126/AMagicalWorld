using AMagicalWorld.ComplexMagic;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.GameContent.Bestiary.On_BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using System;

namespace AMagicalWorld.Tiles
{
    public class Dissasembler : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            // TileID.Sets.HasOutlines[Type] = true;

            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.AvoidedByNPCs[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(1f, 0f, 1f), Language.GetText("Dissasembler"));
        }

        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            Main.mouseRightRelease = false;

            DissasemblerSystem.DissasemblerOpen = true;
            DissasemblerSystem.PositionOpened = new Vector2(i * 64, j * 64); // idk if its 64...

            player.CloseSign();
            player.SetTalkNPC(-1);
            Main.npcChatCornerItem = 0;
            Main.npcChatText = "";

            return true;
        }
    }
}