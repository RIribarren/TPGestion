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
    public partial class GridTarjetas : GridCheckBox
    {
        protected List<Tarjeta> tarjetas;

        public GridTarjetas()
        {
            InitializeComponent();
        }

        public void cargarTarjetas(List<Tarjeta> tarjetas)
        {
            Rows.Clear();

            this.tarjetas = tarjetas;

            foreach (var tarjeta in tarjetas)
            {
                Rows.Add(
                    soloLos4UltimosNumeros(tarjeta.numero),
                    tarjeta.fechaEmision.ToShortDateString(),
                    tarjeta.fechaVencimiento.ToShortDateString(),
                    tarjeta.codigoSeguridad,
                    tarjeta.emisor,
                    false);
            }
        }

        private String soloLos4UltimosNumeros(decimal p)
        {
            String numeroTarjeta = p.ToString();
            return "******************".Substring(0, numeroTarjeta.Length - 4) +
                numeroTarjeta.Substring(numeroTarjeta.Length - 4);
        }

        public Tarjeta obtenerTarjeta()
        {
            foreach (DataGridViewRow fila in Rows)
            {
                if (Convert.ToBoolean(fila.Cells[5].Value) == true)
                    return tarjetas.ElementAt(fila.Index);
            }

            return null;
        }
    }
}
