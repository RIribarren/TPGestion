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
    public partial class TextoNumerico : UserControl
    {
        private String contenidoAnterior = "";

        public override String Text
        {
            get { return textBoxTextoNumerico.Text; }
            set { textBoxTextoNumerico.Text = value; }
        }

        public TextoNumerico()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool sonTodosNumeros = Text.ToCharArray().All(Char.IsDigit);

            if (sonTodosNumeros)
                contenidoAnterior = Text;
            else
            {
                Text = contenidoAnterior;
                textBoxTextoNumerico.SelectionStart = Text.Length + 1;
            }
        }
    }
}
