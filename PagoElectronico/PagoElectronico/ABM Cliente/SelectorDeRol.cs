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
    public partial class SelectorDeRol : GridCheckBox
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
                rolesSeleccionados.Add(roles.ElementAt(celdaSeleccionada.RowIndex));
                return rolesSeleccionados;
            }

            return null;
        }
    }
}
