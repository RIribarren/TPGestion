namespace PagoElectronico.ABM_Cliente
{
    partial class AltaCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FechaNacimiento = new PagoElectronico.WidgetsGUI.Fecha();
            this.Nacionalidad = new PagoElectronico.WidgetsGUI.ComboValidable();
            this.Pais = new PagoElectronico.WidgetsGUI.ComboValidable();
            this.TipoIdentificacion = new PagoElectronico.WidgetsGUI.ComboValidable();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RespuestaSecreta = new PagoElectronico.WidgetsGUI.TextoPasswordValidable();
            this.PreguntaSecreta = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.Password = new PagoElectronico.WidgetsGUI.TextoPasswordValidable();
            this.Username = new PagoElectronico.WidgetsGUI.TextoValidable();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.selectorDeRol1 = new PagoElectronico.ABM_Cliente.SelectorDeRol();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.textBoxDepto = new PagoElectronico.WidgetsGUI.Texto();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDepto);
            this.groupBox1.Controls.Add(this.FechaNacimiento);
            this.groupBox1.Controls.Add(this.Nacionalidad);
            this.groupBox1.Controls.Add(this.Pais);
            this.groupBox1.Controls.Add(this.TipoIdentificacion);
            this.groupBox1.Controls.Add(this.Localidad);
            this.groupBox1.Controls.Add(this.Calle);
            this.groupBox1.Controls.Add(this.Domicilio);
            this.groupBox1.Controls.Add(this.Email);
            this.groupBox1.Controls.Add(this.NroIdentificacion);
            this.groupBox1.Controls.Add(this.Apellido);
            this.groupBox1.Controls.Add(this.Nombre);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos de Cliente";
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.Location = new System.Drawing.Point(364, 154);
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.Size = new System.Drawing.Size(182, 27);
            this.FechaNacimiento.TabIndex = 35;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.Location = new System.Drawing.Point(326, 130);
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.SelectedIndex = -1;
            this.Nacionalidad.Size = new System.Drawing.Size(121, 21);
            this.Nacionalidad.TabIndex = 34;
            // 
            // Pais
            // 
            this.Pais.Location = new System.Drawing.Point(65, 156);
            this.Pais.Name = "Pais";
            this.Pais.SelectedIndex = -1;
            this.Pais.Size = new System.Drawing.Size(121, 21);
            this.Pais.TabIndex = 33;
            // 
            // TipoIdentificacion
            // 
            this.TipoIdentificacion.Location = new System.Drawing.Point(114, 103);
            this.TipoIdentificacion.Name = "TipoIdentificacion";
            this.TipoIdentificacion.SelectedIndex = -1;
            this.TipoIdentificacion.Size = new System.Drawing.Size(121, 21);
            this.TipoIdentificacion.TabIndex = 32;
            // 
            // Localidad
            // 
            this.Localidad.Location = new System.Drawing.Point(306, 103);
            this.Localidad.Name = "Localidad";
            this.Localidad.Size = new System.Drawing.Size(100, 20);
            this.Localidad.TabIndex = 31;
            // 
            // Calle
            // 
            this.Calle.Location = new System.Drawing.Point(306, 51);
            this.Calle.Name = "Calle";
            this.Calle.Size = new System.Drawing.Size(100, 20);
            this.Calle.TabIndex = 30;
            // 
            // Domicilio
            // 
            this.Domicilio.Location = new System.Drawing.Point(306, 25);
            this.Domicilio.Name = "Domicilio";
            this.Domicilio.Size = new System.Drawing.Size(100, 20);
            this.Domicilio.TabIndex = 29;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(65, 130);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(100, 20);
            this.Email.TabIndex = 28;
            // 
            // NroIdentificacion
            // 
            this.NroIdentificacion.Location = new System.Drawing.Point(114, 77);
            this.NroIdentificacion.Name = "NroIdentificacion";
            this.NroIdentificacion.Size = new System.Drawing.Size(100, 20);
            this.NroIdentificacion.TabIndex = 27;
            // 
            // Apellido
            // 
            this.Apellido.Location = new System.Drawing.Point(65, 51);
            this.Apellido.Name = "Apellido";
            this.Apellido.Size = new System.Drawing.Size(100, 20);
            this.Apellido.TabIndex = 26;
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(65, 25);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 20);
            this.Nombre.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Tipo Identificación";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(251, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Fecha de Nacimiento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Nacionalidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Localidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Depto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Calle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Domicilio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "País";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "e-Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nro. Identificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RespuestaSecreta);
            this.groupBox2.Controls.Add(this.PreguntaSecreta);
            this.groupBox2.Controls.Add(this.Password);
            this.groupBox2.Controls.Add(this.Username);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 139);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Campos de Usuario";
            // 
            // RespuestaSecreta
            // 
            this.RespuestaSecreta.Location = new System.Drawing.Point(117, 104);
            this.RespuestaSecreta.Name = "RespuestaSecreta";
            this.RespuestaSecreta.Size = new System.Drawing.Size(150, 20);
            this.RespuestaSecreta.TabIndex = 14;
            // 
            // PreguntaSecreta
            // 
            this.PreguntaSecreta.Location = new System.Drawing.Point(117, 78);
            this.PreguntaSecreta.Name = "PreguntaSecreta";
            this.PreguntaSecreta.Size = new System.Drawing.Size(150, 20);
            this.PreguntaSecreta.TabIndex = 13;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(76, 52);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(100, 20);
            this.Password.TabIndex = 12;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(76, 26);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(100, 20);
            this.Username.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.selectorDeRol1);
            this.groupBox3.Location = new System.Drawing.Point(273, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 114);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rol";
            // 
            // selectorDeRol1
            // 
            this.selectorDeRol1.Location = new System.Drawing.Point(6, 16);
            this.selectorDeRol1.Name = "selectorDeRol1";
            this.selectorDeRol1.Size = new System.Drawing.Size(267, 89);
            this.selectorDeRol1.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Respuesta secreta";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Pregunta secreta";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Username";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(12, 358);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 2;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(495, 358);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 3;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // textBoxDepto
            // 
            this.textBoxDepto.Location = new System.Drawing.Point(306, 77);
            this.textBoxDepto.Name = "textBoxDepto";
            this.textBoxDepto.Size = new System.Drawing.Size(100, 20);
            this.textBoxDepto.TabIndex = 36;
            // 
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 393);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaCliente";
            this.Text = "Alta de Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonGuardar;
        private PagoElectronico.WidgetsGUI.TextoValidable Nombre;
        private PagoElectronico.WidgetsGUI.TextoValidable Apellido;
        private PagoElectronico.WidgetsGUI.TextoNumericoValidable NroIdentificacion;
        private PagoElectronico.WidgetsGUI.TextoValidable Email;
        private PagoElectronico.WidgetsGUI.TextoValidable Localidad;
        private PagoElectronico.WidgetsGUI.TextoValidable Calle;
        private PagoElectronico.WidgetsGUI.TextoValidable Domicilio;
        private PagoElectronico.WidgetsGUI.TextoValidable PreguntaSecreta;
        private PagoElectronico.WidgetsGUI.TextoPasswordValidable Password;
        private PagoElectronico.WidgetsGUI.TextoValidable Username;
        private PagoElectronico.WidgetsGUI.TextoPasswordValidable RespuestaSecreta;
        private PagoElectronico.WidgetsGUI.ComboValidable TipoIdentificacion;
        private PagoElectronico.WidgetsGUI.ComboValidable Pais;
        private PagoElectronico.WidgetsGUI.ComboValidable Nacionalidad;
        private PagoElectronico.WidgetsGUI.Fecha FechaNacimiento;
        private SelectorDeRol selectorDeRol1;
        private PagoElectronico.WidgetsGUI.Texto textBoxDepto;
    }
}