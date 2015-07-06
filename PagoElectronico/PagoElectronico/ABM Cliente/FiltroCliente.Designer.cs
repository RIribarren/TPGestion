namespace PagoElectronico.ABM_Cliente
{
    partial class FiltroCliente
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
            this.ComboFiltroTipoIdentificacion = new PagoElectronico.ABM_Cliente.ComboIdentificacion();
            this.TextoFiltroNroIdentificacion = new PagoElectronico.WidgetsGUI.TextoNumerico();
            this.TextoFiltroEmail = new PagoElectronico.WidgetsGUI.Texto();
            this.TextoFiltroApellido = new PagoElectronico.WidgetsGUI.Texto();
            this.TextoFiltroNombre = new PagoElectronico.WidgetsGUI.Texto();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.ComboFiltroTipoIdentificacion);
            this.gBox1.Controls.Add(this.TextoFiltroNroIdentificacion);
            this.gBox1.Controls.Add(this.TextoFiltroEmail);
            this.gBox1.Controls.Add(this.TextoFiltroApellido);
            this.gBox1.Controls.Add(this.TextoFiltroNombre);
            this.gBox1.Controls.Add(this.label5);
            this.gBox1.Controls.Add(this.label4);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(644, 106);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Filtros de búsqueda";
            // 
            // ComboFiltroTipoIdentificacion
            // 
            this.ComboFiltroTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFiltroTipoIdentificacion.Location = new System.Drawing.Point(514, 19);
            this.ComboFiltroTipoIdentificacion.Name = "ComboFiltroTipoIdentificacion";
            this.ComboFiltroTipoIdentificacion.Size = new System.Drawing.Size(121, 21);
            this.ComboFiltroTipoIdentificacion.TabIndex = 9;
            // 
            // TextoFiltroNroIdentificacion
            // 
            this.TextoFiltroNroIdentificacion.Location = new System.Drawing.Point(513, 46);
            this.TextoFiltroNroIdentificacion.Name = "TextoFiltroNroIdentificacion";
            this.TextoFiltroNroIdentificacion.Size = new System.Drawing.Size(100, 20);
            this.TextoFiltroNroIdentificacion.TabIndex = 8;
            // 
            // TextoFiltroEmail
            // 
            this.TextoFiltroEmail.Location = new System.Drawing.Point(56, 72);
            this.TextoFiltroEmail.Name = "TextoFiltroEmail";
            this.TextoFiltroEmail.Size = new System.Drawing.Size(100, 20);
            this.TextoFiltroEmail.TabIndex = 7;
            // 
            // TextoFiltroApellido
            // 
            this.TextoFiltroApellido.Location = new System.Drawing.Point(56, 46);
            this.TextoFiltroApellido.Name = "TextoFiltroApellido";
            this.TextoFiltroApellido.Size = new System.Drawing.Size(100, 20);
            this.TextoFiltroApellido.TabIndex = 6;
            // 
            // TextoFiltroNombre
            // 
            this.TextoFiltroNombre.Location = new System.Drawing.Point(56, 20);
            this.TextoFiltroNombre.Name = "TextoFiltroNombre";
            this.TextoFiltroNombre.Size = new System.Drawing.Size(100, 20);
            this.TextoFiltroNombre.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "e-Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nro. de identificación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de identificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(581, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Email,
            this.TipoIdentificacion,
            this.NroIdentificacion,
            this.Seleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(644, 150);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // Email
            // 
            this.Email.HeaderText = "e-Mail";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // TipoIdentificacion
            // 
            this.TipoIdentificacion.HeaderText = "Tipo de Id.";
            this.TipoIdentificacion.Name = "TipoIdentificacion";
            this.TipoIdentificacion.ReadOnly = true;
            // 
            // NroIdentificacion
            // 
            this.NroIdentificacion.HeaderText = "Nro. Identificacion";
            this.NroIdentificacion.Name = "NroIdentificacion";
            this.NroIdentificacion.ReadOnly = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            // 
            // FiltroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 323);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "FiltroCliente";
            this.Text = "Pago Electrónico - Selección de cliente";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private PagoElectronico.WidgetsGUI.Texto TextoFiltroEmail;
        private PagoElectronico.WidgetsGUI.Texto TextoFiltroApellido;
        private PagoElectronico.WidgetsGUI.Texto TextoFiltroNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ComboIdentificacion ComboFiltroTipoIdentificacion;
        private PagoElectronico.WidgetsGUI.TextoNumerico TextoFiltroNroIdentificacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroIdentificacion;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
    }
}