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
    public partial class VentanaPadre : Form
    {
        public VentanaPadre()
        {
            InitializeComponent();
        }

        public void abrirVentanaHija(VentanaPadreHijo ventana)
        {
            this.Hide();
            ventana.ejecutar(this);
        }

        public void operacionTerminada()
        {
            this.Show();
        }
    }
}
