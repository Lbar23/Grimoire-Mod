using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Grimoire.Content.Dusts;
using Terraria.ID;
using Terraria.DataStructures;

namespace Grimoire.Content.Projectiles.Weapons.ThreeLeaf
{
    internal class LeadProjectile : ModProjectile
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
            dust = Terraria.Dust.NewDustPerfect(position, 11, new Vector2(0f, 0f), 0, new Color(176, 190, 197), 2.4418604f);
            dust.noGravity = true;

        }

    }
}

