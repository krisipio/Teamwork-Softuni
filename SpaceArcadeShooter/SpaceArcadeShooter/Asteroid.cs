using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceArcadeShooter
{
    public class Asteroid : GameObject
    {
        static Random RNG = new Random();
        public int health { get; set; }
        public int startPosition = RNG.Next(0, 700);

        const int maxLeftSpeed = -3;
        const int maxRightSpeed = 4;
        public static List<Asteroid> AsteroidObjects;
        const int minFallSpeed = 2;
        const int maxFallSpeed = 6;
        private bool offsetExplosion = true; // Offset the explosion and set it to false so it happens only once.
        private int explosionCounter = 0;
        private int explosionLastFrame = 26; // How many frames the explosion has.

        public Asteroid(int X, int Y, string imagePath) : base(X, Y, imagePath)
        {
            collisionTimer.Start();

            Xspeed = RNG.Next(maxLeftSpeed, maxRightSpeed);
            Yspeed = RNG.Next(minFallSpeed, maxFallSpeed);
            this.X = startPosition + X;
            this.Y = RNG.Next(-1600, -200);

            health = img.Height + img.Width;
        }

        public void Move()
        {
            if (!hasExploded)
            {
                // If asteroid moves to the sides, get it back up
                // to a random position with random fall speed
                // and random side movement.
                X += Xspeed;
                if (X < -200 || X > 900)
                {
                    Xspeed = RNG.Next(maxLeftSpeed, maxRightSpeed);
                    Yspeed = RNG.Next(minFallSpeed, maxFallSpeed);
                    X = RNG.Next(0, 700);
                    Y = -200;
                }

                // If asteroid falls down, get it back up
                // to a random position with random fall speed
                // and random side movement.
                Y += Yspeed;
                if (Y < -1700 || Y > 800)
                {
                    Xspeed = RNG.Next(maxLeftSpeed, maxRightSpeed);
                    Yspeed = RNG.Next(minFallSpeed, maxFallSpeed);
                    X = RNG.Next(0, 700);
                    Y = -200;
                }
            }            
        }

        public void Explode()
        {
            if (offsetExplosion) // If true offset and set it to false.
            {
                X = X + (img.Width / 2) - 120;
                Y = Y + (img.Height / 2) - 120;
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
                AsteroidObjects.Remove(this);
                Y = 790;
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

        public static string[] asteroidPaths = 
        {
            @"Asteroids\medium_Asteroid0.png", @"Asteroids\medium_Asteroid1.png",
            @"Asteroids\medium_Asteroid2.png", @"Asteroids\medium_Asteroid3.png",
            @"Asteroids\medium_Asteroid4.png", @"Asteroids\medium_Asteroid5.png",

            @"Asteroids\small_Asteroid0.png", @"Asteroids\small_Asteroid1.png",
            @"Asteroids\small_Asteroid2.png", @"Asteroids\small_Asteroid3.png",
            @"Asteroids\small_Asteroid4.png", @"Asteroids\small_Asteroid5.png",

            @"Asteroids\big_Asteroid0.png", @"Asteroids\big_Asteroid1.png",
            @"Asteroids\big_Asteroid2.png", @"Asteroids\big_Asteroid3.png",
            @"Asteroids\big_Asteroid4.png", @"Asteroids\big_Asteroid5.png",
        };

        public static Asteroid MakeRandomAsteroid()
        {
            return new Asteroid(0, 0, asteroidPaths[RNG.Next(0, asteroidPaths.Length)]);
        }

        public static Asteroid[] MakeAllAsteroids()
        {
            Asteroid[] Asteroids = new Asteroid[asteroidPaths.Length];

            for (int i = 0; i < Asteroids.Length; i++)
            {
                Asteroids[i] = new Asteroid(0, 0, asteroidPaths[i]);
                Asteroids[i].collidable = true;
            }

            return Asteroids;
        }
    }
}
