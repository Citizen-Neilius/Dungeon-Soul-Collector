using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Neil Little SDEV 260
//  16 November 2019
//    Week 12 Homework.
/***************************************************************************************************** Main form Maze */
namespace FormGame
{
    public partial class Form1 : Form 
    {
        
        locationMethods mlocationMethods = new locationMethods();   // Location method holds the matrix maze data and the image identifier.
        InterfaceBattle.Form1 fight = new InterfaceBattle.Form1();  //Setting up the battle forms
        public string nName;   //user name
        public int mHeadcount;    // How many souls the user is carrying 
        public int mheaddeposit;   // how many souls the user has deposited.
   
            
        public void mImageSelector() //***************************************** Method references _imagemain and assigns image from resources to picturebox1
        {
            switch (mlocationMethods._ImageMain)  
            {
                case 1:
                    pictureBox1.Image = Properties.Resources._01; break;
                case 2:
                    pictureBox1.Image = Properties.Resources._02; break;
                case 3:
                    pictureBox1.Image = Properties.Resources._03; break;
                case 4:
                    pictureBox1.Image = Properties.Resources._04; break;
                case 5:
                    pictureBox1.Image = Properties.Resources._05; break;
                case 6:
                    pictureBox1.Image = Properties.Resources._06; break;
                case 7:
                    pictureBox1.Image = Properties.Resources._07; break;
                case 8:
                    pictureBox1.Image = Properties.Resources._08; break;
                case 9:
                   pictureBox1.Image = Properties.Resources._09; break;
                case 10:
                    pictureBox1.Image = Properties.Resources._10; break;
                case 11:
                    pictureBox1.Image = Properties.Resources._11; break;
                case 12:
                    pictureBox1.Image = Properties.Resources._12; break;
                case 13:
                   pictureBox1.Image = Properties.Resources._13; break;
                case 14:
                    pictureBox1.Image = Properties.Resources._14; break;
                case 15:
                    pictureBox1.Image = Properties.Resources._15; break;
                case 16:
                    pictureBox1.Image = Properties.Resources._16; break;
                case 17:
                    pictureBox1.Image = Properties.Resources._17; break;
                case 18:
                    pictureBox1.Image = Properties.Resources._18; break;
                case 19:
                   pictureBox1.Image = Properties.Resources._19; break;
                case 20:
                   pictureBox1.Image = Properties.Resources._20;break;
                case 21:
                    pictureBox1.Image = Properties.Resources._21; break;
                case 22:
                    pictureBox1.Image = Properties.Resources._22; break;
                case 23:
                    pictureBox1.Image = Properties.Resources._23; break;
                case 24:
                    pictureBox1.Image = Properties.Resources._24; break;
                case 25:
                    pictureBox1.Image = Properties.Resources._25; break;
                case 26:
                    pictureBox1.Image = Properties.Resources._26; break;
                case 27:
                    pictureBox1.Image = Properties.Resources._27; break;
                case 28:
                    pictureBox1.Image = Properties.Resources._28; break;
                    

            }
        }
       
        public Form1()
        {
            InitializeComponent();
        }

            public void Walls(bool fwd,bool bck) //********************* User bumps into walls
            {
            buttFwd.Enabled = bck;
            Buttback.Enabled = fwd;
                if (mlocationMethods._ImageMain == 0)
        
                {
                    buttLeft.Enabled = false;
                    buttRight.Enabled = false;
                }
                else
                {
                    buttFwd.Enabled = true;
                    buttLeft.Enabled = true;
                    buttRight.Enabled = true;
                Buttback.Enabled = true;
                }
            }
        int encounter;

        private void button1_Click(object sender, EventArgs e) //pressing the up button.  Depending on heading will deduct or add to y or x.
        {

            if (encounter > 3)
            {//***************************  Counts movement.  If over 3 moves, a random number between 4 and 9 is generated.

                Random rnd = new Random();  
                encounter = rnd.Next(4, 9);
                label2.Text = Convert.ToString(encounter);

            }
            else
                encounter++;
            label2.Text = Convert.ToString(encounter);

            switch (mlocationMethods.heading) // x y heading   x up and down 0-7, y left to right 0 - 5, heading n=0 n,e,s,w
            {
                case 0:
                    mlocationMethods.x = mlocationMethods.x - 1; break;  //
                case 1:
                    mlocationMethods.y = mlocationMethods.y + 1; break;
                case 2:
                    mlocationMethods.x = mlocationMethods.x + 1; break;
                case 3:
                    mlocationMethods.y = mlocationMethods.y - 1; break;

            }
            if (encounter == 7)  // ******************************************* if random number = 7, battle starts. 
            {
                GC.Collect();   //Garbage collection Memory is cleaned up when battle scene is initiated . Forced garbage collection.
                encounter = 0;
                
                fight.fightingRightNow = true;
                fight.Visible = true;
                FightNow();
                mHeadcount = mHeadcount + 1;
            }

                mlocationMethods.GetImageNumber(mlocationMethods.x, mlocationMethods.y, mlocationMethods.heading);
                mImageSelector();
            
            label1.Text = "x " + mlocationMethods.x + " y " + mlocationMethods.y + " heading " + mlocationMethods.heading;
            Walls(true,false);
        }

