using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceArcadeShooter
{
    class Explosion : GameObject
    {
        private int imageNumber = 25;

        public Explosion(int X, int Y, string image) : base(X,Y, image)
        {
        }

        internal bool Animate()
        { 
            if (imageNumber <= 52)
            {
                ImagePath = @"\Resources\Explosion\00" + imageNumber + ".png"; 
                img = Image.FromFile(Directory.GetCurrentDirectory() + ImagePath);
                imageNumber++;
                return false;
            }
            else
            {
                imageNumber = 25;
                return true;
            }            
        }
    }
}
