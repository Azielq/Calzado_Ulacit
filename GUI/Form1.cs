using Calzado_Ulacit.GUI.User_Controls;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            InitializeStyles();
        }

        public void InitializeStyles()
        {
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#7148b5");
            button1.BackColor = ColorTranslator.FromHtml("#7148b5");
            button2.BackColor = ColorTranslator.FromHtml("#7148b5");
            button3.BackColor = ColorTranslator.FromHtml("#7148b5");
            button4.BackColor = ColorTranslator.FromHtml("#7148b5");
            button5.BackColor = ColorTranslator.FromHtml("#7148b5");

            // Carga el UserControl1 en el panelContainer
            UserControl1 uc1 = new UserControl1();
            LoadUserControl(uc1 );





        }

        private void LoadUserControl(UserControl uc)
        {
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
            uc.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UC_Clients uC_Clients = new UC_Clients();
            LoadUserControl(uC_Clients );
            button1.BackColor = ColorTranslator.FromHtml("#513d95");
            button2.BackColor = ColorTranslator.FromHtml("#7148b5");
            button3.BackColor = ColorTranslator.FromHtml("#7148b5");
            button4.BackColor = ColorTranslator.FromHtml("#7148b5");
            button5.BackColor = ColorTranslator.FromHtml("#7148b5");
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_Stock ucS = new UC_Stock();
            LoadUserControl(ucS);
            button1.BackColor = ColorTranslator.FromHtml("#7148b5");
            button2.BackColor = ColorTranslator.FromHtml("#513d95");
            button3.BackColor = ColorTranslator.FromHtml("#7148b5");
            button4.BackColor = ColorTranslator.FromHtml("#7148b5");
            button5.BackColor = ColorTranslator.FromHtml("#7148b5");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UC_Sell ucSll = new UC_Sell();
            LoadUserControl(ucSll);
            button1.BackColor = ColorTranslator.FromHtml("#7148b5");
            button2.BackColor = ColorTranslator.FromHtml("#7148b5");
            button3.BackColor = ColorTranslator.FromHtml("#513d95");
            button4.BackColor = ColorTranslator.FromHtml("#7148b5");
            button5.BackColor = ColorTranslator.FromHtml("#7148b5");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UC_CashOut ucCO = new UC_CashOut();
            LoadUserControl(ucCO);
            button1.BackColor = ColorTranslator.FromHtml("#7148b5");
            button2.BackColor = ColorTranslator.FromHtml("#7148b5");
            button3.BackColor = ColorTranslator.FromHtml("#7148b5");
            button4.BackColor = ColorTranslator.FromHtml("#513d95");
            button5.BackColor = ColorTranslator.FromHtml("#7148b5");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
