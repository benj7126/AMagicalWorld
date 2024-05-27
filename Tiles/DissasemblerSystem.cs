using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;

namespace AMagicalWorld.Tiles
{
    public class DissasemblerSystem : ModSystem
    {
        public static bool DissasemblerOpen = false;
        public static Vector2 PositionOpened;
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            if (!DissasemblerOpen && false)
                return;

            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));

            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "AMagicalWorld: Displaying Skill Dissasembler",
                    delegate
                    {
                        AssemblerUI(Main.spriteBatch);
                        /*
                        if (recasting != 0f)
                            UIDrawReCasting(Main.spriteBatch);
                        else
                            UIDrawPicking(Main.spriteBatch);
                        */

                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        private void AssemblerUI(SpriteBatch spriteBatch)
        {
            Texture2D UI = (Texture2D)ModContent.Request<Texture2D>("AMagicalWorld/Tiles/DissasemblerUI", ReLogic.Content.AssetRequestMode.ImmediateLoad);
            Texture2D UIAnim = (Texture2D)ModContent.Request<Texture2D>("AMagicalWorld/Tiles/DissasemblerUIAnim", ReLogic.Content.AssetRequestMode.ImmediateLoad);

            Vector2 topLeft = Main.ScreenSize.ToVector2() / 2 - UI.Size() / 2;
            spriteBatch.Draw(UI, topLeft, Color.White);

            Rectangle rec = new Rectangle(0, 0 + 140 * ((int)(Main.GlobalTimeWrappedHourly * 10) % 6), 140, 140);
            Vector2 animTopLeft = topLeft + new Vector2(154, 26);
            spriteBatch.Draw(UIAnim, animTopLeft, rec, Color.White);
        }
    }
}
