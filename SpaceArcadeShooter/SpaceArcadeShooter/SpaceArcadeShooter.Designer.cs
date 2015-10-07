namespace SpaceArcadeShooter
{
    partial class SpaceArcadeShooter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.AmmoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.ScoreLabel.Location = new System.Drawing.Point(638, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(67, 13);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "0000000000";
            // 
            // AmmoLabel
            // 
            this.AmmoLabel.AutoSize = true;
            this.AmmoLabel.BackColor = System.Drawing.Color.Transparent;
            this.AmmoLabel.ForeColor = System.Drawing.Color.White;
            this.AmmoLabel.Location = new System.Drawing.Point(638, 636);
            this.AmmoLabel.Name = "AmmoLabel";
            this.AmmoLabel.Size = new System.Drawing.Size(48, 13);
            this.AmmoLabel.TabIndex = 1;
            this.AmmoLabel.Text = "Ammo: 0";
            // 
            // SpaceArcadeShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(848, 670);
            this.Controls.Add(this.AmmoLabel);
            this.Controls.Add(this.ScoreLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SpaceArcadeShooter";
            this.Text = "Space Arcade Shooter";
            this.Load += new System.EventHandler(this.SpaceArcadeShooter_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceArcadeShooter_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceArcadeShooter_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceArcadeShooter_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label AmmoLabel;
    }
}

