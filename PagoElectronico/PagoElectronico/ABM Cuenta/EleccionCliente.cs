using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.ABM_Cliente;
using PagoElectronico.Modelo;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class EleccionCliente : FiltroCliente
    {
        protected Cliente cliente = null;

        public EleccionCliente()
        {
            InitializeComponent();
        }

        protected override void tomarAccion(Cliente cliente)
        {
            this.cliente = cliente;
        }

        protected override List<Cliente> obtenerClientes()
        {
            return RepositorioDeDatos.getInstance().obtenerClientesFiltrados(c => c.habilitado);
        }

        public Cliente obtenerCliente()
        {
            return this.cliente;
        }
    }
}
