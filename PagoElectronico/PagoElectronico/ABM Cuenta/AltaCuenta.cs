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
    public partial class AltaCuenta : Ventana
    {
        private Cliente cliente;

        public AltaCuenta(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (noEsValidoYMuestraMensaje())
                return;

            try
            {
                Cuenta nuevaCuenta = new Cuenta(
                    cliente,
                    PaisDeRegistro.obtenerPais(),
                    TipoDeMoneda.obtenerMoneda(),
                    TipoDeCuenta.obtenerTipoCuenta(),
                    int.Parse(textoNumericoValidable1.Text));

                RepositorioDeDatos.getInstance().crearCuenta(nuevaCuenta);
                volverDeOperacionExitosa("La cuenta fue creada");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }



    }
}
