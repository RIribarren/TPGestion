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
    public partial class ComboValidable : UserControl, Validable
    {
        public ComboBox.ObjectCollection Items
        {
            get { return comboBoxCombo.Items; }
        }

        public bool esValido()
        {
            return comboBoxCombo.SelectedIndex >= 0;
        }

        public String obtenerMensajeDeError()
        {
            return "Debe seleccionar un valor de la lista de " + Name;
        }

        public ComboValidable()
        {
            InitializeComponent();
        }
    }
}
