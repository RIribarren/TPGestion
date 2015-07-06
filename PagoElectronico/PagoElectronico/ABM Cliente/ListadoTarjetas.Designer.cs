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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gBox2 = new PagoElectronico.WidgetsGUI.GBox();
            this.FechaVencimiento = new PagoElectronico.WidgetsGUI.Fecha();
            this.FechaEmision = new PagoElectronico.WidgetsGUI.Fecha();
            this.textoEmisor = new PagoElectronico.WidgetsGUI.Texto();
            this.textoCodigo = new PagoElectronico.WidgetsGUI.TextoNumerico();
            this.textoNumero = new PagoElectronico.WidgetsGUI.TextoNumerico();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.gBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TarjetasDeCliente)).BeginInit();
            this.gBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.TarjetasDeCliente);
            this.gBox1.Location = new System.Drawing.Point(15, 150);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(562, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Dar de baja";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(454, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Modificar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(346, 337);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Nueva tarjeta";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gBox2
            // 
            this.gBox2.Controls.Add(this.FechaVencimiento);
            this.gBox2.Controls.Add(this.FechaEmision);
            this.gBox2.Controls.Add(this.textoEmisor);
            this.gBox2.Controls.Add(this.textoCodigo);
            this.gBox2.Controls.Add(this.textoNumero);
            this.gBox2.Controls.Add(this.label5);
            this.gBox2.Controls.Add(this.label4);
            this.gBox2.Controls.Add(this.label3);
            this.gBox2.Controls.Add(this.label2);
            this.gBox2.Controls.Add(this.label1);
            this.gBox2.Location = new System.Drawing.Point(15, 12);
            this.gBox2.Name = "gBox2";
            this.gBox2.Size = new System.Drawing.Size(658, 103);
            this.gBox2.TabIndex = 6;
            this.gBox2.TabStop = false;
            this.gBox2.Text = "Filtros de búsqueda";
            // 
            // FechaVencimiento
            // 
            this.FechaVencimiento.Location = new System.Drawing.Point(467, 42);
            this.FechaVencimiento.Name = "FechaVencimiento";
            this.FechaVencimiento.Size = new System.Drawing.Size(182, 27);
            this.FechaVencimiento.TabIndex = 9;
            // 
            // FechaEmision
            // 
            this.FechaEmision.Location = new System.Drawing.Point(467, 14);
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.Size = new System.Drawing.Size(182, 27);
            this.FechaEmision.TabIndex = 8;
            // 
            // textoEmisor
            // 
            this.textoEmisor.Location = new System.Drawing.Point(116, 71);
            this.textoEmisor.Name = "textoEmisor";
            this.textoEmisor.Size = new System.Drawing.Size(100, 20);
            this.textoEmisor.TabIndex = 7;
            // 
            // textoCodigo
            // 
            this.textoCodigo.Location = new System.Drawing.Point(116, 45);
            this.textoCodigo.Name = "textoCodigo";
            this.textoCodigo.Size = new System.Drawing.Size(100, 20);
            this.textoCodigo.TabIndex = 6;
            // 
            // textoNumero
            // 
            this.textoNumero.Location = new System.Drawing.Point(116, 19);
            this.textoNumero.Name = "textoNumero";
            this.textoNumero.Size = new System.Drawing.Size(100, 20);
            this.textoNumero.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Emisor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Código de seguridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de emisión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(598, 121);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Buscar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ListadoTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 368);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.gBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "ListadoTarjetas";
            this.Text = "Pago Electrónico - Selección de tarjeta";
            this.gBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TarjetasDeCliente)).EndInit();
            this.gBox2.ResumeLayout(false);
            this.gBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
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
        private System.Windows.Forms.Button button1;
        private PagoElectronico.WidgetsGUI.GBox gBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private PagoElectronico.WidgetsGUI.Fecha FechaVencimiento;
        private PagoElectronico.WidgetsGUI.Fecha FechaEmision;
        private PagoElectronico.WidgetsGUI.Texto textoEmisor;
        private PagoElectronico.WidgetsGUI.TextoNumerico textoCodigo;
        private PagoElectronico.WidgetsGUI.TextoNumerico textoNumero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

    }
}