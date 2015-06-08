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

namespace PagoElectronico.Transferencias
{
    public partial class FTransferencias : Ventana
    {
        private Cliente cliente;

        public FTransferencias(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        protected override void cargarDatos()
        {
            comboCuentas1.cargarCuentas(RepositorioDeDatos.getInstance().obtenerCuentasDeCliente(cliente));
            comboCuentas2.cargarCuentas(RepositorioDeDatos.getInstance().obtenerCuentas());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (noEsValidoYMuestraMensaje()) return;

            try
            {
                RepositorioDeDatos.getInstance().transferir(
                    comboCuentas1.obtenerCuenta(),
                    comboCuentas2.obtenerCuenta(),
                    Convert.ToDecimal(textoNumericoValidable1.Text));

                volverDeOperacionExitosa("La transferencia se realizó exitosamente");
                
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }
    }
}
