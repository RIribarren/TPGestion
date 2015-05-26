namespace PagoElectronico.WidgetsGUI
{
    partial class TextoNumerico
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTextoNumerico = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxTextoNumerico
            // 
            this.textBoxTextoNumerico.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTextoNumerico.Location = new System.Drawing.Point(0, 0);
            this.textBoxTextoNumerico.Name = "textBoxTextoNumerico";
            this.textBoxTextoNumerico.Size = new System.Drawing.Size(100, 20);
            this.textBoxTextoNumerico.TabIndex = 0;
            this.textBoxTextoNumerico.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TextoNumerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxTextoNumerico);
            this.Name = "TextoNumerico";
            this.Size = new System.Drawing.Size(100, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTextoNumerico;
    }
}
