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
            Username.accionEnter = login;
            Password.accionEnter = login;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            if (noEsValidoYMuestraMensaje())
                return;

            try
            {
                Usuario usuario = RepositorioDeDatos.getInstance().login(Username.Text, Password.Text);

                if (usuario.rol.estaActivo)
                    abrirVentanaHija(new MenuPrincipal(usuario));
                else
                    mostrarError("El rol del usuario no está habilitado");

                limpiar();
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }
    }
}
