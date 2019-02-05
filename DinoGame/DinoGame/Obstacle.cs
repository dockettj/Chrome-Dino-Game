using System;
using System.Drawing;
using System.Windows.Forms;

namespace DinoGame
{
    class Cactus
    {

        string[] possibleCactus = new string[7] { "cactus1", "cactus2", "cactus3", "cactus4", "cactus5", "cactus6", "cactus7", };
        public PictureBox cactus = new PictureBox();

        Random rand = new Random();
        int selectedCactus;

        public Cactus()
        {
             // Cacti always needs to reside on Y=279.
            // X will be a constantly changing variable, to make it move on the map.

            selectedCactus = rand.Next(0, 6);

            selectCactus(selectedCactus);

            cactus.Location = new Point(900, 280);
            cactus.BackColor = Color.Transparent;
            cactus.SizeMode = PictureBoxSizeMode.StretchImage;
            cactus.Size = new Size(43, 90);
        }

        private void selectCactus(int cactiNumber)
        {
            switch (cactiNumber)
            {
                case 0:
                    cactus.Image = Properties.Resources.cactus1;
                    break;
                case 1:
                    cactus.Image = Properties.Resources.cactus2;
                    break;
                case 2:
                    cactus.Image = Properties.Resources.cactus3;
                    break;
                case 3:
                    cactus.Image = Properties.Resources.cactus4;
                    break;
                case 4:
                    cactus.Image = Properties.Resources.cactus5;
                    break;
                case 5:
                    cactus.Image = Properties.Resources.cactus1;
                    break;
                case 6:
                    cactus.Image = Properties.Resources.cactus1;
                    break;

                default:
                    cactus.Image = Properties.Resources.cactus1;
                    break;
            }
        }

        public void updatePosition(double movementSpeed)
        {
            if (this.cactus != null)
            {
                cactus.Location = new Point(Convert.ToInt32(cactus.Location.X - movementSpeed), cactus.Location.Y);
                selectCactus(selectedCactus);
            }
        }
    }
}
