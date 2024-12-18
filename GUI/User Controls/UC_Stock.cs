using Calzado_Ulacit.Logica;
using Calzado_Ulacit.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            LoadDataGrid(); // Carga datos en el DataGridView principal
            CalculateAndDisplaySummary();  // Muestra resumen de datos
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ValidateDataTable(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                // Validar que shoeSize sea un entero válido
                if (!int.TryParse(row["shoeSize"]?.ToString(), out int shoeSize))
                {
                    row["shoeSize"] = 0; // Asignar valor predeterminado si no es válido
                }
            }
        }   

        private void LoadDataGrid()
        {
            ShoeDataAccess dataAccess = new ShoeDataAccess();
            dataGridView1.DataSource = dataAccess.fillDataGrid();

            // Asegurar que el tipo de dato de shoeSize sea correcto
            dataGridView1.Columns["shoeSize"].ValueType = typeof(int);

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            // Configurar el estilo de la columna de precio
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "C"; // Formato moneda
                                // Crear cultura personalizada
            CultureInfo ci = new CultureInfo("es-ES", false);
            // Cambiar el símbolo de moneda, por ejemplo a €
            ci.NumberFormat.CurrencySymbol = "$";

            style.FormatProvider = ci;

            // Asignar el estilo a la columna de precio
            dataGridView1.Columns["priceDataGridViewTextBoxColumn"].DefaultCellStyle = style;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_Stock_Load(object sender, EventArgs e)
        {
            // Carga datos en el DataGridView principal
            CalculateAndDisplaySummary();  // Muestra resumen de datos


            // Desactiva la selección de la fila inicial
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        // Métodos para cambiar color en los TextBoxes cuando se ingresan datos
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
            // Restablece los campos de entrada a su valor predeterminado si están vacíos
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
            // Captura datos de entrada
            string shoeName = textBox2.Text;
            string shoeColor = textBox1.Text;
            string shoeType = textBox4.Text;
            
            float shoePrice;

            // Verifica que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                textBox3.Text.Equals("Enter shoe price here") ||
                textBox2.Text.Equals("Enter shoe name here") ||
                textBox1.Text.Equals("Enter shoe color here") ||
                textBox1.Text.Equals("Enter stock here") ||
                textBox4.Text.Equals("Enter shoe type here"))
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

            // Validar que el ComboBox tenga un valor numérico
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || comboBox1.Text.Equals("Select shoe size"))
            {
                MessageBox.Show("Por favor, seleccione una talla de zapato.");
                return;
            }

            // Verifica que la talla sea un número entero
            if (!int.TryParse(comboBox1.Text.Trim(), out int shoeSize) || shoeSize <= 0)
            {
                MessageBox.Show("Por favor, seleccione una talla válida (número entero positivo).");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox5.Text) || textBox5.Text.Equals("Enter stock here"))
            {
                MessageBox.Show("Por favor, ingrese un stock válido.");
                return;
            }

            int shoeStock;
            if (!int.TryParse(textBox5.Text, out shoeStock) || shoeStock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero positivo.");
                return;
            }

            // Convierte el precio de string a float y agrega el zapato a la base de datos
            if (float.TryParse(textBox3.Text, out shoePrice))
            {
                Shoe shoe = new Shoe(shoeName, shoeColor, shoeSize, shoeType, shoePrice, shoeStock);

                ShoeDataAccess dataAccess = new ShoeDataAccess();
                dataAccess.AddShoe(shoe);

                MessageBox.Show("Zapato agregado exitosamente");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
                return;
            }


            // Actualiza DataGrid y resumen después de agregar
            LoadDataGrid();
            CalculateAndDisplaySummary();
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Verificar que haya un zapato seleccionado en el DataGridView
                var selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow != null)
                {
                    // Actualizar la celda del DataGridView con el valor seleccionado del ComboBox
                    selectedRow.Cells["shoeSize"].Value = comboBox1.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Botón Eliminar: verifica que haya una fila seleccionada
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
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                textBox3.Text.Equals("Enter shoe price here") ||
                textBox2.Text.Equals("Enter shoe name here") ||
                textBox1.Text.Equals("Enter shoe color here") ||
                textBox4.Text.Equals("Enter shoe type here") ||
                textBox5.Text.Equals("Enter stock here") ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                comboBox1.Text.Equals("Select shoe size"))
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

            // Validar que el precio sea un valor decimal válido
            if (!float.TryParse(textBox3.Text, out float shoePrice))
            {
                MessageBox.Show("El precio debe ser un valor numérico.");
                return;
            }



            // Validar que la talla sea un número entero válido
            if (!int.TryParse(comboBox1.Text.Trim(), out int shoeSize) || shoeSize <= 0)
            {
                MessageBox.Show("Por favor, seleccione una talla válida (número entero positivo).");
                return;
            }


            // Validar el stock
            int shoeStock;
            if (!int.TryParse(textBox5.Text, out shoeStock) || shoeStock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero positivo.");
                return;
            }

            // Verificar que haya una fila seleccionada en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int shoeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["shoeIdDataGridViewTextBoxColumn"].Value);

                // Crear un objeto Shoe con los datos actualizados
                Shoe updatedShoe = new Shoe(
                    textBox2.Text.Trim(),
                    textBox1.Text.Trim(),
                    shoeSize,  // Tamaño del zapato validado
                    textBox4.Text.Trim(),
                    shoePrice,
                    shoeStock
                );

                // Instancia de ShoeDataAccess para actualizar el zapato en la base de datos
                ShoeDataAccess dataAccess = new ShoeDataAccess();
                dataAccess.UpdateShoe(shoeId, updatedShoe);

                // Actualizar la fila seleccionada en el DataGridView
                var selectedRow = dataGridView1.SelectedRows[0];
                selectedRow.Cells["shoeNameDataGridViewTextBoxColumn"].Value = updatedShoe.ShoeName;
                selectedRow.Cells["shoeColorDataGridViewTextBoxColumn"].Value = updatedShoe.ShoeColor;
                selectedRow.Cells["shoeSize"].Value = shoeSize.ToString(); // Convertir a texto antes de asignar
                selectedRow.Cells["typeDataGridViewTextBoxColumn"].Value = updatedShoe.Type;
                selectedRow.Cells["priceDataGridViewTextBoxColumn"].Value = updatedShoe.Price;
                selectedRow.Cells["Stock"].Value = updatedShoe.Stock;

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
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            // Cargar datos nuevamente para garantizar consistencia
            LoadDataGrid();
            CalculateAndDisplaySummary();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Validar los datos de las celdas antes de asignarlos
                textBox2.Text = row.Cells["shoeNameDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                textBox1.Text = row.Cells["shoeColorDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                // Asignar valores existentes a los campos de texto
                textBox5.Text = row.Cells["Stock"].Value?.ToString() ?? "Enter stock here";
                textBox5.ForeColor = Color.Black;

                // Validar si el tamaño es un número válido antes de asignarlo al ComboBox
                if (int.TryParse(row.Cells["shoeSize"].Value?.ToString(), out int shoeSize))
                {
                    comboBox1.Text = shoeSize.ToString();
                }
                else
                {
                    comboBox1.Text = "Select shoe size"; // Valor predeterminado si es inválido
                }

                textBox4.Text = row.Cells["typeDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
                textBox3.Text = row.Cells["priceDataGridViewTextBoxColumn"].Value?.ToString() ?? "";
            }

        }

        private void UC_Stock_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void CalculateAndDisplaySummary()
        {
            Dictionary<string, int> typeCounts = new Dictionary<string, int>();
            float totalMoney = 0;

            // Recorre dataGridView1 para calcular totales
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                float price = Convert.ToSingle(row.Cells["priceDataGridViewTextBoxColumn"].Value ?? 0); // columna de precio
                string type = row.Cells["typeDataGridViewTextBoxColumn"].Value?.ToString() ?? ""; // columna de tipo


                // Acumulamos el total de dinero
                totalMoney += price;

                // Contamos la cantidad de cada tipo
                if (typeCounts.ContainsKey(type))
                {
                    typeCounts[type]++;
                }
                else
                {
                    typeCounts[type] = 1;
                }
            }

            // Crear DataTable para mostrar en dataGridViewSummary
            DataTable summaryTable = new DataTable();
            summaryTable.Columns.Add("Description", typeof(string));
            summaryTable.Columns.Add("Amount", typeof(string));

            // Agregar cantidad de cada tipo al DataTable
            foreach (var typeCount in typeCounts)
            {
                summaryTable.Rows.Add($"Amount of {typeCount.Key}", typeCount.Value);
            }

            

            // Asignar el DataTable al DataGridView de resumen
            dataGridView2.DataSource = summaryTable;

            label10.Text = $"Total Investment: {totalMoney}";

            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Mostrar un mensaje de error amigable
            MessageBox.Show($"Se produjo un error al procesar los datos en la columna {e.ColumnIndex + 1}, fila {e.RowIndex + 1}. \n" +
                            $"Detalles del error: {e.Exception.Message}",
                            "Error de DataGridView",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            // Evitar que la aplicación se detenga por el error
            e.ThrowException = false;

            string problematicValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "null";
            Console.WriteLine($"Valor problemático: {problematicValue}");

            MessageBox.Show($"Error al procesar los datos: {e.Exception.Message}\n" +
                            $"Valor problemático: {problematicValue}",
                            "Error en DataGridView",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            e.ThrowException = false;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "shoeSize")
            {
                // Validar que el valor sea un entero positivo
                if (!int.TryParse(e.FormattedValue.ToString(), out int size) || size <= 0)
                {
                    MessageBox.Show("El tamaño del zapato debe ser un número entero mayor que 0.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // Cancela la edición si el valor no es válido
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text.Equals("Enter stock here"))
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
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

            if (textBox4.Text.Equals(""))
            {
                textBox4.Text = "Enter shoe type here";
                textBox4.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
