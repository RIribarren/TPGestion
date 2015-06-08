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
    public partial class Texto : TextBox, Limpiable
    {
        public Action accionEnter = null;

        public Texto()
        {
            InitializeComponent();
        }


        public void limpiar()
        {
            Clear();
        }

        private void Texto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && accionEnter != null)
                accionEnter();
        }
    }
}
