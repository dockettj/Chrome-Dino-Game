/* Google Chrome Dino Game Recreation
 * Created for 10th grade day! Woot Woot!
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
        // Editable Variables. These are the only things you should really edit unless you're feeling adventureous.

        double movementSpeed = 6; // How fast the dino moves. 
        double movementSpeedIncrement = 0.01; // The amount faster that the dino will get every frame.
        int maxJumpHeight = 170; // The maximum position that the dino can jump. I'd reccomend it be greater than 150. 
        bool isCustomCharacter = true;


        double[] vel = new double[] { 0, 0 };
        double[] pos = new double[] { 0, 0 };
        double[] acc = new double[] { 0, 0 };

        bool jumpingRaise, jumpingLower = false;

        int dinoAnimationPosition = 1; // Position 0 is not moving.

        List<Cactus> cactus = new List<Cactus>();

        Random rand;
        int minimumCactusSpawn, maximumCactusSpawn;

        int totalScore;


         
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pos[0] = dino.Location.X;
            pos[1] = dino.Location.Y;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            minimumCactusSpawn = 3000;
            maximumCactusSpawn = 3500;

            Cactus joshua = new Cactus();
            Controls.Add(joshua.cactus);
            joshua.cactus.BringToFront();
            cactus.Add(joshua);

            tickSpawn.Interval = rand.Next(minimumCactusSpawn, maximumCactusSpawn);


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

            movementSpeed += movementSpeedIncrement;
            ground.Location = new Point(Convert.ToInt32(ground.Location.X - movementSpeed), ground.Location.Y);
            if (ground.Location.X <= this.Width - ground.Width) { ground.Left = 0; }

            foreach (Cactus c in cactus)
            {
                c.updatePosition(movementSpeed);
                CheckCactusColission(c);
                if (c.cactus.Location.X < -25)
                {
                    Controls.Remove(c.cactus);                }
            }
        }


        private void Clock_Tick(object sender, EventArgs e)
        {
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
            if (minimumCactusSpawn >= 1500)
            {
                minimumCactusSpawn -= 50;
            }

            tickSpawn.Interval = rand.Next(minimumCactusSpawn, maximumCactusSpawn);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tickGround.Enabled = true;
            tickClock.Enabled = true;
            tickScore.Enabled = true;
            tickSpawn.Enabled = true;
            btnPlay.Visible = false;

            if (!isCustomCharacter)
            {
                tickAnimation.Enabled = true;
            }

        }

        private void EndGame()
        {
            tickGround.Enabled = false;
            tickClock.Enabled = false;
            tickScore.Enabled = false;
            tickSpawn.Enabled = false;
            btnPlay.Visible = true;

            if (!isCustomCharacter)
            {
                tickAnimation.Enabled = false;
            }

        }

        private void CheckCactusColission(Cactus cactus)
        {
            if (dino.Bounds.IntersectsWith(cactus.cactus.Bounds))
            {
                cactus.cactus.Enabled = false;
                cactus.cactus.Visible = false;
                EndGame();
            }
        }
    }
}
