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
using PagoElectronico.ABM_Cuenta;

namespace PagoElectronico.Facturacion
{
    public partial class FFacturacion : Ventana
    {
        private Cliente cliente;

        public FFacturacion(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        protected override void cargarDatos()
        {
            cargarTransaccionesPendientes();
        }

        private void cargarTransaccionesPendientes()
        {
            List<Transaccion> transaccionesPendientes = RepositorioDeDatos.getInstance().obtenerTransaccionesImpagasDeCliente(cliente);
            foreach (Transaccion transaccion in transaccionesPendientes)
            {
                dataGridView1.Rows.Add(transaccion.fecha, transaccion.cuenta, transaccion.descripcion, transaccion.importe);
            }

            Decimal total = transaccionesPendientes.Aggregate<Transaccion,Decimal>(0, (sum, t) => sum + t.importe);
            textBox1.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (noEsValidoYMuestraMensaje()) return;

            try
            {
                RepositorioDeDatos.getInstance().facturar(cliente);
                volverDeOperacionExitosa("Se han facturado todos los gastos al cliente");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }
    }
}
