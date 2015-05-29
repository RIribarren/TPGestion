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

namespace PagoElectronico.ABM_Rol
{
    public partial class DataRol : Ventana
    {
        protected ABMRol abmRol;
        protected List<Funcionalidad> todasLasFuncionalidades;
        protected String operacionMensaje;

        public DataRol(ABMRol abmRol) : base()
        {
            this.abmRol = abmRol;
            InitializeComponent();
        }

        public DataRol(): base()
        {
            InitializeComponent();
        }

        protected override void cargarDatos()
        {
            cargarFuncionalidades(RepositorioDeDatos.getInstance().getFuncionalidades());
        }

        protected virtual void cargarFuncionalidades(List<Funcionalidad> funcionalidadesDeRol)
        {
            dataGridViewFuncionalidades.Rows.Clear();
            dataGridViewFuncionalidades.Refresh();
            todasLasFuncionalidades = RepositorioDeDatos.getInstance().getFuncionalidades();
            
            foreach (Funcionalidad funcionalidad in todasLasFuncionalidades)
            {
                dataGridViewFuncionalidades.Rows.Add(funcionalidad.nombre, false);
            }
        }

        protected List<Funcionalidad> obtenerFuncionalidades()
        {
            List<Funcionalidad> funcionalidadesElegidas = new List<Funcionalidad>();

            foreach (DataGridViewRow row in dataGridViewFuncionalidades.Rows)
            {
                bool estaElegida = Convert.ToBoolean(row.Cells[1].FormattedValue);
                if (estaElegida)
                    funcionalidadesElegidas.Add(todasLasFuncionalidades.ElementAt(row.Index));
            }

            return funcionalidadesElegidas;
        }

        protected bool validarDatos()
        {
            if (textBoxNombre.Text == "")
            {
                MessageBox.Show("El campo nombre no puede estar vacío",
                    "Valor invalido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            bool datosSonValidos = validarDatos();

            if (!datosSonValidos)
                return;

            Rol rolModificado = getRolModificado();
            try
            {
                operacionSobreRol(rolModificado);
                volverDeOperacionExitosa("El rol fue " + operacionMensaje);
            }
            catch (ErrorEnRepositorioException excepcion)
            {
                mostrarError(excepcion.mensaje);
            }
        }

        protected virtual Rol getRolModificado()
        {
            return new Rol(
                -1,
                textBoxNombre.Text,
                obtenerFuncionalidades(),
                checkBoxActivado.Checked);
        }

        protected virtual void operacionSobreRol(Rol rol) {}

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
        }
    }
}
