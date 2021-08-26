using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public static void BaddieCall()
        {


        }

        public Form1()
        {
            InitializeComponent();
            Baddie BaddieOne = new Baddie(23, 100, 7);
            Baddie BaddieTwo = BaddieOne.Clone() as Baddie;
            timer1.Start();

            label1.Text = Convert.ToString(BaddieOne.Hp);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    interface Body
    {
        double Hp
        {
            get;
        }
        double Attack { get; }
        double Defense { get; }
    }
    class Baddie : ICloneable, Body
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
        }
        public double Defense
        {
            get
            {
                return this.defense;
            }
        }

        public Baddie(double defense, double hp, double attack)
        {
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
        }

        public object Clone()
        {
            return new Baddie(defense, hp, attack);
        }
    }
}
