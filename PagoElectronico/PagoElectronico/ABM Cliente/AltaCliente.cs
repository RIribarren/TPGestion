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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxNroIdentificacion.Clear();
            comboBoxIdentificacion.SelectedIndex = -1;
            textBoxEmail.Clear();
            comboBoxPais.SelectedIndex = -1;
            textBoxDomicilio.Clear();
            textBoxCalle.Clear();
            textBoxDepto.Clear();
            textBoxLocalidad.Clear();
            comboBoxNacionalidad.SelectedIndex = -1;
            textBoxFechaNacimiento.Clear();

            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxPreguntaSecreta.Clear();
            textBoxRespuestaSecreta.Clear();

            if (indiceRolSeleccionado != -1)
                dataGridViewRoles.Rows[indiceRolSeleccionado].Cells[1].Value = false;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (! sonDatosValidos())
                return;

            Cliente nuevoCliente = new Cliente(
                -1,
                textBoxNombre.Text,
                textBoxApellido.Text,
                textBoxNroIdentificacion.Text,
                tiposIdentificacion.ElementAt(comboBoxIdentificacion.SelectedIndex),
                textBoxEmail.Text,
                paises.ElementAt(comboBoxPais.SelectedIndex),
                textBoxDomicilio.Text,
                textBoxCalle.Text,
                textBoxDepto.Text,
                textBoxLocalidad.Text,
                paises.ElementAt(comboBoxNacionalidad.SelectedIndex),
                textBoxFechaNacimiento.Text);

            Usuario nuevoUsuario= new Usuario(
                -1,
                textBoxUsername.Text,
                textBoxPassword.Text,
                textBoxPreguntaSecreta.Text,
                textBoxRespuestaSecreta.Text,
                obtenerListaDeRol());
        }

        private bool sonDatosValidos()
        {
            String mensajeDeError = "";

            if (textBoxNombre.Text == "")
                mensajeDeError += "El campo nombre no puede estar vacío\n";
            if (textBoxApellido.Text == "")
                mensajeDeError += "El campo apellido no puede estar vacío\n";
            if (textBoxNroIdentificacion.Text == "")
                mensajeDeError += "El campo Nro de identificación no puede estar vacío\n";
            if (comboBoxIdentificacion.SelectedIndex == -1)
                mensajeDeError += "Debe seleccionar un tipo de identificación\n";
            if (textBoxEmail.Text == "")
                mensajeDeError += "El campo e-Mail no puede estar vacío\n";
            if (comboBoxPais.SelectedIndex == -1)
                mensajeDeError += "Debe seleccionar un país\n";
            if (textBoxDomicilio.Text == "")
                mensajeDeError += "El campo domicilio no puede estar vacío\n";
            if (textBoxCalle.Text == "")
                mensajeDeError += "El campo calle no puede estar vacío\n";
            if (textBoxLocalidad.Text == "")
                mensajeDeError += "El campo localidad no puede estar vacío\n";
            if (comboBoxNacionalidad.SelectedIndex == -1)
                mensajeDeError += "Debe seleccionar un país\n";
            if (textBoxFechaNacimiento.Text == "")
                mensajeDeError += "El campo fecha de nacimiento no puede estar vacío\n";
            if (textBoxUsername.Text == "")
                mensajeDeError += "El campo username no puede estar vacío\n";
            if (textBoxPassword.Text == "")
                mensajeDeError += "El campo password no puede estar vacío\n";
            if (textBoxPreguntaSecreta.Text == "")
                mensajeDeError += "El campo pregunta secreta no puede estar vacío\n";
            if (textBoxRespuestaSecreta.Text == "")
                mensajeDeError += "El campo respuesta secreta no puede estar vacío\n";
            if (cantidadRolesSeleccionados() != 1)
                mensajeDeError += "Debe seleccionar un rol\n";

            if (mensajeDeError != "")
            {
                MessageBox.Show(mensajeDeError, "Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private int cantidadRolesSeleccionados()
        {
            int cantidad = 0;

            foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                if (Convert.ToBoolean(row.Cells[1].FormattedValue) == true)
                    cantidad++;

            return cantidad;
        }

        private Rol obtenerListaDeRol()
        {
            foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                if (Convert.ToBoolean(row.Cells[1].FormattedValue) == true)
                    return roles.ElementAt(row.Index);

            return null;
        }
    }
}
