using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calzado_Ulacit.GUI.User_Controls
{
    public partial class Form_SelectClient : Form
    {

        public string SelectedClient { get; private set; } // Cliente seleccionado

        public Form_SelectClient()
        {
            InitializeComponent();
        }

        private void Form_SelectClient_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ulacitShoesDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.Fill(this.ulacitShoesDataSet.Clients);

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.CurrentRow != null)
            {
                SelectedClient = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                this.DialogResult = DialogResult.OK; // Cierra el formulario con OK
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.CurrentRow != null)
            {
                // Combinar nombre y apellido
                string nombre = dataGridView1.CurrentRow.Cells["cltNameDataGridViewTextBoxColumn"].Value.ToString().Trim();
                string apellido = dataGridView1.CurrentRow.Cells["cltLastNameDataGridViewTextBoxColumn"].Value.ToString().Trim();
                SelectedClient = $"{nombre} {apellido}";

                // Confirmar y cerrar el formulario
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
