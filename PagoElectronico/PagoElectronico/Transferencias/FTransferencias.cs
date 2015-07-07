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
            Importe.mayorOIgualA = 1;
        }

        protected override void cargarDatos()
        {
            Cuenta_Origen.cargarCuentas(RepositorioDeDatos.getInstance().obtenerCuentasDeCliente(cliente));
            Cuenta_Destino.cargarCuentas(RepositorioDeDatos.getInstance().obtenerCuentas());
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
                    Cuenta_Origen.obtenerCuenta(),
                    Cuenta_Destino.obtenerCuenta(),
                    Convert.ToDecimal(Importe.Text));

                volverDeOperacionExitosa("La transferencia se realizó exitosamente");
                
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }
    }
}
