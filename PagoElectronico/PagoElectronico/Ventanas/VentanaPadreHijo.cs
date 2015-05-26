using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Ventanas
{
    public partial class VentanaPadreHijo : VentanaPadre
    {
        protected virtual void cargarDatos() { }

        public VentanaPadreHijo()
        {
            InitializeComponent();
        }

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
    }
}
