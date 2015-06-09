using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.WidgetsGUI;
using PagoElectronico.Modelo;

namespace PagoElectronico.ABM_Cliente
{
    public partial class ComboPais : ComboValidable
    {
        private List<Pais> paises;

        public ComboPais()
        {
            InitializeComponent();
            
            paises = RepositorioDeDatos.getInstance().getPaises();
            var nombrePaises = paises.Select(p => p.nombre).ToArray();
            Items.AddRange(nombrePaises);
        }

        public Pais obtenerPais()
        {
            return paises.ElementAt(SelectedIndex);
        }

        public void setPais(Pais pais)
        {
            if (pais != null)
            {
                int indicePais = paises.FindIndex(p => p.id == pais.id);
                SelectedIndex = indicePais;
            }
        }
    }
}
