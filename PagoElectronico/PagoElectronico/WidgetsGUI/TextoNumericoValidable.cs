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
        public int mayorOIgualA = -1;
        
        public TextoNumericoValidable()
        {
            InitializeComponent();
        }

        public bool esValido()
        {
            if (Text == "")
                return false;

            if (cantidadCaracteres > 0 && Text.Length != cantidadCaracteres)
                return false;

            if (mayorOIgualA > 0 && Decimal.Parse(Text) < mayorOIgualA)
                return false;

            return true;
        }

        public String obtenerMensajeDeError()
        {
            if (cantidadCaracteres > 0 && Text.Length != cantidadCaracteres)
                return "El campo " + Name + " debe tener " + cantidadCaracteres.ToString() + " digitos";

            if (mayorOIgualA > -1 && Decimal.Parse(Text) < mayorOIgualA)
                return "El campo " + Name + " debe ser mayor o igual a " + mayorOIgualA.ToString();

            return "El campo " + Name + " no puede estar vacío";
        }
    }
}
