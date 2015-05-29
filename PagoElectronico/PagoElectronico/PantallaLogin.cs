using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Ventanas;
using PagoElectronico.Modelo;
using PagoElectronico.Menu;

namespace PagoElectronico
{
    public partial class PantallaLogin : Ventana
    {
        public PantallaLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!esValido())
            {
                MessageBox.Show(obtenerMensajeDeError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuario;

            try
            {
                usuario = RepositorioDeDatos.getInstance().login(Username.Text, Password.Text);
                abrirVentanaHija(new MenuPrincipal(usuario));
                limpiar();
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                MessageBox.Show(excepcion.mensaje, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
