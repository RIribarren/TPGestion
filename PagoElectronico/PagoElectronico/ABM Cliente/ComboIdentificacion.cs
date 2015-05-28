using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.WidgetsGUI;
using PagoElectronico.Modelo;

namespace PagoElectronico.ABM_Cliente
{
    public partial class ComboIdentificacion : ComboValidable
    {
        protected List<TipoIdentificacion> tiposIdentificacion;

        public ComboIdentificacion()
        {
            InitializeComponent();
            tiposIdentificacion = RepositorioDeDatos.getInstance().getTiposIdentificacion();
            Items.AddRange(tiposIdentificacion.Select(i => i.nombre).ToArray());
        }

        public TipoIdentificacion obtenerTipoIdentificacion()
        {
            return tiposIdentificacion.ElementAt(SelectedIndex);
        }
    }
}
