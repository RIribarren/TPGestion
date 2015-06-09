using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelo;
using System.Linq.Expressions;
using PagoElectronico.Ventanas;

namespace PagoElectronico.ABM_Rol
{
    public partial class ListadoRoles : Ventana
    {
        private List<Rol> roles;
        private Predicate<Rol> filtro = (r => true);
        public Rol rolElegido = null;

        public ListadoRoles()
        {
            InitializeComponent();
        }

        public ListadoRoles(Predicate<Rol> filtro)
        {
            InitializeComponent();
            this.filtro = filtro;
        }

        protected override void cargarDatos()
        {
            List<Rol> todosLosRoles = RepositorioDeDatos.getInstance().getRoles();
            cargarRoles(todosLosRoles.FindAll(filtro));        
        }

        private void cargarRoles(List<Rol> rolesACargar)
        {
            dataGridViewRoles.Rows.Clear();
            dataGridViewRoles.Refresh();
            roles = rolesACargar;
            foreach (Rol rol in roles)
                dataGridViewRoles.Rows.Add(rol.nombre, rol.estaActivo);
        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                rolElegido = roles.ElementAt(e.RowIndex);
                volver();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            var rolesFiltrados = RepositorioDeDatos.getInstance().getRolesFiltrados(getFiltro());
            cargarRoles(rolesFiltrados.FindAll(filtro));
        }

        private Predicate<Rol> getFiltro()
        {
            Predicate<Rol> filtroNombre = rol => { return true; };
            Predicate<Rol> filtroEstado = rol => { return true; };
            
            if (textFiltroNombre.Text != "")
                filtroNombre = rol => { return rol.nombre.Contains(textFiltroNombre.Text); };

            if (comboBoxEstado.SelectedIndex != -1)
                filtroEstado = rol => { return rol.estaActivo == (comboBoxEstado.SelectedIndex == 0); };

            return rol => { return filtroNombre(rol) && filtroEstado(rol); };
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textFiltroNombre.Text = "";
            comboBoxEstado.SelectedIndex = -1;
            buttonBuscar_Click(null, null);
        }
    }
}