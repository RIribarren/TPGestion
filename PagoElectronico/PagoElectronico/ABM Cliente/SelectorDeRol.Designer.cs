namespace PagoElectronico.ABM_Cliente
{
    partial class SelectorDeRol
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
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRoles
            // 
            this.dataGridViewRoles.AllowUserToAddRows = false;
            this.dataGridViewRoles.AllowUserToDeleteRows = false;
            this.dataGridViewRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rol,
            this.Asignado});
            this.dataGridViewRoles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.Size = new System.Drawing.Size(267, 89);
            this.dataGridViewRoles.TabIndex = 1;
            this.dataGridViewRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRoles_CellContentClick);
            // 
            // Rol
            // 
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            // 
            // Asignado
            // 
            this.Asignado.HeaderText = "Asignado";
            this.Asignado.Name = "Asignado";
            // 
            // SelectorDeRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewRoles);
            this.Name = "SelectorDeRol";
            this.Size = new System.Drawing.Size(267, 89);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Asignado;
    }
}
