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


namespace PagoElectronico.ABM_Cliente
{
    public partial class FiltroCliente : Ventana
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Cliente> clientesEnPantalla;

        public FiltroCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gBox1.limpiar();
        }

        protected override void cargarDatos()
        {
            clientes = obtenerClientes();
            cargarClientes(clientes);
        }

        protected void cargarClientes(List<Cliente> clientesACargar)
        {
            clientesEnPantalla = clientesACargar;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (Cliente cliente in clientesEnPantalla)
                dataGridView1.Rows.Add(cliente.nombre, cliente.Apellido, cliente.email,
                    cliente.tipoIdentificacion.nombre, cliente.nroIdentificacion);
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                tomarAccion(clientesEnPantalla.ElementAt(e.RowIndex));
                volver();
            }
        }

        protected virtual void tomarAccion(Cliente cliente) { throw new NotImplementedException(); }

        protected virtual List<Cliente> obtenerClientes() { throw new NotImplementedException(); }

        private void button2_Click(object sender, EventArgs e)
        {
            Predicate<Cliente> filtro = obtenerFiltro();
            cargarClientes(clientes.FindAll(filtro));
        }

        private Predicate<Cliente> obtenerFiltro()
        {
            Predicate<Cliente> filtroNombre = (c => true);
            Predicate<Cliente> filtroApellido = (c => true);
            Predicate<Cliente> filtroEmail = (c => true);
            Predicate<Cliente> filtroNumeroId = (c => true);
            Predicate<Cliente> filtroTipoId = (c => true);

            if (TextoFiltroNombre.Text != "")
                filtroNombre = (c => c.nombre.Contains(TextoFiltroNombre.Text));
            if (TextoFiltroApellido.Text != "")
                filtroApellido = (c => c.Apellido.Contains(TextoFiltroApellido.Text));
            if (TextoFiltroEmail.Text != "")
                filtroEmail = (c => c.email.Contains(TextoFiltroEmail.Text));
            if (TextoFiltroNroIdentificacion.Text != "")
                filtroNumeroId = (c => c.nroIdentificacion.Contains(TextoFiltroNroIdentificacion.Text));
            if (ComboFiltroTipoIdentificacion.SelectedIndex >= 0)
                filtroTipoId = (c => c.tipoIdentificacion.id == ComboFiltroTipoIdentificacion.obtenerTipoIdentificacion().id);

            return (c => filtroNombre(c) && filtroApellido(c) && filtroEmail(c)
                && filtroNumeroId(c) && filtroTipoId(c));
        }

    }
}
