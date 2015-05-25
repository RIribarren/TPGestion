using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Ventanas;
using PagoElectronico.Modelo;

namespace PagoElectronico.ABM_Cliente
{
    public partial class AltaCliente : VentanaPadreHijo
    {
        protected List<Rol> roles;
        protected List<Pais> paises;
        protected List<TipoIdentificacion> tiposIdentificacion;
        protected int indiceRolSeleccionado = -1;
        protected String idAnterior = "";

        public AltaCliente()
        {
            InitializeComponent();
        }

        protected override void cargarDatos()
        {
            cargarRoles();
            cargarPaises();
            cargarTiposIdentificacion();
        }

        protected void cargarTiposIdentificacion()
        {
            tiposIdentificacion = RepositorioDeDatos.getInstance().getTiposIdentificacion();
            comboBoxIdentificacion.Items.AddRange(tiposIdentificacion.Select(i => i.nombre).ToArray());
        }

        protected void cargarRoles()
        {
            roles = RepositorioDeDatos.getInstance().getRolesActivados();

            foreach (Rol rol in roles)
            {
                dataGridViewRoles.Rows.Add(rol.nombre, false);
            }
        }

        protected void cargarPaises()
        {
            paises = RepositorioDeDatos.getInstance().getPaises();
            var nombrePaises = paises.Select(p => p.nombre).ToArray();
            comboBoxPais.Items.AddRange(nombrePaises);
            comboBoxNacionalidad.Items.AddRange(nombrePaises);
        }

        protected void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0))
                return;

            if (indiceRolSeleccionado != -1)
            {
                var chk = (DataGridViewCheckBoxCell) dataGridViewRoles.Rows[indiceRolSeleccionado].Cells[1];
                chk.Value = chk.FalseValue;
            }

            indiceRolSeleccionado = e.RowIndex;
        }

        private void textBoxNroIdentificacion_TextChanged(object sender, EventArgs e)
        {
            bool sonTodosNumeros = textBoxNroIdentificacion.Text.ToCharArray().All(Char.IsDigit);

            if (sonTodosNumeros)
                idAnterior = textBoxNroIdentificacion.Text;
            else
            {
                textBoxNroIdentificacion.Text = idAnterior;
                textBoxNroIdentificacion.SelectionStart = textBoxNroIdentificacion.Text.Length + 1;
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VentanaFecha ventanaFecha = new VentanaFecha();
            ventanaFecha.ShowDialog(this);
            textBoxFechaNacimiento.Text = ventanaFecha.fecha;
        }
    }
}
