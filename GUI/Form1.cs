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
    }
}
