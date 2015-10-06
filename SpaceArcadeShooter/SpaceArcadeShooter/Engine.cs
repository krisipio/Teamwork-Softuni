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
        internal static void HandleShipCollision(Spaceship airCraft, Asteroid[] asteroids)
        {
            if (!airCraft.hasColided)
            {
                for (int i = 0; i < asteroids.Length; i++)
                {
                    if (TwoObjectsCollide(airCraft, asteroids[i]))
                    {
                        airCraft.hasColided = true;
                    }
                }
            }
            else
            {
                airCraft.Explode();
            }                       
        }

        internal static void MoveProjectiles(List<Projectile> Projectiles)
        {
            foreach (var projectile in Projectiles)
            {
                projectile.MoveUp();
            }
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
                //asteroid.RotateImage(); // Not implemented yet.
            }
        }

        internal static void HandleAsteroidCollision(GameObject firstCollider, GameObject secondCollider)
        {
            int speedDivisor = 3; // Decrease the speed change from collision. It is too much without it.
            int collisionCooldown = 3000; // Max milliseconds before collission can occur again.

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

                firstCollider.collisionTimer.Restart();
                secondCollider.collisionTimer.Restart();
            }
        }
        
        internal static void CkeckAsteroidCollision(Asteroid[] Asteroids)
        {
            // Check for collisions between Asteroids
            for (int i = 0; i < Asteroids.Length; i++)
            {
                for (int j = 0; j < Asteroids.Length; j++)
                {
                    if ((i != j) && Engine.TwoObjectsCollide(Asteroids[i], Asteroids[j]))
                    {
                        Engine.HandleAsteroidCollision(Asteroids[i], Asteroids[j]);
                    }
                }
            }
        }

        internal static bool TwoObjectsCollide(GameObject firstObject, GameObject secondObject)
        {
            if (IsPointInCircleRadius(firstObject.X + (firstObject.img.Width / 2),          // Try to get the center of each image
                                      firstObject.Y + (firstObject.img.Height / 2),         // not the upper left corner
                                      secondObject.X + (secondObject.img.Width / 2),
                                      secondObject.Y + (secondObject.img.Height / 2),
                                      secondObject.collisionRadius))
            {
                return true;
            }
            else
            {
                return false;
            }
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
