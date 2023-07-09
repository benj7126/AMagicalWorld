using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace AMagicalWorld.ComplexMagic.Casts
{
    public class PlayerCenter : ACast
    {
        public override string Name => "Player";
        public override string Description => "Casts from player";

        public override Vector2 Position(Player player)
        {
            return player.Center;
        }

        public override Vector2 Direction(Player player)
        {
            return Main.MouseWorld - player.Center;
        }

    }
}
