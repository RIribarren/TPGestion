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
    public partial class TextoValidable : UserControl, Validable
    {
        public override String Text
        {
            get {return textBoxTexto.Text;}
            set { textBoxTexto.Text = value; }
        }

        public TextoValidable()
        {
            InitializeComponent();
        }

        public bool esValido()
        {
            return Text != "";
        }

        public String obtenerMensajeDeError()
        {
            if (esValido())
                return "";

            return "El campo " + Name + " no puede estar vacío";
        }
    }
}
