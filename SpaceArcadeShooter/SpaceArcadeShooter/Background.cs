using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    class Background : GameObject
    {
        public Background(int X, int Y, string imagePath) : base(X, Y, imagePath)
        {

        }

        public void MoveTo(int X, int Y)
        {            
            this.X = X;
            this.Y = Y;
            if (Y > -650) this.Y = -6000;
        }
    }
}
