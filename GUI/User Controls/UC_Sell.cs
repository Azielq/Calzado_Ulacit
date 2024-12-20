using Calzado_Ulacit.Logica;
using Calzado_Ulacit.Persistencia;
using Calzado_Ulacit.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        private int cltId;


        public UC_Sell()
        {
            InitializeComponent();
            button1.Enabled = false; // Deshabilitar inicialmente
        }

        private void UC_Sell_Load(object sender, EventArgs e)
        {
            LoadShoesIntoComboBox();
            UpdateTotals();

            // Configurar el formato de moneda en la columna Unit Price
            if (dataGridView2.Columns["UnitPrice"] != null)
            {
                var usdStyle = new DataGridViewCellStyle
                {
                    Format = "C2", // Formato de moneda con 2 decimales
                    FormatProvider = CultureInfo.GetCultureInfo("en-US") // Cultura para dólar estadounidense
                };
                dataGridView2.Columns["UnitPrice"].DefaultCellStyle = usdStyle;
            }
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

                // Asignar el ID del cliente seleccionado al label7 y a la variable clientId
                label7.Text = selectClientForm.SelectedClientID.ToString();
                cltId = selectClientForm.SelectedClientID; // Asignar a la variable de clase

                // Habilitar el botón de generación de factura
                button1.Enabled = true;
            }
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

        //Evento para añadir al datagrid un zapato al presionar la tecla enter
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
            //Guardar los datos que van en el datagrid en variables
            int shoeId = Convert.ToInt32(shoeRow["shoeId"]);
            string name = shoeRow["shoeName"].ToString();
            float price = Convert.ToSingle(shoeRow["price"]);
            int stock = Convert.ToInt32(shoeRow["Stock"]);

            if (stock <= 0)
            {
                MessageBox.Show($"No hay stock disponible para el zapato {name}.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Agregar al DataGridView una fila con la información del zapato
            dataGridView2.Rows.Add(shoeId, name, 1, price, 0);

            // Opcional: limpiar el texto del combo
            comboBoxShoes.Text = "";
            comboBoxShoes.SelectedIndex = -1;

            UpdateTotals();
        }

        //Esto es para poder deseleccionar las filas del datagrid al clickar fuera
        private void UC_Sell_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }


        //Metodo que configura el input numérico del descuento
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


        //Button SELL
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // **1. Verificar que se haya seleccionado un cliente**
                if (cltId <= 0)
                {
                    MessageBox.Show("Por favor, selecciona un cliente antes de generar la factura.", "Cliente No Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // **2. Validar que haya al menos un ítem en la factura**
                if (dataGridView2.Rows.Count == 0 || (dataGridView2.Rows.Count == 1 && dataGridView2.Rows[0].IsNewRow))
                {
                    MessageBox.Show("No hay ítems en la factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar stock antes de proceder
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    int shoeId = Convert.ToInt32(row.Cells["ShoeID"].Value); // ID del zapato
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value); // Cantidad solicitada

                    // Obtener el stock actual del zapato desde la base de datos
                    ShoeDataAccess shoeDataAcces = new ShoeDataAccess();
                    int currentStock = shoeDataAcces.GetStockById(shoeId);

                    // Verificar si hay suficiente stock
                    if (currentStock < quantity)
                    {
                        MessageBox.Show($"No hay suficiente stock para el zapato con ID {shoeId}. Stock disponible: {currentStock}.",
                                        "Stock Insuficiente",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                }

                // **3. Verificar si el cliente existe en la base de datos**
                InvoiceDataAccess invoiceDataAccess = new InvoiceDataAccess();
                ShoeDataAccess shoeDataAccess = new ShoeDataAccess();

                if (!invoiceDataAccess.ClientExists(cltId))
                {
                    MessageBox.Show("El cliente seleccionado no existe en la base de datos.", "Error de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // **4. Obtener el método de pago seleccionado**
                string selectedPaymentMethod = GetSelectedPaymentMethod();
                if (string.IsNullOrEmpty(selectedPaymentMethod))
                {
                    MessageBox.Show("Por favor, selecciona un método de pago.", "Método de Pago No Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // **5. Crear instancia de Invoice**
                Invoice invoice = new Invoice
                {
                    cltId = cltId, // Asegúrate de que cltId esté asignado correctamente y coincide con la base de datos
                    InvoiceDate = DateTime.Now,
                    Discount = numericUpDown1.Value / 100m, // Convertir porcentaje a decimal
                    TotalAmount = total,
                    PaymentMethod = selectedPaymentMethod // Asignar el método de pago
                };

                // **6. Crear lista de ítems**
                List<InvoiceItem> items = new List<InvoiceItem>();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    int shoeId = Convert.ToInt32(row.Cells["ShoeID"].Value); // Usa el nombre correcto de la columna
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                    decimal discount = Convert.ToDecimal(row.Cells["Discount"].Value);

                    // Obtener el nombre del zapato
                    string shoeName = shoeDataAccess.GetShoeNameById(shoeId);

                    InvoiceItem item = new InvoiceItem
                    {
                        ShoeId = shoeId,
                        ShoeName = shoeName, // Asignar el nombre del zapato
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        Discount = discount
                    };
                    items.Add(item);
                }

                // **7. Guardar la factura en la base de datos**
                invoiceDataAccess.AddInvoice(invoice, items);

                // Actualizar el stock de cada zapato
                foreach (var item in items)
                {
                    shoeDataAccess.ReduceShoeStock(item.ShoeId, item.Quantity);
                }

                // **8. Generar el PDF**
                PDFGenerator pdfGenerator = new PDFGenerator();
                string clientName = label10.Text;
                string pdfDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Facturas");
                if (!Directory.Exists(pdfDirectory))
                {
                    Directory.CreateDirectory(pdfDirectory);
                }
                string pdfPath = Path.Combine(pdfDirectory, $"Factura_{invoice.InvoiceId}.pdf");

                pdfGenerator.GenerateInvoicePDF(invoice, items, clientName, subtotal, tax, total, pdfPath);

                // **9. Mostrar MessageBox de éxito**
                MessageBox.Show($"Factura generada exitosamente.\nPDF guardado en: {pdfPath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // **10. Abrir el PDF automáticamente**
                try
                {
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = pdfPath,
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Factura generada, pero no se pudo abrir el PDF automáticamente.\nPDF guardado en: {pdfPath}\nError: {ex.Message}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // **11. Opcional: Limpiar el formulario después de la facturación**
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar el formulario después de la facturación
        private void ClearForm()
        {
            dataGridView2.Rows.Clear();
            label10.Text = string.Empty;
            label7.Text = string.Empty;
            numericUpDown1.Value = 0;
            UpdateTotals();

            // Deshabilitar el botón de generación de factura hasta que se seleccione un nuevo cliente
            button1.Enabled = false;
            cltId = 0; // Reiniciar clientId

            // Restablecer la selección de método de pago
            radioButton1.Checked = true; // Seleccionar el primer método por defecto
        }

        
        private string GetSelectedPaymentMethod()
        {
            if (radioButton1.Checked)
                return "Cash";
            if (radioButton2.Checked)
                return "Credit Card";

            return string.Empty;
        }

        private void comboBoxShoes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
