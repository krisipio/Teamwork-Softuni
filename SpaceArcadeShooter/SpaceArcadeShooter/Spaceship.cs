using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceArcadeShooter
{
    class Spaceship : GameObject
    {
        public int health { get; set; }
        public int ammoCount { get; set; }

        public Spaceship(int X, int Y) : base(X, Y, @"ShipRotation\0001.png")
        {
            collisionTimer.Start();
            hasExploded = false;
            health = 100;
            ammoCount = 100;
        }
        
        public void Explore()
        {
            // Not implemented.
        }

        public void Attack()
        {
            // Not implemented.
        }        

        private void MoveTo(int X, int Y)
        {
            //if(X<-150 || X>1000) //out of borders
            //{
            //    if (X < -150)
            //        X = 850; //go on the other side
            //    else
            //        X = -50;
            //}
            if (X > 0 && X < 780 && Y > 0 && Y < 570) //in borders
            {
                this.X = X;
                this.Y = Y;
            }
        }

        internal void Shoot(List<Projectile> Projectiles, int X, int Y)
        {
            Projectiles.Add(new Projectile(X, Y));
        }

        internal void MoveRight()
        {
            MoveTo(X + 5, Y);
            ImagePath = @"\Resources\ShipRotation\0134.png"; //change img Path to right rotation frame
            img = Image.FromFile(Directory.GetCurrentDirectory() + ImagePath);        
        }

        internal void MofeLeft()
        {
            MoveTo(X - 5, Y);
            ImagePath = @"\Resources\ShipRotation\0024.png"; //change img Path to left rotation frame
            img = Image.FromFile(Directory.GetCurrentDirectory() + ImagePath);
        }

        internal void MoveUp()
        {
            MoveTo(X, Y - 5);
            ImagePath = @"\Resources\ShipRotation\0001-f.png"; //change img Path to left rotation frame
            img = Image.FromFile(Directory.GetCurrentDirectory() + ImagePath);
        }

        internal void MoveDown()
        {
            MoveTo(X, Y + 5);
            ImagePath = @"\Resources\ShipRotation\0001-b.png"; //change img Path to left rotation frame
            img = Image.FromFile(Directory.GetCurrentDirectory() + ImagePath);
        }

        internal void MoveStop()
        {
            ImagePath = @"\Resources\ShipRotation\0001.png"; //change img Path to default frame
            img = Image.FromFile(Directory.GetCurrentDirectory() + ImagePath);
        }
    }
}
