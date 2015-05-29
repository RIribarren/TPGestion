using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.WidgetsGUI;

namespace PagoElectronico.Ventanas
{
    public partial class Ventana : Form, Limpiable, Validable
    {
        public Ventana()
        {
            InitializeComponent();
        }

        public void abrirVentanaHija(Ventana ventanaHija)
        {
            this.Hide();
            ventanaHija.ejecutar(this);
            this.Show();
        }
        protected virtual void cargarDatos() { }

        public void ejecutar(Ventana ventanaPadre)
        {
            cargarDatos();
            ShowDialog(ventanaPadre);
        }

        protected void volverConMensaje(String titulo, String mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            volver();
        }

        protected void volver()
        {
            Hide();
        }

        public void informarDatosInvalidos()
        {
            if (! this.esValido())
                MessageBox.Show(
                    this.obtenerMensajeDeError(),
                    "Datos inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        public bool esValido()
        {
            Validador validador = new Validador();

            foreach (var validable in this.Controls.OfType<Validable>())
                validador.agregarValidable(validable);

            return validador.sonValoresValidos();
        }

        public String obtenerMensajeDeError()
        {
            Validador validador = new Validador();

            foreach (var validable in this.Controls.OfType<Validable>())
                validador.agregarValidable(validable);

            return validador.obtenerMensajeDeError();
        }

        public void limpiar()
        {
            foreach (var limpiable in this.Controls.OfType<Limpiable>())
                limpiable.limpiar();
        }

        protected bool noEsValidoYMuestraMensaje()
        {
            if (!esValido())
            {
                mostrarError(obtenerMensajeDeError());
                return true;
            }

            return false;
        }

        protected void volverDeOperacionExitosa(String mensaje)
        {
            volverConMensaje("Operacion exitosa", mensaje);
        }

        protected void mostrarError(String mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
