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
            TipoIdentificacion.setTipoIdentificacion(cliente.tipoIdentificacion);
            Email.Text = cliente.email;
            pais.setPais(cliente.pais);
            Altura.Text = cliente.altura;
            Calle.Text = cliente.calle;
            Piso.Text = cliente.piso;
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
            if (noEsValidoYMuestraMensaje())
                return;

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
                        TipoIdentificacion.obtenerTipoIdentificacion(),
                        Email.Text,
                        pais.obtenerPais(),
                        Altura.Text,
                        Calle.Text,
                        Piso.Text,
                        textBoxDepto.Text,
                        Localidad.Text,
                        Nacionalidad.obtenerPais(),
                        FechaNacimiento.getFecha(),
                        Habilitado.Checked));
                volverDeOperacionExitosa("El cliente fue actualizado");
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListadoTarjetas listadoTarjeta = new ListadoTarjetas(cliente);
            abrirVentanaHija(listadoTarjeta);
        }
    }
}
