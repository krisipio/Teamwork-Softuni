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
