using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Tin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tin Grimoire");
            Tooltip.SetDefault("A Common Grimoire made from Tin\nThree Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 4;
            Item.damage = 9;
            Item.knockBack = 1.5f;

            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.UseSound = SoundID.Item43;
            Item.shoot = ModContent.ProjectileType<TinProjectile>();
            Item.shootSpeed = 5f;

            Item.buyPrice(silver: 25, copper: 10);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TinBar, 7)
                .AddIngredient(ItemID.Cobweb, 4)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
