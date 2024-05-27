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
    // https://terraria.fandom.com/wiki/Magic_weapons
    public class MagicFixer : GlobalItem
    {
        static Dictionary<int, Spell> ReplaceCast = new Dictionary<int, Spell>
        {
            //// Pre-Hardmode
            // Wands
            { ItemID.WandofSparking, new Spell(new AttributeSet(2, 3, 12, 13, 14, new List<int>{16})) },
            { ItemID.WandofFrosting, new Spell(new AttributeSet(2, 3, 12, 13, 15, new List<int>{17})) },
            { ItemID.AmethystStaff, new Spell(new AttributeSet(2, 3, 1, 4, 5, new List<int>{}))},
            { ItemID.TopazStaff, new Spell(new AttributeSet(2, 3, 1, 4, 6, new List<int>{}))},
            { ItemID.SapphireStaff, new Spell(new AttributeSet(2, 3, 1, 4, 7, new List<int>{}))},
            { ItemID.EmeraldStaff, new Spell(new AttributeSet(2, 3, 1, 4, 8, new List<int>{}))},
            { ItemID.RubyStaff, new Spell(new AttributeSet(2, 3, 1, 4, 9, new List<int>{}))},
            { ItemID.AmberStaff, new Spell(new AttributeSet(2, 3, 1, 4, 10, new List<int>{}))},
            { ItemID.DiamondStaff, new Spell(new AttributeSet(2, 3, 1, 4, 11, new List<int>{}))},
            // { ItemID.ThunderStaff },
            // { ItemID.Vilethorn },
            // { ItemID.AquaScepter },
            // { ItemID.MagicMissile },
            // { ItemID.WeatherPain },
            // { ItemID.Flamelash },
            // { ItemID.FlowerofFire },

            // Magic guns
            // { ItemID.ZapinatorGray }, // Gray Zapinator
            // { 5066 }, // Roman candle
            // { ItemID.SpaceGun },
            // { ItemID.BeeGun },

            // Spell books
            // { ItemID.DemonScythe },
            // { ItemID.BookofSkulls },
            // { ItemID.WaterBolt },

            // Others
            // { ItemID.CrimsonRod },
            
            //// Hardmode
            // Wands
            // { ItemID.SkyFracture },
            // { ItemID.MeteorStaff },
            // { ItemID.CrystalSerpent },
            // { ItemID.CrystalVileShard },
            // { 3006 }, // Life Drain
            // { ItemID.PoisonStaff },
            // { ItemID.FrostStaff },
            // { ItemID.FlowerofFrost },
            // { ItemID.UnholyTrident },
            // { ItemID.RainbowRod },
            // { 3852 }, // Tome of Infinite Wisdom
            // { ItemID.NettleBurst },
            // { ItemID.VenomStaff },
            // { ItemID.ShadowbeamStaff },
            // { ItemID.InfernoFork },
            // { ItemID.SpectreStaff },
            // { ItemID.BatScepter },
            // { ItemID.Razorpine },
            // { ItemID.BlizzardStaff },
            // { 5065 }, // Resonance Scepter
            // { ItemID.StaffofEarth },
            // { 3870 }, // Betsy's Wrath

            // Magic guns
            // { ItemID.LaserRifle },
            // { ItemID.ZapinatorOrange },
            // { ItemID.WaspGun },
            // { ItemID.LeafBlower },
            // { ItemID.RainbowGun },
            // { ItemID.HeatRay },
            // { ItemID.LaserMachinegun },
            // { ItemID.ChargedBlasterCannon },
            // { ItemID.BubbleGun },

            // Spell books
            // { ItemID.CursedFlames },
            // { ItemID.GoldenShower },
            // { ItemID.CrystalStorm },
            // { ItemID.MagnetSphere },
            // { ItemID.RazorbladeTyphoon },
            // { 3570 }, // Lunar Flare

            // Others
            // { ItemID.IceRod },
            // { ItemID.MagicDagger },
            // { ItemID.MedusaHead },
            // { ItemID.ClingerStaff },
            // { ItemID.SpiritFlame },
            // { ItemID.ShadowFlameHexDoll },
            // { 4270 }, // Blood Thorn
            // { ItemID.NimbusRod },
            // { ItemID.MagicalHarp },
            // { ItemID.ToxicFlask },
            // { 4952 }, // Nightglow
            // { 4715 }, // Stellar Tune
            // { ItemID.NebulaArcanum },
            // { ItemID.NebulaBlaze },
            // { ItemID.LastPrism },

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
            entity.mana = nCast.Attributes.GetIValues(Modifiers.ManaCost);
            entity.useTime = entity.useAnimation = 26;
            entity.reuseDelay = 0; // nCast.Attributes.GetIValues(Modifiers.RecastDelay);
        }

        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            /*
            if (normalShot)
                return true;
            */

            ReplaceCast[item.type].Cast(player);
            return true;
        }
    }
}
