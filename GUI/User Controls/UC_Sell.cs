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
    public partial class UC_Sell : UserControl
    {
        private DataTable shoesTable; // Variable a nivel de clase para reutilizar
        private decimal total;
        private decimal subtotal;
        private decimal tax;
        private string paymentMethod;
        private int invDiscount;
        private string client;
        private int clientId;


        public UC_Sell()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void UC_Sell_Load(object sender, EventArgs e)
        {
            LoadShoesIntoComboBox();
            UpdateTotals();
        }


        private void UpdateTotals()
        {
            subtotal = 0m;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                // Obtener la cantidad y el precio unitario
                object qtyObj = row.Cells["Quantity"].Value;
                object priceObj = row.Cells["UnitPrice"].Value;

                int quantity = 0;
                decimal unitPrice = 0m;

                if (qtyObj != null && int.TryParse(qtyObj.ToString(), out quantity) && quantity > 0)
                {
                    // Validar y obtener el precio
                    if (priceObj != null && decimal.TryParse(priceObj.ToString(), out unitPrice))
                    {
                        subtotal += quantity * unitPrice;
                    }
                }
            }

            // Obtener el descuento
            decimal discountPercentage = numericUpDown1.Value / 100m;
            decimal discountedSubtotal = subtotal * (1 - discountPercentage);

            // Calcular el impuesto sobre el subtotal descontado
            tax = discountedSubtotal * 0.13m;

            // Calcular el total
            total = discountedSubtotal + tax;

            // Actualizar los labels con formato de dólar estadounidense
            label14.Text = discountedSubtotal.ToString("C2", CultureInfo.GetCultureInfo("en-US")); // Subtotal después del descuento
            label11.Text = tax.ToString("C2", CultureInfo.GetCultureInfo("en-US"));               // Impuesto 13%
            label12.Text = total.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario
            Form_SelectClient selectClientForm = new Form_SelectClient();

            // Mostrarlo como cuadro de diálogo
            if (selectClientForm.ShowDialog() == DialogResult.OK)
            {
                // Asignar el cliente seleccionado al label10
                label10.Text = selectClientForm.SelectedClient;

                // Asignar el ID del cliente seleccionado al label7
                label7.Text = selectClientForm.SelectedClientID.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadShoesIntoComboBox()
        {
            ShoeDataAccess shoeData = new ShoeDataAccess();
            shoesTable = shoeData.GetAllShoes(); // Contiene shoeId, shoeName, price

            // Crear una columna calculada (si no existe) para "id - nombre"
            if (!shoesTable.Columns.Contains("DisplayText"))
            {
                shoesTable.Columns.Add("DisplayText", typeof(string));
            }

            foreach (DataRow row in shoesTable.Rows)
            {
                int id = Convert.ToInt32(row["shoeId"]);
                string name = row["shoeName"].ToString();
                row["DisplayText"] = $"{id} - {name}"; // Sin corchetes
            }

            // Configuración del ComboBox sin DataSource
            comboBoxShoes.Items.Clear();
            comboBoxShoes.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxShoes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxShoes.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Crear la colección de autocompletado
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

            foreach (DataRow row in shoesTable.Rows)
            {
                string displayText = row["DisplayText"].ToString();
                string nameOnly = row["shoeName"].ToString();
                string idOnly = row["shoeId"].ToString();

                // Agregar el displayText, el nombre y el ID al AutoCompleteCustomSource
                autoComplete.Add(displayText);
                autoComplete.Add(nameOnly);
                autoComplete.Add(idOnly);

                // Agregar el displayText al ComboBox
                comboBoxShoes.Items.Add(displayText);
            }

            comboBoxShoes.AutoCompleteCustomSource = autoComplete;

            // Suscribirse al evento KeyDown para detectar Enter
            comboBoxShoes.KeyDown += comboBoxShoes_KeyDown;
        }

        private void comboBoxShoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxShoes.SelectedValue != null && comboBoxShoes.SelectedValue is int)
            //{
            //    int selectedShoeId = (int)comboBoxShoes.SelectedValue;
            //    string selectedShoeName = comboBoxShoes.Text;

            //    // Se podría obtener el precio del DataTable original o hacer una consulta adicional:
            //    ShoeDataAccess shoeData = new ShoeDataAccess();
            //    DataTable dt = shoeData.GetAllShoes(); // esto no es muy eficiente cada vez; se recomienda guardar en memoria
            //    DataRow[] rows = dt.Select("shoeId = " + selectedShoeId);
            //    float price = 0;
            //    if (rows.Length > 0)
            //    {
            //        price = Convert.ToSingle(rows[0]["price"]);
            //    }

            //    // Agregar fila al DataGridView
            //    // Asumiendo columnas: ShoeID, ShoeName, Quantity, UnitPrice, Discount
            //    dataGridView2.Rows.Add(selectedShoeId, selectedShoeName, 1, price, 0);
            //    dataGridView2.ClearSelection();
            //}
        }

        private void comboBoxShoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string text = comboBoxShoes.Text.Trim();

                if (string.IsNullOrEmpty(text))
                {
                    // Si no se ingresó nada, no hacer nada
                    return;
                }

                int shoeId;
                bool idFound = false;

                // Intentar parsear el texto como ID
                if (int.TryParse(text, out shoeId))
                {
                    idFound = true;
                }

                if (idFound)
                {
                    // Buscar por ID exacto
                    DataRow[] rows = shoesTable.Select($"shoeId = {shoeId}");
                    if (rows.Length > 0)
                    {
                        AddShoeToGrid(rows[0]);
                        dataGridView2.ClearSelection();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún zapato con ese ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridView2.ClearSelection();
                        return;
                    }
                }
                else
                {
                    // Buscar por DisplayText exacto
                    DataRow[] exactDisplayRows = shoesTable.Select($"DisplayText = '{text.Replace("'", "''")}'");
                    if (exactDisplayRows.Length == 1)
                    {
                        AddShoeToGrid(exactDisplayRows[0]);
                        dataGridView2.ClearSelection();
                        return;
                    }

                    // Buscar por nombre exacto
                    DataRow[] exactNameRows = shoesTable.Select($"shoeName = '{text.Replace("'", "''")}'");
                    if (exactNameRows.Length == 1)
                    {
                        AddShoeToGrid(exactNameRows[0]);
                        dataGridView2.ClearSelection();
                        return;
                    }
                    else if (exactNameRows.Length > 1)
                    {
                        // Tomar la primera coincidencia exacta
                        AddShoeToGrid(exactNameRows[0]);
                        dataGridView2.ClearSelection();
                        return;
                    }

                    // Buscar por coincidencia parcial en cualquier parte del nombre
                    DataRow[] partialNameRows = shoesTable.Select($"shoeName LIKE '%{text.Replace("'", "''")}%'");
                    if (partialNameRows.Length == 1)
                    {
                        AddShoeToGrid(partialNameRows[0]);
                        dataGridView2.ClearSelection();
                        return;
                    }
                    else if (partialNameRows.Length > 1)
                    {
                        MessageBox.Show("Se encontraron múltiples coincidencias, especifique más el nombre o el ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridView2.ClearSelection();
                        return;
                    }

                    // Intentar parsear el texto como parte de DisplayText (e.g., "1032 - Waterproof Hiking Boot")
                    string[] parts = text.Split(new string[] { " - " }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        string idPart = parts[0];
                        if (int.TryParse(idPart, out shoeId))
                        {
                            DataRow[] displayRows = shoesTable.Select($"shoeId = {shoeId}");
                            if (displayRows.Length > 0)
                            {
                                AddShoeToGrid(displayRows[0]);
                                dataGridView2.ClearSelection();
                                return;
                            }
                        }
                    }

                    // Sin coincidencias
                    MessageBox.Show("No se encontró ninguna coincidencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView2.ClearSelection();
                    return;
                }
            }
        }

        private void AddShoeToGrid(DataRow shoeRow)
        {
            int shoeId = Convert.ToInt32(shoeRow["shoeId"]);
            string name = shoeRow["shoeName"].ToString();
            float price = Convert.ToSingle(shoeRow["price"]);

            // Agregar al DataGridView una fila con la información del zapato
            dataGridView2.Rows.Add(shoeId, name, 1, price, 0);

            // Opcional: limpiar el texto del combo
            comboBoxShoes.Text = "";
            comboBoxShoes.SelectedIndex = -1;

            UpdateTotals();
        }

        private void UC_Sell_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Obtener el valor del descuento como decimal (ej. 15% = 0.15)
            decimal discountPercentage = numericUpDown1.Value / 100m;

            // Aplicar el descuento al subtotal
            decimal discountedSubtotal = subtotal * (1 - discountPercentage);

            // Calcular el impuesto sobre el subtotal descontado
            decimal taxAmount = discountedSubtotal * 0.13m;

            // Calcular el total
            total = discountedSubtotal + taxAmount;

            // Actualizar los labels
            label14.Text = discountedSubtotal.ToString("C2", CultureInfo.GetCultureInfo("en-US")); // Subtotal después del descuento
            label11.Text = taxAmount.ToString("C2", CultureInfo.GetCultureInfo("en-US"));        // Impuesto 13%
            label12.Text = total.ToString("C2", CultureInfo.GetCultureInfo("en-US"));            // Total

            UpdateTotals();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotals();
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateTotals();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se cambió la cantidad o el precio
            if (e.RowIndex >= 0 && (e.ColumnIndex == dataGridView2.Columns["Quantity"].Index ||
                                    e.ColumnIndex == dataGridView2.Columns["UnitPrice"].Index))
            {
                UpdateTotals();
            }
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Validación de celdas para evitar valores inválidos
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Quantity")
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int quantity) || quantity < 1)
                {
                    dataGridView2.Rows[e.RowIndex].ErrorText = "La cantidad debe ser un número entero mayor que 0.";
                    e.Cancel = true;
                }
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "UnitPrice")
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal price) || price < 0)
                {
                    dataGridView2.Rows[e.RowIndex].ErrorText = "El precio unitario debe ser un número válido y no negativo.";
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Limpiar el mensaje de error después de editar
            dataGridView2.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    }
}