        void Form1_Load(object sender, EventArgs e)
        { //setting initial location values.
               fight.Show();
            fight.Visible = false;


         
            mlocationMethods.x = 4; mlocationMethods.y = 1; mlocationMethods.heading = 0; mlocationMethods._ImageMain = 4;
            mImageSelector();
        }
        public void FightNow()
        {
            fight.Visible = true;  //The battle form is now visible.
     
        }
        private void Buttback_Click(object sender, EventArgs e) // back button
        { 
            switch (mlocationMethods.heading) // x y heading   x up and down 0-7, y left to right 0 - 5, heading n=0 n,e,s,w
            {
                case 0:
                    mlocationMethods.x = mlocationMethods.x + 1; break;  //
                case 1:
                    mlocationMethods.y = mlocationMethods.y - 1; break;
                case 2:
                    mlocationMethods.x = mlocationMethods.x - 1 ; break;
                case 3:
                    mlocationMethods.y = mlocationMethods.y + 1; break;
            }
            mlocationMethods.GetImageNumber(mlocationMethods.x, mlocationMethods.y, mlocationMethods.heading);
            mImageSelector();

            label1.Text = "x " + mlocationMethods.x + " y " + mlocationMethods.y + " heading " + mlocationMethods.heading;
            Walls(false,true);
        }
        private void buttRight_Click(object sender, EventArgs e)  // turns right
        {
            mlocationMethods.heading = mlocationMethods.heading + 1;
            if (mlocationMethods.heading == 4)
            {
                mlocationMethods.heading = 0;
            }
            mlocationMethods.GetImageNumber(mlocationMethods.x, mlocationMethods.y, mlocationMethods.heading);
            mImageSelector();


        }

        private void buttLeft_Click(object sender, EventArgs e)  //turns left
        {
            if (mlocationMethods.heading == 0)
            {
                mlocationMethods.heading = 4;
            }
            mlocationMethods.heading = mlocationMethods.heading - 1;
            mlocationMethods.GetImageNumber(mlocationMethods.x, mlocationMethods.y, mlocationMethods.heading);
            mImageSelector();

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        public void timer1_Tick(object sender, EventArgs e)
        {

            if (fight.fightingRightNow == false)
            {
                fight.Visible = false;
            }
            else
                fight.Visible = true;
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "")     // Exception handling.  
            {
                throw new System.ArgumentException("Parameter cannot be null", "original");
            }
            else
            {
                label3.Text = textBox1.Text;
                button1.Visible = false;
                textBox1.Visible = false;
            }
            //SoundPlayer player = new SoundPlayer();
            ////player.SoundLocation = @"C:\Users\Neilius\source\repos\TestingGame\FormGame\Game.wav";
            //player.SoundLocation = @"Game.wav";
            ////player.Play();
            //// getting root path
            //string rootLocation = typeof(Program).Assembly.Location;
            //// appending sound location
            //string fullPathToSound = Path.Combine(rootLocation, @"Game.wav");
            ////player.SoundLocation = fullPathToSound;
            //player.Play();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
  
        private void timer2_Tick(object sender, EventArgs e)  // timer for various
        {
            if (fight.Visible == false)  
            {
                label4.Text = "Soul count:\n\t"+ Convert.ToString( mHeadcount);
            }
            if (mlocationMethods._ImageMain == 20)    //if user is looking at the soul hole.
            {
                pictureBox2.Visible = true;
                pictureBox2.BringToFront();
                label5.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
                label5.Visible = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (mHeadcount >= 1)
            {


                mHeadcount--;
                mheaddeposit++;
                label6.Text = "Deposit Three souls!\nSouls deposited: " + mheaddeposit;
            }
        }
        int endtimer;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (mheaddeposit >= 3)   // To win the game.  If the soul count reaches 3, you win.
            {
                endtimer++;
                if (endtimer >= 10)
                    button2.Visible = true;
                button2.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
    
