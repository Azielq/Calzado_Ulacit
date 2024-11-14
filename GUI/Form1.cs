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
        // Constructor principal
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;// Posiciona la ventana en el centro de la pantalla
            InitializeStyles(); // Llama al método para configurar los estilos iniciales
        }

        // Método para inicializar estilos de colores de los paneles y botones
        public void InitializeStyles()
        {
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#7148b5");
            button1.BackColor = ColorTranslator.FromHtml("#7148b5");
            button2.BackColor = ColorTranslator.FromHtml("#7148b5");
            button3.BackColor = ColorTranslator.FromHtml("#7148b5");
            button4.BackColor = ColorTranslator.FromHtml("#7148b5");
            button5.BackColor = ColorTranslator.FromHtml("#7148b5");

            // Carga el UserControl1 en el panel principal al iniciar la aplicación
            UserControl1 uc1 = new UserControl1();
            LoadUserControl(uc1);





        }

        // Método para cargar un UserControl en el panel principal (panel2)
        private void LoadUserControl(UserControl uc)
        {
            panel2.Controls.Clear(); // Limpia el panel de cualquier control existente
            uc.Dock = DockStyle.Fill; // Ajusta el UserControl para llenar el panel
            panel2.Controls.Add(uc); // Agrega el UserControl al panel
            uc.BringToFront(); // Coloca el control al frente del panel
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

        // Eventos que controlan las acciones de los botones para cambiar entre los UserControls
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
            this.Close(); // Cierra la aplicación cuando se presiona el botón de salida
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
