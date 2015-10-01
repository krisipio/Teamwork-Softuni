using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    class Spaceship : GameObject
    {
        public int health { get; set; }
        public int ammoCount { get; set; }

        public void Explore()
        {
            // Not implemented.
        }

        public void Attack()
        {
            // Not implemented.
        }

        public Spaceship(int X,int Y) : base(X,Y, @"ShipRotation\0001.png")
        {
            health = 100;
            ammoCount = 100;
        }
    }
}
