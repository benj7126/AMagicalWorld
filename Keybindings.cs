using Terraria.ModLoader;

namespace AMagicalWorld
{
    internal class Keybindings : ModSystem
    {
        public static ModKeybind Cast { get; private set; }

        public override void Load()
        {
            Cast = KeybindLoader.RegisterKeybind(Mod, "Transform to next form", "R");
        }

        public override void Unload()
        {
            Cast = null;
        }
    }
}
