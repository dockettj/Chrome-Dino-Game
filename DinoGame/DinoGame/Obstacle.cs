using System;
using System.Drawing;
using System.Windows.Forms;

namespace DinoGame
{
    class Cactus
    {

        string[] possibleCactus = new string[7] { "cactus1", "cactus2", "cactus3", "cactus4", "cactus5", "cactus6", "cactus7", };
        public PictureBox cactus = new PictureBox();

        public Cactus()
        {
            // Cacti always needs to reside on Y=279.
            // X will be a constantly changing variable, to make it move on the map.

            Random rand = new Random();
            int selectedCactus = rand.Next(0, 6);

            cactus.Image = Properties.Resources.cactus1;
            cactus.Location = new Point(700, 279);
            cactus.BackColor = Color.Transparent;
            cactus.SizeMode = PictureBoxSizeMode.StretchImage;
            cactus.Size = new Size(43, 90);
        }

        public void updatePosition(double movementSpeed)
        {
            cactus.Location = new Point(Convert.ToInt32(cactus.Location.X - movementSpeed), cactus.Location.Y);
        }

    }
        class Bird
    {

    }
}
