using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Lead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Grimoire");
            Tooltip.SetDefault("An Apprentice's First Grimoire\nThree Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 3;
            Item.damage = 13;
            Item.knockBack = 4f;

            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.UseSound = SoundID.Item43;
            Item.shoot = ModContent.ProjectileType<LeadProjectile>();
            Item.shootSpeed = 8f;

            Item.buyPrice(silver: 50, copper: 10);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 10)
                .AddTile(TileID.Furnaces)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
