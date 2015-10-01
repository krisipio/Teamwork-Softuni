using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceArcadeShooter
{
    static class GraphicsHandler
    {
        //not in use
        static List<PictureBox> images = new List<PictureBox>();
        static void DrawImage(int x,int y,string ImagePath)
        {
            var pic = new PictureBox();
            pic.Location = new Point(x, y);
            pic.Name = "pic" + images.Count;
            pic.Size = new Size(300, 75);
            pic.ImageLocation = @"Resources/" + ImagePath;
            //SpaceArcadeShooter.AddPicture
            images.Add(pic);
        }

        public static void Render()
        {
            
        }
    }
}
