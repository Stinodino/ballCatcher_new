using System;
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
    public partial class Form1 : Form
    {
        // Create pen en ballen.
        Pen blackPen = new Pen(Color.Black, 3);
        Pen redPen = new Pen(Color.Red, 3);
        RekkerBal kleineBal = new RekkerBal(10, 10, 5, 0, 20, (float)0.81, (float)0.97, (float)0.81, "textures/ballen/kleine_rekkerbal.gif", 3, "sounds/grote_rekkerbalbots.wav");
        RekkerBal middelGroteBal = new RekkerBal(100, 10, 5, 0, 40, (float)0.71, (float)0.96, (float)0.81, "textures/ballen/middelgrote_rekkerbal.gif", 2, "sounds/grote_rekkerbalbots.wav");
        RekkerBal groteBal = new RekkerBal(200, 10, 5, 0, 40, (float)0.69, (float)0.95, (float)0.81, "textures/ballen/grote_rekkerbal.gif", 1, "sounds/grote_rekkerbalbots.wav");

        Bom bom;
        Mand mand1;
        Mand mand2;


        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(mijn_paint);

            // start the periodic timer (wekker)
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 20;  // milisec
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();

            //geen timer meer
            this.DoubleBuffered = true;
            int mandGrote = 100;
            mand1 = new Mand(300, ClientRectangle.Height - mandGrote, 0, 0, (float)0.81, "Stino", 0, mandGrote, (float)0.4, (float)0.9, 10, 30, 5, "textures/manden/mand1.png");
            mand2 = new Mand(800, ClientRectangle.Height - mandGrote, 0, 0, (float)0.81, "Mixxamm", 0, mandGrote, (float)0.4, (float)0.9, 10, 30, 5, "textures/manden/mand2.png");

            String[] explosions = new string[16];
            for (int i = 0; i < 16; i++)
                explosions[i] = "textures/bom/explosion/" + i + ".gif";
            bom = new Bom(300, 10, 5, 0, 40, (float)0.40, (float)0.60, (float)0.81, -10, "sounds/grote_rekkerbalbots.wav", "textures/bom/bom.png", explosions);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //beweeg alle objecten
            kleineBal.beweeg(this);
            kleineBal.checkMand(mand1, this);
            kleineBal.checkMand(mand2, this);
            middelGroteBal.beweeg(this);
            middelGroteBal.checkMand(mand1, this);
            middelGroteBal.checkMand(mand2, this);
            groteBal.beweeg(this);
            groteBal.checkMand(mand1, this);
            groteBal.checkMand(mand2, this);
            bom.beweeg(this);
            bom.checkMand(mand1, this);
            bom.checkMand(mand2, this);
            mand1.beweeg(this);
            mand2.beweeg(this);

            // herteken het scherm
            Invalidate();
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.D)
                mand1.rechts(this);
            if (keyData == Keys.Q)
                mand1.links(this);
            if (keyData == Keys.Right)
                mand2.rechts(this);
            if (keyData == Keys.Left)
                mand2.links(this);
            if (keyData == Keys.V)
            {
                kleineBal.valNu();
                middelGroteBal.valNu();
                groteBal.valNu();
                bom.valNu();
            }
            if (keyData == Keys.Up)
                mand2.jump(this);
            if (keyData == Keys.Z)
                mand1.jump(this);

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void mijn_paint(object sender, PaintEventArgs e)
        {
            // Get Graphics Object
            Graphics g = e.Graphics;

            kleineBal.teken(redPen, e);
            middelGroteBal.teken(blackPen, e);
            groteBal.teken(blackPen, e);
            mand2.teken(blackPen, e, this);
            mand1.teken(blackPen, e, this);
            bom.teken(blackPen, e);
        }
    }
}
