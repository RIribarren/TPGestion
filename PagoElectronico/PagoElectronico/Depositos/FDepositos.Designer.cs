namespace PagoElectronico.Depositos
{
    partial class FDepositos
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
            this.comboMoneda1 = new PagoElectronico.WidgetsGUI.ComboMoneda();
            this.textoNumericoValidable1 = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.comboCuentas1 = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.gBox2 = new PagoElectronico.WidgetsGUI.GBox();
            this.gridTarjetas1 = new PagoElectronico.WidgetsGUI.GridTarjetas();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSeguridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gBox1.SuspendLayout();
            this.gBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTarjetas1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.comboMoneda1);
            this.gBox1.Controls.Add(this.textoNumericoValidable1);
            this.gBox1.Controls.Add(this.comboCuentas1);
            this.gBox1.Controls.Add(this.gBox2);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(740, 302);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Datos de depósito";
            // 
            // comboMoneda1
            // 
            this.comboMoneda1.Location = new System.Drawing.Point(76, 72);
            this.comboMoneda1.Name = "comboMoneda1";
            this.comboMoneda1.SelectedIndex = -1;
            this.comboMoneda1.Size = new System.Drawing.Size(121, 21);
            this.comboMoneda1.TabIndex = 6;
            // 
            // textoNumericoValidable1
            // 
            this.textoNumericoValidable1.Location = new System.Drawing.Point(76, 46);
            this.textoNumericoValidable1.Name = "textoNumericoValidable1";
            this.textoNumericoValidable1.Size = new System.Drawing.Size(100, 20);
            this.textoNumericoValidable1.TabIndex = 5;
            // 
            // comboCuentas1
            // 
            this.comboCuentas1.Location = new System.Drawing.Point(76, 19);
            this.comboCuentas1.Name = "comboCuentas1";
            this.comboCuentas1.SelectedIndex = -1;
            this.comboCuentas1.Size = new System.Drawing.Size(121, 21);
            this.comboCuentas1.TabIndex = 4;
            // 
            // gBox2
            // 
            this.gBox2.Controls.Add(this.gridTarjetas1);
            this.gBox2.Location = new System.Drawing.Point(9, 99);
            this.gBox2.Name = "gBox2";
            this.gBox2.Size = new System.Drawing.Size(719, 189);
            this.gBox2.TabIndex = 3;
            this.gBox2.TabStop = false;
            this.gBox2.Text = "Tarjeta";
            // 
            // gridTarjetas1
            // 
            this.gridTarjetas1.AllowUserToAddRows = false;
            this.gridTarjetas1.AllowUserToDeleteRows = false;
            this.gridTarjetas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTarjetas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTarjetas1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.FechaEmision,
            this.FechaVencimiento,
            this.CodigoSeguridad,
            this.Emisor,
            this.Seleccionar});
            this.gridTarjetas1.Location = new System.Drawing.Point(6, 19);
            this.gridTarjetas1.Name = "gridTarjetas1";
            this.gridTarjetas1.Size = new System.Drawing.Size(707, 164);
            this.gridTarjetas1.TabIndex = 0;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // FechaEmision
            // 
            this.FechaEmision.HeaderText = "Fecha de emisión";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.ReadOnly = true;
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.HeaderText = "Fecha de vencimiento";
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.ReadOnly = true;
            // 
            // CodigoSeguridad
            // 
            this.CodigoSeguridad.HeaderText = "Código de seguridad";
            this.CodigoSeguridad.Name = "CodigoSeguridad";
            this.CodigoSeguridad.ReadOnly = true;
            // 
            // Emisor
            // 
            this.Emisor.HeaderText = "Emisor";
            this.Emisor.Name = "Emisor";
            this.Emisor.ReadOnly = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Moneda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Importe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Depositar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FDepositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 397);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "FDepositos";
            this.Text = "Form1";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.gBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTarjetas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PagoElectronico.WidgetsGUI.GBox gBox2;
        private PagoElectronico.WidgetsGUI.ComboMoneda comboMoneda1;
        private PagoElectronico.WidgetsGUI.TextoNumericoValidable textoNumericoValidable1;
        private PagoElectronico.WidgetsGUI.ComboCuentas comboCuentas1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private PagoElectronico.WidgetsGUI.GridTarjetas gridTarjetas1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSeguridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
    }
}