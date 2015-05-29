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

            tarjetas = RepositorioDeDatos.getInstance().obtenerTarjetasDeCliente(cliente);

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
    }
}
