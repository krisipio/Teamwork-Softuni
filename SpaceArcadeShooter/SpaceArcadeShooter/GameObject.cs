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
        public bool collidable { get; set; }
        public bool hasColided { get; set; }
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

        private static int explosionCounter = 0;
        private static int explosionLastFrame = 25; // How many frames the explosion has.
        private string ExplosionPath = string.Empty; // Placeholder.
        private bool offsetExplosion = true; // Offset the explosion and set it to false so it happens only once.
        public static Image[] explosionImageFrames = new Image[27];

        public void Explode()
        {
            if (offsetExplosion) // If true offset and set it to false.
            {
                X = X - 100;
                Y = Y - 100;
                offsetExplosion = false;
            }
            
            if (explosionCounter <= explosionLastFrame)
            {
                img = explosionImageFrames[explosionCounter];
                explosionCounter++;
            }
            else
            {
                Disappear();
            }
        }

        public GameObject(int X, int Y, string ImagePath)
        {
            collisionTimer.Start();
            this.X = X;
            this.Y = Y;
            this.ImagePath = ImagePath;
            img = Image.FromFile(Directory.GetCurrentDirectory() + @"\Resources\" + this.ImagePath);

            for (int i = 0; i < explosionImageFrames.Length; i++)
            {
                ExplosionPath = @"\Resources\Explosion\00" + (i + 25) + ".png"; // +25 since the png name starts from 25.
                explosionImageFrames[i] = Image.FromFile(Directory.GetCurrentDirectory() + ExplosionPath);
            }

            AllObjects.Add(this);
        }
    }    
}
