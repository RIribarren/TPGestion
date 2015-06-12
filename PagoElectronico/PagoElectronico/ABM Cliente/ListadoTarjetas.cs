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
    public partial class ListadoTarjetas : Ventana
    {
        private List<Tarjeta> tarjetas;
        private List<Tarjeta> tarjetasEnPantalla;
        private Cliente cliente;

        public ListadoTarjetas(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            FechaVencimiento.esValidable = false;
            FechaEmision.esValidable = false;
        }

        protected override void cargarDatos()
        {
            tarjetas = RepositorioDeDatos.getInstance().obtenerTarjetasHabilitadasDeCliente(cliente);

            mostrarTarjetas(tarjetas);
        }

        private void mostrarTarjetas(List<Tarjeta> tarjetasAMostrar)
        {
            tarjetasEnPantalla = tarjetasAMostrar;
            TarjetasDeCliente.Rows.Clear();
            foreach (var tarjeta in tarjetasEnPantalla)
            {
                TarjetasDeCliente.Rows.Add(
                    soloLos4UltimosNumeros(tarjeta.numero),
                    tarjeta.fechaEmision.ToShortDateString(),
                    tarjeta.fechaVencimiento.ToShortDateString(),
                    tarjeta.codigoSeguridad,
                    tarjeta.emisor,
                    false);
            }
        }

        private String soloLos4UltimosNumeros(decimal p)
        {
            String numeroTarjeta = p.ToString();
            return "******************".Substring(0, numeroTarjeta.Length -4) +
                numeroTarjeta.Substring(numeroTarjeta.Length - 4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            mostrarTarjetas(tarjetas);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AltaTarjeta altaTarjeta = new AltaTarjeta(cliente);
            abrirVentanaHija(altaTarjeta);
            cargarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!esValido())
            {
                MessageBox.Show(obtenerMensajeDeError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Tarjeta tarjeta = obtenerTarjeta();
            
            ModificarTarjeta modificarTarjeta = new ModificarTarjeta(tarjeta);
            abrirVentanaHija(modificarTarjeta);
            cargarDatos();
        }

        private Tarjeta obtenerTarjeta()
        {
            foreach (DataGridViewRow fila in TarjetasDeCliente.Rows)
            {
                if (Convert.ToBoolean(fila.Cells[5].Value) == true)
                    return tarjetasEnPantalla.ElementAt(fila.Index);
            }

            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (noEsValidoYMuestraMensaje())
                return;

            Tarjeta tarjeta = obtenerTarjeta();
            
            DialogResult confirmado = MessageBox.Show("¿Está seguro que desea dar de baja la tarjeta?",
                "Confirmar operacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmado == DialogResult.Yes)
                try
                {
                    RepositorioDeDatos.getInstance().bajaTarjeta(tarjeta);
                    MessageBox.Show("La tarjeta fue dada de baja", "Operación exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                catch (ErrorEnRepositorioException excepcion)
                {
                    mostrarError(excepcion.mensaje);
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mostrarTarjetas(tarjetas.FindAll(obtenerFiltro()));
        }

        private Predicate<Tarjeta> obtenerFiltro()
        {
            Predicate<Tarjeta> filtroNumero = (t => true);
            Predicate<Tarjeta> filtroCodigo = (t => true);
            Predicate<Tarjeta> filtroEmisor = (t => true);
            Predicate<Tarjeta> filtroFechaEmision = (t => true);
            Predicate<Tarjeta> filtroFechaVencimiento = (t => true);

            if (textoNumero.Text != "")
                filtroNumero = (t => t.numero.ToString().Contains(textoNumero.Text));
            if (textoCodigo.Text != "")
                filtroCodigo = (t => t.codigoSeguridad.ToString().Contains(textoCodigo.Text));
            if (textoEmisor.Text != "")
                filtroEmisor = (t => t.emisor.ToString().Contains(textoEmisor.Text));
            if (FechaEmision.textBoxFecha.Text != "")
                filtroFechaEmision = (t => t.fechaEmision == FechaEmision.getFecha());
            if (FechaVencimiento.textBoxFecha.Text != "")
                filtroFechaVencimiento = (t => t.fechaVencimiento == FechaVencimiento.getFecha());

            return t => filtroNumero(t) && filtroCodigo(t) && filtroEmisor(t)
                && filtroFechaEmision(t) && filtroFechaVencimiento(t);
        }
    }
}
