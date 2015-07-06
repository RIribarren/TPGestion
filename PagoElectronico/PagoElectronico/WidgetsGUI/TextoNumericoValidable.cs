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
        public int cantidadCaracteres = -1;
        
        public TextoNumericoValidable()
        {
            InitializeComponent();
        }

        public bool esValido()
        {
            if (Text == "")
                return false;

            if (cantidadCaracteres > 0)
                return Text.Length == cantidadCaracteres;

            return true;
        }

        public String obtenerMensajeDeError()
        {
            if (cantidadCaracteres > 0)
                return "El campo " + Name + " debe tener " + cantidadCaracteres.ToString() + " digitos";

            return "El campo " + Name + " no puede estar vacío";
        }
    }
}
