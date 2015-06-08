namespace PagoElectronico.Consulta_Saldos
{
    partial class Saldos
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
            this.gBox3 = new PagoElectronico.WidgetsGUI.GBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.FechaRetiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoRetiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gBox4 = new PagoElectronico.WidgetsGUI.GBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.FechaTransferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTransferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CuentaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBox2 = new PagoElectronico.WidgetsGUI.GBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboCuentas1 = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.gBox1.SuspendLayout();
            this.gBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.gBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.gBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.gBox3);
            this.gBox1.Controls.Add(this.textBox1);
            this.gBox1.Controls.Add(this.gBox4);
            this.gBox1.Controls.Add(this.gBox2);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Location = new System.Drawing.Point(12, 39);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(707, 401);
            this.gBox1.TabIndex = 1;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Saldo de cuenta";
            // 
            // gBox3
            // 
            this.gBox3.Controls.Add(this.dataGridView2);
            this.gBox3.Location = new System.Drawing.Point(356, 51);
            this.gBox3.Name = "gBox3";
            this.gBox3.Size = new System.Drawing.Size(341, 154);
            this.gBox3.TabIndex = 2;
            this.gBox3.TabStop = false;
            this.gBox3.Text = "Últimos 5 retiros";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaRetiro,
            this.MontoRetiro});
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(329, 129);
            this.dataGridView2.TabIndex = 1;
            // 
            // FechaRetiro
            // 
            this.FechaRetiro.HeaderText = "Fecha";
            this.FechaRetiro.Name = "FechaRetiro";
            this.FechaRetiro.ReadOnly = true;
            // 
            // MontoRetiro
            // 
            this.MontoRetiro.HeaderText = "Monto";
            this.MontoRetiro.Name = "MontoRetiro";
            this.MontoRetiro.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // gBox4
            // 
            this.gBox4.Controls.Add(this.dataGridView3);
            this.gBox4.Location = new System.Drawing.Point(9, 211);
            this.gBox4.Name = "gBox4";
            this.gBox4.Size = new System.Drawing.Size(688, 184);
            this.gBox4.TabIndex = 3;
            this.gBox4.TabStop = false;
            this.gBox4.Text = "Últimas 10 transferencias de fondos";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaTransferencia,
            this.MontoTransferencia,
            this.CuentaDestino});
            this.dataGridView3.Location = new System.Drawing.Point(6, 19);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(676, 159);
            this.dataGridView3.TabIndex = 2;
            // 
            // FechaTransferencia
            // 
            this.FechaTransferencia.HeaderText = "Fecha";
            this.FechaTransferencia.Name = "FechaTransferencia";
            this.FechaTransferencia.ReadOnly = true;
            // 
            // MontoTransferencia
            // 
            this.MontoTransferencia.HeaderText = "Monto";
            this.MontoTransferencia.Name = "MontoTransferencia";
            this.MontoTransferencia.ReadOnly = true;
            // 
            // CuentaDestino
            // 
            this.CuentaDestino.HeaderText = "Cuenta destino";
            this.CuentaDestino.Name = "CuentaDestino";
            this.CuentaDestino.ReadOnly = true;
            // 
            // gBox2
            // 
            this.gBox2.Controls.Add(this.dataGridView1);
            this.gBox2.Location = new System.Drawing.Point(9, 51);
            this.gBox2.Name = "gBox2";
            this.gBox2.Size = new System.Drawing.Size(341, 154);
            this.gBox2.TabIndex = 1;
            this.gBox2.TabStop = false;
            this.gBox2.Text = "Últimos 5 depósitos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Monto});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(329, 129);
            this.dataGridView1.TabIndex = 0;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Saldo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cuenta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(644, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboCuentas1
            // 
            this.comboCuentas1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCuentas1.FormattingEnabled = true;
            this.comboCuentas1.Location = new System.Drawing.Point(57, 12);
            this.comboCuentas1.Name = "comboCuentas1";
            this.comboCuentas1.Size = new System.Drawing.Size(121, 21);
            this.comboCuentas1.TabIndex = 5;
            this.comboCuentas1.SelectedIndexChanged += new System.EventHandler(this.comboCuentas1_SelectedIndexChanged);
            // 
            // Saldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 476);
            this.Controls.Add(this.comboCuentas1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gBox1);
            this.Name = "Saldos";
            this.Text = "Form1";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.gBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.gBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.gBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private System.Windows.Forms.Label label1;
        private PagoElectronico.WidgetsGUI.GBox gBox3;
        private System.Windows.Forms.TextBox textBox1;
        private PagoElectronico.WidgetsGUI.GBox gBox4;
        private PagoElectronico.WidgetsGUI.GBox gBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRetiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoRetiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaTransferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTransferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CuentaDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private PagoElectronico.WidgetsGUI.ComboCuentas comboCuentas1;

    }
}