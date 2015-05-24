using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelo;

namespace PagoElectronico.ABM_Rol
{
    public partial class ModificacionRol : DataRol
    {
        private Rol rolAModificar;

        public ModificacionRol(ABMRol abmRol, Rol rol)
            : base(abmRol)
        {
            operacionMensaje = "actualizado";
            rolAModificar = rol;
            InitializeComponent();
        }

        protected override void cargarDatos()
        {
            textBoxNombre.Text = rolAModificar.nombre;
            checkBoxActivado.Checked = rolAModificar.estaActivo;
            cargarFuncionalidades(rolAModificar.funcionalidades);
        }

        protected override void cargarFuncionalidades(List<Funcionalidad> funcionalidadesDeRol)
        {
            dataGridViewFuncionalidades.Rows.Clear();
            dataGridViewFuncionalidades.Refresh();
            todasLasFuncionalidades = RepositorioDeDatos.getInstance().getFuncionalidades();

            foreach (Funcionalidad funcionalidad in todasLasFuncionalidades)
            {
                dataGridViewFuncionalidades.Rows.Add(funcionalidad.nombre,
                    rolAModificar.tieneFuncionalidad(funcionalidad));
            }
        }

        protected override void operacionSobreRol(Rol elRol)
        {
            RepositorioDeDatos.getInstance().guardarRol(elRol);
        }

        protected override Rol getRolModificado()
        {
            Rol rolModificado = base.getRolModificado();
            rolModificado.id = rolAModificar.id;
            return rolModificado;
        }
    }
}
