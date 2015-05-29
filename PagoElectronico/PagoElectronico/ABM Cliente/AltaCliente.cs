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
using PagoElectronico.WidgetsGUI;

namespace PagoElectronico.ABM_Cliente
{
    public partial class AltaCliente : Ventana
    {
        protected List<Pais> paises;
        protected int indiceRolSeleccionado = -1;
        protected String idAnterior = "";

        public AltaCliente()
        {
            InitializeComponent();
        }

        protected override void cargarDatos()
        {
            Roles.cargarRoles();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (noEsValidoYMuestraMensaje())
                return;

            Cliente nuevoCliente = new Cliente(
                -1,
                Nombre.Text,
                Apellido.Text,
                NroIdentificacion.Text,
                TipoIdentificacion.obtenerTipoIdentificacion(),
                Email.Text,
                pais.obtenerPais(),
                Domicilio.Text,
                Calle.Text,
                textBoxDepto.Text,
                Localidad.Text,
                Nacionalidad.obtenerPais(),
                FechaNacimiento.getFecha(),
                true);

            Usuario nuevoUsuario = new Usuario(
                -1,
                Username.Text,
                Password.Text,
                PreguntaSecreta.Text,
                RespuestaSecreta.Text,
                Roles.obtenerRol());

            try
            {
                RepositorioDeDatos.getInstance().crearCliente(nuevoCliente, nuevoUsuario);
                volverDeOperacionExitosa("El cliente fue creado");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }
    }
}
