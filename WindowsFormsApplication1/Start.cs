using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BallCatcher
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            string naam1 = textBoxNaam1.Text;
            string naam2 = textBoxNaam2.Text;
            Game form;
            string result1 = System.IO.File.ReadAllText(@"../../files/config/controlsp1.json");
            string result2 = System.IO.File.ReadAllText(@"../../files/config/controlsp2.json");
            Controls controlsSpeler1 = JsonConvert.DeserializeObject<Controls>(result1);
            Controls controlsSpeler2 = JsonConvert.DeserializeObject<Controls>(result2);
            if (naam1 != "" || naam2 != "")
            {
                form = new Game(textBoxNaam1.Text, textBoxNaam2.Text, controlsSpeler1, controlsSpeler2);
            }
            else
            {
                form = new Game(controlsSpeler1, controlsSpeler2);
            }
            form.Show();
            this.Hide();
        }

        private void Start_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelControls.Text = e.KeyChar.ToString();
        }

        private void ButtonControls1_Click(object sender, EventArgs e)
        {
            SetControls form = new SetControls(1);
            form.Show();
        }

        private void ButtonControls2_Click(object sender, EventArgs e)
        {
            SetControls form = new SetControls(2);
            form.Show();
        }


        //public Keys[] VraagControls(string naam)
        //{
        //    Keys[] result = new Keys[4];
        //    labelControls.Text = $"Geef de knop om naar rechts te gaan voor {naam}";
        //    result[0] = GeefInput();
        //}

        //private Keys GeefInput()
        //{

        //}

    }
}
