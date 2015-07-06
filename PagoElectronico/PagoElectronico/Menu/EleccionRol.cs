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

namespace PagoElectronico.Menu
{
    public partial class EleccionRol : Ventana
    {
        private Usuario usuario;
        public Rol rolElegido = null;
        public EleccionRol(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        protected override void cargarDatos()
        {
            foreach (Rol rol in usuario.roles)
                Roles_Disponibles.Items.Add(rol.nombre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.noEsValidoYMuestraMensaje())
                return;

            rolElegido = usuario.roles.ElementAt(Roles_Disponibles.SelectedIndex);
            this.volver();
        }
    }
}
