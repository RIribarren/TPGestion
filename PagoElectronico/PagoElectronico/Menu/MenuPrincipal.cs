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
using PagoElectronico.ABM_Rol;
using PagoElectronico.ABM_Cliente;
using PagoElectronico.ABM_Cuenta;

namespace PagoElectronico.Menu
{
    public partial class MenuPrincipal : Ventana
    {
        private Usuario usuario;

        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        protected override void cargarDatos()
        {
            foreach (Funcionalidad funcionalidad in usuario.rol.funcionalidades)
            {
                Funcionalidades.Items.Add(funcionalidad.nombre);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!esValido())
            {
                MessageBox.Show(obtenerMensajeDeError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ventana ventanaDeFuncionalidad = obtenerVentanaDeFuncionalidad();

            abrirVentanaHija(ventanaDeFuncionalidad);
        }

        private Ventana obtenerVentanaDeFuncionalidad()
        {
            Funcionalidad funcionalidadElegida = usuario.rol.funcionalidades.ElementAt(Funcionalidades.SelectedIndex);

            if (funcionalidadElegida.nombre == "ABM Roles")
                return new ABMRol();
            else if (funcionalidadElegida.nombre == "ABM Clientes")
                return new ABMCliente();
            else if (funcionalidadElegida.nombre == "ABM Cuenta")
                return new ABMCuenta(usuario);

            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            volver();
        }
    }
}
