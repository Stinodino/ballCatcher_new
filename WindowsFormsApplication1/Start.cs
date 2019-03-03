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
            Form1 form;
            if (naam1 != "" || naam2 != "")
            {
                form = new Form1(textBoxNaam1.Text, textBoxNaam2.Text);
            }
            else
            {
                form = new Form1();
            }
            form.Show();
            this.Hide();
        }
    }
}
