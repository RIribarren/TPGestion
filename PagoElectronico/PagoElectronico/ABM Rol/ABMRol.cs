using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelo;
using PagoElectronico.Ventanas;

namespace PagoElectronico.ABM_Rol
{
    public partial class ABMRol : Ventana
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            ListadoRoles listadoRoles = new ListadoRoles((r => r.estaActivo));
            abrirVentanaHija(listadoRoles);
            Rol rolElegido = listadoRoles.rolElegido;

            if (rolElegido == null) return;

            ejecutarBaja(rolElegido);
        }

        private Rol obtenerRol()
        {
            ListadoRoles listadoRoles = new ListadoRoles();
            abrirVentanaHija(listadoRoles);
            return listadoRoles.rolElegido;
        }

        private void ejecutarModificacion(Rol rol)
        {
            abrirVentanaHija(new ModificacionRol(this, rol));
        }

        private void ejecutarBaja(Rol rol)
        {
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea dar de baja el rol " + rol.nombre + "?", 
                "Confirmar operacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
                RepositorioDeDatos.getInstance().bajaRol(rol);

            volver();
        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {
            Rol rolElegido = obtenerRol();
            ejecutarModificacion(rolElegido);
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            abrirVentanaHija(new AltaRol(this));
        }
    }
}
