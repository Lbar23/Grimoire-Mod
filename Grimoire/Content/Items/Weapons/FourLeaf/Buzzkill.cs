using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Grimoire.Content.Projectiles.Weapons.FourLeaf;
using Terraria.DataStructures;

namespace Grimoire.Content.Items.Weapons.FourLeaf
{
    internal class Buzzkill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Buzzkill");
            Tooltip.SetDefault("A Grimoire That Shoots Out the Queen and Her Servants\nFour Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.channel = true;
            Item.damage = 20;
            Item.mana = 18;
            Item.knockBack = 10f;

            Item.useTime = 50;
            Item.useAnimation = 50;

            Item.UseSound = SoundID.Item97;
            Item.shoot = ModContent.ProjectileType<BeeProjectile>();
            Item.shootSpeed = 9f;

            Item.buyPrice(gold: 11, silver: 50);
            Item.rare = ItemRarityID.Orange;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            // Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
            for (int i = 0; i < 5; ++i)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));
                Projectile.NewProjectile(source, position, perturbedSpeed, ProjectileID.Bee, damage, knockback, player.whoAmI); 
            }

			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}

    }
}
