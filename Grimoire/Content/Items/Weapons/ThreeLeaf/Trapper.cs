using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Trapper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trapper's Grimoire");
            Tooltip.SetDefault("A Grimoire Designed for Animals and Other Creatures\nThree Leaf Grimoire");
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
            Item.damage = 18;
            Item.mana = 6;
            Item.knockBack = 0f;
            Item.crit = -2;

            Item.useTime = 8;
            Item.useAnimation = 8;

            Item.UseSound = SoundID.Item108;
            Item.shoot = ModContent.ProjectileType<TrapperProjectile>();
            Item.shootSpeed = 7.5f;

            Item.buyPrice(gold: 20, silver: 50);
            Item.rare = ItemRarityID.Gray;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 1; i++) //replace 3 with however many projectiles you like

            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12)); //12 is the spread in degrees, although like with Set Spread it's technically a 24 degree spread due to the fact that it's randomly between 12 degrees above and 12 degrees below your cursor.
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI); //create the projectile
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
