using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Grimoire.Content.Dusts;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace Grimoire.Content.Projectiles.Weapons.FourLeaf
{
    internal class BeeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 48;    // Sets the width of the Projectile
            Projectile.height = 32;   // Sets the height of the Projectile

            Projectile.friendly = true;        // Doesn't hurt NPCs
            Projectile.tileCollide = false;     // Does go through walls
            Projectile.ignoreWater = true;     // Water does not affect it

            Projectile.DamageType = DamageClass.Magic;

            Projectile.penetrate = 1;  // penetrates 25 enemy
            Projectile.light = 0.8f;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.spriteDirection = Projectile.direction;

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = Projectile.Center;
            dust = Main.dust[Terraria.Dust.NewDust(position, 32, 4, DustID.YellowStarDust, 0f, 0f, 0, new Color(255, 255, 255), 1.5697675f)];
            dust.noGravity = true;

        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = ((Projectile.spriteDirection <= 0) ? SpriteEffects.FlipVertically : SpriteEffects.None);

            // Getting texture of projectile
            Texture2D texture = TextureAssets.Projectile[Type].Value;

            // Get the currently selected frame on the texture.
            Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Type], frameY: Projectile.frame);

            Vector2 origin = sourceRectangle.Size() / 2f;

            // Applying lighting and draw our projectile
            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 300);
            target.AddBuff(BuffID.WitheredArmor, 300);
        }
    }
}