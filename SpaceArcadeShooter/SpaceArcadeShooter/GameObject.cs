using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SpaceArcadeShooter
{
    class GameObject 
    {
        public static List<GameObject> AllObjects=new List<GameObject>();
        public Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\Ammo\AmmoCrate.png"); //placeholder
        public int X { get; set; }
        public int Y { get; set; }
        public int Xspeed { get; set; }
        public int Yspeed { get; set; }
        public bool collidable = false;
        public Stopwatch collisionTimer = new Stopwatch();
        
        public string ImagePath { get; set; }
        public void Appear()
        {
            // Not implemented.
        }        

        public void Disappear()
        {
            AllObjects.Remove(this);
        }        

        public GameObject(int X, int Y, string ImagePath)
        {
            collisionTimer.Start();
            this.X = X;
            this.Y = Y;
            this.ImagePath = ImagePath;
            img = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\" + this.ImagePath);
            AllObjects.Add(this);
        }
    }    
}
