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
    public class Bom: Bal
    {
        int aftellerExplotie = 250;
        /*
        Image explosion1;
        Image explosion2;
        Image explosion3;
        Image explosion4;
        Image explosion5;
        Image explosion6;
        Image explosion7;
        Image explosion8;
        Image explosion9;
        Image explosion10;
        Image explosion11;
        Image explosion12;
        Image explosion13;
        Image explosion14;
        Image explosion15;
        Image explosion16;
        Image explosion17;
        */
        Image[] explosions;

        public Bom(float startX,
          float startY,
          float startVX,
          float startVY,
          int startgroote,
          float balwrijving,
          float balwrijvingbodem,
          float zwaarteKracht,
          int waarde,
          string soundDirecotry,
          string fotoBal,
          string[] fotoExplosies

          ) : base(startX, startY, startVX, startVY, startgroote, balwrijving, balwrijvingbodem, zwaarteKracht, fotoBal, waarde, soundDirecotry)
        {
            explosions = new Image[fotoExplosies.Length];
            for(int i = 0; i<fotoExplosies.Length;i++)
            {
                explosions[i] = Image.FromFile(fotoExplosies[i]);
            }


            /*
            explosion1 = Image.FromFile(fotoExplosie1);
            explosion2 = Image.FromFile(fotoExplosie2);
            explosion3 = Image.FromFile(fotoExplosie3);
            explosion4 = Image.FromFile(fotoExplosie4);
            explosion5 = Image.FromFile(fotoExplosie5);
            explosion6 = Image.FromFile(fotoExplosie6);
            explosion7 = Image.FromFile(fotoExplosie7);
            explosion8 = Image.FromFile(fotoExplosie8);
            explosion9 = Image.FromFile(fotoExplosie9);
            explosion10 = Image.FromFile(fotoExplosie10);
            explosion11 = Image.FromFile(fotoExplosie11);
            explosion12 = Image.FromFile(fotoExplosie12);
            explosion13 = Image.FromFile(fotoExplosie13);
            explosion14 = Image.FromFile(fotoExplosie14);
            explosion15 = Image.FromFile(fotoExplosie15);
            explosion16 = Image.FromFile(fotoExplosie16);
            explosion17 = Image.FromFile(fotoExplosie17);
            */
        }


        public override void teken(Pen onzePen, PaintEventArgs e)
        {
            // Rectangle rect = new Rectangle(Convert.ToInt32(balX), Convert.ToInt32(balY), groote, groote);
            // e.Graphics.DrawEllipse(onzePen, rect);
            Point ulCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY));
            Point urCorner = new Point(Convert.ToInt32(balX) + groote, Convert.ToInt32(balY));
            Point llCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY) + groote);
            Point[] hoeken = { ulCorner, urCorner, llCorner };

            aftellerExplotie = aftellerExplotie - 1;

            if(aftellerExplotie>-1 && aftellerExplotie < explosions.Length)
                e.Graphics.DrawImage(explosions[aftellerExplotie], hoeken);
            else
            if (aftellerExplotie < 1)
                respawn();
            else
                e.Graphics.DrawImage(newImage, hoeken);
            /*

            if (aftellerExplotie == 1)
                e.Graphics.DrawImage(explosion1, hoeken);
            else if (aftellerExplotie == 2)
                e.Graphics.DrawImage(explosion2, hoeken);
            else if (aftellerExplotie == 3)
                e.Graphics.DrawImage(explosion3, hoeken);
            else if (aftellerExplotie == 4)
                e.Graphics.DrawImage(explosion4, hoeken);
            else if (aftellerExplotie == 5)
                e.Graphics.DrawImage(explosion5, hoeken);
            else if (aftellerExplotie == 6)
                e.Graphics.DrawImage(explosion6, hoeken);
            else if (aftellerExplotie == 7)
                e.Graphics.DrawImage(explosion7, hoeken);
            else if (aftellerExplotie == 8)
                e.Graphics.DrawImage(explosion8, hoeken);
            else if (aftellerExplotie == 9)
                e.Graphics.DrawImage(explosion9, hoeken);
            else if (aftellerExplotie == 10)
                e.Graphics.DrawImage(explosion10, hoeken);
            else if (aftellerExplotie == 11)
                e.Graphics.DrawImage(explosion11, hoeken);
            else if (aftellerExplotie == 12)
                e.Graphics.DrawImage(explosion12, hoeken);
            else if (aftellerExplotie == 13)
                e.Graphics.DrawImage(explosion13, hoeken);
            else if (aftellerExplotie == 14)
                e.Graphics.DrawImage(explosion14, hoeken);
            else if (aftellerExplotie == 15)
                e.Graphics.DrawImage(explosion15, hoeken);
            else if (aftellerExplotie == 16)
                e.Graphics.DrawImage(explosion16, hoeken);
            else if (aftellerExplotie == 17)
                e.Graphics.DrawImage(explosion17, hoeken);
            else
            if (aftellerExplotie < 1)
                respawn();
            else
                {
                e.Graphics.DrawImage(newImage, hoeken);
                }
                */
        }


        public void checkMand(Mand mijnMand, Form1 mijnForm)
        {
            int ymand = mijnForm.ClientRectangle.Height - mijnMand.mijnGrote;
            if ((mijnMand.mijnXMand < balX + groote) && ((mijnMand.mijnXMand + mijnMand.mijnGrote > balX) && ((mijnMand.mijnYMand < balY + groote) && (mijnMand.mijnYMand + mijnMand.mijnGrote > balY))))   //test test in mand
            {
                // bal of bom in in mand

                if (aftellerExplotie > 17)
                {
                    mijnMand.addPoint(mijnWaarde);
                    omplof();
                }
            }
        }


        public void omplof()
        {
            aftellerExplotie = 17;
        }

        public void respawn()
        {
            base.respawn();
            aftellerExplotie = 250;
        }
    }
}
