using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Grimoire.Content.Dusts;
using Terraria.ID;

namespace Grimoire.Content.Projectiles.Weapons.ThreeLeaf
{
    internal class ThornProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 38;    // Sets the width of the Projectile
            Projectile.height = 38;   // Sets the height of the Projectile

            Projectile.friendly = true;        // Doesn't hurt NPCs
            Projectile.tileCollide = true;     // Doesn't go through walls
            Projectile.ignoreWater = true;     // Water does not affect it

            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = -1;  // Set at -1 to indicate custom AI

            Projectile.penetrate = 1;  // penetrates 1 enemy

        }

        public override void AI()
        {
            // Rotation
            float rotateSpeed = 0.35f * (float)Projectile.direction;
            Projectile.rotation += rotateSpeed;

            // Light of the Projectile
            Lighting.AddLight(Projectile.Center, 0.41f, 0.236f, 0.47f);

            // Randomizes the 3 dust particles
            if (Main.rand.NextBool(2))
            {
                int numToSpam = Main.rand.Next(3);
                for (int i = 0; i < numToSpam; i++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleSpore, Projectile.velocity.X * 0.1f, 
                        Projectile.velocity.Y * 0.1f, 0, default(Color), 1f);
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 180);
        }

    }
}

