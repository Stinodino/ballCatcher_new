using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallCatcher
{
    public partial class SetControls : Form
    {
        public Keys Speler1Links { get; set; }
        public Keys Speler1Rechts { get; set; }
        public Keys Speler1Omhoog { get; set; }

        public Keys Speler2Links { get; set; }
        public Keys Speler2Rechts { get; set; }
        public Keys Speler2Omhoog { get; set; }

        public int HuidigeSpeler { get; set; }

        public SetControls(int huidigeSpeler)
        {
            InitializeComponent();
            HuidigeSpeler = huidigeSpeler;
            Text = $"Controls voor Speler {HuidigeSpeler}";
            Controls huidigeControls;
            if (HuidigeSpeler == 1)
                huidigeControls = new Controls(Keys.A, Keys.S, Keys.W);
            else
                huidigeControls = new Controls(Keys.Left, Keys.Right, Keys.Up);
            try
            {
                string result = System.IO.File.ReadAllText(@"../../files/config/controlsp" + HuidigeSpeler + ".json");
                if (result != "")
                {
                    huidigeControls = JsonConvert.DeserializeObject<Controls>(result);
                }


                if (HuidigeSpeler == 1)
                {
                    Speler1Links = huidigeControls.Links;
                    Speler1Rechts = huidigeControls.Rechts;
                    Speler1Omhoog = huidigeControls.Omhoog;
                }
                else
                {
                    Speler2Links = huidigeControls.Links;
                    Speler2Rechts = huidigeControls.Rechts;
                    Speler2Omhoog = huidigeControls.Omhoog;
                }

                textBoxLinks.Text = huidigeControls.Links.ToString();
                textBoxRechts.Text = huidigeControls.Rechts.ToString();
                textBoxOmhoog.Text = huidigeControls.Omhoog.ToString();
            }
            catch (System.IO.FileNotFoundException)
            {
                string json = JsonConvert.SerializeObject(huidigeControls);
                using(StreamWriter sw = File.CreateText(@"../../files/config/controlsp" + HuidigeSpeler + ".json"))
                {
                    sw.WriteLine(json);
                }
                textBoxLinks.Text = huidigeControls.Links.ToString();
                textBoxRechts.Text = huidigeControls.Rechts.ToString();
                textBoxOmhoog.Text = huidigeControls.Omhoog.ToString();
            }

        }


        public void SaveControls(string links, string rechts, string omhoog)
        {
            links = links.First().ToString().ToUpper() + links.Substring(1);
            rechts = rechts.First().ToString().ToUpper() + rechts.Substring(1);
            omhoog = omhoog.First().ToString().ToUpper() + omhoog.Substring(1);
            Enum.TryParse(links, out Keys linksKey);
            Enum.TryParse(rechts, out Keys rechtsKey);
            Enum.TryParse(omhoog, out Keys omhoogKey);
            Controls controls = new Controls(linksKey, rechtsKey, omhoogKey);
            string json = JsonConvert.SerializeObject(controls);
            System.IO.File.WriteAllText(@"../../files/config/controlsp" + HuidigeSpeler + ".json", json);
        }

        private void ButtonInstellen_Click(object sender, EventArgs e)
        {
            SaveControls(textBoxLinks.Text, textBoxRechts.Text, textBoxOmhoog.Text);
            Hide();
        }
    }
}
