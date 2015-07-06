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
    public partial class SelectorDeRol : DataGridView, Limpiable, Validable
    {
        protected List<Rol> roles;
        
        public SelectorDeRol()
        {
            InitializeComponent();
        }

        public void cargarRoles()
        {
            roles = RepositorioDeDatos.getInstance().getRolesFiltrados((r => r.estaActivo));

            foreach (Rol rol in roles)
            {
                this.Rows.Add(rol.nombre, false);
            }
        }

        public List<Rol> obtenerRoles()
        {
            List<Rol> rolesSeleccionados = new List<Rol>();
            if (esValido())
            {
                foreach (DataGridViewRow fila in this.Rows)
                    foreach (var celda in fila.Cells.OfType<DataGridViewCheckBoxCell>())
                        if (Boolean.Parse(celda.Value.ToString()) == true)
                            rolesSeleccionados.Add(roles.ElementAt(fila.Index));
            }

            return rolesSeleccionados;
        }

        public void limpiar()
        {
            foreach (DataGridViewRow fila in this.Rows)
                foreach (var celda in fila.Cells.OfType<DataGridViewCheckBoxCell>())
                    celda.Value = false;
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
            return "Debe seleccionar al menos un elemento de la lista " + Name;
        }
    }
}
