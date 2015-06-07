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

namespace PagoElectronico.Retiros
{
    public partial class FRetiro : Ventana
    {
        protected Cliente cliente;

        public FRetiro(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        protected override void cargarDatos()
        {
            comboCuentas1.cargarCuentas(RepositorioDeDatos.getInstance().obtenerCuentasDeCliente(cliente));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (noEsValidoYMuestraMensaje())
                return;

            Cuenta cuenta = comboCuentas1.obtenerCuenta();

            try
            {
                RepositorioDeDatos.getInstance().retirar(
                    cliente,
                    cuenta,
                    Convert.ToDecimal(textoNumerico1.Text),
                    comboMoneda1.obtenerMoneda());

                volverDeOperacionExitosa("Se realizó el retiro");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }

        }

    }
}
