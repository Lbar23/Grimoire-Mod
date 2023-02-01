using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Grimoire.Content.Projectiles.Weapons.ThreeLeaf;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Demonite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupted Grimoire");
            Tooltip.SetDefault("Shoots a Homing Projectile that Inflicts the Cursed Flame Debuff\nThree Leaf Grimoire");
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
            Item.damage = 20;
            Item.crit = 6;
            Item.mana = 15;
            Item.knockBack = 3f;

            Item.useTime = 45;
            Item.useAnimation = 45;

            Item.UseSound = SoundID.Item39;
            Item.shoot = ModContent.ProjectileType<DemoniteProjectile>();
            Item.shootSpeed = 14f;

            Item.buyPrice(gold: 15, silver: 50);
            Item.rare = ItemRarityID.Purple;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 10)
                .AddIngredient(ItemID.ShadowScale, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
