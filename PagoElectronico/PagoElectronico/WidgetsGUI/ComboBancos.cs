using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.Modelo;

namespace PagoElectronico.WidgetsGUI
{
    public partial class ComboBancos : ComboValidable
    {
        protected List<Banco> bancos;

        public ComboBancos()
        {
            InitializeComponent();
            bancos = RepositorioDeDatos.getInstance().obtenerBancos();
            foreach (Banco banco in bancos)
                Items.Add(banco.nombre);
        }

        public Banco obtenerBanco()
        {
            return bancos.ElementAt(SelectedIndex);
        }
    }
}
