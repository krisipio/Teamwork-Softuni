using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceArcadeShooter
{
    class Asteroid : GameObject
    {
        static Random RNG = new Random();
        public int startPosition = RNG.Next(0, 700);

        public Asteroid(int X, int Y, string imagePath) : base(X, Y, imagePath)
        {
            Xspeed = RNG.Next(-2, 3);
            Yspeed = RNG.Next(2, 9);
            this.X = startPosition + X;
            this.Y += Yspeed + Y;
        }

        public void Move()
        {
            // If asteroid moves to the sides, get it back up
            // to a random position with random fall speed
            // and random side movement.
            X += Xspeed;
            if (X < -200 || X > 900)
            {
                startPosition = RNG.Next(0, 700);
                
                Xspeed = RNG.Next(-2, 3);
                Yspeed = RNG.Next(2, 9);
                X = startPosition + X;
                Y = -200;
            }

            // If asteroid falls down, get it back up
            // to a random position with random fall speed
            // and random side movement.
            Y += Yspeed;
            if (Y < -1100 || Y > 800)
            {
                startPosition = RNG.Next(0, 700);

                Xspeed = RNG.Next(-2, 3);
                Yspeed = RNG.Next(2, 9);
                X = startPosition = RNG.Next(0, 700);
                Y = -200;
            }
        }

        public void MoveTo(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            if (Y > 800) this.Y -= 1500;
        }

        public void RotateImage()
        {
            img = Engine.RotateImage(img, 1);
        }

        public static Asteroid[] MakeAsteroids()
        {
            // Repeat them twice for more asteroids
            string[] starPaths = { @"Asteroids\Asteroid0.png", @"Asteroids\Asteroid1.png",
                                   @"Asteroids\Asteroid2.png", @"Asteroids\Asteroid3.png",
                                   @"Asteroids\Asteroid4.png", @"Asteroids\Asteroid5.png",

                                   @"Asteroids\Asteroid0.png", @"Asteroids\Asteroid1.png",
                                   @"Asteroids\Asteroid2.png", @"Asteroids\Asteroid3.png",
                                   @"Asteroids\Asteroid4.png", @"Asteroids\Asteroid5.png",
            };

            Asteroid[] Asteroids = new Asteroid[starPaths.Length];

            for (int i = 0; i < Asteroids.Length; i++)
            {
                Asteroids[i] = new Asteroid(0, RNG.Next(-1000, -50), starPaths[i]);
                Asteroids[i].collidable = true;
            }

            return Asteroids;
        }
    }
}
