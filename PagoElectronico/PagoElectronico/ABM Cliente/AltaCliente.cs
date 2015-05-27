﻿using System;
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
    public partial class AltaCliente : VentanaPadre
    {
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
            selectorDeRol1.cargarRoles();
            cargarPaises();
            cargarTiposIdentificacion();
        }

        protected void cargarTiposIdentificacion()
        {
            tiposIdentificacion = RepositorioDeDatos.getInstance().getTiposIdentificacion();
            TipoIdentificacion.Items.AddRange(tiposIdentificacion.Select(i => i.nombre).ToArray());
        }

        protected void cargarPaises()
        {
            paises = RepositorioDeDatos.getInstance().getPaises();
            var nombrePaises = paises.Select(p => p.nombre).ToArray();
            Pais.Items.AddRange(nombrePaises);
            Nacionalidad.Items.AddRange(nombrePaises);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (! tieneDatosValidos())
                return;

            Cliente nuevoCliente = new Cliente(
                -1,
                Nombre.Text,
                Apellido.Text,
                NroIdentificacion.Text,
                tiposIdentificacion.ElementAt(TipoIdentificacion.SelectedIndex),
                Email.Text,
                paises.ElementAt(Pais.SelectedIndex),
                Domicilio.Text,
                Calle.Text,
                textBoxDepto.Text,
                Localidad.Text,
                paises.ElementAt(Nacionalidad.SelectedIndex),
                FechaNacimiento.Text);

            Usuario nuevoUsuario= new Usuario(
                -1,
                Username.Text,
                Password.Text,
                PreguntaSecreta.Text,
                RespuestaSecreta.Text,
                selectorDeRol1.obtenerRol());

            try
            {
                RepositorioDeDatos.getInstance().crearCliente(nuevoCliente, nuevoUsuario);
                volverConMensaje("Operacion exitosa", "El cliente fue creado");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                MessageBox.Show(excepcion.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
