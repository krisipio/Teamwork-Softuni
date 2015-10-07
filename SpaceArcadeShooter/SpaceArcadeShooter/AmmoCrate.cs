using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceArcadeShooter
{
    public class AmmoCrate : GameObject
    {
        static Random RNG = new Random();
        public int amountContained = 500;
        public int movement = RNG.Next(1, 3);
        public int startPosition = RNG.Next(0, 780);
        public static List<AmmoCrate> AmmoObjects = new List<AmmoCrate>();

        public AmmoCrate(int X, int Y, string imagePath, int AmmoCount) : base(X, Y, imagePath)
        {
            amountContained = AmmoCount;
            this.X = startPosition + X;
            this.Y += movement + Y;
        }

        public void Collected()
        {
            Disappear();
            AmmoObjects.Remove(this);
        }

        public void Move()
        {
            X = startPosition;
            Y += movement;
            if (Y > 800)
            {
                Disappear();
                AmmoObjects.Remove(this);
            }
        }

        public static void SpawnByChance(int chancePerTimerTick, int ammoContained)
        {
            if (RNG.Next(1, 1001) <= chancePerTimerTick && AmmoObjects.Count == 0)
            {
                AmmoObjects.Add(new AmmoCrate(0, -100, @"\Ammo\AmmoCrateSmall.png", ammoContained));
            }
        }
    }
}
