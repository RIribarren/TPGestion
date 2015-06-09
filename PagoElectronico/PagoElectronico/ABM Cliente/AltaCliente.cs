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
                Nro_de_identificacion.Text,
                Tipo_identificacion.obtenerTipoIdentificacion(),
                Email.Text,
                pais.obtenerPais(),
                Altura.Text,
                Calle.Text,
                Piso.Text,
                textBoxDepto.Text,
                Localidad.Text,
                Nacionalidad.obtenerPais(),
                Fecha_de_nacimiento.getFecha(),
                true);

            Usuario nuevoUsuario = new Usuario(
                -1,
                Username.Text,
                Password.Text,
                Pregunta_Secreta.Text,
                Respuesta_Secreta.Text,
                Roles.obtenerRol(),
                nuevoCliente);

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
