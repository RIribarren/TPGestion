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
    enum Operacion
    {
        NINGUNA,
        ALTA,
        BAJA,
        MODIFICACION
    };

    public partial class ABMRol : VentanaPadreHijo
    {
        private Operacion operacion;

        public ABMRol()
        {
            this.operacion = Operacion.NINGUNA;

            InitializeComponent();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            this.operacion = Operacion.BAJA;
            abrirVentanaHija(new ListadoRoles(this));
        }

        public void rolFueSeleccionado(Rol rol)
        {
            if (this.operacion == Operacion.BAJA)
                ejecutarBaja(rol);
            else
                ejecutarModificacion(rol);

            this.operacion = Operacion.NINGUNA;
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
            this.operacion = Operacion.MODIFICACION;
            abrirVentanaHija(new ListadoRoles(this));
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            abrirVentanaHija(new AltaRol(this));
        }
    }
}
