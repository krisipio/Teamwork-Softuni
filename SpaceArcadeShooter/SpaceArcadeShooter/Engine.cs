using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceArcadeShooter
{
    class Engine
    {
        private Engine()
        {
            // Бръм-бръм.
        }

        internal static void MoveBackgroundStars(BackgroundStar[] Stars)
        {
            foreach (var star in Stars)
            {
                star.Move();
            }
        }

        internal static void MoveAsteroids(Asteroid[] Asteroids)
        {
            foreach (var asteroid in Asteroids)
            {
                asteroid.Move();
                asteroid.RotateImage(); // Not working yet.
            }
        }

        internal static void HandleCollision(GameObject firstCollider, GameObject secondCollider)
        {
            int speedDivisor = 2; // Decrease the speed change from collision. It is too much without it;

            if (firstCollider.collisionTimer.ElapsedMilliseconds > 10 &&
                secondCollider.collisionTimer.ElapsedMilliseconds > 10 &&
                !(firstCollider.X < 0 && firstCollider.X > 900) &&
                !(firstCollider.Y < 0 && firstCollider.Y > 800))
            {
                if (firstCollider.X < secondCollider.X) // firstCollider is to the left of secondCollider.
                {
                    firstCollider.Xspeed -= secondCollider.Xspeed / speedDivisor; // firstCollider increases speed to the left.
                    secondCollider.Xspeed += firstCollider.Xspeed / speedDivisor; // secondCollider decreases speed to the left.
                }
                else // firstCollider is to the left of secondCollider.
                {
                    firstCollider.Xspeed += secondCollider.Xspeed / speedDivisor; // firstCollider increases speed to the left.
                    secondCollider.Xspeed -= firstCollider.Xspeed / speedDivisor; // secondCollider decreases speed to the left.
                }

                if (firstCollider.Y < secondCollider.Y)  // firstCollider is above secondCollider.
                {
                    firstCollider.Yspeed -= secondCollider.Yspeed / speedDivisor; // firstCollider decreases.
                    firstCollider.Yspeed = Math.Max(firstCollider.Yspeed, 1); // Making sure it doesn't go back up, or stop.

                    secondCollider.Yspeed += firstCollider.Yspeed / speedDivisor; // secondCollider increases speed.
                }
                else  // firstCollider is under secondCollider.
                {
                    firstCollider.Yspeed += secondCollider.Yspeed / speedDivisor; // secondCollider increases speed.

                    secondCollider.Yspeed -= firstCollider.Yspeed / speedDivisor; // firstCollider decreases speed.
                    secondCollider.Yspeed = Math.Max(secondCollider.Yspeed, 1); // Making sure it doesn't go back up, or stop.
                }

                firstCollider.collisionTimer.Reset();
                firstCollider.collisionTimer.Start();
                secondCollider.collisionTimer.Reset();
                secondCollider.collisionTimer.Start();
            }
        }

        public static void HandleAsteroidCollision(Asteroid[] Asteroids, int collisionRadius)
        {
            // Check for collisions between Asteroids
            for (int i = 0; i < Asteroids.Length; i++)
            {
                for (int j = 0; j < Asteroids.Length; j++)
                {
                    if ((i != j) && Engine.TwoObjectsCollide(Asteroids[i], Asteroids[j], collisionRadius))
                    {
                        Engine.HandleCollision(Asteroids[i], Asteroids[j]);
                    }
                }
            }
        }

        public static bool TwoObjectsCollide(GameObject firstObject, GameObject secondObject, double collisionRadius)
        {
            if (IsPointInCircleRadius(firstObject.X, firstObject.Y, secondObject.X, secondObject.Y, collisionRadius))
                return true;
            else
                return false;
        }

        private static bool IsPointInCircleRadius (double pointX, double pointY, double circleX, double circleY, double circleR)
        {
            if (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) <= Math.Pow(circleR, 2))
                return true;
            else
                return false;
        }

        internal static Image RotateImage(Image img, int angle)
        {
            // Rotate?
            return img;
        }
        
    }
}
