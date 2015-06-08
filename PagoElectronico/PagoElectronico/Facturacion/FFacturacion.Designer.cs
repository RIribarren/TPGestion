namespace PagoElectronico.Facturacion
{
    partial class FFacturacion
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
            this.button2 = new System.Windows.Forms.Button();
            this.gBox2 = new PagoElectronico.WidgetsGUI.GBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCuentas1 = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.label1 = new System.Windows.Forms.Label();
            this.gBox1 = new PagoElectronico.WidgetsGUI.GBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.gBox2.SuspendLayout();
            this.gBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gBox2
            // 
            this.gBox2.Controls.Add(this.textBox1);
            this.gBox2.Controls.Add(this.label2);
            this.gBox2.Controls.Add(this.comboCuentas1);
            this.gBox2.Controls.Add(this.label1);
            this.gBox2.Controls.Add(this.gBox1);
            this.gBox2.Location = new System.Drawing.Point(10, 10);
            this.gBox2.Name = "gBox2";
            this.gBox2.Size = new System.Drawing.Size(615, 310);
            this.gBox2.TabIndex = 8;
            this.gBox2.TabStop = false;
            this.gBox2.Text = "Datos de facturación";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(509, 266);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total";
            // 
            // comboCuentas1
            // 
            this.comboCuentas1.Location = new System.Drawing.Point(97, 266);
            this.comboCuentas1.Name = "comboCuentas1";
            this.comboCuentas1.SelectedIndex = -1;
            this.comboCuentas1.Size = new System.Drawing.Size(121, 21);
            this.comboCuentas1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cuenta a utilizar";
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.dataGridView1);
            this.gBox1.Location = new System.Drawing.Point(6, 19);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(603, 241);
            this.gBox1.TabIndex = 1;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Items a facturar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.Importe});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(591, 216);
            this.dataGridView1.TabIndex = 0;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(550, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Facturar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 362);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gBox2);
            this.Controls.Add(this.button1);
            this.Name = "FFacturacion";
            this.Text = "Form1";
            this.gBox2.ResumeLayout(false);
            this.gBox2.PerformLayout();
            this.gBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private PagoElectronico.WidgetsGUI.GBox gBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private PagoElectronico.WidgetsGUI.ComboCuentas comboCuentas1;
        private System.Windows.Forms.Label label1;
        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;

    }
}