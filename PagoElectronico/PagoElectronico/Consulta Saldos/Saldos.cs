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

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Saldos : Ventana
    {
        private Cliente cliente;
        
        public Saldos(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            volver();
        }

    }
}
