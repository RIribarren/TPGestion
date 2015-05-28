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
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            clientes = RepositorioDeDatos.getInstance().obtenerClientes();

            foreach (Cliente cliente in clientes)
            {
                dataGridView1.Rows.Add(cliente.nombre, cliente.Apellido, cliente.email,
                    cliente.tipoIdentificacion.nombre, cliente.nroIdentificacion);
            }
        }
    }
}
