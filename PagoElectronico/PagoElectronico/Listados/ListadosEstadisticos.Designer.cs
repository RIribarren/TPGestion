namespace PagoElectronico.Listados
{
    partial class ListadosEstadisticos
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
            this.gBox1 = new PagoElectronico.WidgetsGUI.GBox();
            this.comboListado = new PagoElectronico.WidgetsGUI.ComboValidable();
            this.comboTrimestre = new PagoElectronico.WidgetsGUI.ComboValidable();
            this.comboAnio = new PagoElectronico.WidgetsGUI.ComboValidable();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gBox2 = new PagoElectronico.WidgetsGUI.GBox();
            this.dataGridPaises = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridTransferencias = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridComisiones = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comisiones_Facturadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridInhabilitaciones = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inhabilitaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridTipoCuentas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBox1.SuspendLayout();
            this.gBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPaises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransferencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComisiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInhabilitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTipoCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.comboListado);
            this.gBox1.Controls.Add(this.comboTrimestre);
            this.gBox1.Controls.Add(this.comboAnio);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(537, 80);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Datos del listado";
            // 
            // comboListado
            // 
            this.comboListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboListado.FormattingEnabled = true;
            this.comboListado.Items.AddRange(new object[] {
            "Inhabilitaciones de cuentas de clientes",
            "Clientes con mayor cantidad de comisiones facturadas",
            "Clientes con mayor cantidad de transacciones entre cuentas propias",
            "Paises con mayor cantidad de movimientos",
            "Total facturado por cada tipo de cuenta"});
            this.comboListado.Location = new System.Drawing.Point(271, 19);
            this.comboListado.Name = "comboListado";
            this.comboListado.Size = new System.Drawing.Size(260, 21);
            this.comboListado.TabIndex = 5;
            this.comboListado.SelectedIndexChanged += new System.EventHandler(this.comboValidable3_SelectedIndexChanged);
            // 
            // comboTrimestre
            // 
            this.comboTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrimestre.FormattingEnabled = true;
            this.comboTrimestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboTrimestre.Location = new System.Drawing.Point(62, 46);
            this.comboTrimestre.Name = "comboTrimestre";
            this.comboTrimestre.Size = new System.Drawing.Size(121, 21);
            this.comboTrimestre.TabIndex = 4;
            this.comboTrimestre.SelectedIndexChanged += new System.EventHandler(this.comboTrimestre_SelectedIndexChanged);
            // 
            // comboAnio
            // 
            this.comboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnio.FormattingEnabled = true;
            this.comboAnio.Location = new System.Drawing.Point(62, 19);
            this.comboAnio.Name = "comboAnio";
            this.comboAnio.Size = new System.Drawing.Size(121, 21);
            this.comboAnio.TabIndex = 3;
            this.comboAnio.SelectedIndexChanged += new System.EventHandler(this.comboAnio_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de listado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trimestre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año";
            // 
            // gBox2
            // 
            this.gBox2.Controls.Add(this.dataGridTipoCuentas);
            this.gBox2.Controls.Add(this.dataGridPaises);
            this.gBox2.Controls.Add(this.dataGridTransferencias);
            this.gBox2.Controls.Add(this.dataGridComisiones);
            this.gBox2.Controls.Add(this.dataGridInhabilitaciones);
            this.gBox2.Location = new System.Drawing.Point(12, 98);
            this.gBox2.Name = "gBox2";
            this.gBox2.Size = new System.Drawing.Size(537, 213);
            this.gBox2.TabIndex = 1;
            this.gBox2.TabStop = false;
            this.gBox2.Text = "Listado Estadístico";
            // 
            // dataGridPaises
            // 
            this.dataGridPaises.AllowUserToAddRows = false;
            this.dataGridPaises.AllowUserToDeleteRows = false;
            this.dataGridPaises.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPaises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPaises.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridPaises.Location = new System.Drawing.Point(9, 19);
            this.dataGridPaises.Name = "dataGridPaises";
            this.dataGridPaises.ReadOnly = true;
            this.dataGridPaises.Size = new System.Drawing.Size(522, 188);
            this.dataGridPaises.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "País";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Ingresos";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Egresos";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridTransferencias
            // 
            this.dataGridTransferencias.AllowUserToAddRows = false;
            this.dataGridTransferencias.AllowUserToDeleteRows = false;
            this.dataGridTransferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTransferencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataGridTransferencias.Location = new System.Drawing.Point(9, 19);
            this.dataGridTransferencias.Name = "dataGridTransferencias";
            this.dataGridTransferencias.ReadOnly = true;
            this.dataGridTransferencias.Size = new System.Drawing.Size(522, 188);
            this.dataGridTransferencias.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Transferencias realizadas";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridComisiones
            // 
            this.dataGridComisiones.AllowUserToAddRows = false;
            this.dataGridComisiones.AllowUserToDeleteRows = false;
            this.dataGridComisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Comisiones_Facturadas});
            this.dataGridComisiones.Location = new System.Drawing.Point(9, 19);
            this.dataGridComisiones.Name = "dataGridComisiones";
            this.dataGridComisiones.ReadOnly = true;
            this.dataGridComisiones.Size = new System.Drawing.Size(522, 188);
            this.dataGridComisiones.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Comisiones_Facturadas
            // 
            this.Comisiones_Facturadas.HeaderText = "Comisiones Facturadas";
            this.Comisiones_Facturadas.Name = "Comisiones_Facturadas";
            this.Comisiones_Facturadas.ReadOnly = true;
            // 
            // dataGridInhabilitaciones
            // 
            this.dataGridInhabilitaciones.AllowUserToAddRows = false;
            this.dataGridInhabilitaciones.AllowUserToDeleteRows = false;
            this.dataGridInhabilitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridInhabilitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInhabilitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Documento,
            this.Inhabilitaciones});
            this.dataGridInhabilitaciones.Location = new System.Drawing.Point(9, 19);
            this.dataGridInhabilitaciones.Name = "dataGridInhabilitaciones";
            this.dataGridInhabilitaciones.ReadOnly = true;
            this.dataGridInhabilitaciones.Size = new System.Drawing.Size(522, 188);
            this.dataGridInhabilitaciones.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            // 
            // Inhabilitaciones
            // 
            this.Inhabilitaciones.HeaderText = "Inhabilitaciones";
            this.Inhabilitaciones.Name = "Inhabilitaciones";
            this.Inhabilitaciones.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridTipoCuentas
            // 
            this.dataGridTipoCuentas.AllowUserToAddRows = false;
            this.dataGridTipoCuentas.AllowUserToDeleteRows = false;
            this.dataGridTipoCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTipoCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTipoCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dataGridTipoCuentas.Location = new System.Drawing.Point(9, 19);
            this.dataGridTipoCuentas.Name = "dataGridTipoCuentas";
            this.dataGridTipoCuentas.ReadOnly = true;
            this.dataGridTipoCuentas.Size = new System.Drawing.Size(522, 188);
            this.dataGridTipoCuentas.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Tipo de cuenta";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Total Facturado";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // ListadosEstadisticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox2);
            this.Controls.Add(this.gBox1);
            this.Name = "ListadosEstadisticos";
            this.Text = "Pago Electrónico - Listados estadísticos";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.gBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPaises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTransferencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComisiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInhabilitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTipoCuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private PagoElectronico.WidgetsGUI.ComboValidable comboListado;
        private PagoElectronico.WidgetsGUI.ComboValidable comboTrimestre;
        private PagoElectronico.WidgetsGUI.ComboValidable comboAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PagoElectronico.WidgetsGUI.GBox gBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridInhabilitaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inhabilitaciones;
        private System.Windows.Forms.DataGridView dataGridComisiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comisiones_Facturadas;
        private System.Windows.Forms.DataGridView dataGridTransferencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridView dataGridPaises;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dataGridTipoCuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    }
}