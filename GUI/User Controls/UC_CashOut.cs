using Calzado_Ulacit.Persistencia;
using Guna.UI2.WinForms.Suite;
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
    public partial class UC_CashOut : UserControl
    {
        public UC_CashOut()
        {
            InitializeComponent();
        }

        private void UC_CashOut_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-7); // Fecha inicial (una semana antes)
            dateTimePicker2.Value = DateTime.Now.AddDays(1); // Fecha final (hoy)

            button4_Click(sender, e); // Cargar datos iniciales
        }


        // Botón de buscar Facturas por fecha
        private void button4_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;


            if (startDate > endDate)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InvoiceDataAccess dataAccess = new InvoiceDataAccess();
            DataTable salesData = dataAccess.GetSalesByDateRange(startDate, endDate);

            //Si hay filas seleccionadas entonces...
            if (salesData.Rows.Count > 0)
            {
                // Asignar los datos al DataGridView
                dataGridView1.DataSource = salesData;

                dataGridView1.Columns["invoiceId"].HeaderText = "Invoice ID";
                dataGridView1.Columns["cltId"].HeaderText = "Client ID";
                dataGridView1.Columns["CltName"].HeaderText = "Client Name";
                dataGridView1.Columns["invoiceDate"].HeaderText = "Invoice Date";
                dataGridView1.Columns["invoiceDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["discount"].HeaderText = "Discount";


                // Formatear la columna Invoice Total
                var usdStyle = new DataGridViewCellStyle
                {
                    Format = "C", // Formato de moneda
                    FormatProvider = new System.Globalization.CultureInfo("en-US") // Cultura USD
                };
                dataGridView1.Columns["totalAmount"].DefaultCellStyle = usdStyle;
                dataGridView1.Columns["totalAmount"].HeaderText = "Invoice Total";
                dataGridView1.Columns["PaymentMethod"].HeaderText = "Payment Method";
                dataGridView1.Columns["PaymentMethod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Obtener el total directamente de los datos, manejando nulos
                decimal total = salesData.AsEnumerable()
                    .Where(row => !row.IsNull("totalAmount")) // Ignorar valores nulos
                    .Sum(row => Convert.ToDecimal(row["totalAmount"])); // Conversión segura

                // Formatear el total en el Label como dólar estadounidense
                label3.Text = $"Grand Total: {total.ToString("C", new System.Globalization.CultureInfo("en-US"))}";
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el rango de fechas seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                label3.Text = "Grand Total: $0.00";
            }
        }
    }
}
