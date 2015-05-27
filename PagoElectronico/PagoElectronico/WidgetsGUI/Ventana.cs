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
    public partial class VentanaPadre : Form, Limpiable
    {
        public VentanaPadre()
        {
            InitializeComponent();
        }

        public void abrirVentanaHija(VentanaPadre ventanaHija)
        {
            this.Hide();
            ventanaHija.ejecutar(this);
            this.Show();
        }
        protected virtual void cargarDatos() { }

        public void ejecutar(VentanaPadre ventanaPadre)
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

        protected bool tieneDatosValidos()
        {
            Validador validador = new Validador();

            foreach (var validable in this.Controls.OfType<Validable>())
                validador.agregarValidable(validable);
            
            foreach (var groupBox in this.Controls.OfType<GroupBox>())
                agregarValidablesDeGroupBox(groupBox, validador);

            if (!validador.sonValoresValidos())
            {
                MessageBox.Show(validador.obtenerMensajeDeError(),
                    "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }

            return true;
        }

        private void agregarValidablesDeGroupBox(GroupBox groupBox, Validador validador)
        {
            foreach (var validable in groupBox.Controls.OfType<Validable>())
                validador.agregarValidable(validable);

            foreach (var gb in groupBox.Controls.OfType<GroupBox>())
                agregarValidablesDeGroupBox(gb, validador);
        }

        public void limpiar()
        {
            foreach (var limpiable in this.Controls.OfType<Limpiable>())
                limpiable.limpiar();

            foreach (var groupBox in this.Controls.OfType<GroupBox>())
                limpiarGroupBox(groupBox);
        }

        private void limpiarGroupBox(GroupBox groupBox)
        {
            foreach (var limpiable in groupBox.Controls.OfType<Limpiable>())
                limpiable.limpiar();

            foreach (var gb in groupBox.Controls.OfType<GroupBox>())
                limpiarGroupBox(gb);
        }
    }
}
