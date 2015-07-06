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
using PagoElectronico.Depositos;
using PagoElectronico.Retiros;
using PagoElectronico.Transferencias;
using PagoElectronico.Facturacion;
using PagoElectronico.Consulta_Saldos;

namespace PagoElectronico.Menu
{
    public partial class MenuPrincipal : Ventana
    {
        private Usuario usuario;
        private Rol rolAUsar;

        public MenuPrincipal(Usuario usuario, Rol rolAUsar)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.rolAUsar = rolAUsar;
        }

        protected override void cargarDatos()
        {
            foreach (Funcionalidad funcionalidad in rolAUsar.funcionalidades)
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

            if (ventanaDeFuncionalidad != null)
                abrirVentanaHija(ventanaDeFuncionalidad);
        }

        private Ventana obtenerVentanaDeFuncionalidad()
        {
            Funcionalidad funcionalidadElegida = rolAUsar.funcionalidades.ElementAt(Funcionalidades.SelectedIndex);

            if (funcionalidadElegida.id == Funcionalidad.ABMROL)
                return new ABMRol();
            else if (funcionalidadElegida.id == Funcionalidad.ABMCLIENTE)
                return new ABMCliente();
            else if (funcionalidadElegida.id == Funcionalidad.ABMCUENTA)
                return new ABMCuenta(usuario);
            else if (funcionalidadElegida.id == Funcionalidad.DEPOSITOS)
                return new FDepositos(usuario.cliente);
            else if (funcionalidadElegida.id == Funcionalidad.RETIROEFECTIVO)
                return new FRetiro(usuario.cliente);
            else if (funcionalidadElegida.id == Funcionalidad.TRANSFERENCIA)
                return new FTransferencias(usuario.cliente);
            else if (funcionalidadElegida.id == Funcionalidad.FACTURACION)
                return obtenerVentanaFacturacion();
            else if (funcionalidadElegida.id == Funcionalidad.SALDOS)
                return obtenerVentanaSaldos();

            throw new NotImplementedException();
        }

        private Ventana obtenerVentanaSaldos()
        {
            Cliente cliente = obtenerCliente();
            if (cliente == null)
                return null;

            return new Saldos(cliente);
        }

        private Ventana obtenerVentanaFacturacion()
        {
            Cliente cliente = obtenerCliente();
            if (cliente == null)
                return null;

            return new FFacturacion(cliente);
        }

        private Cliente obtenerCliente()
        {
            if (usuario.esAdmin())
            {
                EleccionCliente eleccionCliente = new EleccionCliente();
                abrirVentanaHija(eleccionCliente);
                return eleccionCliente.obtenerCliente();
            }

            return usuario.cliente;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            volver();
        }
    }
}
