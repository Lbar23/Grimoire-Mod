using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;
using Terraria.DataStructures;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Galaxy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Grimoire");
            Tooltip.SetDefault("A Grimoire Blessed by the Stars\nThree Leaf Grimoire");
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
            Item.damage = 13;
            Item.mana = 9;
            Item.crit = 21;
            Item.knockBack = 5f;

            Item.useTime = 30;
            Item.useAnimation = 30;

            Item.UseSound = SoundID.Item105;
            Item.shoot = ModContent.ProjectileType<GalaxyProjectile>();
            Item.shootSpeed = 38f;

            Item.buyPrice(gold: 8, silver: 50);
            Item.rare = ItemRarityID.Blue;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 8; // 8 shots
            float rotation = MathHelper.ToRadians(150);

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
