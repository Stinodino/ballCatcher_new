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
        /*public float balX = 0;
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
        protected Image newImage;*/






        public RekkerBal(float startX, 
            float startY,  
            float startVX, 
            float startVY, 
            int startgroote, 
            float balwrijving, 
            float balwrijvingbodem,
            float zwaarteKracht,
            string fotoBal,
            int waarde
            ) : base(startX, startY, startVX, startVY, startgroote, balwrijving, balwrijvingbodem, zwaarteKracht, fotoBal, waarde)

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
        }
    }
}
