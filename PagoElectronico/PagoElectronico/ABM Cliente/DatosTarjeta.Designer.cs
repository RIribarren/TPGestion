namespace PagoElectronico.ABM_Cliente
{
    partial class DatosTarjeta
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
            this.Emisor = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.CodigoDeSeguridad = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.FechaDeVencimiento = new PagoElectronico.WidgetsGUI.Fecha();
            this.FechaDeEmision = new PagoElectronico.WidgetsGUI.Fecha();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Numero = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.Emisor);
            this.gBox1.Controls.Add(this.CodigoDeSeguridad);
            this.gBox1.Controls.Add(this.FechaDeVencimiento);
            this.gBox1.Controls.Add(this.FechaDeEmision);
            this.gBox1.Controls.Add(this.label5);
            this.gBox1.Controls.Add(this.label4);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Controls.Add(this.Numero);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(317, 167);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Datos de tarjeta";
            // 
            // Emisor
            // 
            this.Emisor.Location = new System.Drawing.Point(56, 135);
            this.Emisor.Name = "Emisor";
            this.Emisor.Size = new System.Drawing.Size(150, 20);
            this.Emisor.TabIndex = 9;
            // 
            // CodigoDeSeguridad
            // 
            this.CodigoDeSeguridad.Location = new System.Drawing.Point(124, 107);
            this.CodigoDeSeguridad.Name = "CodigoDeSeguridad";
            this.CodigoDeSeguridad.Size = new System.Drawing.Size(40, 20);
            this.CodigoDeSeguridad.TabIndex = 8;
            // 
            // FechaDeVencimiento
            // 
            this.FechaDeVencimiento.Location = new System.Drawing.Point(124, 74);
            this.FechaDeVencimiento.Name = "FechaDeVencimiento";
            this.FechaDeVencimiento.Size = new System.Drawing.Size(182, 27);
            this.FechaDeVencimiento.TabIndex = 7;
            // 
            // FechaDeEmision
            // 
            this.FechaDeEmision.Location = new System.Drawing.Point(124, 45);
            this.FechaDeEmision.Name = "FechaDeEmision";
            this.FechaDeEmision.Size = new System.Drawing.Size(182, 27);
            this.FechaDeEmision.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Emisor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Código de seguridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de emisión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número";
            // 
            // Numero
            // 
            this.Numero.Location = new System.Drawing.Point(56, 20);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(150, 20);
            this.Numero.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DatosTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 217);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "DatosTarjeta";
            this.Text = "AltaTarjeta";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        protected PagoElectronico.WidgetsGUI.TextoNumericoValidable Numero;
        protected PagoElectronico.WidgetsGUI.TextoValidable Emisor;
        protected PagoElectronico.WidgetsGUI.TextoNumericoValidable CodigoDeSeguridad;
        protected PagoElectronico.WidgetsGUI.Fecha FechaDeVencimiento;
        protected PagoElectronico.WidgetsGUI.Fecha FechaDeEmision;
    }
}