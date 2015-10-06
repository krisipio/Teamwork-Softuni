using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                
        static Background Space = new Background(0, -6000, @"Space\Background.png");
        static BackgroundStar[] Stars = BackgroundStar.MakeStars();
        static Asteroid[] Asteroids = Asteroid.MakeAsteroids();
        static List<Projectile> Projectiles = new List<Projectile>();

        static Spaceship AirCraft = new Spaceship(400, 540);
        //static Explosion Boom = new Explosion(50, 50, @"Explosion\0025.png");

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
            this.Refresh(); //trigger Paint event

            if (!AirCraft.hasColided)
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
                    AirCraft.Shoot(Projectiles, AirCraft.X, AirCraft.Y);
                }
            }         
                  
            Space.MoveTo(Space.X, Space.Y + 1);
            Engine.MoveBackgroundStars(Stars);
            Engine.MoveProjectiles(Projectiles);
            Engine.CkeckAsteroidCollision(Asteroids);
            Engine.MoveAsteroids(Asteroids);
            Engine.HandleShipCollision(AirCraft, Asteroids);
        }

        private void SpaceArcadeShooter_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                right = false;
                if (!AirCraft.hasColided)
                {
                    AirCraft.MoveStop();
                }
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                left = false;
                if (!AirCraft.hasColided)
                {
                    AirCraft.MoveStop();
                }
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                up = false;
                if (!AirCraft.hasColided)
                {
                    AirCraft.MoveStop();
                }
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                down = false;
                if (!AirCraft.hasColided)
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
            GameObject.Init();
            //GraphicsHandler.Render();
        }

        public void SpaceArcadeShooter_Paint(object sender, PaintEventArgs e)
        {   
            foreach (var GameObj in GameObject.AllObjects)
            {
                e.Graphics.DrawImage(GameObj.img, new Point(GameObj.X, GameObj.Y));
            }
        }
    }
}
