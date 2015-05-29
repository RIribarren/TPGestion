namespace PagoElectronico.ABM_Cliente
{
    partial class ListadoTarjetas
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
            this.TarjetasDeCliente = new PagoElectronico.WidgetsGUI.GridCheckBox();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Em = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.gBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TarjetasDeCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.TarjetasDeCliente);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(658, 181);
            this.gBox1.TabIndex = 1;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Tarjetas de cliente";
            // 
            // TarjetasDeCliente
            // 
            this.TarjetasDeCliente.AllowUserToAddRows = false;
            this.TarjetasDeCliente.AllowUserToDeleteRows = false;
            this.TarjetasDeCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TarjetasDeCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TarjetasDeCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.N,
            this.FE,
            this.FV,
            this.CS,
            this.Em,
            this.S});
            this.TarjetasDeCliente.Location = new System.Drawing.Point(9, 19);
            this.TarjetasDeCliente.Name = "TarjetasDeCliente";
            this.TarjetasDeCliente.Size = new System.Drawing.Size(643, 150);
            this.TarjetasDeCliente.TabIndex = 7;
            // 
            // N
            // 
            this.N.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.N.HeaderText = "Numero";
            this.N.Name = "N";
            this.N.ReadOnly = true;
            this.N.Width = 69;
            // 
            // FE
            // 
            this.FE.HeaderText = "Fecha de emisión";
            this.FE.Name = "FE";
            this.FE.ReadOnly = true;
            // 
            // FV
            // 
            this.FV.HeaderText = "Fecha de vencimiento";
            this.FV.Name = "FV";
            this.FV.ReadOnly = true;
            // 
            // CS
            // 
            this.CS.HeaderText = "Código de seguridad";
            this.CS.Name = "CS";
            this.CS.ReadOnly = true;
            // 
            // Em
            // 
            this.Em.HeaderText = "Emisor";
            this.Em.Name = "Em";
            this.Em.ReadOnly = true;
            // 
            // S
            // 
            this.S.HeaderText = "Seleccionar";
            this.S.Name = "S";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Dar de baja";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(460, 199);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(352, 199);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Nueva tarjeta";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ListadoTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 233);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "ListadoTarjetas";
            this.Text = "ListadoTarjetas";
            this.gBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TarjetasDeCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private PagoElectronico.WidgetsGUI.GridCheckBox TarjetasDeCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn FE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Em;
        private System.Windows.Forms.DataGridViewCheckBoxColumn S;

    }
}