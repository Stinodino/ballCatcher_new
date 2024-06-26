﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BallCatcher
{
    public partial class Game : Form
    {
        private const int FPS = 240; // Ik heb dit hoog gezet want dat maakt het precies sowieso beter ondanks dat ik maar een 60fps scherm heb. (wanneer ik dit op 60 zet dan is het merkbaar lagere framerate)
        private Random random = new Random();
        public string Naam1 { get; set; }
        public string Naam2 { get; set; }
        public bool Fullscreen { get; set; }

        // Create pen en ballen.
        private Pen blackPen = new Pen(Color.Black, 3);
        private Pen redPen = new Pen(Color.Red, 3);
        private static List<Bal> ballen = new List<Bal>
            {
            new RekkerBal(1000, 110, 2, 0, 20, (float)0.81, (float)0.97, @"../../files/images/ballen/kleine_rekkerbal.png", 3, @"../../files/sounds/kleine_rekkerbalbots.wav"),
            new RekkerBal(100, 100, 1, 0, 40, (float)0.71, (float)0.96, @"../../files/images/ballen/middelgrote_rekkerbal.png", 2, @"../../files/sounds/middelgrote_rekkerbalbots.wav"),
            new RekkerBal(400, 130, -1, 0, 40, (float)0.69, (float)0.95, @"../../files/images/ballen/grote_rekkerbal.png", 1, @"../../files/sounds/grote_rekkerbalbots.wav")};
        private Bom bom;
        private List<Mand> manden = new List<Mand>();
        private string[] explosions;

        private static List<Bom> bomLijst = new List<Bom>();

        public Game(string naam1, string naam2, Controls controls1, Controls controls2)
        {
            Naam1 = naam1;
            Naam2 = naam2;
            InitializeComponent();
            Paint += new PaintEventHandler(MijnPaint);

            // start beweging timer
            System.Windows.Forms.Timer bewegingTimer = new System.Windows.Forms.Timer
            {
                Interval = 1  // milisec
            };
            bewegingTimer.Tick += new System.EventHandler(BewegingTimerTick);
            bewegingTimer.Start();

            //start fps timer
            System.Windows.Forms.Timer refreshScreenTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000/FPS  // milisec
            };
            refreshScreenTimer.Tick += new System.EventHandler(refreshScreenTimerTick);
            refreshScreenTimer.Start();


            DoubleBuffered = true;
            int mandGrote = 100;
            var mand1 = new Mand(300, ClientRectangle.Height - mandGrote, 0, 0, Naam1, 0, mandGrote, (float)0.4, (float)0.9, 10, 30, 5, @"../../files/images/manden/mand1.png");
            var mand2 = new Mand(800, ClientRectangle.Height - mandGrote, 0, 0, Naam2, 0, mandGrote, (float)0.4, (float)0.9, 10, 30, 5, @"../../files/images/manden/mand2.png");

            if(naam1.Length > 0)
            {
                mand1.Controls = controls1;
                manden.Add(mand1);
            }
            if(naam2.Length > 0)
            {
                mand2.Controls = controls2;
                manden.Add(mand2);
            }

            explosions = new string[16];
            for (int i = 0; i < 16; i++)
                explosions[i] = @"../../files/images/ballen/explosion/" + Convert.ToString(i + 1) + ".gif";
            bom = new Bom(300, 10, 5, 0, 40, (float)0.40, (float)0.60, -10, @"../../files/sounds/grote_rekkerbalbots.wav", @"../../files/images/ballen/bom.png", explosions);
        }
        public Game(Controls controls1, Controls controls2) : this("Speler1", "Speler2", controls1, controls2)
        {

        }


        private void refreshScreenTimerTick(object sender, EventArgs e)
        {
            Invalidate();
        }



            private void BewegingTimerTick(object sender, EventArgs e)
        {
            foreach (Bal bal in ballen)
            {
                bal.Beweeg(this);
                foreach(Mand mand in manden)
                {
                    bal.CheckMand(mand, this);
                }
            }

            bom.Beweeg(this);
            foreach(Mand mand in manden)
            {
                bom.CheckMand(mand, this);
                mand.Beweeg(this);
            }
            
            int bomRegen = random.Next(0, 1000);
            if (bomRegen == 1 && ballen.OfType<Bom>().Count() == 0)
            {
                for (int i = 0; i < random.Next(1, 50); i++)
                    ballen.Add(new Bom(300, 10, 5, 0, 40, (float)0.40, (float)0.60, -10, @"../../files/sounds/grote_rekkerbalbots.wav", @"../../files/images/ballen/bom.png", explosions));
                foreach (Bal bom in ballen)
                {
                    if(bom is Bom)
                    {
                        bom.Respawn();
                        bom.ValNu();
                    }
                }
            }

            foreach (Bal bal1 in ballen)
            {
                foreach (Bal bal2 in ballen)
                {
                    float middelpunt1x = bal1.balX + (bal1.groote / 2);
                    float middelpunt1y = bal1.balY + (bal1.groote / 2);

                    float middelpunt2x = bal2.balX + (bal2.groote / 2);
                    float middelpunt2y = bal2.balY + (bal2.groote / 2);


                    float afstand = (float)Math.Sqrt((float)Math.Pow(middelpunt1x - middelpunt2x, 2) + Math.Pow(middelpunt1y - middelpunt2y, 2));

                    if (afstand < (bal1.groote / 2) + (bal2.groote / 2) && bal1 != bal2)
                    {
                        bal1.CheckBotsing(bal2);
                    }
                }
            }
            // herteken het scherm
            //Invalidate();
        }

        public static bool IsBomInLijst(Bom bom)
        {
            return bomLijst.Contains(bom);
        }

        public static bool IsInBalLijst(Bom bom)
        {
            return ballen.Contains(bom);
        }

        public static void VerwijderBom(Bom bom)
        {
            ballen.Remove(bom);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.V)
            {
                for (int i = 0; i < ballen.Count; i++) { ballen[i].ValNu(); }
                bom.ValNu();
            }
            else if (keyData == Keys.F11)
                GoFullscreen();
            else
            {
                foreach(var mand in manden)
                {
                    var controls = mand.Controls;

                    if(keyData == controls.Rechts)
                    {
                        mand.Rechts(this);
                    }
                    else if(keyData == controls.Links)
                    {
                        mand.Links(this);
                    }
                    else if(keyData == controls.Omhoog)
                    {
                        mand.Jump(this);
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MijnPaint(object sender, PaintEventArgs e)
        {
            // Get Graphics Object
            Graphics g = e.Graphics;

            for (int i = 0; i < ballen.Count; i++)
                ballen[i].Teken(blackPen, e);

            foreach(var mand in manden)
            {
                mand.Teken(blackPen, e, this);
            }
            bom.Teken(blackPen, e);
            foreach (Bom bom in bomLijst.ToList())
                bom.Teken(blackPen, e);
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GoFullscreen()
        {
            if (!Fullscreen)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                Fullscreen = true;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.Sizable;
                Fullscreen = false;
            }
        }
    }
}