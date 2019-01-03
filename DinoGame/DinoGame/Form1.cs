/* Google Chrome Dino Game Recreation
 * Created as a possible 10th grade day program.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinoGame
{
    public partial class Form1 : Form
    {

        double[] vel = new double[] { 0, 0 };
        double[] pos = new double[] { 0, 0 };
        double[] acc = new double[] { 0, 0 };


        public Form1()
        {
            InitializeComponent();
        }

        private void Ground_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Tick");
            double movement = 5;
            ground.Location = new Point(Convert.ToInt32(ground.Location.X - movement), ground.Location.Y);
            if (ground.Location.X <= this.Width - ground.Width) { ground.Left = 0; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pos[0] = dino.Location.X;
            pos[1] = dino.Location.Y;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            if (dino.Location.Y < 290) // Our gravity engine
            {
                acc[1] = 0.45;
                vel[1] += acc[1];
                pos[1] += (vel[1] + 0.55 * acc[1]);

                dino.Location = new Point(Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1]));
            }
            else
            {
                dino.Location = new Point(dino.Location.X, 290);
                vel[1] = 0.45;
            }
        }

        private void ButtonPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Space)&& dino.Location.Y >= 290) {
                pos[1] = 150;
                dino.Location = new Point(Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1]));
            }
        }
    }
}
