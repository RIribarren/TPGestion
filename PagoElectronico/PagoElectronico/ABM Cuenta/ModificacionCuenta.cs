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
    public partial class ModificacionCuenta : Ventana
    {
        protected Cuenta cuenta;
        public ModificacionCuenta(Cuenta cuenta)
        {
            InitializeComponent();
            this.cuenta = cuenta;
        }

        protected override void cargarDatos()
        {
            PaisDeRegistro.setPais(cuenta.pais);
            TipoDeMoneda.setMoneda(cuenta.moneda);
            TipoDeCuenta.setTipoCuenta(cuenta.tipoCuenta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (noEsValidoYMuestraMensaje())
                return;

            Cuenta cuentaModificada = new Cuenta(cuenta.Numero,
                PaisDeRegistro.obtenerPais(),
                TipoDeMoneda.obtenerMoneda(),
                cuenta.fechaCreacion,
                cuenta.cliente,
                TipoDeCuenta.obtenerTipoCuenta(),
                cuenta.estado);

            try
            {
                RepositorioDeDatos.getInstance().guardarCuenta(cuentaModificada);
                volverDeOperacionExitosa("La cuenta fue modificada");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }
    }
}
