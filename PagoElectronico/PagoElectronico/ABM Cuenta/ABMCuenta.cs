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

namespace PagoElectronico.ABM_Cuenta
{
    public partial class ABMCuenta : Ventana
    {
        private Usuario usuario;

        public ABMCuenta(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente clienteElegido;
            if (usuario.esAdmin())
                clienteElegido = elegirCliente();
            else
                clienteElegido = usuario.cliente;

            if (clienteElegido == null)
                return;

            AltaCuenta altaCuenta = new AltaCuenta(clienteElegido);
            abrirVentanaHija(altaCuenta);
        }

        private Cliente elegirCliente()
        {
            EleccionCliente eleccionCliente = new EleccionCliente();
            abrirVentanaHija(eleccionCliente);
            return eleccionCliente.obtenerCliente();
        }
    }
}
