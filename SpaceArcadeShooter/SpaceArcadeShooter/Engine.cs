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

        public static void HandleAsteroidCollision(Asteroid[] Asteroids, int collisionRadius)
        {
            // Check for collisions between Asteroids
            for (int i = 0; i < Asteroids.Length; i++)
            {
                for (int j = 0; j < Asteroids.Length; j++)
                {
                    if ((i != j) &&
                        Engine.TwoObjectsCollide(Asteroids[i], Asteroids[j], collisionRadius))
                    {
                        Asteroids[i].HandleCollision(Asteroids[j]);
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
