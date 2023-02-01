using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Silver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Grimoire");
            Tooltip.SetDefault("Grimoire for the Gifted\nThree Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 5;
            Item.damage = 20;
            Item.knockBack = 4f;
            Item.autoReuse = true;

            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.UseSound = SoundID.Item43;
            Item.shoot = ModContent.ProjectileType<SilverProjectile>();
            Item.shootSpeed = 9f;

            Item.buyPrice(silver: 70, copper: 50);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
