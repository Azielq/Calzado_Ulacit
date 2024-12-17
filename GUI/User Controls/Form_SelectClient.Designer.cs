namespace Calzado_Ulacit.GUI.User_Controls
{
    partial class Form_SelectClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cltIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltPhoneNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ulacitShoesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ulacitShoesDataSet = new Calzado_Ulacit.UlacitShoesDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.ulacitShoesDataSet1 = new Calzado_Ulacit.UlacitShoesDataSet1();
            this.ulacitShoesDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsTableAdapter = new Calzado_Ulacit.UlacitShoesDataSetTableAdapters.ClientsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(208)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(51)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(51)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cltIdDataGridViewTextBoxColumn,
            this.cltNameDataGridViewTextBoxColumn,
            this.cltLastNameDataGridViewTextBoxColumn,
            this.cltAddressDataGridViewTextBoxColumn,
            this.cltPhoneNumDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clientsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semilight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(834, 420);
            this.dataGridView1.TabIndex = 14;
            // 
            // cltIdDataGridViewTextBoxColumn
            // 
            this.cltIdDataGridViewTextBoxColumn.DataPropertyName = "cltId";
            this.cltIdDataGridViewTextBoxColumn.HeaderText = "ID";
            this.cltIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cltIdDataGridViewTextBoxColumn.Name = "cltIdDataGridViewTextBoxColumn";
            this.cltIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.cltIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // cltNameDataGridViewTextBoxColumn
            // 
            this.cltNameDataGridViewTextBoxColumn.DataPropertyName = "cltName";
            this.cltNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.cltNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cltNameDataGridViewTextBoxColumn.Name = "cltNameDataGridViewTextBoxColumn";
            this.cltNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cltNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // cltLastNameDataGridViewTextBoxColumn
            // 
            this.cltLastNameDataGridViewTextBoxColumn.DataPropertyName = "cltLastName";
            this.cltLastNameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.cltLastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cltLastNameDataGridViewTextBoxColumn.Name = "cltLastNameDataGridViewTextBoxColumn";
            this.cltLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cltLastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // cltAddressDataGridViewTextBoxColumn
            // 
            this.cltAddressDataGridViewTextBoxColumn.DataPropertyName = "cltAddress";
            this.cltAddressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.cltAddressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cltAddressDataGridViewTextBoxColumn.Name = "cltAddressDataGridViewTextBoxColumn";
            this.cltAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.cltAddressDataGridViewTextBoxColumn.Width = 125;
            // 
            // cltPhoneNumDataGridViewTextBoxColumn
            // 
            this.cltPhoneNumDataGridViewTextBoxColumn.DataPropertyName = "cltPhoneNum";
            this.cltPhoneNumDataGridViewTextBoxColumn.HeaderText = "Phone Num";
            this.cltPhoneNumDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cltPhoneNumDataGridViewTextBoxColumn.Name = "cltPhoneNumDataGridViewTextBoxColumn";
            this.cltPhoneNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.cltPhoneNumDataGridViewTextBoxColumn.Width = 125;
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.ulacitShoesDataSetBindingSource;
            // 
            // ulacitShoesDataSetBindingSource
            // 
            this.ulacitShoesDataSetBindingSource.DataSource = this.ulacitShoesDataSet;
            this.ulacitShoesDataSetBindingSource.Position = 0;
            // 
            // ulacitShoesDataSet
            // 
            this.ulacitShoesDataSet.DataSetName = "UlacitShoesDataSet";
            this.ulacitShoesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 54);
            this.label2.TabIndex = 15;
            this.label2.Text = "Select a client";
            // 
            // ulacitShoesDataSet1
            // 
            this.ulacitShoesDataSet1.DataSetName = "UlacitShoesDataSet1";
            this.ulacitShoesDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ulacitShoesDataSet1BindingSource
            // 
            this.ulacitShoesDataSet1BindingSource.DataSource = this.ulacitShoesDataSet1;
            this.ulacitShoesDataSet1BindingSource.Position = 0;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(72)))), ((int)(((byte)(181)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(357, 533);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 31);
            this.label6.TabIndex = 34;
            this.label6.Text = "Clients Table";
            // 
            // Form_SelectClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 607);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_SelectClient";
            this.ShowIcon = false;
            this.Text = "Select a Client";
            this.Load += new System.EventHandler(this.Form_SelectClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ulacitShoesDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource ulacitShoesDataSetBindingSource;
        private UlacitShoesDataSet ulacitShoesDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource ulacitShoesDataSet1BindingSource;
        private UlacitShoesDataSet1 ulacitShoesDataSet1;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private UlacitShoesDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltPhoneNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
    }
}