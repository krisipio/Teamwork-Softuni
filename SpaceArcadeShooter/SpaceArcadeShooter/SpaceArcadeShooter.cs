using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceArcadeShooter
{
    public partial class SpaceArcadeShooter : Form
    {

        bool right;
        bool left;



        public SpaceArcadeShooter()
        {
            InitializeComponent();
        }

  

        private void SpaceArcadeShooter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Right)
            {
                right = true; 
            }
            if (e.KeyCode==Keys.Left)
            {
                left = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (right==true)
            {
                Plane.Left += 5;
            }
            if (left == true)
            {
                Plane.Left -= 5;
            }
        }

        private void SpaceArcadeShooter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode==Keys.Left)
            {
                left = false;
            }
        }

        
    }
}
