using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Grimoire.Content.Dusts;
using Terraria.ID;
using Terraria.DataStructures;

namespace Grimoire.Content.Projectiles.Weapons.ThreeLeaf
{
    internal class CopperProjectile : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.width = 16;    // Sets the width of the Projectile
            Projectile.height = 16;   // Sets the height of the Projectile

            Projectile.friendly = true;        // Doesn't hurt NPCs
            Projectile.tileCollide = true;     // Doesn't go through walls
            Projectile.ignoreWater = true;     // Water does not affect it

            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = 0;  // Set at -1 to indicate custom AI

            Projectile.penetrate = 2;  // penetrates 2 enemy

        }

        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = Projectile.Center;
            dust = Dust.NewDustPerfect(position, 55, new Vector2(2.5581398f, 0f), 127, new Color(255, 191, 0), 2.267442f);
            dust.noGravity = true;
            dust.fadeIn = 1.639535f;
        }

    }
}

