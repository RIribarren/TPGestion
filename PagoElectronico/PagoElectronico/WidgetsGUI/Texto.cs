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
    public partial class Texto : UserControl, Limpiable
    {
        public override String Text
        {
            get { return textBoxTexto.Text; }
            set { textBoxTexto.Text = value; }
        }

        public Texto()
        {
            InitializeComponent();
        }


        public void limpiar()
        {
            textBoxTexto.Clear();
        }
    }
}
