using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace SpaceArcadeShooter
{
    public class GameObject 
    {
        public static List<GameObject> AllObjects=new List<GameObject>();
        public Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\Ammo\AmmoCrate.png"); //placeholder
        public int X { get; set; }
        public int Y { get; set; }
        public int Xspeed { get; set; }
        public int Yspeed { get; set; }
        public bool collidable { get; set; }
        public bool hasExploded { get; set; }
        public int collisionRadius { get; set; }
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

        public static Image[] explosionImageFrames = new Image[27];
        public static void Init()
        {
            for (int i = 0; i < explosionImageFrames.Length; i++)
            {
                var str = @"\Resources\Explosion\00" + (i + 25) + ".png"; // +25 since the png name starts from 25.
                explosionImageFrames[i] = Image.FromFile(Directory.GetCurrentDirectory() + str);
            }
        }

        public GameObject(int X, int Y, string ImagePath)
        {
            collisionTimer.Start();            
            this.X = X;
            this.Y = Y;
            this.ImagePath = ImagePath;
            img = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\" + this.ImagePath);
            collisionRadius = (int)Math.Sqrt( img.Width* img.Height)-10;
            AllObjects.Add(this);
        }
    }    
}
