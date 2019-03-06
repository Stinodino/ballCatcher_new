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
        public int groote = 10;
        protected float wrijving;
        protected float wrijvingbodem;
        protected int mijnWaarde;
        protected bool val = false;
        protected Random rnd;
        protected float mijnZwaarteKracht = (float)0.3;
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
            vxbal = rnd.Next(-3, 3);
            vybal = -1;
        }



        public void CheckBotsing(Bal bal)
        {

            float middelpunt1x = balX + (groote / 2);
            float middelpunt1y = balY + (groote / 2);

            float middelpunt2x = bal.balX + (bal.groote / 2);
            float middelpunt2y = bal.balY + (bal.groote / 2);


            float afstand = (float)Math.Sqrt((float)Math.Pow(middelpunt1x - middelpunt2x, 2) + Math.Pow(middelpunt1y - middelpunt2y, 2));


            //ricoTan berekenen
            float ricoTan;
            if (middelpunt1y - middelpunt2y == 0)
                ricoTan = 1000000000;
            else
                ricoTan = (middelpunt1x - middelpunt2x) / (middelpunt1y - middelpunt2y);

            //ricoNorm berekenen
            float ricoNorm = -1 / ricoTan;

            float hoek = (float)Math.Atan(ricoNorm);

            //ballen uit elkaar zetten
            float middelpuntBallenX = (middelpunt1x + middelpunt2x) / 2;//niet 100% correct
            float middelpuntBallenY = (middelpunt1y + middelpunt2y) / 2;//niet 100% correct


            if (middelpunt1x >= middelpunt2x && middelpunt1y >= middelpunt2y)
            {
                //bal1 rechts onder
                middelpunt1x = middelpuntBallenX + Math.Abs((groote / 2 + 1) * (float)Math.Cos(hoek));
                middelpunt1y = middelpuntBallenY + Math.Abs((groote / 2 + 1) * (float)Math.Sin(hoek));
                middelpunt2x = middelpuntBallenX - Math.Abs((bal.groote / 2 + 1) * (float)Math.Cos(Math.PI - hoek));
                middelpunt2y = middelpuntBallenY - Math.Abs((bal.groote / 2 + 1) * (float)Math.Sin(Math.PI - hoek));
            }
            else if (middelpunt1x <= middelpunt2x && middelpunt1y >= middelpunt2y)
            {
                //bal1 links onder
                middelpunt1x = middelpuntBallenX - Math.Abs((groote / 2 + 1) * (float)Math.Cos(hoek));
                middelpunt1y = middelpuntBallenY + Math.Abs((groote / 2 + 1) * (float)Math.Sin(hoek));
                middelpunt2x = middelpuntBallenX + Math.Abs((bal.groote / 2 + 1) * (float)Math.Cos(Math.PI - hoek));
                middelpunt2y = middelpuntBallenY - Math.Abs((bal.groote / 2 + 1) * (float)Math.Sin(Math.PI - hoek));
            }
            else if (middelpunt1x <= middelpunt2x && middelpunt1y <= middelpunt2y)
            {
                //bal1 links boven
                middelpunt1x = middelpuntBallenX - Math.Abs((groote / 2 + 1) * (float)Math.Cos(hoek));
                middelpunt1y = middelpuntBallenY - Math.Abs((groote / 2 + 1) * (float)Math.Sin(hoek));
                middelpunt2x = middelpuntBallenX + Math.Abs((bal.groote / 2 + 1) * (float)Math.Cos(Math.PI - hoek));
                middelpunt2y = middelpuntBallenY + Math.Abs((bal.groote / 2 + 1) * (float)Math.Sin(Math.PI - hoek));
            }
            else
            {
                //bal1 rechts boven
                middelpunt1x = middelpuntBallenX + Math.Abs((groote / 2 + 1) * (float)Math.Cos(hoek));
                middelpunt1y = middelpuntBallenY - Math.Abs((groote / 2 + 1) * (float)Math.Sin(hoek));
                middelpunt2x = middelpuntBallenX - Math.Abs((bal.groote / 2 + 1) * (float)Math.Cos(Math.PI - hoek));
                middelpunt2y = middelpuntBallenY + Math.Abs((bal.groote / 2 + 1) * (float)Math.Sin(Math.PI - hoek));
            }


            balX = middelpunt1x - (groote / 2);
            balY = middelpunt1y - (groote / 2);
            bal.balX = middelpunt2x - (bal.groote / 2);
            bal.balY = middelpunt2y - (bal.groote / 2);

            //snelheden omvormen naar ander assenstelsel

            float vNorm1 = vxbal * (float)Math.Cos(hoek) - vybal * (float)Math.Sin(hoek);
            float vtan1 = vybal * (float)Math.Cos(hoek) + vxbal * (float)Math.Sin(hoek);
            float vNorm2 = bal.vxbal * (float)Math.Cos(hoek) - bal.vybal * (float)Math.Sin(hoek);
            float vtan2 = bal.vybal * (float)Math.Cos(hoek) + bal.vxbal * (float)Math.Sin(hoek);

            //e berekenen
            float wrijvingtot = (wrijving + bal.wrijving) / 2;

            //snelheden na de botsing berekenen
            float vNorm1Na = (groote * vNorm1 + bal.groote * vNorm2 - bal.groote * wrijvingtot * (vNorm1 - vNorm2)) / (groote + bal.groote);
            float vNorm2Na = wrijvingtot * (vNorm1 - vNorm2) + vNorm1Na;


            //omvormen van assenstelsel
            vxbal = vNorm1Na * (float)Math.Cos(-hoek) - vtan1 * (float)Math.Sin(-hoek);
            vybal = vtan1 * (float)Math.Cos(-hoek) + vNorm1Na * (float)Math.Sin(-hoek);
            bal.vxbal = vNorm2Na * (float)Math.Cos(-hoek) - vtan2 * (float)Math.Sin(-hoek);
            bal.vybal = vtan2 * (float)Math.Cos(-hoek) + vNorm2Na * (float)Math.Sin(-hoek);


        }
    }
}
