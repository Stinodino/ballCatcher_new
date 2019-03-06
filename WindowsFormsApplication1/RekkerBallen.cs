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




    public class RekkerBal : Bal
    {
        public RekkerBal(float startX,
            float startY,
            float startVX,
            float startVY,
            int startgroote,
            float balwrijving,
            float balwrijvingbodem,
            string fotoBal,
            int waarde,
            string soundDirecotry
            ) : base(startX, startY, startVX, startVY, startgroote, balwrijving, balwrijvingbodem, fotoBal, waarde, soundDirecotry)

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
        }
    }
}
