using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THAW6_MaulanaMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString() == "" || Convert.ToInt32(textBox1.Text.ToString())<=3) 
            {
                MessageBox.Show("Error nyawa < 3 atau null"); 
            }
            else
            {
                FormGame.text = Convert.ToInt32(textBox1.Text);
                FormGame Game = new FormGame();
                Game.Show();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
