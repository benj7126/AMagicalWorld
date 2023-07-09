using AMagicalWorld.ComplexMagic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AMagicalWorld
{
    public class MagicFixer : GlobalItem
    {
        static Dictionary<int, Spell> ReplaceCast = new Dictionary<int, Spell>
        {
            { ItemID.AmethystStaff, new Spell(new AttributeSet(2, 3, 1, 4, 5, new List<int>{}))},
            { ItemID.TopazStaff, new Spell(new AttributeSet(2, 3, 1, 4, 6, new List<int>{}))},
            { ItemID.SapphireStaff, new Spell(new AttributeSet(2, 3, 1, 4, 7, new List<int>{}))},
            { ItemID.EmeraldStaff, new Spell(new AttributeSet(2, 3, 1, 4, 8, new List<int>{}))},
            { ItemID.RubyStaff, new Spell(new AttributeSet(2, 3, 1, 4, 9, new List<int>{}))},
            { ItemID.AmberStaff, new Spell(new AttributeSet(2, 3, 1, 4, 10, new List<int>{}))},
            { ItemID.DiamondStaff, new Spell(new AttributeSet(2, 3, 1, 4, 11, new List<int>{}))},
        };
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            if (ReplaceCast.ContainsKey(entity.type))
            {
                return true;
            }

            return false;
        }

        public override void SetDefaults(Item entity)
        {
            Spell nCast = ReplaceCast[entity.type];
            entity.mana = 0;
            entity.useTime = entity.useAnimation = 1;
            entity.reuseDelay = nCast.Attributes.GetIValues(Modifiers.RecastDelay, 100)-1;
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            ReplaceCast[item.type].Cast(player);
            return false;
        }
    }
}
