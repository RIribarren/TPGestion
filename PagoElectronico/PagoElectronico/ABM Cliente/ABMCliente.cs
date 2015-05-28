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
    public partial class ABMCliente : Ventana
    {
        public ABMCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirVentanaHija(new AltaCliente());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BajaCliente bajaCliente = new BajaCliente();
            abrirVentanaHija(bajaCliente);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FiltroModificacionCliente filtoModificacion = new FiltroModificacionCliente();
            abrirVentanaHija(filtoModificacion);
        }
    }
}
