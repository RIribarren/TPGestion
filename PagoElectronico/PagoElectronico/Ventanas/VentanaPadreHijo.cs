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
        private VentanaPadre ventanaPadre;

        protected virtual void cargarDatos() { }

        public VentanaPadreHijo()
        {
            InitializeComponent();
        }

        public void ejecutar(VentanaPadre ventanaPadre)
        {
            this.ventanaPadre = ventanaPadre;
            cargarDatos();
            Show();
        }

        protected void volverConMensaje(String titulo, String mensaje)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            volver();
        }

        protected void volver()
        {
            Hide();
            ventanaPadre.operacionTerminada();
        }

        protected void VentanaPadreHijo_FormClosing(object sender, FormClosingEventArgs e)
        {
            volver();
        }
    }
}
