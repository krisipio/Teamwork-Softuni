using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    class GameObject 
    {
        public static List<GameObject> AllObjects=new List<GameObject>();
        public int X { get; set; }
        public int Y { get; set; }

        public string ImagePath { get; set; }

        public void Appear()
        {
            // Not implemented.
        }

        public void Disappear()
        {
            AllObjects.Remove(this);
        }

        public GameObject(int x, int y, string ImgPath)
        {
            this.X = x;
            this.Y = y;
            this.ImagePath = ImgPath;
            AllObjects.Add(this);
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
            if (X > 0 && X < 830 && Y > 0 && Y < 600) //in borders
            {
                this.X = X;
                this.Y = Y;
            }
        }
    }    
}
