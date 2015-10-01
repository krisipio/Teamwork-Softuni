using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    class Background : GameObject
    {

        public void Explore()
        {
            // Not implemented.
        }

        public void Attack()
        {
            // Not implemented.
        }
        //Space\Background.jpg
        public Background(int X, int Y) : base(X,Y, @"Space\Background0.png")
        {

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
            
            this.X = X;
            this.Y = Y;
        }
    }
}
