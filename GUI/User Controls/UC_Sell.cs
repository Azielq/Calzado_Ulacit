﻿using Calzado_Ulacit.Persistencia;
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
    public partial class UC_Sell : UserControl
    {
        private DataTable shoesTable; // Variable a nivel de clase para reutilizar

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

            // Crear una columna calculada (o poblada) para "[id] - [shoeName]"
            if (!shoesTable.Columns.Contains("DisplayText"))
            {
                shoesTable.Columns.Add("DisplayText", typeof(string));
            }
            foreach (DataRow row in shoesTable.Rows)
            {
                int id = Convert.ToInt32(row["shoeId"]);
                string name = row["shoeName"].ToString();
                row["DisplayText"] = $"[{id}] - {name}";
            }

            comboBoxShoes.DataSource = shoesTable;
            comboBoxShoes.DisplayMember = "DisplayText";
            comboBoxShoes.ValueMember = "shoeId";
            comboBoxShoes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxShoes.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Autocompletado con la columna DisplayText
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            foreach (DataRow row in shoesTable.Rows)
            {
                autoComplete.Add(row["DisplayText"].ToString());
            }
            comboBoxShoes.AutoCompleteCustomSource = autoComplete;

            // Suscribirse al evento KeyDown para detectar Enter
            comboBoxShoes.KeyDown += comboBoxShoes_KeyDown;
        }

        private void comboBoxShoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxShoes.SelectedValue != null && comboBoxShoes.SelectedValue is int)
            {
                int selectedShoeId = (int)comboBoxShoes.SelectedValue;
                string selectedShoeName = comboBoxShoes.Text;

                // Se podría obtener el precio del DataTable original o hacer una consulta adicional:
                ShoeDataAccess shoeData = new ShoeDataAccess();
                DataTable dt = shoeData.GetAllShoes(); // esto no es muy eficiente cada vez; se recomienda guardar en memoria
                DataRow[] rows = dt.Select("shoeId = " + selectedShoeId);
                float price = 0;
                if (rows.Length > 0)
                {
                    price = Convert.ToSingle(rows[0]["price"]);
                }

                // Agregar fila al DataGridView
                // Asumiendo columnas: ShoeID, ShoeName, Quantity, UnitPrice, Discount
                dataGridView2.Rows.Add(selectedShoeId, selectedShoeName, 1, price, 0);
            }
        }

        private void comboBoxShoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el behavior por defecto del combo
                string text = comboBoxShoes.Text.Trim();

                int shoeId = 0;
                bool idFound = false;

                // Intentar parsear el ID desde el texto (formato "[id] - nombre" o solo id)
                if (text.StartsWith("[") && text.Contains("]"))
                {
                    int endBracketIndex = text.IndexOf(']');
                    string idPart = text.Substring(1, endBracketIndex - 1);
                    if (int.TryParse(idPart, out shoeId))
                    {
                        idFound = true;
                    }
                }
                else
                {
                    // Intento directo: ¿ingresó solo un número?
                    if (int.TryParse(text, out shoeId))
                    {
                        idFound = true;
                    }
                }

                if (idFound)
                {
                    // Buscar por ID exacto
                    DataRow[] rows = shoesTable.Select($"shoeId = {shoeId}");
                    if (rows.Length > 0)
                    {
                        AddShoeToGrid(rows[0]);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún zapato con ese ID.");
                        return;
                    }
                }
                else
                {
                    // Si no es ID, intentamos coincidencia exacta en DisplayText
                    DataRow[] exactRows = shoesTable.Select($"DisplayText = '{text.Replace("'", "''")}'");
                    if (exactRows.Length == 1)
                    {
                        // Coincidencia exacta en DisplayText
                        AddShoeToGrid(exactRows[0]);
                        return;
                    }
                    else if (exactRows.Length > 1)
                    {
                        // Si por alguna razón hay múltiples filas con el mismo DisplayText exacto
                        // (algo improbable si el ID es único), se toma la primera.
                        AddShoeToGrid(exactRows[0]);
                        return;
                    }

                    // Si no hay coincidencia exacta, probar con LIKE para coincidencias parciales
                    DataRow[] partialRows = shoesTable.Select($"DisplayText LIKE '%{text.Replace("'", "''")}%'");
                    if (partialRows.Length == 1)
                    {
                        // Una sola coincidencia parcial
                        AddShoeToGrid(partialRows[0]);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ninguna coincidencia.");
                    }
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
        }
    }
}
