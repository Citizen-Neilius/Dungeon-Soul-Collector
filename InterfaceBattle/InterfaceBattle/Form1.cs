using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Neil Little SDEV 260
//  16 November 2019
//  16 November 2019
//    Week 12 Homework.



namespace InterfaceBattle
{
    public partial class Form1 : Form

    {
        public int headCount;             // How many baddies were defeated
        public  bool fightingRightNow;    // Fight is happening
        Baddie BaddieOne = new Baddie(23, 40, 7);  //uses interface "body" .Making a bad guy with 23 defense, 100 hit points and 7 attack.
        Potion potion = new Potion();  //Potion that contains two interfaces.
        Hero hero = new Hero(60, 103, 40);  // Using interface "body".  Hero is made with 60 defense 103 Hp, and 40 attack
        int counter2;  // counter for Hero attack
        double ClonedBaddieHp;  // BaddieOne was cloned into BaddieTwo, and This double is the HP of BaddieTwo.
        void AttackHero()  // changes the baddie picture to attack pose (ttype 2) Open for counter attack.
        {
            pictureBox1.Image = Properties.Resources.BaddieA02;
            counter = 0;
            TType = 2;
        }

        void BaddieAni()  // if not countered by hero, the damage is done!  and then reset 
        {
            if (TType != 3) TType = 1;


            pictureBox1.Image = Properties.Resources.BaddieA01;
                hero.Hp = (hero.Hp - (hero.Defense - BaddieOne.Attack) / 4);
                HeroLabel();
                label3.Text = "OUCH!";
                label3.Visible = true;
                label2.Text = "Baddie Attacks!";
                label2.Visible = true;
            


        }
        void BaddieLabel()  //updating the current baddie information
        {
            if (BaddieOne.Hp <= 0)  //if the bad guy dies... You WIN!  
            {
                counter = 0;
                counter2 = 0;
    
                pictureBox1.Image = Properties.Resources.BaddieA03;
                label2.Visible = false;
                label1.Text = "YOU WIN!!";
                label4.Text = "You WIN!!";
                headCount = headCount +1;
                label3.Text ="Souls Collected: " + Convert.ToString(headCount);
                TType = 3;
            }
            else
                label1.Text = "Baddie\nBaddie HP:    " + BaddieOne.Hp + "\n";
        }
        void HeroLabel()   // UPdates hero's label
        {
            if (hero.Hp <= 0)
            {
                ButtonExit.Visible = true;
                ButtonExit.BringToFront();
                timer1.Enabled = false;
                label7.Text = "\n\nGAME OVER! \nPress OK to exit";
                label7.Visible = true;
            }
            else
                label4.Text = "Hero\nHP:    " + hero.Hp + "\n";
        }
        void MCounter() // if the hero attacks during the baddie's attack pose, a counter attack happens.
        {

            pictureBox1.Image = Properties.Resources.BaddieA01;
         

            label3.Text = "Arrrg!!";
            label3.Visible = true;
            label2.Text = "Hero Counters! Double Damage!";
            label2.Visible = true;
            BaddieOne.Hp = (BaddieOne.Hp - 20); //((BaddieOne.Defense - hero.Attack) / 2));
            BaddieLabel();
            counter = 1;
            counter2 = 0;

            if (TType != 3) TType = 1;

        }
        void MAttack()  // Normal hero attack.
        {
            if (TType == 3)
            {

            }
            else if (TType == 1)
            {
                TType = 1;
                pictureBox1.Image = Properties.Resources.BaddieA01;
           
                label3.Text = "Arrrg!!";
                label3.Visible = true;
                label2.Text = "Hero Attack!!";
                label2.Visible = true;
                BaddieLabel();
                BaddieOne.Hp = (BaddieOne.Hp - 10);// ((BaddieOne.Defense - hero.Attack) / 4));
                counter2 = 0;
            }
        }
        void NewBaddie()
        {

        }
        public Form1()
        {
            InitializeComponent();
            Baddie BaddieTwo = BaddieOne.Clone() as Baddie;  // CLONED Baddie ONE!
            ClonedBaddieHp = BaddieTwo.Hp;
            HeroLabel();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaddieLabel();
            HeroLabel();
            label3.Visible = false;
            label2.Visible = false;
            ButtonAttack.Enabled = true;
            TType = 1;
            label8.Text = "Your Potion: \n" +
            "Ingredients:\n" + potion.Base + "\n" + potion.GoodStuff;
        }
        int counter;
        int TType;
        int labeltimer;
        private void timer1_Tick(object sender, EventArgs e)  //timer one for Baddie attack sequence.
        {

            if (fightingRightNow == true)
            {
                counter = counter + 1;
                label5.Text = Convert.ToString(counter);
                if (TType == 1)
                {
                    
                    pictureBox1.Image = Properties.Resources.BaddieA01;
                    if (counter == 40)
                    {
                        AttackHero();
                    }
                    if (counter == 20)

                    {
                        label3.Visible = false;
                        label2.Visible = false;
                    }
                }
                else if (TType == 2)
                {
                    if (counter == 5)
                    {
                        BaddieAni();
                    }
                }
                else if (TType == 3)
                {
                    if (counter >= 30)
                    {
                        fightingRightNow = false;
                        BaddieOne.Hp = 40;
                        //pictureBox1.Image = Properties.Resources.BaddieA01;
                        TType = 1;
                        //pictureBox1.Visible = true;
                        //label2.Text = "A new Baddie Appears! \nHis class was cloned\nusing IClone! \nPress OK to exit";
                        //ButtonExit.Visible = true;
                        //label1.Text = "Baddie\nBaddie HP:    " + ClonedBaddieHp + "\n";

                    }
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)  //Hero attack button
        {
            if (TType == 2)
                MCounter();
            else if (TType == 1)
                MAttack();
        }

        private void timer2_Tick(object sender, EventArgs e)  // timer two for hero attacks.
        {
            if (fightingRightNow == true)
            {
                counter2++;
                label6.Text = Convert.ToString(counter2) + ButtonAttack.Enabled + "    " + TType;
                if (counter2 >= 30)
                { ButtonAttack.Enabled = true; ButtonAttack.Visible = true; }
                else
                { ButtonAttack.Enabled = false; ButtonAttack.Visible = false; }
            }
            if (pictureBox1.Image == Properties.Resources.BaddieA03)
            {
                labeltimer = labeltimer + 1;
                if (labeltimer >= 40)
                {
                    pictureBox1.Image = Properties.Resources.BaddieA01;
                    
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        // Instance field

        public void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    interface PotionIngredients1 // potion interface 1
    {
        string Base { get;}
    }
    interface PotionIngredients2 // Potion inteface 2
    { 
        string GoodStuff { get;}
    }
    class Potion : PotionIngredients1, PotionIngredients2 //Class potion includes two "ingredient" interfaces.
    {
        string _base = "Sadness Oil";
        public string Base
        {

            get
            {
                return this._base;
            }
        }
        string _goodStuff = "Four Loko";
        public string GoodStuff
        {
            get
            {
                return this._goodStuff;
            }
        }
    }
        interface Body   // This interface "body" can be inherited by anything with a body, like hero or bad guy.
    {
        double Hp
        {
            get; set;
        }
        double Attack { get; }
        double Defense { get; }
    }
    class Baddie : ICloneable, Body  // Icloneable interface enables this class to be cloned.  
                                        // Class for the Baddie
    {
        double hp = 500;
        double attack = 23;
        double defense = 7;
        public double Attack
        {
            get
            {
                return this.attack;
            }
        }
        public double Hp
        {
            get
            {
                return this.hp;
            }
            set { hp = value; }
        }
        public double Defense
        {
            get
            {
                return this.defense;
            }
        }
        public void AttackHero()
        {

        }

        public Baddie(double defense, double hp, double attack)
        {
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
        }

        public object Clone()  // More clone set up
        {
            return new Baddie(defense, hp, attack);
        }
    }
    class Hero : Body // Hero uses body interface.
    {
        double hp = 500;
        double attack = 23;
        double defense = 7;
        string Name;
        public double Attack 
        {
            get
            {
                return this.attack;
            }
        }
        public double Hp
        {
            get
            {
                return this.hp;
            }
            set { hp = value; }
        }
        public double Defense
        {
            get
            {
                return this.defense;
            }
        }


        public Hero(double defense, double hp, double attack)
        {
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
        }

    }

}
    
