using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.WidgetsGUI;

namespace PagoElectronico.Menu
{
    public partial class ListaValidable : ListBox, Validable, Limpiable
    {
        public ListaValidable()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            SelectedItem = -1;
        }

        public bool esValido()
        {
            return SelectedIndex > -1;
        }

        public String obtenerMensajeDeError()
        {
            return "Debe elegir un elemento de la lista " + Name;
        }
    }
}
