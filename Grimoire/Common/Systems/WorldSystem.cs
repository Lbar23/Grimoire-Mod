using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Grimoire.Content.Items.Weapons.ThreeLeaf;
using Terraria;
using Terraria.ID;

namespace Grimoire.Common.Systems
{
    internal class WorldSystem : ModSystem
    {
        public override void PostWorldGen()
        {
            int[] itemsInSurfaceChests = { ModContent.ItemType<Novice>() };
            int[] skyChestIndex = { ModContent.ItemType<Galaxy>() };
			int[] dungeonChestIndex = { ModContent.ItemType<Trapper>() };
            int itemChoice = 0;

			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 0 * 36)  // Only puts items in Surface Chests
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) // 40 slots in a chest, goes through each one
					{
						if (chest.item[inventoryIndex].type == ItemID.None) // Only puts items in empty slot
						{
							if (Main.rand.NextBool(4)) // Item has 25% rarity
							{ chest.item[inventoryIndex].SetDefaults(itemsInSurfaceChests[itemChoice]); }

							itemChoice = (itemChoice + 1) % itemsInSurfaceChests.Length; // Next in array (makes sure that the item can only appear in the void spot after the vanilla items)
							break;
						}
					}
				}
				itemChoice = 0;
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 13 * 36)  // Only puts items in Sky Chests
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) // 40 slots in a chest, goes through each one
					{
						if (chest.item[inventoryIndex].type == ItemID.None) // Only puts items in empty slot
						{
							if (Main.rand.NextBool(3)) // Item has 33% rarity
							{ chest.item[inventoryIndex].SetDefaults(skyChestIndex[itemChoice]); }

							itemChoice = (itemChoice + 1) % skyChestIndex.Length; // Next in array (makes sure that the item can only appear in the void spot after the vanilla items)
							break;
						}
					}
				}
				itemChoice = 0;
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 2 * 36)  // Only puts items in Locked Gold Chests
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) // 40 slots in a chest, goes through each one
					{
						if (chest.item[inventoryIndex].type == ItemID.None) // Only puts items in empty slot
						{
							if (Main.rand.NextBool(5)) // Item has 20% rarity
							{ chest.item[inventoryIndex].SetDefaults(dungeonChestIndex[itemChoice]); }

							itemChoice = (itemChoice + 1) % dungeonChestIndex.Length; // Next in array (makes sure that the item can only appear in the void spot after the vanilla items)
							break;
						}
					}
				}
			}
		}
    }
}
