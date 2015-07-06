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

                if (usuario.roles.Any(r => r.estaActivo))
                {
                    Rol rolAUsar = obtenerRolAUsar(usuario);

                    if (rolAUsar != null)
                        abrirVentanaHija(new MenuPrincipal(usuario, rolAUsar));
                }
                else
                    mostrarError("El rol del usuario no está habilitado");

                limpiar();
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }

        private Rol obtenerRolAUsar(Usuario usuario)
        {
            if (usuario.roles.FindAll(r => r.estaActivo).Count == 1)
                return usuario.roles.Find(r => r.estaActivo);

            EleccionRol eleccionRol = new EleccionRol(usuario);
            abrirVentanaHija(eleccionRol);

            Rol rolAUsar = eleccionRol.rolElegido;
            return rolAUsar;
        }
    }
}
