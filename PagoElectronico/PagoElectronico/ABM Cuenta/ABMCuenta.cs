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
            Cliente clienteElegido = obtenerCliente();

            if (clienteElegido == null) return;

            AltaCuenta altaCuenta = new AltaCuenta(clienteElegido);
            abrirVentanaHija(altaCuenta);
        }

        private Cliente obtenerCliente()
        {
            if (usuario.esAdmin())
            {
                EleccionCliente eleccionCliente = new EleccionCliente();
                abrirVentanaHija(eleccionCliente);
                return eleccionCliente.obtenerCliente();
            }
            else
                return usuario.cliente;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cuenta cuentaElegida = obtenerCuenta();
            
            if (cuentaElegida != null)
                bajaDeCuenta(cuentaElegida);
        }

        private void bajaDeCuenta(Cuenta cuenta)
        {
            DialogResult confirmado = MessageBox.Show("Está seguro que desea dar de baja la cuenta?", "Confirmar acción", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmado == DialogResult.Yes)
            {
                try
                {
                    RepositorioDeDatos.getInstance().bajaCuenta(cuenta);
                    volverDeOperacionExitosa("La cuenta fue dada de baja");
                }
                catch (ErrorEnRepositorioException excepcion)
                {
                    mostrarError(excepcion.mensaje);
                }
            }
        }

        private Cuenta obtenerCuenta()
        {
            Cliente clienteElegido = obtenerCliente();
            if (clienteElegido == null) return null;

            FiltroCuenta filtroCuentas = new FiltroCuenta(clienteElegido);
            abrirVentanaHija(filtroCuentas);

            return filtroCuentas.cuenta;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cuenta cuentaElegida = obtenerCuenta();

            if (cuentaElegida == null)
                return;

            ModificacionCuenta modificacionCuenta = new ModificacionCuenta(cuentaElegida);
            abrirVentanaHija(modificacionCuenta);
        }
    }
}
