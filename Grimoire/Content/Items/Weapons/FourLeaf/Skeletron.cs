using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Grimoire.Content.Projectiles.Weapons.FourLeaf;
using Terraria.DataStructures;

namespace Grimoire.Content.Items.Weapons.FourLeaf
{
    internal class Skeletron : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skeletron's Grimoire");
            Tooltip.SetDefault("Skeletron's Personal Grimoire\nFour Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.channel = true;
            Item.damage = 30;
            Item.mana = 60;
            Item.knockBack = 5f;
           
            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.UseSound = SoundID.DD2_SkeletonHurt;
            Item.shoot = ModContent.ProjectileType<SkeletronProjectile>();
            Item.shootSpeed = 10f;

            Item.buyPrice(gold: 8, silver: 50);
            Item.rare = ItemRarityID.Gray;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
