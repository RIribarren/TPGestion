using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelo;
using PagoElectronico.WidgetsGUI;

namespace PagoElectronico.ABM_Cliente
{
    public partial class SelectorDeRol : UserControl, Validable, Limpiable
    {
        protected List<Rol> roles;
        private DataGridViewCheckBoxCell celdaSeleccionada = null;

        public SelectorDeRol()
        {
            InitializeComponent();
        }

        public void cargarRoles()
        {
            roles = RepositorioDeDatos.getInstance().getRolesActivados();

            foreach (Rol rol in roles)
            {
                dataGridViewRoles.Rows.Add(rol.nombre, false);
            }
        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0))
                return;

            if (celdaSeleccionada != null)
                celdaSeleccionada.Value = celdaSeleccionada.FalseValue;

            celdaSeleccionada = (DataGridViewCheckBoxCell)senderGrid.Rows[e.RowIndex].Cells[1];
        }

        public Rol obtenerRol()
        {
            MessageBox.Show("estoy");
            if (esValido())
                return roles.ElementAt(celdaSeleccionada.RowIndex);

            return null;
        }

        public bool esValido()
        {
            if (celdaSeleccionada == null)
                return false;

            return Convert.ToBoolean(celdaSeleccionada.Value);
        }

        public String obtenerMensajeDeError()
        {
            return "Debe seleccionar un rol";
        }

        public void limpiar()
        {
            foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                if (Convert.ToBoolean(row.Cells[1].Value) == true)
                    ((DataGridViewCheckBoxCell)row.Cells[1]).Value = false;
        }
    }
}
