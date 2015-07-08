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

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Saldos : Ventana
    {
        private Cliente cliente;
        
        public Saldos(Cliente cliente)
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
            volver();
        }

        private void comboCuentas1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarSaldo();
            cargarUltimos5Depositos();
            cargarUltimos5Retiros();
            cargarUltimas10Transferencias();
            cargarUltimas10TransferenciasRecibidas();
        }

        private void cargarSaldo()
        {
            Cuenta cuenta = comboCuentas1.obtenerCuenta();
            textBox1.Text = RepositorioDeDatos.getInstance().obtenerSaldoDeCuenta(cuenta).ToString();
        }

        private void cargarUltimas10Transferencias()
        {
            dataGridView3.Rows.Clear();
            Cuenta cuenta = comboCuentas1.obtenerCuenta();
            List<Transferencia> ultimas10Transferencias = RepositorioDeDatos.getInstance().obtenerUltimas10Transferencias(cuenta);
            foreach (Transferencia t in ultimas10Transferencias)
            {
                dataGridView3.Rows.Add(t.fecha, t.monto, t.cuenta.Numero);
            }
        }

        private void cargarUltimas10TransferenciasRecibidas()
        {
            dataGridView4.Rows.Clear();
            Cuenta cuenta = comboCuentas1.obtenerCuenta();
            List<Transferencia> ultimas10Transferencias = RepositorioDeDatos.getInstance().obtenerUltimas10TransferenciasRecibidas(cuenta);
            foreach (Transferencia t in ultimas10Transferencias)
            {
                dataGridView4.Rows.Add(t.fecha, t.monto, t.cuenta.Numero);
            }
        }

        private void cargarUltimos5Retiros()
        {
            dataGridView2.Rows.Clear();
            Cuenta cuenta = comboCuentas1.obtenerCuenta();
            List<Retiro> ultimos5Retiros = RepositorioDeDatos.getInstance().obtenerUltimos5Retiros(cuenta);
            foreach (Retiro r in ultimos5Retiros)
            {
                dataGridView2.Rows.Add(r.fecha, r.monto);
            }
        }

        private void cargarUltimos5Depositos()
        {
            dataGridView1.Rows.Clear();
            Cuenta cuenta = comboCuentas1.obtenerCuenta();
            List<Deposito> ultimos5Depositos = RepositorioDeDatos.getInstance().obtenerUltimos5Depositos(cuenta);
            foreach (Deposito d in ultimos5Depositos)
            {
                dataGridView1.Rows.Add(d.fecha, d.monto);
            }
        }

    }
}
