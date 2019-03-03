using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication1
{




    public class Bal
    {
        public float balX = 0;
        public float balY = 0;
        protected float vxbal = (float)0;
        protected float vybal = 0;
        protected int groote = 10;
        protected float wrijving;
        protected float wrijvingbodem;
        protected int mijnWaarde;
        protected bool val = false;
        protected Random rnd;
        protected float mijnZwaarteKracht = (float)0.81;
        protected Image newImage;
        protected SoundPlayer botser;






        public Bal(float startX,
            float startY,
            float startVX,
            float startVY,
            int startgroote,
            float balwrijving,
            float balwrijvingbodem,
            float zwaarteKracht,
            string fotoBal,
            int waarde,
            string soundDirecotry)

        {
            balX = startX;
            balY = startY;
            vxbal = startVX;
            vybal = startVY;
            groote = startgroote;
            wrijving = balwrijving;
            wrijvingbodem = balwrijvingbodem;
            mijnWaarde = waarde;
            rnd = new Random();
            mijnZwaarteKracht = zwaarteKracht;
            newImage = Image.FromFile(fotoBal);
            botser = new SoundPlayer(soundDirecotry);
        }


        public void beweeg(Form1 mijnform)
        {
            // wekker loopt af
            // pas de positie van de bal aan

            if (val)
                vybal = vybal + mijnZwaarteKracht;

            balY = balY + vybal;
            balX = balX + vxbal;



            if (balY > mijnform.ClientRectangle.Height - groote)
            {
                balY = mijnform.ClientRectangle.Height - groote;
                vybal = -vybal * wrijving;

                vxbal = vxbal * wrijvingbodem;
                if(Math.Abs(vybal) > 1)
                    botser.Play();
            }
            if (balX > mijnform.ClientRectangle.Width - groote)
            {

                balX = mijnform.ClientRectangle.Width - groote;
                vxbal = -vxbal * wrijving;
                vybal = vybal * wrijving;
            }
            if (balX < 0)
            {
                balX = 0;
                vxbal = -vxbal * wrijving;
                vybal = vybal * wrijving;
            }
        }

        public void valNu()
        {
            val = true;
        }

        public virtual void teken(Pen onzePen, PaintEventArgs e)
        {
            // Rectangle rect = new Rectangle(Convert.ToInt32(balX), Convert.ToInt32(balY), groote, groote);
            // e.Graphics.DrawEllipse(onzePen, rect);
            Point ulCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY));
            Point urCorner = new Point(Convert.ToInt32(balX) + groote, Convert.ToInt32(balY));
            Point llCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY) + groote);
            Point[] hoeken = { ulCorner, urCorner, llCorner };
            e.Graphics.DrawImage(newImage, hoeken);

                float middelpunt1x = balX+(groote/2);
                float middelpunt1y = balY+(groote/2);


        }
        public void checkMand(Mand mijnMand, Form1 mijnForm)
        {
            if (((mijnMand.mijnXMand < balX) && (balX < mijnMand.mijnXMand + 100)) && (((mijnMand.mijnYMand < balY) && (balY < mijnMand.mijnYMand + 100))))
            {
                // bal of bom in in mand
                mijnMand.addPoint(mijnWaarde);
                respawn();
            }
        }
        public void respawn()
        {
            balX = 25;
            balY = 101;
            vxbal = rnd.Next(1, 50);
            vybal = -5;
        }

        

        public void checkbotsing(Bal[] ballen,int eigenNr)
        {
            for(int i = 0; i<ballen.Length;i++)
            {
                float middelpunt1x = balX+(groote/2);
                float middelpunt1y = balY+(groote/2);

                float middelpunt2x = ballen[i].balX+(ballen[i].groote/2);
                float middelpunt2y = ballen[i].balY+(ballen[i].groote/2);


                float afstand = (float)Math.Sqrt((float)Math.Pow(middelpunt1x-middelpunt2x,2) + Math.Pow(middelpunt1y-middelpunt2y,2));

                if(afstand<(groote/2)+(ballen[i].groote/2) && eigenNr != i)
                    {
                    //later nog algoritme schrijvenn
                    }


            }
        }
        
    }
}
