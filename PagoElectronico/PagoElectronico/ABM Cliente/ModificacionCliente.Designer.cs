namespace PagoElectronico.ABM_Cliente
{
    partial class ModificacionCliente
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
            this.button2 = new System.Windows.Forms.Button();
            this.gBox1 = new PagoElectronico.WidgetsGUI.GBox();
            this.Habilitado = new PagoElectronico.WidgetsGUI.CBox();
            this.Nacionalidad = new PagoElectronico.ABM_Cliente.ComboPais();
            this.pais = new PagoElectronico.ABM_Cliente.ComboPais();
            this.TipoDeIdentificacion = new PagoElectronico.ABM_Cliente.ComboIdentificacion();
            this.textBoxDepto = new PagoElectronico.WidgetsGUI.Texto();
            this.FechaNacimiento = new PagoElectronico.WidgetsGUI.Fecha();
            this.Localidad = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.Calle = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.Domicilio = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.Email = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.NroIdentificacion = new PagoElectronico.WidgetsGUI.TextoNumericoValidable();
            this.Apellido = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.Nombre = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gBox1
            // 
            this.gBox1.Controls.Add(this.Habilitado);
            this.gBox1.Controls.Add(this.Nacionalidad);
            this.gBox1.Controls.Add(this.pais);
            this.gBox1.Controls.Add(this.TipoDeIdentificacion);
            this.gBox1.Controls.Add(this.textBoxDepto);
            this.gBox1.Controls.Add(this.FechaNacimiento);
            this.gBox1.Controls.Add(this.Localidad);
            this.gBox1.Controls.Add(this.Calle);
            this.gBox1.Controls.Add(this.Domicilio);
            this.gBox1.Controls.Add(this.Email);
            this.gBox1.Controls.Add(this.NroIdentificacion);
            this.gBox1.Controls.Add(this.Apellido);
            this.gBox1.Controls.Add(this.Nombre);
            this.gBox1.Controls.Add(this.label12);
            this.gBox1.Controls.Add(this.label11);
            this.gBox1.Controls.Add(this.label10);
            this.gBox1.Controls.Add(this.label9);
            this.gBox1.Controls.Add(this.label8);
            this.gBox1.Controls.Add(this.label7);
            this.gBox1.Controls.Add(this.label6);
            this.gBox1.Controls.Add(this.label5);
            this.gBox1.Controls.Add(this.label4);
            this.gBox1.Controls.Add(this.label3);
            this.gBox1.Controls.Add(this.label2);
            this.gBox1.Controls.Add(this.label1);
            this.gBox1.Location = new System.Drawing.Point(10, 12);
            this.gBox1.Name = "gBox1";
            this.gBox1.Size = new System.Drawing.Size(558, 212);
            this.gBox1.TabIndex = 8;
            this.gBox1.TabStop = false;
            this.gBox1.Text = "Campos de Cliente";
            // 
            // cBox1
            // 
            this.Habilitado.AutoSize = true;
            this.Habilitado.Location = new System.Drawing.Point(17, 189);
            this.Habilitado.Name = "cBox1";
            this.Habilitado.Size = new System.Drawing.Size(73, 17);
            this.Habilitado.TabIndex = 112;
            this.Habilitado.Text = "Habilitado";
            this.Habilitado.UseVisualStyleBackColor = true;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.Location = new System.Drawing.Point(325, 122);
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.SelectedIndex = -1;
            this.Nacionalidad.Size = new System.Drawing.Size(121, 21);
            this.Nacionalidad.TabIndex = 111;
            // 
            // pais
            // 
            this.pais.Location = new System.Drawing.Point(64, 148);
            this.pais.Name = "pais";
            this.pais.SelectedIndex = -1;
            this.pais.Size = new System.Drawing.Size(121, 21);
            this.pais.TabIndex = 110;
            // 
            // TipoDeIdentificacion
            // 
            this.TipoDeIdentificacion.Location = new System.Drawing.Point(113, 96);
            this.TipoDeIdentificacion.Name = "TipoDeIdentificacion";
            this.TipoDeIdentificacion.SelectedIndex = -1;
            this.TipoDeIdentificacion.Size = new System.Drawing.Size(121, 21);
            this.TipoDeIdentificacion.TabIndex = 109;
            // 
            // textBoxDepto
            // 
            this.textBoxDepto.Location = new System.Drawing.Point(305, 70);
            this.textBoxDepto.Name = "textBoxDepto";
            this.textBoxDepto.Size = new System.Drawing.Size(100, 20);
            this.textBoxDepto.TabIndex = 108;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.Location = new System.Drawing.Point(363, 147);
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.Size = new System.Drawing.Size(182, 27);
            this.FechaNacimiento.TabIndex = 107;
            // 
            // Localidad
            // 
            this.Localidad.Location = new System.Drawing.Point(305, 96);
            this.Localidad.Name = "Localidad";
            this.Localidad.Size = new System.Drawing.Size(100, 20);
            this.Localidad.TabIndex = 103;
            // 
            // Calle
            // 
            this.Calle.Location = new System.Drawing.Point(305, 44);
            this.Calle.Name = "Calle";
            this.Calle.Size = new System.Drawing.Size(100, 20);
            this.Calle.TabIndex = 102;
            // 
            // Domicilio
            // 
            this.Domicilio.Location = new System.Drawing.Point(305, 18);
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Size = new System.Drawing.Size(100, 20);
            this.Domicilio.TabIndex = 101;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(64, 123);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(100, 20);
            this.Email.TabIndex = 100;
            // 
            // NroIdentificacion
            // 
            this.NroIdentificacion.Location = new System.Drawing.Point(113, 70);
            this.NroIdentificacion.Name = "NroIdentificacion";
            this.NroIdentificacion.Size = new System.Drawing.Size(100, 20);
            this.NroIdentificacion.TabIndex = 99;
            // 
            // Apellido
            // 
            this.Apellido.Location = new System.Drawing.Point(64, 44);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(100, 20);
            this.Apellido.TabIndex = 98;
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(64, 18);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 20);
            this.Nombre.TabIndex = 97;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 96;
            this.label12.Text = "Tipo Identificación";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 95;
            this.label11.Text = "Fecha de Nacimiento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 94;
            this.label10.Text = "Nacionalidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Localidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "Depto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "Calle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 90;
            this.label6.Text = "Domicilio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 89;
            this.label5.Text = "País";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "e-Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Nro. Identificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Nombre";
            // 
            // ModificacionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 261);
            this.Controls.Add(this.gBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ModificacionCliente";
            this.Text = "ModificacionCliente";
            this.gBox1.ResumeLayout(false);
            this.gBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private PagoElectronico.WidgetsGUI.GBox gBox1;
        private ComboPais Nacionalidad;
        private ComboPais pais;
        private ComboIdentificacion TipoDeIdentificacion;
        private PagoElectronico.WidgetsGUI.Texto textBoxDepto;
        private PagoElectronico.WidgetsGUI.Fecha FechaNacimiento;
        private PagoElectronico.WidgetsGUI.TextoValidable Localidad;
        private PagoElectronico.WidgetsGUI.TextoValidable Calle;
        private PagoElectronico.WidgetsGUI.TextoValidable Domicilio;
        private PagoElectronico.WidgetsGUI.TextoValidable Email;
        private PagoElectronico.WidgetsGUI.TextoNumericoValidable NroIdentificacion;
        private PagoElectronico.WidgetsGUI.TextoValidable Apellido;
        private PagoElectronico.WidgetsGUI.TextoValidable Nombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PagoElectronico.WidgetsGUI.CBox Habilitado;
    }
}