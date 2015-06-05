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
    public partial class FiltroCuenta : Ventana
    {
        protected List<Cuenta> cuentas;
        protected Cliente cliente;
        public Cuenta cuenta = null;

        public FiltroCuenta(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        protected override void cargarDatos()
        {
            cuentas = RepositorioDeDatos.getInstance().obtenerCuentasDeCliente(cliente);

            foreach (Cuenta cuenta in cuentas)
                dataGridView1.Rows.Add(cuenta.Numero, cuenta.pais.nombre, cuenta.moneda.nombre, cuenta.tipoCuenta.nombre);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                cuenta = cuentas.ElementAt(e.RowIndex);
                volver();
            }
        }
    }
}
