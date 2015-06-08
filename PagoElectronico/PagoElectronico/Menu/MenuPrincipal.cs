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
        private int ABMROL = 1;
        //private int LOGIN = 2;
        //private int ABRUSUARIO = 3;
        private int ABMCLIENTE = 4;
        private int ABMCUENTA = 5;
        private int DEPOSITOS = 6;
        private int RETIROEFECTIVO = 7;
        private int TRANSFERENCIA = 8;
        private int FACTURACION = 9;
        private int SALDOS = 10;
       // private int LISTADO = 11;

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

            if (ventanaDeFuncionalidad != null)
                abrirVentanaHija(ventanaDeFuncionalidad);
        }

        private Ventana obtenerVentanaDeFuncionalidad()
        {
            Funcionalidad funcionalidadElegida = usuario.rol.funcionalidades.ElementAt(Funcionalidades.SelectedIndex);

            if (funcionalidadElegida.id == ABMROL)
                return new ABMRol();
            else if (funcionalidadElegida.id == ABMCLIENTE)
                return new ABMCliente();
            else if (funcionalidadElegida.id == ABMCUENTA)
                return new ABMCuenta(usuario);
            else if (funcionalidadElegida.id == DEPOSITOS)
                return new FDepositos(usuario.cliente);
            else if (funcionalidadElegida.id == RETIROEFECTIVO)
                return new FRetiro(usuario.cliente);
            else if (funcionalidadElegida.id == TRANSFERENCIA)
                return new FTransferencias(usuario.cliente);
            else if (funcionalidadElegida.id == FACTURACION)
                return obtenerVentanaFacturacion();
            else if (funcionalidadElegida.id == SALDOS)
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
