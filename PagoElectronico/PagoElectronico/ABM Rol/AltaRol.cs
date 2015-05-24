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
    public partial class AltaRol : DataRol
    {
        public AltaRol(ABMRol abmRol) : base(abmRol)
        {
            operacionMensaje = "creado";
            InitializeComponent();
        }

        protected override void operacionSobreRol(Rol rol)
        {
            RepositorioDeDatos.getInstance().crearRol(rol);
        }

    }
}
