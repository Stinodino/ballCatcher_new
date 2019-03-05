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

namespace WindowsFormsApplication1
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
            if (naam1 != "" || naam2 != "")
            {
                form = new Game(textBoxNaam1.Text, textBoxNaam2.Text);
            }
            else
            {
                form = new Game();
            }
            form.Show();
            this.Hide();
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
