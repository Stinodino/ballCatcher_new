using System;
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
        private Random random = new Random();
        public string Naam1 { get; set; }
        public string Naam2 { get; set; }
        public Controls Controls1 { get; set; }
        public Controls Controls2 { get; set; }


        public bool Fullscreen { get; set; }


        // Create pen en ballen.
        private Pen blackPen = new Pen(Color.Black, 3);
        private Pen redPen = new Pen(Color.Red, 3);
        private static List<Bal> ballen = new List<Bal>
            {
            new RekkerBal(10, 10, 5, 0, 20, (float)0.81, (float)0.97, (float)0.81, @"../../files/images/ballen/kleine_rekkerbal.png", 3, @"../../files/sounds/kleine_rekkerbalbots.wav"),
            new RekkerBal(100, 10, 5, 0, 40, (float)0.71, (float)0.96, (float)0.81, @"../../files/images/ballen/middelgrote_rekkerbal.png", 2, @"../../files/sounds/middelgrote_rekkerbalbots.wav"),
            new RekkerBal(200, 10, 5, 0, 40, (float)0.69, (float)0.95, (float)0.81, @"../../files/images/ballen/grote_rekkerbal.png", 1, @"../../files/sounds/grote_rekkerbalbots.wav")};
        private Bom bom;
        private Mand mand1;
        private Mand mand2;
        private string[] explosions;

        private static List<Bom> bomLijst = new List<Bom>();

        public Game(string naam1, string naam2, Controls controls1, Controls controls2)
        {
            Controls1 = controls1;
            Controls2 = controls2;
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
        public Game(Controls controls1, Controls controls2) : this("Speler1", "Speler2", controls1, controls2)
        {

        }


        private void Timer1Tick(object sender, EventArgs e)
        {
            foreach (Bal bal in ballen)
            {
                bal.Beweeg(this);
                bal.CheckMand(mand1, this);
                bal.CheckMand(mand2, this);
            }

            bom.Beweeg(this);
            bom.CheckMand(mand1, this);
            bom.CheckMand(mand2, this);
            mand1.Beweeg(this);
            mand2.Beweeg(this);

            int bomRegen = random.Next(0, 350);
            if (bomRegen == 1 && ballen.OfType<Bom>().Count() == 0)
            {
                for (int i = 0; i < random.Next(1, 50); i++)
                    ballen.Add(new Bom(300, 10, 5, 0, 40, (float)0.40, (float)0.60, (float)0.81, -10, @"../../files/sounds/grote_rekkerbalbots.wav", @"../../files/images/ballen/bom.png", explosions));
                foreach (Bal bom in ballen)
                {
                    if(bom is Bom)
                    {
                        bom.Respawn();
                        bom.ValNu();
                    }
                }

            }
            foreach (Bal bom in ballen)
            {
                if(bom is Bom)
                {
                    bom.Beweeg(this);
                    bom.CheckMand(mand1, this);
                    bom.CheckMand(mand2, this);
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
            Invalidate();
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
            if (keyData == Controls1.Rechts)
                mand1.Rechts(this);
            else if (keyData == Controls1.Links)
                mand1.Links(this);
            else if (keyData == Controls2.Rechts)
                mand2.Rechts(this);
            else if (keyData == Controls2.Links)
                mand2.Links(this);
            else if (keyData == Keys.V)
            {
                for (int i = 0; i < ballen.Count; i++) { ballen[i].ValNu(); }
                bom.ValNu();
            }
            else if (keyData == Controls2.Omhoog)
                mand2.Jump(this);
            else if (keyData == Controls1.Omhoog)
                mand1.Jump(this);
            else if (keyData == Keys.F11)
                GoFullscreen();

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void MijnPaint(object sender, PaintEventArgs e)
        {
            // Get Graphics Object
            Graphics g = e.Graphics;

            for (int i = 0; i < ballen.Count; i++)
                ballen[i].Teken(blackPen, e);

            mand2.Teken(blackPen, e, this);
            mand1.Teken(blackPen, e, this);
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
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                Fullscreen = true;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                Fullscreen = false;
            }
        }
    }
}
