using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.WidgetsGUI
{
    public class Validador
    {
        private List<Validable> listaDeValidables;

        public Validador(params Validable[] listaDeValidables)
        {
            this.listaDeValidables = new List<Validable>(listaDeValidables);
        }

        bool sonValidos()
        {
            return listaDeValidables.All(v => v.esValido());
        }

        String obtenerMensajeDeError()
        {
            return listaDeValidables.Aggregate("", (mensaje, v) => mensaje + "\n" + v.obtenerMensajeDeError());
        }
    }
}
