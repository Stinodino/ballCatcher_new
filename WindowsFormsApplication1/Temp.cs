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






    public class Bal
    {
        float balX = 0;
        float balY = 0;
        float vxbal = (float)0;
        float vybal = 0;
        int groote = 10;
        float wrijving;
        bool val = false;
        
        public Bal(float startX,float startY,float startVX,float startVY,int startgroote,float balwrijving)
        {
            balX = startX;
            balY = startY;
            vxbal = startVX;
            vybal = startVY;
            groote = startgroote;
            wrijving = balwrijving;

        }

        public void beweeg(Form1 mijnform)
        {
            // wekker loopt af
            // pas de positie van de bal aan

            if (val)
                vybal = vybal + (float)0.1;
            
            balY = balY + vybal;
            balX = balX + vxbal;

            if (balY > mijnform.ClientRectangle.Height - groote)
            {
                balY = mijnform.ClientRectangle.Height - groote;
                vybal = -vybal * (float)wrijving;

                vxbal = vxbal * (float)wrijving;
            }
            if (balX > mijnform.ClientRectangle.Width - groote)
            {

                balX = mijnform.ClientRectangle.Width - groote;
                vxbal = -vxbal * (float)wrijving;
                vybal = vybal * (float)wrijving;
            }
            if (balX < 0)
            {
                balX = 0;
                vxbal = -vxbal * (float)wrijving;
                vybal = vybal * (float)wrijving;
            }
        }

        public void valNu()
        {
            val = true;

        }


        public void teken(Pen onzePen, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(Convert.ToInt32(balX), Convert.ToInt32(balY), groote, groote);
            e.Graphics.DrawEllipse(onzePen, rect);
        }
    }









    public partial class Form1 : Form
    {
        // Create pen.

        Pen blackPen = new Pen(Color.Black, 3);
        Pen redPen = new Pen(Color.Red, 3);
        float stijnX = 100;
        float stijnY = 600;
        Bal rodeBal = new Bal(40, 10, 5, 0, 7,(float)0.81);
        Bal zwarteBal = new Bal(10,10,5,0,7,(float)0.71);




        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(mijn_paint);

            // start the periodic timer (wekker)
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1;  // milisec
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
            this.DoubleBuffered = true;

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //beweeg alle objecten
            rodeBal.beweeg(this);
            zwarteBal.beweeg(this);

            // herteken het scherm
            Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
            {
                //MessageBox.Show("You pressed Right arrow key");
                stijnX = stijnX + 3;
                return true;
            }
            if (keyData == Keys.Left)
            {
                stijnX = stijnX - 3;
                return true;
            }
            if (keyData == Keys.Up)
            {
                stijnY = stijnY - 3;
                return true;
            }
            if (keyData == Keys.Down)
            {
                stijnY = stijnY + 3;
                return true;
            }
            if (keyData == Keys.V)
            {
                rodeBal.valNu();
                zwarteBal.valNu();
            }




            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void mijn_paint(object sender, PaintEventArgs e)
        {
            // Get Graphics Object
            Graphics g = e.Graphics;

            // Method under System.Drawing.Graphics
            //g.DrawString("Welcome C#", new Font("Verdana", 20), new SolidBrush(Color.Tomato), 40, 40);

            // zet stijn
            Image newImage = Image.FromFile("stijn.jpg");
            // Create parallelogram for drawing image.
            Point ulCorner = new Point(Convert.ToInt32(stijnX), Convert.ToInt32(stijnY));
            Point urCorner = new Point(Convert.ToInt32(stijnX) + 100, Convert.ToInt32(stijnY));
            Point llCorner = new Point(Convert.ToInt32(stijnX), Convert.ToInt32(stijnY) + 100);
            Point[] hoeken = { ulCorner, urCorner, llCorner };
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, hoeken);

            //teken alle objecten
            rodeBal.teken(redPen, e);
            zwarteBal.teken(blackPen, e);


        }

    }
}
