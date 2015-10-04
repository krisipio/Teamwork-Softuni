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

        private static int collisionRadius = 130;
        
        static Background Space = new Background(0, -6000, @"Space\Background.png");
        static BackgroundStar[] Stars = BackgroundStar.MakeStars();
        static Asteroid[] Asteroids = Asteroid.MakeAsteroids();


        static Spaceship AirCraft = new Spaceship(400, 540);

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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh(); //trigger Paint event
            if (right)
            {
                AirCraft.MoveRight();                
            }
            if (left)
            {
                AirCraft.MofeLeft();                
            }
            if (up)
            {
                AirCraft.MoveUp();                
            }
            if (down)
            {
                AirCraft.MoveDown();                               
            }

            Space.MoveTo(Space.X, Space.Y + 1);
            Engine.MoveBackgroundStars(Stars);
            //Engine.HandleAsteroidCollision(Asteroids, collisionRadius);
            Engine.MoveAsteroids(Asteroids);            

        }

        private void SpaceArcadeShooter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                right = false;
                AirCraft.MoveStop();
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                left = false;
                AirCraft.MoveStop();
            }
            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                up = false;
            }
            if(e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                down = false;
            }
        }

        private void SpaceArcadeShooter_Load(object sender, EventArgs e)
        {
            
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
