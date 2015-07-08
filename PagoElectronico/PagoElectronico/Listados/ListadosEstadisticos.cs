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

namespace PagoElectronico.Listados
{
    public partial class ListadosEstadisticos : Ventana
    {
        public ListadosEstadisticos()
        {      
            InitializeComponent();
        }

        protected override void cargarDatos()
        {
            for (int i = 2016; i <= RepositorioDeDatos.getInstance().obtenerFechaDelSistema().Year; i++)
                comboAnio.Items.Add(i);

            comboTrimestre.SelectedIndex = 0;
            comboAnio.SelectedIndex = 0;
            mostrarInhabilitaciones();
        }

        private void mostrarInhabilitaciones()
        {
            int anio = int.Parse(comboAnio.Items[comboAnio.SelectedIndex].ToString());
            int trimestre = int.Parse(comboTrimestre.Items[comboTrimestre.SelectedIndex].ToString());
            List<Inhabilitacion> inhabilitaciones = RepositorioDeDatos.getInstance().obtenerInhabilitacionesDeCliente(anio, trimestre);

            dataGridInhabilitaciones.Rows.Clear();
            foreach (Inhabilitacion inhabilitacion in inhabilitaciones)
                dataGridInhabilitaciones.Rows.Add(inhabilitacion.nombre, inhabilitacion.apellido, inhabilitacion.documento, inhabilitacion.inhabilitaciones);

            ocultarReportes();
            dataGridInhabilitaciones.Visible = true;
        }

        private void ocultarReportes()
        {
            dataGridInhabilitaciones.Visible = false;
            dataGridComisiones.Visible = false;
            dataGridTransferencias.Visible = false;
            dataGridPaises.Visible = false;
            dataGridTipoCuentas.Visible = false;
        }

        private void comboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (esValido())
                mostrarResutadoReporte();
        }

        private void mostrarResutadoReporte()
        {
            try
            {
                if (comboListado.SelectedIndex == 0)
                    mostrarInhabilitaciones();
                else if (comboListado.SelectedIndex == 1)
                    mostrarComisiones();
                else if (comboListado.SelectedIndex == 2)
                    mostrarTransferencias();
                else if (comboListado.SelectedIndex == 3)
                    mostrarPaises();
                else if (comboListado.SelectedIndex == 4)
                    mostrarTipoCuentas();
            }
            catch (ErrorEnRepositorioException ex)
            {
                mostrarError(ex.mensaje);
            }
        }

        private void mostrarTipoCuentas()
        {
            int anio = int.Parse(comboAnio.Items[comboAnio.SelectedIndex].ToString());
            int trimestre = int.Parse(comboTrimestre.Items[comboTrimestre.SelectedIndex].ToString());
            List<TipoCuenta> tiposCuenta = RepositorioDeDatos.getInstance().obtenerTotalFacturadoTipoCuentas(anio, trimestre);

            dataGridTipoCuentas.Rows.Clear();
            foreach (TipoCuenta tipoCuenta in tiposCuenta)
                dataGridTipoCuentas.Rows.Add(tipoCuenta.nombre, tipoCuenta.totalFacturado);

            ocultarReportes();
            dataGridTipoCuentas.Visible = true;

        }

        private void mostrarPaises()
        {
            int anio = int.Parse(comboAnio.Items[comboAnio.SelectedIndex].ToString());
            int trimestre = int.Parse(comboTrimestre.Items[comboTrimestre.SelectedIndex].ToString());
            List<Pais> paises = RepositorioDeDatos.getInstance().obtenerPaisesConMasMovimientos(anio, trimestre);

            dataGridPaises.Rows.Clear();
            foreach (Pais pais in paises)
                dataGridPaises.Rows.Add(pais.nombre, pais.ingresos, pais.egresos);

            ocultarReportes();
            dataGridPaises.Visible = true;
        }

        private void mostrarTransferencias()
        {
            int anio = int.Parse(comboAnio.Items[comboAnio.SelectedIndex].ToString());
            int trimestre = int.Parse(comboTrimestre.Items[comboTrimestre.SelectedIndex].ToString());
            List<TransferenciasRealizadas> transferencias = RepositorioDeDatos.getInstance().obtenerClientesConMayoresTransferenciasPropias(anio, trimestre);

            dataGridTransferencias.Rows.Clear();
            foreach (TransferenciasRealizadas transferenciasRealizadas in transferencias)
                dataGridTransferencias.Rows.Add(transferenciasRealizadas.nombre, transferenciasRealizadas.apellido, transferenciasRealizadas.documento, transferenciasRealizadas.transferencias);

            ocultarReportes();
            dataGridTransferencias.Visible = true;
        }

        private void mostrarComisiones()
        {
            int anio = int.Parse(comboAnio.Items[comboAnio.SelectedIndex].ToString());
            int trimestre = int.Parse(comboTrimestre.Items[comboTrimestre.SelectedIndex].ToString());
            List<Comision> comisiones = RepositorioDeDatos.getInstance().obtenerClientesConMayoresComisionesFacturadas(anio, trimestre);

            dataGridComisiones.Rows.Clear();
            foreach (Comision comision in comisiones)
                dataGridComisiones.Rows.Add(comision.nombre, comision.apellido, comision.documento, comision.comisiones);

            ocultarReportes();
            dataGridComisiones.Visible = true;
        }

        private void comboTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (esValido())
                mostrarResutadoReporte();
        }

        private void comboValidable3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (esValido())
                mostrarResutadoReporte();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            volver();
        }
    }
}
