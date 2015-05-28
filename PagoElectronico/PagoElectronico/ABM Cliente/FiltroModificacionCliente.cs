using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelo;

namespace PagoElectronico.ABM_Cliente
{
    public partial class FiltroModificacionCliente : FiltroCliente
    {
        public FiltroModificacionCliente()
        {
            InitializeComponent();
        }

        protected override List<PagoElectronico.Modelo.Cliente> obtenerClientes()
        {
            return RepositorioDeDatos.getInstance().obtenerClientes();
        }

        protected override void tomarAccion(Cliente cliente)
        {
            ModificacionCliente modificacionCliente = new ModificacionCliente(cliente);
            abrirVentanaHija(modificacionCliente);
        }
    }
}
