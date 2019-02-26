﻿/* Google Chrome Dino Game Recreation
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

        int dinoLowLocation = 285; // The location of the dino when it is not jumping. Leave it a 285 when not using a custom character, but, if using a custom character, feel free to change it.
        double initMovementSpeed = 6; // How fast the dino moves. 
        double movementSpeedIncrement = 0.003; // The amount faster that the dino will get every frame.
        double gravity = 0.4; // Gravity. Lower is less of it. NOTE: Make it negative to fly into space thje first time you jump. Rocket shoes baby!
        int maxJumpHeight = 100; // The maximum position that the dino can jump. I'd reccomend it be greater than 150. 
        bool isCustomCharacter = false;


        double[] vel = new double[] { 0, 0 };
        double[] pos = new double[] { 0, 0 };
        double[] acc = new double[] { 0, 0 };

        double movementSpeed;

        bool jumpingRaise, jumpingLower = false;

        int dinoAnimationPosition = 1; // Position 0 is not moving.

        List<Cactus> cacti = new List<Cactus>();
        List<Bird> birds = new List<Bird>();

        Random rand;
        int minimumSpawnTime, maximumSpawnTime;

        int totalScore;
        bool scoreTrigger = true;



        public Form1()
        {
            InitializeComponent();
            rand = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            movementSpeed = initMovementSpeed;

            pos[0] = dino.Location.X;
            pos[1] = dino.Location.Y;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            minimumSpawnTime = 3000;
            maximumSpawnTime = 3500;

            Cactus joshua = new Cactus();
            Controls.Add(joshua.cactus);
            joshua.cactus.BringToFront();
            cacti.Add(joshua);

            tickSpawn.Interval = rand.Next(minimumSpawnTime, maximumSpawnTime);


        }

        private void ButtonPress(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) && dino.Location.Y >= dinoLowLocation)
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


            try
            {
                foreach (Cactus c in cacti)
                {
                    c.updatePosition(movementSpeed);
                    CheckCactusColission(c);
                    if (c.cactus.Location.X < -25)
                    {
                        scoreTrigger = true;
                        Controls.Remove(c.cactus);
                        cacti.Remove(c);
                    }
                }

                foreach (Bird b in birds)
                {
                    b.updatePosition(movementSpeed);
                    CheckBirdColission(b);
                    if (b.bird.Location.X < -25)
                    {
                        scoreTrigger = true;
                        Controls.Remove(b.bird);
                        birds.Remove(b);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            finalScoreLabel.Visible = false;
            scoreLabel.Visible = true;


            if (jumpingLower == true) // Our gravity engine ( I think. That sounds like the right thing to call it. So I'm going to keep it like that.)
            {
                acc[1] = gravity; // Gravity. Lower is less of it. NOTE: Make it negative to fly into space thje first time you jump. Rocket shoes baby!
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
                dino.Location = new Point(dino.Location.X, dinoLowLocation);
                vel[1] = 0.45;
            }
        }

        private void Spawn_Tick(object sender, EventArgs e)
        {
            int choice = rand.Next(0, 2);

            if (choice == 0) // We want to spawn a cactus
            {
                if (minimumSpawnTime >= 1500)
                {
                    minimumSpawnTime -= 50;
                }

                tickSpawn.Interval = rand.Next(minimumSpawnTime, maximumSpawnTime);
                Cactus cactus = new Cactus();
                Controls.Add(cactus.cactus);
                cactus.cactus.BringToFront();
                this.cacti.Add(cactus);
            }
            else if (choice == 1)
            {
                if (minimumSpawnTime >= 1500)
                {
                    minimumSpawnTime -= 50;
                }

                tickSpawn.Interval = rand.Next(minimumSpawnTime, maximumSpawnTime);
                Bird bird = new Bird();
                Controls.Add(bird.bird);
                bird.bird.BringToFront();
                this.birds.Add(bird);
            }
        }

        private void Score_Tick(object sender, EventArgs e)
        {
            if (scoreTrigger)
            {
                for (int i = 0; i < cacti.Count; i++)
                {
                    if (dino.Location.X >= cacti.ElementAt(i).cactus.Location.X)
                    {
                        scoreTrigger = false;
                        totalScore = totalScore + 1;
                    }
                }
                    for (int b = 0; b < birds.Count; b++)
                    {
                        if (dino.Location.X >= birds.ElementAt(b).bird.Location.X)
                        {
                            scoreTrigger = false;
                            totalScore = totalScore + 1;
                        }
                    }
                }

                scoreLabel.Text = totalScore.ToString("0000");
            }

            public void Animation_Tick(object sender, EventArgs e)
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

                foreach (Bird bird in birds)
                {
                    bird.update();
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

            private void CheckCactusColission(Cactus cactus)
            {
                if (dino.Bounds.IntersectsWith(cactus.cactus.Bounds))
                {
                    cactus.cactus.Enabled = false;
                    cactus.cactus.Visible = false;
                    EndGame();
                }
            }

            private void CheckBirdColission(Bird bird)
            {
                if (dino.Bounds.IntersectsWith(bird.bird.Bounds))
                {
                    bird.bird.Enabled = false;
                    bird.bird.Visible = false;
                    EndGame();
                }
            }

            private void EndGame()
            {
                tickGround.Enabled = false;
                tickClock.Enabled = false;
                tickScore.Enabled = false;
                tickSpawn.Enabled = false;
                btnPlay.Visible = true;
                scoreTrigger = true;
                cacti = new List<Cactus>();

                dino.Location = new Point(dino.Location.X, dinoLowLocation);
                vel[1] = 0.45;

                finalScoreLabel.Visible = true;
                finalScoreLabel.Text = "Final Score: " + totalScore.ToString("0000");
                totalScore = 0;
                scoreLabel.Visible = false;
                scoreLabel.Text = totalScore.ToString("0000");

                jumpingLower = false;
                jumpingRaise = false;

                movementSpeed = initMovementSpeed;

                dinoAnimationPosition = 1;

                if (!isCustomCharacter)
                {
                    tickAnimation.Enabled = false;
                }

            }
        }
    } 
