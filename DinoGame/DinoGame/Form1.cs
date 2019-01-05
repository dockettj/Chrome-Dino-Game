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

        bool jumpingRaise, jumpingLower = false;

        int dinoAnimationPosition = 1; // Position 0 is not moving.

        List<Cactus> cactus = new List<Cactus>();

        int totalScore;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pos[0] = dino.Location.X;
            pos[1] = dino.Location.Y;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void ButtonPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Space) && dino.Location.Y >= 290)
            {
                jumpingRaise = true;
                dinoAnimationPosition = 0;
            }
        }

        private void Ground_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Tick");
            double movement = 8;
            movement += 0.001;
            ground.Location = new Point(Convert.ToInt32(ground.Location.X - movement), ground.Location.Y);
            if (ground.Location.X <= this.Width - ground.Width) { ground.Left = 0; }

            foreach (Cactus c in cactus)
            {
                c.updatePosition(movement);
                CheckCactusColission(c);
                if (c.cactus.Location.X < -25)
                {
                    Controls.Remove(c.cactus);                }
            }
        }


        private void Clock_Tick(object sender, EventArgs e)
        {
            int maxJumpHeight = 150;

            if (jumpingLower == true) // Our gravity engine ( I think. That sounds like the right thing to call it. So I'm going to keep it like that.)
            {
                acc[1] = 0.6; // Gravity. Lower is less of it. NOTE: Make it negative to fly into space thje first time you jump. Rocket shoes baby!
                vel[1] += acc[1];
                pos[1] += (vel[1] + 0.55 * acc[1]);

                dino.Location = new Point(Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1]));
                if (dino.Location.Y >= 280)
                {
                    jumpingLower = false;
                    dinoAnimationPosition = 1;
                }
            }
            else if (jumpingRaise == true)
            {
                acc[1] = -1.5; 
                vel[1] += acc[1];
                pos[1] += (vel[1] + 0.55 * acc[1]);

                dino.Location = new Point(Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1]));
                if (dino.Location.Y <= maxJumpHeight)
                {
                    vel[1] = 0.45;
                    jumpingRaise = false;
                    jumpingLower = true;
                }
            }
            else
            {
                dino.Location = new Point(dino.Location.X, 290);
                vel[1] = 0.45;
            }
        }

        private void Spawn_Tick(object sender, EventArgs e)
        {
            Cactus joshua = new Cactus();
            Controls.Add(joshua.cactus);
            joshua.cactus.BringToFront();
            cactus.Add(joshua);
        }


        private void Score_Tick(object sender, EventArgs e)
        {
            totalScore++;
            scoreLabel.Text = totalScore.ToString("0000");
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            if (dinoAnimationPosition == 0)
            {
                dino.Image = Properties.Resources.dinoStanding;
            }
            else if (dinoAnimationPosition == 1)
            {
                dino.Image = Properties.Resources.dinoWalk1;
                dinoAnimationPosition = 2;
            }
            else if (dinoAnimationPosition == 2)
            {
                dino.Image = Properties.Resources.dinoWalk2;
                dinoAnimationPosition = 1;
            }
        }

        private void EndGame()
        {
            //MessageBox.Show("Ending");
            tickClock.Enabled = tickGround.Enabled = tickSpawn.Enabled = false;
            MessageBox.Show(this, "Ended Game");
            Application.Exit();
        }

        private void CheckCactusColission(Cactus cactus)
        {
            if (dino.Bounds.IntersectsWith(cactus.cactus.Bounds))
            {
                EndGame();
            }
        }
    }
}
