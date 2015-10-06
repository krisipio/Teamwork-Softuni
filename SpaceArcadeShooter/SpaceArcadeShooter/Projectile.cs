using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    class Projectile : GameObject
    {
        public int movementSpeed = 20;

        public Projectile(int X, int Y) : base(X, Y, @"Ammo\Lazer1.png")
        {
            hasColided = false;
        }

        public void MoveUp()
        {
            Y -= movementSpeed;

            if (Y < -400)
            {
                Disappear();
            }
        }
    }
}
