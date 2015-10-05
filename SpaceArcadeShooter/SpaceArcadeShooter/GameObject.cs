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
        
        private static int explosionStage = 25;
        private string ExplosionPath = @"\Resources\Explosion\00" + explosionStage + ".png";
        private bool offsetExplosion = true;

        public void Explode()
        {
            if (offsetExplosion)
            {
                X = X - 100;
                Y = Y - 100;
                offsetExplosion = false;
            }

            if (explosionStage <= 52)
            {
                ExplosionPath = @"\Resources\Explosion\00" + explosionStage + ".png";
                img = Image.FromFile(Directory.GetCurrentDirectory() + ExplosionPath);
                explosionStage++;
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
            AllObjects.Add(this);
        }
    }    
}
