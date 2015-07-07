namespace PagoElectronico.Transferencias
{
    partial class FTransferencias
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
            this.Importe = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.Cuenta_Destino = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.Cuenta_Origen = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.Importe);
            this.gBox1.Controls.Add(this.Cuenta_Destino);
            this.gBox1.Controls.Add(this.Cuenta_Origen);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(287, 111);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Datos de transferencia";
            // 
            // Importe
            // 
            this.Importe.Location = new System.Drawing.Point(115, 73);
            this.Importe.Name = "Importe";
            this.Importe.Size = new System.Drawing.Size(100, 20);
            this.Importe.TabIndex = 5;
            // 
            // Cuenta_Destino
            // 
            this.Cuenta_Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cuenta_Destino.Location = new System.Drawing.Point(115, 46);
            this.Cuenta_Destino.Name = "Cuenta_Destino";
            this.Cuenta_Destino.Size = new System.Drawing.Size(121, 21);
            this.Cuenta_Destino.TabIndex = 4;
            // 
            // Cuenta_Origen
            // 
            this.Cuenta_Origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cuenta_Origen.Location = new System.Drawing.Point(115, 19);
            this.Cuenta_Origen.Name = "Cuenta_Origen";
            this.Cuenta_Origen.Size = new System.Drawing.Size(121, 21);
            this.Cuenta_Origen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Importe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuenta destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta de origen";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Transferir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 163);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "FTransferencias";
            this.Text = "Pago Electrónico - Transferencias";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private PagoElectronico.WidgetsGUI.TextoNumericoValidable Importe;
        private PagoElectronico.WidgetsGUI.ComboCuentas Cuenta_Destino;
        private PagoElectronico.WidgetsGUI.ComboCuentas Cuenta_Origen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}