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
    public partial class TextoNumericoValidable : TextoNumerico, Validable, Limpiable
    {
        public TextoNumericoValidable()
        {
            InitializeComponent();
        }

        public bool esValido()
        {
            return Text != "";
        }

        public String obtenerMensajeDeError()
        {
            return "El campo " + Name + " no puede estar vacío";
        }
    }
}
