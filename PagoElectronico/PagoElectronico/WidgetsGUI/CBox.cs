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
    public partial class CBox : CheckBox, Limpiable
    {
        public CBox()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            this.Checked = false;
        }
    }
}
