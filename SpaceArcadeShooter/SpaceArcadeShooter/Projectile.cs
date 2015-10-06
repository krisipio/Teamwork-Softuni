using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    public class Projectile : GameObject
    {
        public int damage = 10;
        public static List<Projectile> ProjectileObjects = new List<Projectile>();

        public Projectile(int X, int Y) : base(X, Y, @"Ammo\Lazer2.png")
        {
            Yspeed = -20;
            hasExploded = false;
        }

        public void MoveUp()
        {
            Y += Yspeed;

            if (Y < -400)
            {
                Disappear();
                ProjectileObjects.Remove(this);
            }
        }
    }
}
