using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceArcadeShooter
{
    public partial class SpaceArcadeShooter : Form
    {
        private static bool right { get; set; }
        private static bool left { get; set; }
        private static bool up { get; set; }
        private static bool down { get; set; }
        private static bool shoot { get; set; }

        private static int minAsteroidNumber = 20;
                
        static Background SpaceBackground = new Background(0, -6000, @"Space\Background.png");
        
        

        public static Spaceship AirCraft = new Spaceship(400, 540);

        public SpaceArcadeShooter()
        {
            InitializeComponent();
        }  

        private void SpaceArcadeShooter_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                right = true;                
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                left = true;                
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                up = true;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                down = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(); //trigger Paint event

            if (!AirCraft.hasExploded)
            {
                if (up)
                {
                    AirCraft.MoveUp();
                }
                if (down)
                {
                    AirCraft.MoveDown();
                }
                if (right)
                {
                    AirCraft.MoveRight();
                }
                if (left)
                {
                    AirCraft.MofeLeft();
                }
                if (shoot)
                {
                    AirCraft.Shoot(Projectile.ProjectileObjects, AirCraft.X, AirCraft.Y);
                }
            }

            int tempPoints = 0;

            SpaceBackground.MoveTo(SpaceBackground.X, SpaceBackground.Y + 1);

            Engine.MoveBackgroundStars(BackgroundStar.StarObjects);
            Engine.MoveProjectiles(Projectile.ProjectileObjects);
            Engine.CkeckAsteroidCollision(Asteroid.AsteroidObjects);
            Engine.MoveAsteroids(Asteroid.AsteroidObjects);
            Engine.HandleProjectileDestruction(Projectile.ProjectileObjects, Asteroid.AsteroidObjects);
            Engine.ExplodeAsteroidIfDamaged(Asteroid.AsteroidObjects, ref tempPoints);
            Engine.CreateAsteroid(Asteroid.AsteroidObjects, minAsteroidNumber);
            Engine.HandleShipCollision(AirCraft, Asteroid.AsteroidObjects);
            Engine.SpawnAndMoveAmmoCrates(((int)AmmoCrate.LastSpawned.ElapsedMilliseconds)/1000, 300); // 2 out of 1000 chance to spawn per tick. 300 ammo contained.
            Engine.HandleAmmoCollecting(AirCraft, AmmoCrate.AmmoObjects);

            AirCraft.score += (uint)(tempPoints / 10);
            ScoreLabel.Text = AirCraft.score.ToString().PadLeft(10, '0');
            AmmoLabel.Text = "Ammo: " + AirCraft.ammoCount;

            if (AirCraft.hasExploded)
            {
                GameOverLabel.Show();
            }
        }

        private void SpaceArcadeShooter_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                right = false;
                if (!AirCraft.hasExploded)
                {
                    AirCraft.MoveStop();
                }
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                left = false;
                if (!AirCraft.hasExploded)
                {
                    AirCraft.MoveStop();
                }
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                up = false;
                if (!AirCraft.hasExploded)
                {
                    AirCraft.MoveStop();
                }
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                down = false;
                if (!AirCraft.hasExploded)
                {
                    AirCraft.MoveStop();
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot = false;
            }
        }

        private void SpaceArcadeShooter_Load(object sender, EventArgs e)
        {
            GameOverLabel.Hide();
            timer1.Stop();

            PrivateFontCollection pfc = new PrivateFontCollection();

            //pfc.AddFontFile(Directory.GetCurrentDirectory() + @"\Resources\Font\ka1.ttf");
            //ScoreLabel.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);
            //AmmoLabel.Font = new Font(pfc.Families[0], 16, FontStyle.Regular);

            pfc.AddFontFile(Directory.GetCurrentDirectory() + @"\Resources\Font\dn.ttf");
            ScoreLabel.Font = new Font(pfc.Families[0], 32, FontStyle.Regular);
            AmmoLabel.Font = new Font(pfc.Families[0], 32, FontStyle.Regular);

            Color BlackOpaqueColor = Color.FromArgb(100, Color.Black);
            PlayLabel.Font = new Font(pfc.Families[0], 64, FontStyle.Regular);
            PlayLabel.BackColor = BlackOpaqueColor;
            GameOverLabel.Font = new Font(pfc.Families[0], 96, FontStyle.Regular);
            GameOverLabel.BackColor = BlackOpaqueColor;

            GameObject.Init();
            Asteroid.AsteroidObjects = Asteroid.MakeStartingAsteroids().ToList();
            AmmoCrate.LastSpawned.Start();
            BackgroundStar.StarObjects = BackgroundStar.MakeStars();
        }

        public void SpaceArcadeShooter_Paint(object sender, PaintEventArgs e)
        {   
            foreach (var GameObj in GameObject.AllObjects)
            {
                e.Graphics.DrawImage(GameObj.img, new Point(GameObj.X, GameObj.Y));
            }
        }

        private void PlayLabel_Click(object sender, EventArgs e)
        {
            timer1.Start();
            PlayLabel.Hide();
        }

        private void GameOverLabel_Click(object sender, EventArgs e)
        {
            GameOverLabel.Hide();
            Engine.ClearInteractiveObjects(Asteroid.AsteroidObjects, AmmoCrate.AmmoObjects);
            AirCraft = new Spaceship(400, 540);
        }
    }
}
