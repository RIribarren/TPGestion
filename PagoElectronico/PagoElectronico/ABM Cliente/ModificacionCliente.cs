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
    public partial class ModificacionCliente : Ventana
    {
        private Cliente cliente;

        public ModificacionCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        protected override void cargarDatos()
        {
            Nombre.Text = cliente.nombre;
            Apellido.Text = cliente.Apellido;
            NroIdentificacion.Text = cliente.nroIdentificacion;
            TipoDeIdentificacion.setTipoIdentificacion(cliente.tipoIdentificacion);
            Email.Text = cliente.email;
            pais.setPais(cliente.pais);
            Domicilio.Text = cliente.domicilio;
            Calle.Text = cliente.calle;
            textBoxDepto.Text = cliente.depto;
            Localidad.Text = cliente.localidad;
            Nacionalidad.setPais(cliente.nacionalidad);
            FechaNacimiento.setFecha(cliente.fechaNacimiento);
            Habilitado.Checked = cliente.habilitado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.esValido())
            {
                informarDatosInvalidos();
                return;
            }

            guardarCliente();
        }

        private void guardarCliente()
        {
            try
            {
                RepositorioDeDatos.getInstance().guardarCliente(
                    new Cliente(cliente.id,
                        Nombre.Text,
                        Apellido.Text,
                        NroIdentificacion.Text,
                        TipoDeIdentificacion.obtenerTipoIdentificacion(),
                        Email.Text,
                        pais.obtenerPais(),
                        Domicilio.Text,
                        Calle.Text,
                        textBoxDepto.Text,
                        Localidad.Text,
                        Nacionalidad.obtenerPais(),
                        FechaNacimiento.getFecha(),
                        Habilitado.Checked));
                volverConMensaje("Operacion exitosa", "El cliente fue actualizado");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                MessageBox.Show(excepcion.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
