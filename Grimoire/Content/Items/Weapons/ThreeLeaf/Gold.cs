using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;
using Terraria.DataStructures;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Gold : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Grimoire");
            Tooltip.SetDefault("The Grimoire Used by Masters\nThree Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 8;
            Item.damage = 23;
            Item.knockBack = 4f;
            Item.crit = 6;
            Item.autoReuse = true;

            Item.useTime = 40;
            Item.useAnimation = 40;

            Item.UseSound = SoundID.Item43;
            Item.shoot = ModContent.ProjectileType<GoldProjectile>();
            Item.shootSpeed = 30f;

            Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Yellow;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 10)
                .AddIngredient(ItemID.FallenStar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3; // 3 shots
            float rotation = MathHelper.ToRadians(7);

            position += Vector2.Normalize(velocity) * 20f;

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            return false; // return false to stop vanilla from calling Projectile.NewProjectile.
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
