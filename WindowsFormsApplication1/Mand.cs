﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallCatcher
{
    public class Mand
    {
        public Controls Controls { get; set; }
        public float mijnXMand = 100;
        public float mijnYMand = 100;
        float mijnVXMand = 0;
        float mijnVYMand = 0;
        float mijnZwaarteKracht = (float) 0.3;
        public int Punten { get; set; }
        public int mijnGrote;
        float mijngroteWrijving = 0;
        float mijnkleineWrijving = 0;
        float mijnSnelheidLemiet = 10;
        float mijnJumpKracht = 10;
        float mijnHorizontaleVersnelling = 5;
        string mijnFotoMand = "../../files/images/manden/mand1.png";
        string naam = "";
        Image newImage;

        public Mand(float startMandX, float startMandY, float startMandVX, float startMandVY, string speler, int mijnPunten, int startGrote ,float groteWrijving,float kleineWrijving, float snelheidLemiet, float jumpKracht, float horizontaleVersnelling, string foto)
        {
            mijnXMand = startMandX;
            mijnYMand = startMandY;
            mijnVXMand = startMandVX;
            mijnVYMand = startMandVY;
            mijngroteWrijving = groteWrijving;
            mijnkleineWrijving = kleineWrijving;
            mijnFotoMand = foto;
            naam = speler;
            Punten = mijnPunten;
            mijnGrote = startGrote;
            mijnJumpKracht = jumpKracht;
            mijnSnelheidLemiet = snelheidLemiet;
            mijnHorizontaleVersnelling = horizontaleVersnelling;
            newImage = Image.FromFile(mijnFotoMand);
        }

        public void Rechts(Game mijnForm)
        {
            if ((mijnXMand < mijnForm.ClientRectangle.Width - mijnGrote) && (mijnVXMand < mijnSnelheidLemiet))//is NIET tegen rand? & nog niet aan lemiet?
                mijnVXMand = mijnVXMand + mijnHorizontaleVersnelling;
        }

        public void Links(Game mijnForm)
        {
            if ((mijnXMand > 0 ) && (mijnVXMand > - mijnSnelheidLemiet))//is NIET tegen rand? & nog niet aan lemiet?
                mijnVXMand = mijnVXMand - mijnHorizontaleVersnelling;
        }

        public void Jump(Game mijnForm)
        {
            if (mijnYMand == mijnForm.ClientRectangle.Height - mijnGrote) //is tegen grond? + mand stuitert niet meer?

                mijnVYMand = mijnJumpKracht;
        }


        public void Teken(Pen onzePen, PaintEventArgs e, Game mijnForm)
        {

            // Create parallelogram for drawing image..
            Point ulCorner = new Point(Convert.ToInt32(mijnXMand), Convert.ToInt32(mijnYMand));
            Point urCorner = new Point(Convert.ToInt32(mijnXMand) + mijnGrote, Convert.ToInt32(mijnYMand));
            Point llCorner = new Point(Convert.ToInt32(mijnXMand), Convert.ToInt32(mijnYMand) + mijnGrote);
            Point[] hoeken = { ulCorner, urCorner, llCorner };
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, hoeken);
            Graphics g = e.Graphics;
            g.DrawString(naam, new Font("Verdana",12), new SolidBrush (Color.White), mijnXMand + 10, mijnYMand + 40);
            g.DrawString(Convert.ToString(Punten), new Font("Verdana", 12), new SolidBrush(Color.White), mijnXMand + 30, mijnYMand + 60);
        }

        public void AddPoint(int waarde)
        {
            Punten = Punten + waarde;
        }


        public void Beweeg(Game mijnForm)
        {
                mijnVYMand = mijnVYMand + mijnZwaarteKracht;

            mijnYMand = mijnYMand + mijnVYMand;
            mijnXMand = mijnXMand + mijnVXMand;

            if (mijnYMand > mijnForm.ClientRectangle.Height - mijnGrote) //door bodem is
            {
                mijnYMand = mijnForm.ClientRectangle.Height - mijnGrote; //zet terug in frame
                mijnVYMand = -mijnVYMand * mijngroteWrijving;

                mijnVXMand = mijnVXMand * mijnkleineWrijving;
            }
            if (mijnXMand > mijnForm.ClientRectangle.Width - mijnGrote) //als tegen rechterrand botst
            {

                mijnXMand = mijnForm.ClientRectangle.Width - mijnGrote;
                mijnVXMand = -mijnVXMand * mijngroteWrijving;
                mijnVYMand = mijnVYMand * mijngroteWrijving;
            }
            if (mijnXMand < 0) // als tegen linker rand botst
            {
                mijnXMand = 0;
                mijnVXMand = -mijnVXMand * mijngroteWrijving;
                mijnVYMand = mijnVYMand * mijngroteWrijving;
            }
        }
    }
}
