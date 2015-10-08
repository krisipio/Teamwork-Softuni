using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    public class Projectile : GameObject
    {
        public int damage = 10;
        public static List<Projectile> ProjectileObjects = new List<Projectile>();
        private static Image StaticLaserImg = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\Ammo\Lazer3.png");
        public Projectile(int X, int Y) : base(X, Y, @"Ammo\Lazer3.png")
        {
            Yspeed = -20;
            this.X = X + 23; // Offset the lazer so it shoots from the proper position.
            hasExploded = false;
            this.img = StaticLaserImg;
        }

        public void MoveUp()
        {
            Y += Yspeed;

            if (Y < 0)
            {
                Disappear();
                ProjectileObjects.Remove(this);
            }
        }
    }
}
