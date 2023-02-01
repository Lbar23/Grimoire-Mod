using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;
using Terraria.DataStructures;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Vulcan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan's Grimoire");
            Tooltip.SetDefault("A Grimoire used by the Fire God Vulcan\nThree Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Flamethrower);
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.damage = 18;
            Item.mana = 4;

            Item.useTime = 5;
            Item.useAnimation = 5;

            Item.buyPrice(gold: 20, silver: 50);
            Item.rare = ItemRarityID.Orange;
            Item.useAmmo = AmmoID.None;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 15)
                .AddIngredient(ItemID.Obsidian, 7)
                .AddTile(TileID.Hellforge)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
