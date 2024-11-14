using Avalonia.Styling;
using Calzado_Ulacit.Logica;
using Calzado_Ulacit.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            LoadDataGrid();
            // Desactiva la selección de la fila inicial
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
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

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón AÑADIR DATOS
            // Captura los valores de los TextBox
            string name = textBox2.Text; //TB2
            string lastName = textBox1.Text; //TB1
            string address = textBox4.Text;
            int phoneNumber;

            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                textBox3.Text.Equals("Enter client phone number here") ||
                textBox2.Text.Equals("Enter client name here") ||
                textBox1.Text.Equals("Enter client last name here") ||
                textBox4.Text.Equals("Enter client address here"))
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

            if (int.TryParse(textBox3.Text, out phoneNumber))
            {
                // Crear una instancia del cliente
                Client client = new Client(name, lastName, address, phoneNumber);

                // Crear una instancia de ClientDataAccess para agregar el cliente a la base de datos
                ClientDataAccess dataAccess = new ClientDataAccess();
                dataAccess.AddClient(client);

                MessageBox.Show("Cliente agregado exitosamente");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número de teléfono válido.");
            }

            LoadDataGrid();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete Button
            if (dataGridView1.SelectedRows.Count > 0) // Verifica que haya una fila seleccionada
            {
                // Obtiene el ID de la fila seleccionada
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int clientId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["cltIdDataGridViewTextBoxColumn"].Value);

                // Crear instancia de ClientDataAccess y eliminar cliente
                ClientDataAccess dataAccess = new ClientDataAccess();
                dataAccess.DeleteClientById(clientId);

                // Elimina la fila del DataGridView
                dataGridView1.Rows.RemoveAt(selectedRowIndex);

                MessageBox.Show("La fila ha sido eliminada correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private void LoadDataGrid()
        {
            ClientDataAccess dataAccess = new ClientDataAccess();
            dataGridView1.DataSource = dataAccess.fillDataGrid();
            // Desactiva la selección de la fila inicial
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private void UC_Clients_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            // Evento vacío para evitar la propagación del click al formulario
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                textBox3.Text.Equals("Enter client phone number here") ||
                textBox2.Text.Equals("Enter client name here") ||
                textBox1.Text.Equals("Enter client last name here") ||
                textBox4.Text.Equals("Enter client address here"))
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

            // Verificar que el número de teléfono sea un entero válido
            if (!int.TryParse(textBox3.Text, out int phoneNumber))
            {
                MessageBox.Show("El número de teléfono debe ser un valor numérico.");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int clientId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["cltIdDataGridViewTextBoxColumn"].Value);

                // Crear un objeto Client con los datos actualizados (sin el ID)
                Client updatedClient = new Client(
                    textBox2.Text.Trim(),
                    textBox1.Text.Trim(),
                    textBox4.Text.Trim(),
                    phoneNumber
                );

                // Instancia de ClientDataAccess para actualizar el cliente en la base de datos
                ClientDataAccess dataAccess = new ClientDataAccess();
                dataAccess.UpdateClient(clientId, updatedClient);

                // Actualizar la fila seleccionada en el DataGridView
                dataGridView1.SelectedRows[0].Cells["cltNameDataGridViewTextBoxColumn"].Value = updatedClient.CltName;
                dataGridView1.SelectedRows[0].Cells["cltLastNameDataGridViewTextBoxColumn"].Value = updatedClient.CltLastName;
                dataGridView1.SelectedRows[0].Cells["cltAddressDataGridViewTextBoxColumn"].Value = updatedClient.CltAddress;
                dataGridView1.SelectedRows[0].Cells["cltPhoneNumDataGridViewTextBoxColumn"].Value = updatedClient.CltPhoneNum;

                MessageBox.Show("Cliente actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para actualizar.");
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            LoadDataGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la fila seleccionada sea válida
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila en la que se hizo doble clic
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Asigna los valores de la fila a los TextBox
                textBox2.Text = row.Cells["cltNameDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                textBox1.Text = row.Cells["cltLastNameDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                textBox4.Text = row.Cells["cltAddressDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                textBox3.Text = row.Cells["cltPhoneNumDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
