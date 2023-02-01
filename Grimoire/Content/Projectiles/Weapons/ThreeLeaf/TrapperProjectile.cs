using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Grimoire.Content.Projectiles.Weapons.ThreeLeaf
{
    internal class TrapperProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;

            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = 1;
            Projectile.timeLeft = 300;
            Projectile.light = 0.75f;

            Projectile.penetrate = 5;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

            if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
            {
                Projectile.velocity.Y = 0;
            }

            if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
            {
                Projectile.velocity.Y = 0;
                Projectile.velocity.X = 0;
            }

            return false;
        }

        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.6395349f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Projectile.Center;
                dust = Terraria.Dust.NewDustPerfect(position, 199, new Vector2(2.0930233f, 0f), 125, new Color(255, 255, 255), 2.3837209f);
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(53, Main.LocalPlayer);
            }
        }
    }
}
