using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Grimoire.Content.Dusts;
using Terraria.ID;
using Terraria.DataStructures;

namespace Grimoire.Content.Projectiles.Weapons.FourLeaf
{
    internal class SkeletronProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 56;    // Sets the width of the Projectile
            Projectile.height = 76;   // Sets the height of the Projectile

            Projectile.friendly = true;        // Doesn't hurt NPCs
            Projectile.tileCollide = false;     // Does go through walls
            Projectile.ignoreWater = true;     // Water does not affect it

            Projectile.DamageType = DamageClass.Magic;

            Projectile.penetrate = 25;  // penetrates 25 enemy
            Projectile.light = 0.8f;

            DrawOriginOffsetY = -6;

        }

        public override void AI()
        {
            Vector2 dustPosition = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            dust = Main.dust[Terraria.Dust.NewDust(dustPosition, 30, 30, DustID.Titanium, 0f, 0f, 163, new Color(255, 255, 255), 1.7441859f)];
            dust.noGravity = true;

            if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
            {
                Player player = Main.player[Projectile.owner];
                if (player.channel)
                {
                    float maxDistance = 18f;
                    Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    if (distanceToCursor > maxDistance)
                    {
                        distanceToCursor = maxDistance / distanceToCursor;
                        vectorToCursor *= distanceToCursor;
                    }

                    int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
                    int oldVelocityXBy1000 = (int)(Projectile.velocity.X * 1000f);
                    int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
                    int oldVelocityYBy1000 = (int)(Projectile.velocity.Y * 1000f);

                    if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
                    { Projectile.netUpdate = true; }

                    Projectile.velocity = vectorToCursor;
                }
                else if (Projectile.ai[0] == 0f)
                {
                    Projectile.netUpdate = true;

                    float maxDistance = 14f;
                    Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    if (distanceToCursor == 0f)
                    {
                        vectorToCursor = Projectile.Center - player.Center;
                        distanceToCursor = vectorToCursor.Length();
                    }

                    distanceToCursor = maxDistance / distanceToCursor;
                    vectorToCursor *= distanceToCursor;

                    Projectile.velocity = vectorToCursor;

                    if (Projectile.velocity == Vector2.Zero)
                    { Projectile.Kill(); }

                    Projectile.ai[0] = 1f;
                }
            }

            /*if (Projectile.velocity != Vector2.Zero) // Adds direction to projectile, but glitches a bit when moving
            {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(290);
            }*/

            float rotateSpeed = 0.35f * (float)Projectile.direction; // Alone, it switches the direction of the rotation as it gets to the cursor
            Projectile.rotation += rotateSpeed;

        }

        public override void Kill(int timeLeft)
        {
            if (Projectile.penetrate == 1)
            {
                // Makes the projectile hit all enemies as it circunvents the penetrate limit.
                Projectile.maxPenetrate = -1;
                Projectile.penetrate = -1;

                int explosionArea = 60;
                Vector2 oldSize = Projectile.Size;
                // Resize the projectile hitbox to be bigger.
                Projectile.position = Projectile.Center;
                Projectile.Size += new Vector2(explosionArea);
                Projectile.Center = Projectile.position;

                Projectile.tileCollide = false;
                Projectile.velocity *= 0.01f;
                // Damage enemies inside the hitbox area
                Projectile.Damage();
                Projectile.scale = 0.01f;

                //Resize the hitbox to its original size
                Projectile.position = Projectile.Center;
                Projectile.Size = new Vector2(10);
                Projectile.Center = Projectile.position;
            }
        }
    }
}

