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
            int speedDivisor = 3; // Decrease the speed change from collision. It is too much without it.
            int collisionCooldown = 60; // Max milliseconds before collission can occur again.

            if (firstCollider.collisionTimer.ElapsedMilliseconds > collisionCooldown &&
                secondCollider.collisionTimer.ElapsedMilliseconds > collisionCooldown &&
                !(firstCollider.X < 0 && firstCollider.X > 900) &&
                !(firstCollider.Y < 0 && firstCollider.Y > 800))
            {
                if (firstCollider.X < secondCollider.X) // firstCollider is to the left of secondCollider.
                {
                    firstCollider.Xspeed -= secondCollider.Xspeed / speedDivisor; // firstCollider increases speed to the left.
                    secondCollider.Xspeed += firstCollider.Xspeed / speedDivisor; // secondCollider decreases speed to the left.
                }
                else // firstCollider is to the right of secondCollider.
                {
                    firstCollider.Xspeed += secondCollider.Xspeed / speedDivisor; // firstCollider increases speed to the right.
                    secondCollider.Xspeed -= firstCollider.Xspeed / speedDivisor; // secondCollider decreases speed to the right.
                }

                if (firstCollider.Y < secondCollider.Y)  // firstCollider is above secondCollider.
                {
                    firstCollider.Yspeed -= secondCollider.Yspeed / speedDivisor; // firstCollider decreases.
                    firstCollider.Yspeed = Math.Max(firstCollider.Yspeed, 1); // Making sure it doesn't go back up.

                    secondCollider.Yspeed += firstCollider.Yspeed / speedDivisor; // secondCollider increases speed.
                }
                else  // firstCollider is under secondCollider.
                {
                    firstCollider.Yspeed += secondCollider.Yspeed / speedDivisor; // secondCollider increases speed.

                    secondCollider.Yspeed -= firstCollider.Yspeed / speedDivisor; // firstCollider decreases speed.
                    secondCollider.Yspeed = Math.Max(secondCollider.Yspeed, 1); // Making sure it doesn't go back up.
                }

                firstCollider.collisionTimer.Reset();
                firstCollider.collisionTimer.Start();
                secondCollider.collisionTimer.Reset();
                secondCollider.collisionTimer.Start();
            }
        }

        internal static void HandleAsteroidCollision(Asteroid[] Asteroids, int collisionRadius)
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

        internal static bool TwoObjectsCollide(GameObject firstObject, GameObject secondObject, double collisionRadius)
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
