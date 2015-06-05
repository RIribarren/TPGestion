namespace PagoElectronico.ABM_Cuenta
{
    partial class AltaCuenta
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
            this.TipoDeCuenta = new PagoElectronico.WidgetsGUI.ComboTipoCuenta();
            this.TipoDeMoneda = new PagoElectronico.WidgetsGUI.ComboMoneda();
            this.PaisDeRegistro = new PagoElectronico.ABM_Cliente.ComboPais();
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
            this.gBox1.Controls.Add(this.TipoDeCuenta);
            this.gBox1.Controls.Add(this.TipoDeMoneda);
            this.gBox1.Controls.Add(this.PaisDeRegistro);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(234, 107);
            this.gBox1.TabIndex = 0;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Datos de cuenta";
            // 
            // TipoDeCuenta
            // 
            this.TipoDeCuenta.Location = new System.Drawing.Point(93, 73);
            this.TipoDeCuenta.Name = "TipoDeCuenta";
            this.TipoDeCuenta.SelectedIndex = -1;
            this.TipoDeCuenta.Size = new System.Drawing.Size(121, 21);
            this.TipoDeCuenta.TabIndex = 5;
            // 
            // TipoDeMoneda
            // 
            this.TipoDeMoneda.Location = new System.Drawing.Point(93, 46);
            this.TipoDeMoneda.Name = "TipoDeMoneda";
            this.TipoDeMoneda.SelectedIndex = -1;
            this.TipoDeMoneda.Size = new System.Drawing.Size(121, 21);
            this.TipoDeMoneda.TabIndex = 4;
            // 
            // PaisDeRegistro
            // 
            this.PaisDeRegistro.Location = new System.Drawing.Point(93, 19);
            this.PaisDeRegistro.Name = "PaisDeRegistro";
            this.PaisDeRegistro.SelectedIndex = -1;
            this.PaisDeRegistro.Size = new System.Drawing.Size(121, 21);
            this.PaisDeRegistro.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de cuenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Moneda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "País de registro";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AltaCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 158);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox1);
            this.Name = "AltaCuenta";
            this.Text = "Alta de cuenta";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PagoElectronico.ABM_Cliente.ComboPais PaisDeRegistro;
        private System.Windows.Forms.Label label3;
        private PagoElectronico.WidgetsGUI.ComboMoneda TipoDeMoneda;
        private PagoElectronico.WidgetsGUI.ComboTipoCuenta TipoDeCuenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}