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
    public partial class ComboTipoCuenta : ComboValidable
    {
        protected List<TipoCuenta> tiposCuenta;

        public ComboTipoCuenta()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            tiposCuenta = RepositorioDeDatos.getInstance().obtenerTiposCuenta();
            foreach (TipoCuenta tipo in tiposCuenta)
                Items.Add(tipo.nombre);
        }

        public TipoCuenta obtenerTipoCuenta()
        {
            return tiposCuenta.ElementAt(SelectedIndex);
        }

        public void setTipoCuenta(TipoCuenta tipoCuenta)
        {
            SelectedIndex = tiposCuenta.IndexOf(tiposCuenta.Find(t => t.id == tipoCuenta.id));
        }
    }
}
