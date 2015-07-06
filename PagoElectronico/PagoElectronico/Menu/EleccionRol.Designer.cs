namespace PagoElectronico.Menu
{
    partial class EleccionRol
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
            this.button1 = new System.Windows.Forms.Button();
            this.gBox1 = new PagoElectronico.WidgetsGUI.GBox();
            this.Roles_Disponibles = new PagoElectronico.Menu.ListaValidable();
            this.gBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Elegir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.Roles_Disponibles);
            this.gBox1.Location = new System.Drawing.Point(12, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(296, 112);
            this.gBox1.TabIndex = 2;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Roles disponibles";
            // 
            // Roles_Disponibles
            // 
            this.Roles_Disponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roles_Disponibles.FormattingEnabled = true;
            this.Roles_Disponibles.ItemHeight = 20;
            this.Roles_Disponibles.Location = new System.Drawing.Point(6, 19);
            this.Roles_Disponibles.Name = "Roles_Disponibles";
            this.Roles_Disponibles.Size = new System.Drawing.Size(284, 84);
            this.Roles_Disponibles.TabIndex = 1;
            // 
            // EleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 160);
            this.Controls.Add(this.gBox1);
            this.Controls.Add(this.button1);
            this.Name = "EleccionRol";
            this.Text = "Pago Electrónico - Elección de rol";
            this.gBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private ListaValidable Roles_Disponibles;
    }
}