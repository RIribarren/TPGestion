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
    public partial class ModificarTarjeta : DatosTarjeta
    {
        private Tarjeta tarjeta;

        public ModificarTarjeta(Tarjeta tarjeta)
        {
            InitializeComponent();
            this.tarjeta = tarjeta;
        }

        protected override void cargarDatos()
        {
            Numero.Text = tarjeta.numero.ToString();
            FechaDeEmision.setFecha(tarjeta.fechaEmision);
            FechaDeVencimiento.setFecha(tarjeta.fechaVencimiento);
            CodigoDeSeguridad.Text = tarjeta.codigoSeguridad;
            Emisor.Text = tarjeta.emisor;
        }

        protected override void tomarAccion()
        {
            Tarjeta tarjetaModificada = new Tarjeta(
                tarjeta.id,
                tarjeta.cliente,
                Convert.ToDecimal(Numero.Text),
                FechaDeEmision.getFecha(),
                FechaDeVencimiento.getFecha(),
                CodigoDeSeguridad.Text,
                Emisor.Text);

            try
            {
                RepositorioDeDatos.getInstance().guardarTarjeta(tarjetaModificada);
                volverConMensaje("Operación exitosa", "La tarjeta fue modificada");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                MessageBox.Show(excepcion.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
