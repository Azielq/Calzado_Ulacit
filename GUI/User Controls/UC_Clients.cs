using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calzado_Ulacit
{
    public partial class UC_Clients : UserControl
    {
        public UC_Clients()
        {
            InitializeComponent();
        }

        private void UC_Clients_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text.Equals("Enter client name here"))
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }

            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Enter client last name here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Enter client phone number here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter client address here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (textBox1.Text.Equals("Enter client last name here"))
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Enter client name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Enter client phone number here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter client address here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Address
            textBox4.ForeColor = Color.Black;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            //Adrress
            if (textBox4.Text.Equals("Enter client address here"))
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }

            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Enter client last name here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Enter client name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Enter client phone number here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text.Equals("Enter client phone number here"))
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }

            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Enter client last name here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Enter client name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter client address here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.Equals("Enter client last name here"))
                textBox1.Text = "Enter client last name here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);

            if (string.IsNullOrEmpty(textBox2.Text) || !textBox2.Text.Equals("Enter client name here"))
                textBox2.Text = "Enter client name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);

            if (string.IsNullOrEmpty(textBox3.Text) || !textBox3.Text.Equals("Enter client phone number here"))
                textBox3.Text = "Enter client phone number here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);

            if (string.IsNullOrEmpty(textBox4.Text) || !textBox4.Text.Equals("Enter client address here"))
                textBox4.Text = "Enter client address here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);

        }
    }
}
