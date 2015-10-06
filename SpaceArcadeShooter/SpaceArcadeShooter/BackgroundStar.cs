using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    public class BackgroundStar : GameObject
    {
        static Random RNG = new Random();
        public int movement = RNG.Next(1, 13);
        public int startPosition = RNG.Next(0, 780);
        public static BackgroundStar[] StarObjects = BackgroundStar.MakeStars();

        public BackgroundStar(int X, int Y, string imagePath) : base(X, Y, imagePath)
        {
            this.X = startPosition + X;
            this.Y += movement + Y;
        }

        public void Move()
        {
            X = startPosition;
            Y += movement;
            if (Y > 800)
            {
                Y -= 1500;
                startPosition = RNG.Next(0, 780);
                movement = RNG.Next(1, 13);
            }
        }

        public void MoveTo(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            if (Y > 800) this.Y -= 1500;
        }

        public static BackgroundStar[] MakeStars()
        {
            // 4x for more stars
            string[] starPaths = { @"Space\Star1.png", @"Space\Star2.png",
                                   @"Space\Star3.png", @"Space\Star4.png",
                                   @"Space\Star5.png", @"Space\Star6.png",
                                   @"Space\Star7.png", @"Space\Star8.png",
                                   @"Space\Star9.png", @"Space\Star10.png",
                                   @"Space\Star11.png", @"Space\Star12.png",

                                   @"Space\Star1.png", @"Space\Star2.png",
                                   @"Space\Star3.png", @"Space\Star4.png",
                                   @"Space\Star5.png", @"Space\Star6.png",
                                   @"Space\Star7.png", @"Space\Star8.png",
                                   @"Space\Star9.png", @"Space\Star10.png",
                                   @"Space\Star11.png", @"Space\Star12.png",

                                   @"Space\Star1.png", @"Space\Star2.png",
                                   @"Space\Star3.png", @"Space\Star4.png",
                                   @"Space\Star5.png", @"Space\Star6.png",
                                   @"Space\Star7.png", @"Space\Star8.png",
                                   @"Space\Star9.png", @"Space\Star10.png",
                                   @"Space\Star11.png", @"Space\Star12.png",

                                   @"Space\Star1.png", @"Space\Star2.png",
                                   @"Space\Star3.png", @"Space\Star4.png",
                                   @"Space\Star5.png", @"Space\Star6.png",
                                   @"Space\Star7.png", @"Space\Star8.png",
                                   @"Space\Star9.png", @"Space\Star10.png",
                                   @"Space\Star11.png", @"Space\Star12.png"};

            BackgroundStar[] Stars = new BackgroundStar[starPaths.Length];

            for (int i = 0; i < Stars.Length; i++)
            {
                Stars[i] = new BackgroundStar(0, RNG.Next(-500, -50), starPaths[i]);
            }

            return Stars;
        }
    }
}
