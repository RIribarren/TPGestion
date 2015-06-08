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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCuentas1 = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.comboCuentas2 = new PagoElectronico.WidgetsGUI.ComboCuentas();
            this.textoNumericoValidable1 = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.textoNumericoValidable1);
            this.gBox1.Controls.Add(this.comboCuentas2);
            this.gBox1.Controls.Add(this.comboCuentas1);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(263, 111);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Datos de transferencia";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuenta destino";
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
            // comboCuentas1
            // 
            this.comboCuentas1.Location = new System.Drawing.Point(115, 19);
            this.comboCuentas1.Name = "comboCuentas1";
            this.comboCuentas1.SelectedIndex = -1;
            this.comboCuentas1.Size = new System.Drawing.Size(121, 21);
            this.comboCuentas1.TabIndex = 3;
            // 
            // comboCuentas2
            // 
            this.comboCuentas2.Location = new System.Drawing.Point(115, 46);
            this.comboCuentas2.Name = "comboCuentas2";
            this.comboCuentas2.SelectedIndex = -1;
            this.comboCuentas2.Size = new System.Drawing.Size(121, 21);
            this.comboCuentas2.TabIndex = 4;
            // 
            // textoNumericoValidable1
            // 
            this.textoNumericoValidable1.Location = new System.Drawing.Point(115, 73);
            this.textoNumericoValidable1.Name = "textoNumericoValidable1";
            this.textoNumericoValidable1.Size = new System.Drawing.Size(100, 20);
            this.textoNumericoValidable1.TabIndex = 5;
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
            this.button2.Location = new System.Drawing.Point(200, 129);
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
            this.ClientSize = new System.Drawing.Size(288, 163);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "FTransferencias";
            this.Text = "Form1";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private PagoElectronico.WidgetsGUI.TextoNumericoValidable textoNumericoValidable1;
        private PagoElectronico.WidgetsGUI.ComboCuentas comboCuentas2;
        private PagoElectronico.WidgetsGUI.ComboCuentas comboCuentas1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}