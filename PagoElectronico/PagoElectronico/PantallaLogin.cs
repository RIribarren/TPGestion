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
            if (noEsValidoYMuestraMensaje())
                return;

            try
            {
                Usuario usuario = RepositorioDeDatos.getInstance().login(Username.Text, Password.Text);
                abrirVentanaHija(new MenuPrincipal(usuario));
                limpiar();
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }
    }
}
