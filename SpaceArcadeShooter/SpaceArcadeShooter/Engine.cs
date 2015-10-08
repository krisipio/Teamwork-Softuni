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
        internal static void ClearAsteroids(List<Asteroid> Asteroids)
        {
            foreach (var asteroid in Asteroids.ToList())
            {
                asteroid.health = 0;
            }
        }

        internal static void HandleAmmoCollecting(Spaceship airCraft, List<AmmoCrate> crates)
        {
            foreach (var crate in crates.ToList())
            {
                if (IsObjectCenterInsideRectanlge(airCraft, crate))
                {
                    airCraft.ammoCount += crate.amountContained;
                    crate.Collected();
                }
            }
        }

        internal static void SpawnAndMoveAmmoCrates(int chancePerTimerTick, int ammoContained)
        {
            AmmoCrate.SpawnByChance(chancePerTimerTick, ammoContained);
            
            foreach (var ammoCrate in AmmoCrate.AmmoObjects.ToList())
            {
                ammoCrate.Move();
            }
        }
        
        internal static void CreateAsteroid(List<Asteroid> Asteroids, int minAsteroidNumber)
        {
            if (Asteroids.Count < minAsteroidNumber)
            {
                Asteroids.Add(Asteroid.MakeRandomAsteroid());
            }
        }

        internal static void ExplodeAsteroidIfDamaged(List<Asteroid> Asteroids, ref int points)
        {
            foreach (var asteroid in Asteroids.ToList())
            {
                if (asteroid.health <= 0)
                {
                    asteroid.hasExploded = true;
                    points = asteroid.pointsOnDestruction;
                    asteroid.Explode();                    
                }
            }
        }

        internal static void HandleProjectileDestruction(List<Projectile> Projectiles, List<Asteroid> Asteroids)
        {
            foreach (var projectile in Projectiles.ToList())
            {
                if (!projectile.hasExploded)
                {
                    foreach (var asteroid in Asteroids.ToList())
                    {
                        if (!asteroid.hasExploded && TwoObjectsCollide(projectile, asteroid))
                        {
                            projectile.hasExploded = true;
                            asteroid.health -= projectile.damage;
                        }
                    }
                }
                else
                {
                    projectile.Disappear();
                }
            }
        }

        internal static void HandleShipCollision(Spaceship airCraft, List<Asteroid> Asteroids)
        {
            if (!airCraft.hasExploded)
            {
                for (int i = 0; i < Asteroids.Count; i++)
                {
                    if (!Asteroids[i].hasExploded && TwoObjectsCollide(airCraft, Asteroids[i]))
                    {
                        airCraft.hasExploded = true;
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
            foreach (var projectile in Projectiles.ToList())
            {
                projectile.MoveUp();
            }
        }

        internal static void MoveBackgroundStars(BackgroundStar[] Stars)
        {
            foreach (var star in Stars.ToList())
            {
                star.Move();
            }
        }

        internal static void MoveAsteroids(List<Asteroid> Asteroids)
        {
            foreach (var asteroid in Asteroids.ToList())
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
        
        internal static void CkeckAsteroidCollision(List<Asteroid> Asteroids)
        {
            // Check for collisions between Asteroids
            for (int i = 0; i < Asteroids.Count; i++)
            {
                for (int j = 0; j < Asteroids.Count; j++)
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
            if (IsPointInCircleRadius(firstObject.X + (firstObject.img.Width / 2),   // Try to get the center of each image
                                      firstObject.Y + (firstObject.img.Height / 2),  // not the upper left corner
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

        internal static bool IsPointInCircleRadius (double pointX, double pointY, double circleX, double circleY, double circleR)
        {
            if (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) <= Math.Pow(circleR, 2))
                return true;
            else
                return false;
        }

        internal static bool IsObjectCenterInsideRectanlge(GameObject firstObject, GameObject secondObject)
        {
            int rectangleSizeModifier = 50; // Increase the size of the rectangle.

            if (isPointInRectangle(firstObject.X + (firstObject.img.Width / 2),
                                   firstObject.Y + (firstObject.img.Height / 2),
                                   secondObject.X - rectangleSizeModifier,
                                   secondObject.Y - rectangleSizeModifier,
                                   secondObject.img.Width + rectangleSizeModifier,
                                   secondObject.img.Height + rectangleSizeModifier))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool isPointInRectangle(double pointX, double pointY, double rektLeft, double rektTop, double rektWidth, double rektHeight)
        {
            if (pointY >= rektTop && pointY <= rektTop + rektHeight &&
                pointX >= rektLeft && pointX <= rektLeft + rektWidth)
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
