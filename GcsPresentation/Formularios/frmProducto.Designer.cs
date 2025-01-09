namespace GcsPresentation.Formularios
{
    partial class frmProducto
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
            label1 = new Label();
            label6 = new Label();
            btnGuardarEditar = new Button();
            btnVolverEditar = new Button();
            btnGuardarNuevo = new Button();
            btnVolverNuevo = new Button();
            comboBoxCategoriaNuevo = new ComboBox();
            label3 = new Label();
            comboBoxHabilitado = new ComboBox();
            tabEditar = new TabPage();
            label4 = new Label();
            textBoxCantidadEditar = new NumericUpDown();
            textBoxPrecioVentaEditar = new TextBox();
            label5 = new Label();
            textBoxDescripcionEditar = new TextBox();
            label11 = new Label();
            textBoxCodigoEditar = new TextBox();
            label12 = new Label();
            comboBoxCategoriaEditar = new ComboBox();
            label13 = new Label();
            textBoxPrecioCompraEditar = new TextBox();
            label14 = new Label();
            textBoxPrecioCompraNuevo = new TextBox();
            tabNuevo = new TabPage();
            label10 = new Label();
            textBoxCantidadNuevo = new NumericUpDown();
            textBoxPrecioVentaNuevo = new TextBox();
            label9 = new Label();
            textBoxDescripcionNuevo = new TextBox();
            label8 = new Label();
            textBoxCodigoNuevo = new TextBox();
            label7 = new Label();
            label2 = new Label();
            dataGridViewProductos = new DataGridView();
            btnBuscar = new Button();
            textBoxBuscar = new TextBox();
            btnNuevoLista = new Button();
            tabLista = new TabPage();
            tabControlMain = new TabControl();
            tabEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxCantidadEditar).BeginInit();
            tabNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxCantidadNuevo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            tabLista.SuspendLayout();
            tabControlMain.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 3;
            label1.Text = "Inventario / Producto";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 188);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 12;
            label6.Text = "Habilitado:";
            // 
            // btnGuardarEditar
            // 
            btnGuardarEditar.BackColor = Color.White;
            btnGuardarEditar.Cursor = Cursors.Hand;
            btnGuardarEditar.FlatStyle = FlatStyle.Flat;
            btnGuardarEditar.ForeColor = Color.FromArgb(30, 90, 195);
            btnGuardarEditar.Location = new Point(623, 268);
            btnGuardarEditar.Name = "btnGuardarEditar";
            btnGuardarEditar.Size = new Size(75, 23);
            btnGuardarEditar.TabIndex = 11;
            btnGuardarEditar.Text = "Guardar";
            btnGuardarEditar.UseVisualStyleBackColor = false;
            // 
            // btnVolverEditar
            // 
            btnVolverEditar.BackColor = Color.White;
            btnVolverEditar.Cursor = Cursors.Hand;
            btnVolverEditar.FlatStyle = FlatStyle.Flat;
            btnVolverEditar.Location = new Point(35, 268);
            btnVolverEditar.Name = "btnVolverEditar";
            btnVolverEditar.Size = new Size(75, 23);
            btnVolverEditar.TabIndex = 10;
            btnVolverEditar.Text = "Volver";
            btnVolverEditar.UseVisualStyleBackColor = false;
            // 
            // btnGuardarNuevo
            // 
            btnGuardarNuevo.BackColor = Color.White;
            btnGuardarNuevo.Cursor = Cursors.Hand;
            btnGuardarNuevo.FlatStyle = FlatStyle.Flat;
            btnGuardarNuevo.ForeColor = Color.FromArgb(30, 90, 195);
            btnGuardarNuevo.Location = new Point(623, 270);
            btnGuardarNuevo.Name = "btnGuardarNuevo";
            btnGuardarNuevo.Size = new Size(75, 23);
            btnGuardarNuevo.TabIndex = 5;
            btnGuardarNuevo.Text = "Guardar";
            btnGuardarNuevo.UseVisualStyleBackColor = false;
            // 
            // btnVolverNuevo
            // 
            btnVolverNuevo.BackColor = Color.White;
            btnVolverNuevo.Cursor = Cursors.Hand;
            btnVolverNuevo.FlatStyle = FlatStyle.Flat;
            btnVolverNuevo.Location = new Point(35, 270);
            btnVolverNuevo.Name = "btnVolverNuevo";
            btnVolverNuevo.Size = new Size(75, 23);
            btnVolverNuevo.TabIndex = 4;
            btnVolverNuevo.Text = "Volver";
            btnVolverNuevo.UseVisualStyleBackColor = false;
            btnVolverNuevo.Click += btnVolverNuevo_Click;
            // 
            // comboBoxCategoriaNuevo
            // 
            comboBoxCategoriaNuevo.Cursor = Cursors.Hand;
            comboBoxCategoriaNuevo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoriaNuevo.FormattingEnabled = true;
            comboBoxCategoriaNuevo.Location = new Point(35, 35);
            comboBoxCategoriaNuevo.Name = "comboBoxCategoriaNuevo";
            comboBoxCategoriaNuevo.Size = new Size(311, 23);
            comboBoxCategoriaNuevo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 20);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Categoría:";
            // 
            // comboBoxHabilitado
            // 
            comboBoxHabilitado.Cursor = Cursors.Hand;
            comboBoxHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHabilitado.FormattingEnabled = true;
            comboBoxHabilitado.Location = new Point(35, 203);
            comboBoxHabilitado.Name = "comboBoxHabilitado";
            comboBoxHabilitado.Size = new Size(104, 23);
            comboBoxHabilitado.TabIndex = 13;
            // 
            // tabEditar
            // 
            tabEditar.Controls.Add(label4);
            tabEditar.Controls.Add(textBoxCantidadEditar);
            tabEditar.Controls.Add(textBoxPrecioVentaEditar);
            tabEditar.Controls.Add(label5);
            tabEditar.Controls.Add(textBoxDescripcionEditar);
            tabEditar.Controls.Add(label11);
            tabEditar.Controls.Add(textBoxCodigoEditar);
            tabEditar.Controls.Add(label12);
            tabEditar.Controls.Add(comboBoxCategoriaEditar);
            tabEditar.Controls.Add(label13);
            tabEditar.Controls.Add(textBoxPrecioCompraEditar);
            tabEditar.Controls.Add(label14);
            tabEditar.Controls.Add(comboBoxHabilitado);
            tabEditar.Controls.Add(label6);
            tabEditar.Controls.Add(btnGuardarEditar);
            tabEditar.Controls.Add(btnVolverEditar);
            tabEditar.Location = new Point(4, 24);
            tabEditar.Name = "tabEditar";
            tabEditar.Padding = new Padding(3);
            tabEditar.Size = new Size(732, 316);
            tabEditar.TabIndex = 2;
            tabEditar.Text = "Editar";
            tabEditar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(390, 128);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 25;
            label4.Text = "Cantidad:";
            // 
            // textBoxCantidadEditar
            // 
            textBoxCantidadEditar.Location = new Point(387, 146);
            textBoxCantidadEditar.Name = "textBoxCantidadEditar";
            textBoxCantidadEditar.Size = new Size(120, 23);
            textBoxCantidadEditar.TabIndex = 24;
            // 
            // textBoxPrecioVentaEditar
            // 
            textBoxPrecioVentaEditar.Location = new Point(387, 89);
            textBoxPrecioVentaEditar.Name = "textBoxPrecioVentaEditar";
            textBoxPrecioVentaEditar.Size = new Size(311, 23);
            textBoxPrecioVentaEditar.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(390, 74);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 22;
            label5.Text = "Precio Venta:";
            // 
            // textBoxDescripcionEditar
            // 
            textBoxDescripcionEditar.Location = new Point(35, 146);
            textBoxDescripcionEditar.Name = "textBoxDescripcionEditar";
            textBoxDescripcionEditar.Size = new Size(311, 23);
            textBoxDescripcionEditar.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(38, 131);
            label11.Name = "label11";
            label11.Size = new Size(72, 15);
            label11.TabIndex = 20;
            label11.Text = "Descripción:";
            // 
            // textBoxCodigoEditar
            // 
            textBoxCodigoEditar.Location = new Point(35, 89);
            textBoxCodigoEditar.Name = "textBoxCodigoEditar";
            textBoxCodigoEditar.Size = new Size(311, 23);
            textBoxCodigoEditar.TabIndex = 19;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(38, 74);
            label12.Name = "label12";
            label12.Size = new Size(49, 15);
            label12.TabIndex = 18;
            label12.Text = "Código:";
            // 
            // comboBoxCategoriaEditar
            // 
            comboBoxCategoriaEditar.Cursor = Cursors.Hand;
            comboBoxCategoriaEditar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoriaEditar.FormattingEnabled = true;
            comboBoxCategoriaEditar.Location = new Point(35, 35);
            comboBoxCategoriaEditar.Name = "comboBoxCategoriaEditar";
            comboBoxCategoriaEditar.Size = new Size(311, 23);
            comboBoxCategoriaEditar.TabIndex = 17;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(38, 20);
            label13.Name = "label13";
            label13.Size = new Size(61, 15);
            label13.TabIndex = 16;
            label13.Text = "Categoría:";
            // 
            // textBoxPrecioCompraEditar
            // 
            textBoxPrecioCompraEditar.Location = new Point(387, 35);
            textBoxPrecioCompraEditar.Name = "textBoxPrecioCompraEditar";
            textBoxPrecioCompraEditar.Size = new Size(311, 23);
            textBoxPrecioCompraEditar.TabIndex = 15;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(390, 20);
            label14.Name = "label14";
            label14.Size = new Size(89, 15);
            label14.TabIndex = 14;
            label14.Text = "Precio Compra:";
            // 
            // textBoxPrecioCompraNuevo
            // 
            textBoxPrecioCompraNuevo.Location = new Point(387, 35);
            textBoxPrecioCompraNuevo.Name = "textBoxPrecioCompraNuevo";
            textBoxPrecioCompraNuevo.Size = new Size(311, 23);
            textBoxPrecioCompraNuevo.TabIndex = 1;
            // 
            // tabNuevo
            // 
            tabNuevo.Controls.Add(label10);
            tabNuevo.Controls.Add(textBoxCantidadNuevo);
            tabNuevo.Controls.Add(textBoxPrecioVentaNuevo);
            tabNuevo.Controls.Add(label9);
            tabNuevo.Controls.Add(textBoxDescripcionNuevo);
            tabNuevo.Controls.Add(label8);
            tabNuevo.Controls.Add(textBoxCodigoNuevo);
            tabNuevo.Controls.Add(label7);
            tabNuevo.Controls.Add(btnGuardarNuevo);
            tabNuevo.Controls.Add(btnVolverNuevo);
            tabNuevo.Controls.Add(comboBoxCategoriaNuevo);
            tabNuevo.Controls.Add(label3);
            tabNuevo.Controls.Add(textBoxPrecioCompraNuevo);
            tabNuevo.Controls.Add(label2);
            tabNuevo.Location = new Point(4, 24);
            tabNuevo.Name = "tabNuevo";
            tabNuevo.Padding = new Padding(3);
            tabNuevo.Size = new Size(732, 316);
            tabNuevo.TabIndex = 1;
            tabNuevo.Text = "Nuevo";
            tabNuevo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(390, 128);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 13;
            label10.Text = "Cantidad:";
            // 
            // textBoxCantidadNuevo
            // 
            textBoxCantidadNuevo.Location = new Point(387, 146);
            textBoxCantidadNuevo.Name = "textBoxCantidadNuevo";
            textBoxCantidadNuevo.Size = new Size(120, 23);
            textBoxCantidadNuevo.TabIndex = 12;
            // 
            // textBoxPrecioVentaNuevo
            // 
            textBoxPrecioVentaNuevo.Location = new Point(387, 89);
            textBoxPrecioVentaNuevo.Name = "textBoxPrecioVentaNuevo";
            textBoxPrecioVentaNuevo.Size = new Size(311, 23);
            textBoxPrecioVentaNuevo.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(390, 74);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 10;
            label9.Text = "Precio Venta:";
            // 
            // textBoxDescripcionNuevo
            // 
            textBoxDescripcionNuevo.Location = new Point(35, 146);
            textBoxDescripcionNuevo.Name = "textBoxDescripcionNuevo";
            textBoxDescripcionNuevo.Size = new Size(311, 23);
            textBoxDescripcionNuevo.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(38, 131);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 8;
            label8.Text = "Descripción:";
            // 
            // textBoxCodigoNuevo
            // 
            textBoxCodigoNuevo.Location = new Point(35, 89);
            textBoxCodigoNuevo.Name = "textBoxCodigoNuevo";
            textBoxCodigoNuevo.Size = new Size(311, 23);
            textBoxCodigoNuevo.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(38, 74);
            label7.Name = "label7";
            label7.Size = new Size(49, 15);
            label7.TabIndex = 6;
            label7.Text = "Código:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(390, 20);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 0;
            label2.Text = "Precio Compra:";
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Location = new Point(22, 57);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.Size = new Size(685, 253);
            dataGridViewProductos.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(632, 18);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(403, 18);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(201, 23);
            textBoxBuscar.TabIndex = 1;
            // 
            // btnNuevoLista
            // 
            btnNuevoLista.BackColor = Color.White;
            btnNuevoLista.Cursor = Cursors.Hand;
            btnNuevoLista.FlatStyle = FlatStyle.Flat;
            btnNuevoLista.Location = new Point(22, 18);
            btnNuevoLista.Name = "btnNuevoLista";
            btnNuevoLista.Size = new Size(75, 23);
            btnNuevoLista.TabIndex = 0;
            btnNuevoLista.Text = "Nuevo";
            btnNuevoLista.UseVisualStyleBackColor = false;
            btnNuevoLista.Click += btnNuevoLista_Click;
            // 
            // tabLista
            // 
            tabLista.Controls.Add(dataGridViewProductos);
            tabLista.Controls.Add(btnBuscar);
            tabLista.Controls.Add(textBoxBuscar);
            tabLista.Controls.Add(btnNuevoLista);
            tabLista.Location = new Point(4, 24);
            tabLista.Name = "tabLista";
            tabLista.Padding = new Padding(3);
            tabLista.Size = new Size(732, 316);
            tabLista.TabIndex = 0;
            tabLista.Text = "Lista";
            tabLista.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabLista);
            tabControlMain.Controls.Add(tabNuevo);
            tabControlMain.Controls.Add(tabEditar);
            tabControlMain.ItemSize = new Size(80, 20);
            tabControlMain.Location = new Point(12, 47);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(740, 344);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 2;
            // 
            // frmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 407);
            Controls.Add(label1);
            Controls.Add(tabControlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProducto";
            Load += frmProducto_Load;
            tabEditar.ResumeLayout(false);
            tabEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxCantidadEditar).EndInit();
            tabNuevo.ResumeLayout(false);
            tabNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBoxCantidadNuevo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            tabLista.ResumeLayout(false);
            tabLista.PerformLayout();
            tabControlMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label6;
        private Button btnGuardarEditar;
        private Button btnVolverEditar;
        private Button btnGuardarNuevo;
        private Button btnVolverNuevo;
        private ComboBox comboBoxCategoriaNuevo;
        private Label label3;
        private ComboBox comboBoxHabilitado;
        private TabPage tabEditar;
        private TextBox textBoxPrecioCompraNuevo;
        private TabPage tabNuevo;
        private Label label2;
        private DataGridView dataGridViewProductos;
        private Button btnBuscar;
        private TextBox textBoxBuscar;
        private Button btnNuevoLista;
        private TabPage tabLista;
        private TabControl tabControlMain;
        private TextBox textBoxDescripcionNuevo;
        private Label label8;
        private TextBox textBoxCodigoNuevo;
        private Label label7;
        private Label label10;
        private NumericUpDown textBoxCantidadNuevo;
        private TextBox textBoxPrecioVentaNuevo;
        private Label label9;
        private Label label4;
        private NumericUpDown textBoxCantidadEditar;
        private TextBox textBoxPrecioVentaEditar;
        private Label label5;
        private TextBox textBoxDescripcionEditar;
        private Label label11;
        private TextBox textBoxCodigoEditar;
        private Label label12;
        private ComboBox comboBoxCategoriaEditar;
        private Label label13;
        private TextBox textBoxPrecioCompraEditar;
        private Label label14;
    }
}