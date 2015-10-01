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

        public void MoveTo(int X, int Y)
        {
            //if(X<-150 || X>1000) //out of borders
            //{
            //    if (X < -150)
            //        X = 850; //go on the other side
            //    else
            //        X = -50;
            //}
            if (X > 0 && X < 780 && Y > 0 && Y < 570) //in borders
            {
                this.X = X;
                this.Y = Y;
            }
        }
    }
}
