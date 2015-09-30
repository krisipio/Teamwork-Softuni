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
            this.Plane = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Plane
            // 
            this.Plane.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Plane.Location = new System.Drawing.Point(93, 163);
            this.Plane.Name = "Plane";
            this.Plane.Size = new System.Drawing.Size(70, 67);
            this.Plane.TabIndex = 0;
            this.Plane.Text = "Plane";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SpaceArcadeShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Plane);
            this.Name = "SpaceArcadeShooter";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceArcadeShooter_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceArcadeShooter_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Plane;
        private System.Windows.Forms.Timer timer1;
    }
}

