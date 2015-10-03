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

        public void HandleCollision(GameObject collider)
        {
            if (collisionTimer.ElapsedMilliseconds > 1000 &&
                !(X < 0 && X > 900) && !(Y < 0 && Y > 800))
            {
                if (Xspeed < collider.Xspeed)
                {
                    if (collider.Xspeed > 0)
                    {
                        Xspeed += collider.Xspeed / 2;
                        collider.Xspeed--;
                    }
                    else
                    {
                        Xspeed -= collider.Xspeed / 2;
                        collider.Xspeed++;
                    }                                        
                }
                else
                {
                    if (collider.Xspeed > 0)
                    {
                        Xspeed += collider.Xspeed / 2;
                        collider.Xspeed++;
                    }
                    else
                    {
                        Xspeed -= collider.Xspeed / 2;
                        collider.Xspeed--;
                    }
                }

                if (Yspeed < collider.Yspeed)
                {
                    Yspeed += collider.Yspeed / 2;
                    collider.Yspeed++;
                }
                else
                {
                    Yspeed -= collider.Yspeed / 2;
                    collider.Yspeed--;
                }
                collisionTimer.Reset();
                collisionTimer.Start();
            }
            
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
