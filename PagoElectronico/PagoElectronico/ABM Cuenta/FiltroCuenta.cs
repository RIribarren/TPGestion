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
        protected List<Cuenta> cuentasEnPantalla;
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

            mostrarCuentas(cuentas);
        }

        protected void mostrarCuentas(List<Cuenta> cuentasAMostrar)
        {
            cuentasEnPantalla = cuentasAMostrar;

            dataGridView1.Rows.Clear();

            foreach (Cuenta cuenta in cuentasEnPantalla)
                dataGridView1.Rows.Add(cuenta.Numero, cuenta.pais.nombre, cuenta.moneda.nombre, cuenta.tipoCuenta.nombre);
        }

        protected Predicate<Cuenta> obtenerFiltro()
        {
            Predicate<Cuenta> filtroNumero = (c => true);
            Predicate<Cuenta> filtroPais = (c => true);
            Predicate<Cuenta> filtroMoneda = (c => true);
            Predicate<Cuenta> filtroTipoCuenta = (c => true);

            if (textoNumero.Text != "")
                filtroNumero = (c => c.Numero.ToString().Contains(textoNumero.Text));
            if (comboPais1.SelectedIndex >= 0)
                filtroPais = (c => c.pais.id == comboPais1.obtenerPais().id);
            if (comboMoneda1.SelectedIndex >= 0)
                filtroMoneda = (c => c.moneda.id == comboMoneda1.obtenerMoneda().id);
            if (comboTipoCuenta1.SelectedIndex >= 0)
                filtroTipoCuenta = (c => c.tipoCuenta.id == comboTipoCuenta1.obtenerTipoCuenta().id);

            return (c => filtroNumero(c) && filtroPais(c) && filtroMoneda(c) && filtroTipoCuenta(c));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                cuenta = cuentasEnPantalla.ElementAt(e.RowIndex);
                volver();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarCuentas(cuentas.FindAll(obtenerFiltro()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            mostrarCuentas(cuentas);
        }
    }
}
