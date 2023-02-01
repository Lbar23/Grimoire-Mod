using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Grimoire.Content.Items.Weapons.FourLeaf;
using System;

namespace Grimoire.Content.Items
{
    internal class TreasureBags : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            var entitySource = player.GetSource_OpenItem(1);

            if (context == "bossBag" && arg == ItemID.SkeletronBossBag)
            {
                if (Main.rand.NextBool(3))
                { player.QuickSpawnItem(entitySource, ModContent.ItemType<Skeletron>(), 1); }
            }

            if (context == "bossBag" && arg == ItemID.QueenBeeBossBag)
            {
                if (Main.rand.NextBool(8))
                { player.QuickSpawnItem(entitySource, ModContent.ItemType<Buzzkill>(), 1); }
            }
        }
    }
}
