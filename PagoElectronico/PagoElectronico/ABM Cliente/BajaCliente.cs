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
    public partial class BajaCliente : FiltroCliente
    {
        public BajaCliente()
        {
            InitializeComponent();
        }

        protected override List<Cliente> obtenerClientes()
        {
            return RepositorioDeDatos.getInstance().obtenerClientesFiltrados(c => c.habilitado);
        }

        protected override void tomarAccion(Cliente cliente)
        {
            DialogResult accionConfirmada = MessageBox.Show(
                "¿Está seguro que desea dar de baja al cliente?",
                "Confirmar acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (accionConfirmada == DialogResult.Yes)
                try
                {
                    RepositorioDeDatos.getInstance().bajaCliente(cliente);
                    volverDeOperacionExitosa("El cliente fue dado de baja");
                }
                catch (ErrorEnRepositorioException excepcion)
                {
                    mostrarError(excepcion.mensaje);
                }
        }
    }
}
