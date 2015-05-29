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
    public partial class GridCheckBox : DataGridView, Limpiable, Validable
    {
        protected DataGridViewCheckBoxCell celdaSeleccionada = null;

        public GridCheckBox()
        {
            InitializeComponent();
        }

        public bool esValido()
        {
            foreach (DataGridViewRow fila in this.Rows)
                if (fila.Cells.OfType<DataGridViewCheckBoxCell>().Any(c => Convert.ToBoolean(c.Value) == true))
                    return true;

            return false;
        }

        public string obtenerMensajeDeError()
        {
            return "Debe seleccionar un elemento de la lista " + Name;
        }

        public void limpiar()
        {
            foreach (DataGridViewRow fila in this.Rows)
                foreach (var celda in fila.Cells.OfType<DataGridViewCheckBoxCell>())
                    celda.Value = false;
        }

        private void GridCheckBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0))
                return;

            if (celdaSeleccionada != null)
                celdaSeleccionada.Value = celdaSeleccionada.FalseValue;

            celdaSeleccionada = (DataGridViewCheckBoxCell)senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }
}
