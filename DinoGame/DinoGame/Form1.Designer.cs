﻿namespace DinoGame
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tickGround = new System.Windows.Forms.Timer(this.components);
            this.tickClock = new System.Windows.Forms.Timer(this.components);
            this.cacti = new System.Windows.Forms.PictureBox();
            this.dino = new System.Windows.Forms.PictureBox();
            this.ground = new System.Windows.Forms.PictureBox();
            this.tickSpawn = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.tickScore = new System.Windows.Forms.Timer(this.components);
            this.tickAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cacti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            this.SuspendLayout();
            // 
            // tickGround
            // 
            this.tickGround.Enabled = true;
            this.tickGround.Interval = 1;
            this.tickGround.Tick += new System.EventHandler(this.Ground_Tick);
            // 
            // tickClock
            // 
            this.tickClock.Enabled = true;
            this.tickClock.Interval = 1;
            this.tickClock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // cacti
            // 
            this.cacti.BackColor = System.Drawing.Color.Transparent;
            this.cacti.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cacti.ErrorImage = null;
            this.cacti.Image = global::DinoGame.Properties.Resources.cactus1;
            this.cacti.Location = new System.Drawing.Point(675, 12);
            this.cacti.Name = "cacti";
            this.cacti.Size = new System.Drawing.Size(43, 90);
            this.cacti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cacti.TabIndex = 3;
            this.cacti.TabStop = false;
            // 
            // dino
            // 
            this.dino.BackColor = System.Drawing.Color.Transparent;
            this.dino.Image = global::DinoGame.Properties.Resources.dinoStanding;
            this.dino.Location = new System.Drawing.Point(92, 286);
            this.dino.Name = "dino";
            this.dino.Size = new System.Drawing.Size(54, 78);
            this.dino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dino.TabIndex = 2;
            this.dino.TabStop = false;
            // 
            // ground
            // 
            this.ground.BackColor = System.Drawing.Color.Transparent;
            this.ground.Image = global::DinoGame.Properties.Resources.ground;
            this.ground.Location = new System.Drawing.Point(0, 360);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(1287, 29);
            this.ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ground.TabIndex = 1;
            this.ground.TabStop = false;
            // 
            // tickSpawn
            // 
            this.tickSpawn.Enabled = true;
            this.tickSpawn.Interval = 2100;
            this.tickSpawn.Tick += new System.EventHandler(this.Spawn_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Rockwell", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(12, 12);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(100, 46);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "0000";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tickScore
            // 
            this.tickScore.Enabled = true;
            this.tickScore.Interval = 1000;
            this.tickScore.Tick += new System.EventHandler(this.Score_Tick);
            // 
            // tickAnimation
            // 
            this.tickAnimation.Enabled = true;
            this.tickAnimation.Interval = 66;
            this.tickAnimation.Tick += new System.EventHandler(this.Animation_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(730, 388);
            this.ControlBox = false;
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.cacti);
            this.Controls.Add(this.dino);
            this.Controls.Add(this.ground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Chrome Dino Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ButtonPress);
            ((System.ComponentModel.ISupportInitialize)(this.cacti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ground;
        private System.Windows.Forms.PictureBox dino;
        private System.Windows.Forms.Timer tickGround;
        private System.Windows.Forms.Timer tickClock;
        private System.Windows.Forms.PictureBox cacti;
        private System.Windows.Forms.Timer tickSpawn;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer tickScore;
        private System.Windows.Forms.Timer tickAnimation;
    }
}

