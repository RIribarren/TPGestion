using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.WidgetsGUI
{
    public partial class VentanaFecha : Form
    {
        public DateTime fecha;
        public VentanaFecha()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            fecha = monthCalendar1.SelectionStart;
            this.Hide();
        }

        public DateTime getFecha()
        {
            return fecha;
        }
    }
}
