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
    public partial class GBox : GroupBox, Validable, Limpiable
    {
        public GBox()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            foreach (Limpiable limpiable in this.Controls.OfType<Limpiable>())
                limpiable.limpiar();
        }

        public bool esValido()
        {
            Validador validador = new Validador();
            
            foreach (Validable validable in this.Controls.OfType<Validable>())
                validador.agregarValidable(validable);

            return validador.sonValoresValidos();
        }

        public String obtenerMensajeDeError()
        {
            Validador validador = new Validador();

            foreach (Validable validable in this.Controls.OfType<Validable>())
                validador.agregarValidable(validable);

            return validador.obtenerMensajeDeError().TrimEnd('\n');
        }
    }
}
