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
    //form para seleccionar un cliente, este form se llama desde UC_Sell
    public partial class Form_SelectClient : Form
    {

        public string SelectedClient { get; private set; } // Cliente seleccionado
        public int SelectedClientID { get; private set; } //ID Seleccionado

        public Form_SelectClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;// Posiciona la ventana en el centro de la pantalla
            

        }

        private void Form_SelectClient_Load(object sender, EventArgs e)
        {
            //esta línea de código carga datos en la tabla 'ulacitShoesDataSet.Clients'
            this.clientsTableAdapter.Fill(this.ulacitShoesDataSet.Clients);
            dataGridView1.ClearSelection();
        }


        // Evento para seleccionar cliente
        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Combinar nombre y apellido
                string nombre = selectedRow.Cells["cltNameDataGridViewTextBoxColumn"].Value.ToString().Trim();
                string apellido = selectedRow.Cells["cltLastNameDataGridViewTextBoxColumn"].Value.ToString().Trim();
                SelectedClient = $"{nombre} {apellido}";

                // Obtener el ID del cliente seleccionado
                SelectedClientID = Convert.ToInt32(selectedRow.Cells["cltIDDataGridViewTextBoxColumn"].Value);

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
