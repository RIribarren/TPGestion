namespace PagoElectronico.Retiros
{
    partial class FRetiro
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
            this.label4 = new System.Windows.Forms.Label();
            this.textoNumericoValidable1 = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.textoImporte = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.comboMoneda1 = new PagoElectronico.WidgetsGUI.ComboMoneda();
            this.comboCuentas1 = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBancos1 = new PagoElectronico.WidgetsGUI.ComboBancos();
            this.label5 = new System.Windows.Forms.Label();
            this.gBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.label5);
            this.gBox1.Controls.Add(this.comboBancos1);
            this.gBox1.Controls.Add(this.label4);
            this.gBox1.Controls.Add(this.textoNumericoValidable1);
            this.gBox1.Controls.Add(this.textoImporte);
            this.gBox1.Controls.Add(this.comboMoneda1);
            this.gBox1.Controls.Add(this.comboCuentas1);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(256, 164);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Datos de retiro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nro Documento";
            // 
            // textoNumericoValidable1
            // 
            this.textoNumericoValidable1.Location = new System.Drawing.Point(94, 131);
            this.textoNumericoValidable1.Name = "textoNumericoValidable1";
            this.textoNumericoValidable1.Size = new System.Drawing.Size(100, 20);
            this.textoNumericoValidable1.TabIndex = 7;
            // 
            // textoImporte
            // 
            this.textoImporte.Location = new System.Drawing.Point(53, 48);
            this.textoImporte.Name = "textoImporte";
            this.textoImporte.Size = new System.Drawing.Size(100, 20);
            this.textoImporte.TabIndex = 6;
            // 
            // comboMoneda1
            // 
            this.comboMoneda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMoneda1.Location = new System.Drawing.Point(53, 74);
            this.comboMoneda1.Name = "comboMoneda1";
            this.comboMoneda1.Size = new System.Drawing.Size(121, 21);
            this.comboMoneda1.TabIndex = 5;
            // 
            // comboCuentas1
            // 
            this.comboCuentas1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCuentas1.Location = new System.Drawing.Point(53, 21);
            this.comboCuentas1.Name = "comboCuentas1";
            this.comboCuentas1.Size = new System.Drawing.Size(121, 21);
            this.comboCuentas1.TabIndex = 3;
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
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(193, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Retirar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBancos1
            // 
            this.comboBancos1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBancos1.FormattingEnabled = true;
            this.comboBancos1.Location = new System.Drawing.Point(53, 102);
            this.comboBancos1.Name = "comboBancos1";
            this.comboBancos1.Size = new System.Drawing.Size(121, 21);
            this.comboBancos1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Banco";
            // 
            // FRetiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 215);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "FRetiro";
            this.Text = "Pago Electrónico - Retiros";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private PagoElectronico.WidgetsGUI.ComboMoneda comboMoneda1;
        private PagoElectronico.WidgetsGUI.ComboCuentas comboCuentas1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private PagoElectronico.WidgetsGUI.TextoNumericoValidable textoImporte;
        private PagoElectronico.WidgetsGUI.TextoNumericoValidable textoNumericoValidable1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private PagoElectronico.WidgetsGUI.ComboBancos comboBancos1;
    }
}