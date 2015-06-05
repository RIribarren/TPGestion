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
    public partial class ComboMoneda : ComboValidable
    {
        protected List<Moneda> monedas;

        public ComboMoneda()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            monedas = RepositorioDeDatos.getInstance().obtenerMonedas();
            foreach (Moneda moneda in monedas)
                Items.Add(moneda.nombre);
        }

        public Moneda obtenerMoneda()
        {
            return monedas.ElementAt(SelectedIndex);
        }
    }
}
