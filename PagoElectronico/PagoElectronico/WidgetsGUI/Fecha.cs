using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.WidgetsGUI
{
    public partial class Fecha : UserControl, Validable, Limpiable
    {
        private DateTime fecha;
        public bool esValidable = true;

        public Fecha()
        {
            InitializeComponent();
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            VentanaFecha ventanaFecha = new VentanaFecha();
            ventanaFecha.ShowDialog(this);
            setFecha(ventanaFecha.getFecha());
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public void setFecha(DateTime fecha)
        {
            this.fecha = fecha;
            textBoxFecha.Text = fecha.ToString().Split(' ')[0];
        }

        public void limpiar()
        {
            textBoxFecha.Clear();
        }

        public bool esValido()
        {
            if (!esValidable)
                return true;

            return textBoxFecha.Text != "";
        }

        public String obtenerMensajeDeError()
        {
            return "Debe seleccionar una fecha para el campo " + Name;
        }
    }
}
