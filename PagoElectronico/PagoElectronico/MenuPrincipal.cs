using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.ABM_Rol;
using PagoElectronico.Ventanas;
using PagoElectronico.ABM_Cliente;

namespace PagoElectronico
{
    public partial class MenuPrincipal : VentanaPadre
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirVentanaHija(new ABMRol());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirVentanaHija(new ABMCliente());
        }
    }
}
