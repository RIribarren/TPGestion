namespace PagoElectronico.ABM_Rol
{
    partial class DataRol
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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.dataGridViewFuncionalidades = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxActivado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(295, 363);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(106, 24);
            this.buttonGuardar.TabIndex = 5;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.dataGridViewFuncionalidades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBoxActivado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 333);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos de Rol";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(56, 27);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // dataGridViewFuncionalidades
            // 
            this.dataGridViewFuncionalidades.AllowUserToAddRows = false;
            this.dataGridViewFuncionalidades.AllowUserToDeleteRows = false;
            this.dataGridViewFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFuncionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Activado});
            this.dataGridViewFuncionalidades.Location = new System.Drawing.Point(10, 121);
            this.dataGridViewFuncionalidades.Name = "dataGridViewFuncionalidades";
            this.dataGridViewFuncionalidades.Size = new System.Drawing.Size(374, 201);
            this.dataGridViewFuncionalidades.TabIndex = 3;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Activado
            // 
            this.Activado.HeaderText = "Activado";
            this.Activado.Name = "Activado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Listado de funcionalidades";
            // 
            // checkBoxActivado
            // 
            this.checkBoxActivado.AutoSize = true;
            this.checkBoxActivado.Location = new System.Drawing.Point(9, 58);
            this.checkBoxActivado.Name = "checkBoxActivado";
            this.checkBoxActivado.Size = new System.Drawing.Size(68, 17);
            this.checkBoxActivado.TabIndex = 1;
            this.checkBoxActivado.Text = "Activado";
            this.checkBoxActivado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // DataRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 400);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DataRol";
            this.Text = "AltaRol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuncionalidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxNombre;
        public System.Windows.Forms.DataGridView dataGridViewFuncionalidades;
        public System.Windows.Forms.CheckBox checkBoxActivado;


    }
}