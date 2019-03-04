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
using System.Threading;

namespace WindowsFormsApplication1
{
    public class Bom: Bal
    {
        int aftellerExplotie = 250;
        Image[] explosions;
        public SoundPlayer OmplofSpeler { get; set; }

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
            OmplofSpeler = new SoundPlayer(@"../../files/sounds/bom.wav");
            OmplofSpeler.Load();
        }


        public override void Teken(Pen onzePen, PaintEventArgs e)
        {
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
        }


        public void checkMand(Mand mijnMand, Game mijnForm)
        {
            int ymand = mijnForm.ClientRectangle.Height - mijnMand.mijnGrote;
            if ((mijnMand.mijnXMand < balX + groote) && ((mijnMand.mijnXMand + mijnMand.mijnGrote > balX) && ((mijnMand.mijnYMand < balY + groote) && (mijnMand.mijnYMand + mijnMand.mijnGrote > balY))))   //test test in mand
            {
                if (aftellerExplotie > 17)
                {
                    mijnMand.addPoint(mijnWaarde);
                    Omplof();
                }
            }
        }


        public void Omplof()
        {
            aftellerExplotie = 17;
            Thread geluid = new Thread(() => Bal.SpeelGeluid(OmplofSpeler));
            geluid.Start();
        }

        public void respawn()
        {
            base.Respawn();
            aftellerExplotie = 250;
        }
    }
}
