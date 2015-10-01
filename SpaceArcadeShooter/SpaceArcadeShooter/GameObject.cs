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
    }    
}
