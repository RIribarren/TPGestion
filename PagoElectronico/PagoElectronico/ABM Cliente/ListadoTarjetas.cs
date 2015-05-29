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
        private Cliente cliente;

        public ListadoTarjetas(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        protected override void cargarDatos()
        {
            dataGridView1.Rows.Clear();

            tarjetas = RepositorioDeDatos.getInstance().obtenerTarjetasHabilitadasDeCliente(cliente);

            foreach (var tarjeta in tarjetas)
            {
                dataGridView1.Rows.Add(
                    tarjeta.numero,
                    tarjeta.fechaEmision,
                    tarjeta.fechaVencimiento,
                    tarjeta.codigoSeguridad,
                    tarjeta.emisor,
                    false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AltaTarjeta altaTarjeta = new AltaTarjeta(cliente);
            abrirVentanaHija(altaTarjeta);
            cargarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tarjeta tarjeta = obtenerTarjeta();
            if (tarjeta == null)
                return;

            ModificarTarjeta modificarTarjeta = new ModificarTarjeta(tarjeta);
            abrirVentanaHija(modificarTarjeta);
            cargarDatos();
        }

        private Tarjeta obtenerTarjeta()
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(fila.Cells[5].Value) == true)
                    return tarjetas.ElementAt(fila.Index);
            }

            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tarjeta tarjeta = obtenerTarjeta();
            if (tarjeta == null)
                return;

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
                    MessageBox.Show(excepcion.mensaje, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
