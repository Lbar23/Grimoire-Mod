using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;
using Terraria.DataStructures;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Thorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorn Grimoire");
            Tooltip.SetDefault("Cast Powerful Thorns from the Jungle\nThree Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 12;
            Item.damage = 30;
            Item.knockBack = 3f;

            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.UseSound = SoundID.Item76;
            Item.shoot = ModContent.ProjectileType<ThornProjectile>();
            Item.shootSpeed = 48f;

            Item.buyPrice(gold: 10, silver: 50);
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.JungleSpores, 15)
                .AddIngredient(ItemID.Stinger, 15)
                .AddIngredient(ItemID.Vine, 7)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 2; // 2 shots
			float rotation = MathHelper.ToRadians(10);

			position += Vector2.Normalize(velocity) * 20f;

			for (int i = 0; i < numberProjectiles; i++) {
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
