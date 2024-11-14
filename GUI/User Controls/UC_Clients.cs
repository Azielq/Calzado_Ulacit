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
            fillDataGrid();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón AÑADIR DATOS
            // Captura los valores de los TextBox
            string name = textBox2.Text; //TB2
            string lastName = textBox1.Text; //TB1
            string address = textBox4.Text;
            int phoneNumber;

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

            fillDataGrid();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

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
        }

        private void fillDataGrid()
        {
            //SqlConnection conexion = new SqlConnection("server=403-PROF\\ULACIT; database=model; integrated security = true");
            SqlConnection conexion = new SqlConnection("server=AZIEL; database=UlacitShoes; integrated security = true");
            conexion.Open();
            //Tabla de datos en memoria
            DataTable dt = new DataTable();
            //DataAdapter es un objeto que almacena n número de DataTables
            SqlDataAdapter adaptador = new SqlDataAdapter("select * from Clients", conexion);
            //Llena el adaptador con la instrucción sql
            adaptador.Fill(dt);
            //Carga el datagridview1
            dataGridView1.DataSource = dt;
            conexion.Close();
        }

    }
}
