namespace PagoElectronico.WidgetsGUI
{
    partial class ComboValidable
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
            this.comboBoxCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxCombo
            // 
            this.comboBoxCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCombo.FormattingEnabled = true;
            this.comboBoxCombo.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCombo.Name = "comboBoxCombo";
            this.comboBoxCombo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCombo.TabIndex = 0;
            // 
            // ComboValidable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxCombo);
            this.Name = "ComboValidable";
            this.Size = new System.Drawing.Size(121, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCombo;
    }
}
