﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Game : Form
    {
        Random random = new Random();
        public string Naam1 { get; set; }
        public string Naam2 { get; set; }

        public Keys[] Controls1 { get; set; }
        public Keys[] Controls2 { get; set; }

        // Create pen en ballen.
        private Pen blackPen = new Pen(Color.Black, 3);
        private Pen redPen = new Pen(Color.Red, 3);
        private Bal[] ballen = {
            new RekkerBal(10, 10, 5, 0, 20, (float)0.81, (float)0.97, (float)0.81, @"../../files/images/ballen/kleine_rekkerbal.png", 3, @"../../files/sounds/kleine_rekkerbalbots.wav"),
            new RekkerBal(100, 10, 5, 0, 40, (float)0.71, (float)0.96, (float)0.81, @"../../files/images/ballen/middelgrote_rekkerbal.png", 2, @"../../files/sounds/middelgrote_rekkerbalbots.wav"),
            new RekkerBal(200, 10, 5, 0, 40, (float)0.69, (float)0.95, (float)0.81, @"../../files/images/ballen/grote_rekkerbal.png", 1, @"../../files/sounds/grote_rekkerbalbots.wav")};
        private Bom bom;
        private Mand mand1;
        private Mand mand2;
        string[] explosions;

        private static List<Bom> bomLijst = new List<Bom>();

        public Game(string naam1, string naam2)
        {
            Naam1 = naam1;
            Naam2 = naam2;
            InitializeComponent();
            Paint += new PaintEventHandler(MijnPaint);

            // start the periodic timer (wekker)
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer
            {
                Interval = 20  // milisec
            };
            timer1.Tick += new System.EventHandler(Timer1Tick);
            timer1.Start();

            //geen timer meer
            DoubleBuffered = true;
            int mandGrote = 100;
            mand1 = new Mand(300, ClientRectangle.Height - mandGrote, 0, 0, (float)0.81, Naam1, 0, mandGrote, (float)0.4, (float)0.9, 10, 30, 5, @"../../files/images/manden/mand1.png");
            mand2 = new Mand(800, ClientRectangle.Height - mandGrote, 0, 0, (float)0.81, Naam2, 0, mandGrote, (float)0.4, (float)0.9, 10, 30, 5, @"../../files/images/manden/mand2.png");

            explosions = new string[16];
            for (int i = 0; i < 16; i++)
                explosions[i] = @"../../files/images/ballen/explosion/" + Convert.ToString(i + 1) + ".gif";
            bom = new Bom(300, 10, 5, 0, 40, (float)0.40, (float)0.60, (float)0.81, -10, @"../../files/sounds/grote_rekkerbalbots.wav", @"../../files/images/ballen/bom.png", explosions);
        }
        public Game() : this("Speler1", "Speler2")
        {

        }


        private void Timer1Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ballen.Length; i++)
            {
                ballen[i].Beweeg(this);
                ballen[i].CheckMand(mand1, this);
                ballen[i].CheckMand(mand2, this);
            }

            bom.Beweeg(this);
            bom.CheckMand(mand1, this);
            bom.CheckMand(mand2, this);
            mand1.beweeg(this);
            mand2.beweeg(this);

            int bomRegen = random.Next(0, 350);
            if (bomRegen == 1 && bomLijst.Count() == 0)
            {
                for (int i = 0; i < random.Next(1, 50); i++)
                    bomLijst.Add(new Bom(300, 10, 5, 0, 40, (float)0.40, (float)0.60, (float)0.81, -10, @"../../files/sounds/grote_rekkerbalbots.wav", @"../../files/images/ballen/bom.png", explosions));
                foreach (Bom bom in bomLijst)
                {
                    bom.Respawn();
                    bom.ValNu();
                }
                    
            }
            foreach (Bom bom in bomLijst)
            {
                bom.Beweeg(this);
                bom.CheckMand(mand1, this);
                bom.CheckMand(mand2, this);
            }
            //kleineBal.checkbotsing();

            for (int i = 0; i < ballen.Length; i++)
            {
                ballen[i].CheckBotsing(ballen, i);
            }


            // herteken het scherm
            Invalidate();
        }

        public static bool IsBomInLijst(Bom bom)
        {
            return bomLijst.Contains(bom);
        }

        public static void VerwijderBom(Bom bom)
        {
            bomLijst.Remove(bom);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.D)
                mand1.rechts(this);
            else if (keyData == Keys.Q)
                mand1.links(this);
            else if (keyData == Keys.Right)
                mand2.rechts(this);
            else if (keyData == Keys.Left)
                mand2.links(this);
            else if (keyData == Keys.V)
            {
                for (int i = 0; i < ballen.Length; i++) { ballen[i].ValNu(); }
                bom.ValNu();
            }
            else if (keyData == Keys.Up)
                mand2.jump(this);
            else if (keyData == Keys.Z)
                mand1.jump(this);

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void MijnPaint(object sender, PaintEventArgs e)
        {
            // Get Graphics Object
            Graphics g = e.Graphics;

            for (int i = 0; i < ballen.Length; i++)
                ballen[i].Teken(blackPen, e);

            mand2.teken(blackPen, e, this);
            mand1.teken(blackPen, e, this);
            bom.Teken(blackPen, e);
            foreach(Bom bom in bomLijst.ToList())
                bom.Teken(blackPen, e);
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}