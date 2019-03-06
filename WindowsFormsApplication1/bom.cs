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
using System.Windows.Media;

namespace WindowsFormsApplication1
{
    public class Bom: Bal
    {
        int aftellerExplosie = 250;
        Image[] explosions;
        public MediaPlayer OmplofSpeler { get; set; }

        public Bom(float startX,
          float startY,
          float startVX,
          float startVY,
          int startgroote,
          float balwrijving,
          float balwrijvingbodem,
          int waarde,
          string soundDirecotry,
          string fotoBal,
          string[] fotoExplosies

          ) : base(startX, startY, startVX, startVY, startgroote, balwrijving, balwrijvingbodem, fotoBal, waarde, soundDirecotry)
        {
            explosions = new Image[fotoExplosies.Length];
            for(int i = 0; i<fotoExplosies.Length;i++)
            {
                explosions[i] = Image.FromFile(fotoExplosies[i]);
            }
            OmplofSpeler = new MediaPlayer();
        }


        public override void Teken(System.Drawing.Pen onzePen, PaintEventArgs e)
        {
            Point ulCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY));
            Point urCorner = new Point(Convert.ToInt32(balX) + groote, Convert.ToInt32(balY));
            Point llCorner = new Point(Convert.ToInt32(balX), Convert.ToInt32(balY) + groote);
            Point[] hoeken = { ulCorner, urCorner, llCorner };

            aftellerExplosie = aftellerExplosie - 1;

            if (aftellerExplosie > -1 && aftellerExplosie == explosions.Length)
                Omplof(false);
            else if (aftellerExplosie > -1 && aftellerExplosie < explosions.Length)
                e.Graphics.DrawImage(explosions[aftellerExplosie], hoeken);
            else
            if (aftellerExplosie < 1)
            {
                if (!Game.IsInBalLijst(this))
                    Respawn();
                else
                    Game.VerwijderBom(this);
            }
                
            else
                e.Graphics.DrawImage(newImage, hoeken);
        }


        public override void CheckMand(Mand mijnMand, Game mijnForm)
        {
            int ymand = mijnForm.ClientRectangle.Height - mijnMand.mijnGrote;
            if ((mijnMand.mijnXMand < balX + groote) && ((mijnMand.mijnXMand + mijnMand.mijnGrote > balX) && ((mijnMand.mijnYMand < balY + groote) && (mijnMand.mijnYMand + mijnMand.mijnGrote > balY))))   //test test in mand
            {
                if (aftellerExplosie > 17)
                {
                    mijnMand.addPoint(mijnWaarde);
                    Omplof(true);
                }
            }
        }


        public void Omplof(bool zetTeller)
        {
            if(zetTeller)
                aftellerExplosie = 17;
            OmplofSpeler.Open(new Uri(@"../../files/sounds/bom.wav", UriKind.Relative));
            OmplofSpeler.Play();
        }

        public override void Respawn()
        {
            base.Respawn();
            aftellerExplosie = 250;
        }
    }
}
