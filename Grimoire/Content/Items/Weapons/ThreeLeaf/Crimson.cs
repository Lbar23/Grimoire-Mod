using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Crimson : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Grimoire");
            Tooltip.SetDefault("Shoots a Homing Projectile that Inflicts the Ichor Debuff\nThree Leaf Grimoire");
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
            Item.damage = 25;
            Item.crit = 6;
            Item.mana = 15;
            Item.knockBack = 3f;

            Item.useTime = 40;
            Item.useAnimation = 40;

            Item.UseSound = SoundID.Item39;
            Item.shoot = ModContent.ProjectileType<CrimsonProjectile>();
            Item.shootSpeed = 18f;

            Item.buyPrice(gold: 15, silver: 50);
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 10)
                .AddIngredient(ItemID.TissueSample, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
