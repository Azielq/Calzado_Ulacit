using Calzado_Ulacit.Logica;
using Calzado_Ulacit.Persistencia;
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
    public partial class UC_Stock : UserControl
    {
        public UC_Stock()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataGrid()
        {
            ShoeDataAccess dataAccess = new ShoeDataAccess();
            dataGridView1.DataSource = dataAccess.fillDataGrid();
            // Desactiva la selección de la fila inicial
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Stock_Load(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Type
            textBox4.ForeColor = Color.Black;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Equals("Enter shoe color here"))
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Enter shoe name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Enter shoe price here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter shoe type here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox2.Text.Equals("Enter shoe name here"))
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }

            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Enter shoe color here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Enter shoe price here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter shoe type here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void textBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Equals("Enter shoe color here"))
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Enter shoe name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Enter shoe price here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter shoe type here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void textBox4_MouseClick_1(object sender, MouseEventArgs e)
        {
            // Type
            if (textBox4.Text.Equals("Enter shoe type here"))
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }

            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Enter shoe color here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Enter shoe name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox3.Text.Equals(""))
            {
                textBox3.Text = "Enter shoe price here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text.Equals("Enter shoe price here"))
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }

            if (textBox1.Text.Equals(""))
            {
                textBox1.Text = "Enter shoe color here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox2.Text.Equals(""))
            {
                textBox2.Text = "Enter shoe name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter shoe type here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void clear()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.Equals("Enter shoe color here"))
            {
                textBox1.Text = "Enter shoe color here";
                textBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (string.IsNullOrEmpty(textBox2.Text) || !textBox2.Text.Equals("Enter shoe name here"))
            {
                textBox2.Text = "Enter shoe name here";
                textBox2.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (string.IsNullOrEmpty(textBox3.Text) || !textBox3.Text.Equals("Enter shoe price here"))
            {
                textBox3.Text = "Enter shoe price here";
                textBox3.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (string.IsNullOrEmpty(textBox4.Text) || !textBox4.Text.Equals("Enter shoe type here"))
            {
                textBox4.Text = "Enter shoe type here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }

            if (string.IsNullOrEmpty(comboBox1.Text) || !textBox4.Text.Equals("Select shoe size"))
            {
                comboBox1.Text = "Select shoe size";
                comboBox1.ForeColor = Color.FromArgb(224, 224, 224);
            }

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string shoeName = textBox2.Text;
            string shoeColor = textBox1.Text;
            string shoeType = textBox4.Text;
            int shoeSize = comboBox1.SelectedIndex;
            float shoePrice;

            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                textBox3.Text.Equals("Enter shoe price here") ||
                textBox2.Text.Equals("Enter shoe name here") ||
                textBox1.Text.Equals("Enter shoe color here") ||
                textBox4.Text.Equals("Enter shoe type here"))
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

            if (float.TryParse(textBox3.Text, out shoePrice))
            {
                Shoe shoe = new Shoe(shoeName, shoeColor, shoeSize, shoeType, shoePrice);

                ShoeDataAccess dataAccess = new ShoeDataAccess();
                dataAccess.AddShoe(shoe);

                MessageBox.Show("Zapato agregado exitosamente");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
            }

            LoadDataGrid();
            clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            // Cambiar el color de fuente a negro cuando se hace clic en el ComboBox
            comboBox1.ForeColor = Color.Black;

        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            // Si no se seleccionó ninguna opción, restaura el color de fondo original
            if (comboBox1.SelectedIndex == -1)
            {
                
                comboBox1.ForeColor = Color.FromArgb(224, 224, 224); // Restaurar el color del texto original si se cambió
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Deselecciona el ComboBox después de seleccionar una opción
            if (comboBox1.SelectedIndex != -1)
            {
                this.ActiveControl = label1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Delete Button
            if (dataGridView1.SelectedRows.Count > 0) // Verifica que haya una fila seleccionada
            {
                // Obtiene el ID de la fila seleccionada
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int shoeId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["shoeIdDataGridViewTextBoxColumn"].Value);

                // Crear instancia de ShoeDataAccess y eliminar zapato
                ShoeDataAccess dataAccess = new ShoeDataAccess();
                dataAccess.DeleteShoeById(shoeId);

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

        private void button4_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                textBox3.Text.Equals("Enter shoe price here") ||
                textBox2.Text.Equals("Enter shoe name here") ||
                textBox1.Text.Equals("Enter shoe color here") ||
                textBox4.Text.Equals("Enter shoe type here") ||
                comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

            // Verificar que el precio sea un valor decimal válido
            if (!float.TryParse(textBox3.Text, out float shoePrice))
            {
                MessageBox.Show("El precio debe ser un valor numérico.");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int shoeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["shoeIdDataGridViewTextBoxColumn"].Value);

                // Crear un objeto Shoe con los datos actualizados (sin el ID)
                Shoe updatedShoe = new Shoe(
                    textBox2.Text.Trim(),
                    textBox1.Text.Trim(),
                    comboBox1.SelectedIndex,  // Tamaño del zapato
                    textBox4.Text.Trim(),
                    shoePrice
                );

                // Instancia de ShoeDataAccess para actualizar el zapato en la base de datos
                ShoeDataAccess dataAccess = new ShoeDataAccess();
                dataAccess.UpdateShoe(shoeId, updatedShoe);

                // Actualizar la fila seleccionada en el DataGridView
                dataGridView1.SelectedRows[0].Cells["shoeNameDataGridViewTextBoxColumn"].Value = updatedShoe.ShoeName;
                dataGridView1.SelectedRows[0].Cells["shoeColorDataGridViewTextBoxColumn"].Value = updatedShoe.ShoeColor;
                dataGridView1.SelectedRows[0].Cells["shoeSize"].Value = updatedShoe.ShoeSize;
                dataGridView1.SelectedRows[0].Cells["typeDataGridViewTextBoxColumn"].Value = updatedShoe.Type;
                dataGridView1.SelectedRows[0].Cells["priceDataGridViewTextBoxColumn"].Value = updatedShoe.Price;

                MessageBox.Show("Zapato actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un zapato para actualizar.");
            }

            // Limpiar los campos de texto y restablecer el ComboBox
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            LoadDataGrid();

        }
    }
}
