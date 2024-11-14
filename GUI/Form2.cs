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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            UserControl1 uc = new UserControl1();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
