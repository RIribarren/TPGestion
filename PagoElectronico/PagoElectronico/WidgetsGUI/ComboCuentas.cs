using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelo;

namespace PagoElectronico.WidgetsGUI
{
    public partial class ComboCuentas : ComboValidable
    {
        protected List<Cuenta> cuentas;
     
        public ComboCuentas()
        {
            InitializeComponent();
        }

        public void cargarCuentas(List<Cuenta> cuentas)
        {
            this.cuentas = cuentas;
            foreach (Cuenta cuenta in cuentas)
                Items.Add(cuenta.Numero);
        }

        public Cuenta obtenerCuenta()
        {
            return cuentas.ElementAt(SelectedIndex);
        }
    }
}
