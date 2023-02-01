using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Grimoire.Content.Items.Weapons.ThreeLeaf
{
    internal class Novice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Novice Grimoire");
            Tooltip.SetDefault("A Beginner's Grimoire\nThree Leaf Grimoire");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 2;
            Item.damage = 6;
            Item.knockBack = 1.2f;

            Item.useTime = 30;
            Item.useAnimation = 20;

            Item.UseSound = SoundID.Item21;
            Item.shoot = ProjectileID.DiamondBolt;

            Item.shootSpeed = 5f;

            Item.buyPrice(silver: 20, copper: 5);
            Item.rare = ItemRarityID.White;

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
    }
}
