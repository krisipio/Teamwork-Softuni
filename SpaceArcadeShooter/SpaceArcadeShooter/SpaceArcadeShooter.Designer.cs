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
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.ScoreLabel.Location = new System.Drawing.Point(638, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ScoreLabel.Size = new System.Drawing.Size(99, 20);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "0000000000";
            // 
            // SpaceArcadeShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(848, 670);
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
    }
}

