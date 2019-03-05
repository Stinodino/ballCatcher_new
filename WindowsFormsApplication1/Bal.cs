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
using System.Windows.Media;

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
        public MediaPlayer Botser { get; set; }
        public Uri SoundDirectory { get; set; }






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
            Botser = new MediaPlayer();
            SoundDirectory = new Uri(soundDirecotry, UriKind.Relative);
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
                    Botser.Open(SoundDirectory);
                    Botser.Play();
                    //Geluid.Start();
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

        public virtual void Teken(System.Drawing.Pen onzePen, PaintEventArgs e)
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
        public virtual void CheckMand(Mand mijnMand, Game mijnForm)
        {
            if (((mijnMand.mijnXMand < balX) && (balX < mijnMand.mijnXMand + 100)) && (((mijnMand.mijnYMand < balY) && (balY < mijnMand.mijnYMand + 100))))
            {
                // bal of bom in in mand
                mijnMand.addPoint(mijnWaarde);
                Respawn();
            }
        }
        public virtual void Respawn()
        {
            balX = rnd.Next(100, 1400);
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
                    //ricoTan berekenen
                    float ricoTan;
                    if (middelpunt1y - middelpunt2y == 0)
                        ricoTan = 1000000000;
                    else
                        ricoTan = (middelpunt1x - middelpunt2x) / (middelpunt1y - middelpunt2y);

                    //ricoNorm berekenen
                    float ricoNorm = -1 / ricoTan;

                    //ballen uit elkaar zetten
                    float middelpuntBallenX = (balX + ballen[i].balX) / 2;
                    float middelpuntBallenY = (balY + ballen[i].balY) / 2;

                    if (middelpunt1x >= middelpunt2x && middelpunt1y >= middelpunt2y)
                    {
                        //bal1 rechts onder
                        middelpunt1x = middelpuntBallenX + (afstand / 2);
                        middelpunt1y = middelpuntBallenY + (afstand / 2);
                        middelpunt1x = middelpuntBallenX - (afstand / 2);
                        middelpunt1y = middelpuntBallenY - (afstand / 2);
                    }
                    else if (middelpunt1x <= middelpunt2x && middelpunt1y >= middelpunt2y)
                    {
                        //bal1 links onder
                        middelpunt1x = middelpuntBallenX - (afstand / 2);
                        middelpunt1y = middelpuntBallenY + (afstand / 2);
                        middelpunt1x = middelpuntBallenX + (afstand / 2);
                        middelpunt1y = middelpuntBallenY - (afstand / 2);
                    }
                    else if (middelpunt1x <= middelpunt2x && middelpunt1y <= middelpunt2y)
                    {
                        //bal1 links boven
                        middelpunt1x = middelpuntBallenX - (afstand / 2);
                        middelpunt1y = middelpuntBallenY - (afstand / 2);
                        middelpunt1x = middelpuntBallenX + (afstand / 2);
                        middelpunt1y = middelpuntBallenY + (afstand / 2);
                    }
                    else
                    {
                        //bal1 links onder
                        middelpunt1x = middelpuntBallenX - (afstand / 2);
                        middelpunt1y = middelpuntBallenY + (afstand / 2);
                        middelpunt1x = middelpuntBallenX + (afstand / 2);
                        middelpunt1y = middelpuntBallenY - (afstand / 2);
                    }

                    //balX = mi



                    //snelheden omvormen naar ander assenstelsel
                    float hoek = (float)Math.Atan(ricoNorm);

                    float vNorm1 = vxbal * (float)Math.Cos(hoek) + vybal * (float)Math.Sin(hoek);
                    float vtan1 = vybal * (float)Math.Cos(hoek) + vxbal * (float)Math.Sin(hoek);

                    float vNorm2 = ballen[i].vxbal * (float)Math.Cos(hoek) + ballen[i].vybal * (float)Math.Sin(hoek);
                    float vtan2 = ballen[i].vybal * (float)Math.Cos(hoek) + ballen[i].vxbal * (float)Math.Sin(hoek);

                    /*
                    //snelheden omvormen naar ander assenstelsel
                    float vtot1 = (float)Math.Sqrt(Math.Pow(vxbal, 2) + Math.Pow(vybal, 2));
                    float vNorm1 = vtot1 * (float)Math.Cos(hoek);
                    float vtan1 = vtot1 * (float)Math.Sin(hoek);

                    //vNorm2 en vTan2 berekenen
                    float vtot2 = (float)Math.Sqrt(Math.Pow(ballen[i].vxbal, 2) + Math.Pow(ballen[i].vybal, 2));
                    float vNorm2 = vtot2 * (float)Math.Cos(hoek);
                    float vtan2 = vtot2 * (float)Math.Sin(hoek);
                    */

                    //e berekenen
                    float wrijvingtot = (wrijving + ballen[i].wrijving) / 2;

                    //snelheden na de botsing berekenen
                    float vNorm1Na = (groote * vNorm1 + ballen[i].groote * vNorm2 - ballen[i].groote * wrijvingtot * (vNorm1 - vNorm2)) / (groote + ballen[i].groote);
                    float vNorm2Na = wrijvingtot * (vNorm1 - vNorm2) + vNorm1Na;

                    //omvormen van assenstelsel
                    vxbal = vNorm1Na * (float)Math.Cos(hoek) + vtan1 * (float)Math.Cos(hoek);
                    vybal = vtan1 * (float)Math.Cos(hoek) + vtan1 * (float)Math.Cos(hoek);
                    ballen[i].vxbal = vNorm2Na * (float)Math.Cos(hoek) + vtan2 * (float)Math.Cos(hoek);
                    ballen[i].vybal = vtan2 * (float)Math.Cos(hoek) + vtan2 * (float)Math.Cos(hoek);


                }
            }
        }
    }
}
