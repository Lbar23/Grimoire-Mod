using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Grimoire.Content.Items.Weapons.FourLeaf;
using Terraria.GameContent.ItemDropRules;

namespace Grimoire.Content.Items
{
    internal class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (npc.type == NPCID.SkeletronHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Skeletron>(), 3));
            }

            if (npc.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Buzzkill>(), 8));
            }
        }
    }
}
