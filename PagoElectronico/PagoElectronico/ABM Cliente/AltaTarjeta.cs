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
    public partial class AltaTarjeta : DatosTarjeta
    {
        private Cliente cliente;

        public AltaTarjeta(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        protected override void tomarAccion()
        {
            Tarjeta nuevaTarjeta = new Tarjeta(
                -1,
                cliente,
                Convert.ToDecimal(Numero.Text),
                FechaDeEmision.getFecha(),
                FechaDeVencimiento.getFecha(),
                CodigoDeSeguridad.Text,
                Emisor.Text,
                true);

            try
            {
                RepositorioDeDatos.getInstance().crearTarjeta(nuevaTarjeta);
                volverConMensaje("Operacion exitosa", "La tarjeta fue vinculada con el cliente");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                MessageBox.Show(excepcion.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
