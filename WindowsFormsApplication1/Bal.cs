using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{




    public class Bal
    {
        public float balX = 0;
        public float balY = 0;
        protected float vxbal = 0;
        protected float vybal = 0;
        protected int groote = 10;
        protected float wrijving;
        protected float wrijvingbodem;
        protected int mijnWaarde;
        protected bool val = false;
        protected Random rnd;
        protected float mijnZwaarteKracht = (float)0.81;
        protected Image newImage;
        public SoundPlayer Botser { get; set; }
        public Thread Geluid { get; set; }






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
            Botser = new SoundPlayer(soundDirecotry);
            Botser.Load();
        }


        public static void SpeelGeluid(SoundPlayer s)
        {
            s.Play();
        }

        public void Beweeg(Game mijnform)
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
                if (Math.Abs(vybal) > 1)
                {
                    Geluid = new Thread(() => SpeelGeluid(Botser));
                    Geluid.Start();
                }

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

        public void ValNu()
        {
            val = true;
        }

        public virtual void Teken(Pen onzePen, PaintEventArgs e)
        {
            // Rectangle rect = new Rectangle(Convert.ToInt32(balX), Convert.ToInt32(balY), groote, groote);
            // e.Graphics.DrawEllipse(onzePen, rect);
            Point ulCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY));
            Point urCorner = new Point(Convert.ToInt32(balX) + groote, Convert.ToInt32(balY));
            Point llCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY) + groote);
            Point[] hoeken = { ulCorner, urCorner, llCorner };
            e.Graphics.DrawImage(newImage, hoeken);

            float middelpunt1x = balX + (groote / 2);
            float middelpunt1y = balY + (groote / 2);


        }
        public void CheckMand(Mand mijnMand, Game mijnForm)
        {
            if (((mijnMand.mijnXMand < balX) && (balX < mijnMand.mijnXMand + 100)) && (((mijnMand.mijnYMand < balY) && (balY < mijnMand.mijnYMand + 100))))
            {
                // bal of bom in in mand
                mijnMand.addPoint(mijnWaarde);
                Respawn();
            }
        }
        public void Respawn()
        {
            balX = 750;
            balY = 100;
            vxbal = rnd.Next(-70, 70);
            vybal = -5;
        }



        public void CheckBotsing(Bal[] ballen, int eigenNr)
        {
            for (int i = 0; i < ballen.Length; i++)
            {
                float middelpunt1x = balX + (groote / 2);
                float middelpunt1y = balY + (groote / 2);

                float middelpunt2x = ballen[i].balX + (ballen[i].groote / 2);
                float middelpunt2y = ballen[i].balY + (ballen[i].groote / 2);


                float afstand = (float)Math.Sqrt((float)Math.Pow(middelpunt1x - middelpunt2x, 2) + Math.Pow(middelpunt1y - middelpunt2y, 2));

                if (afstand < (groote / 2) + (ballen[i].groote / 2) && eigenNr != i)
                {
                    //later nog algoritme schrijvenn
                }


            }
        }

    }
}
