using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.WidgetsGUI
{
    public class Validador
    {
        private List<Validable> listaDeValidables = new List<Validable>();

        public Validador(params Validable[] listaDeValidables)
        {
            this.listaDeValidables = new List<Validable>(listaDeValidables);
        }

        public Validador()
        {}

        public void agregarValidable(Validable validable)
        {
            listaDeValidables.Add(validable);
        }

        public bool sonValoresValidos()
        {
            return listaDeValidables.All(v => v.esValido());
        }

        public String obtenerMensajeDeError()
        {
            return listaDeValidables.Aggregate("", (mensaje, v) =>
                v.esValido() ?
                    mensaje
                    : mensaje + v.obtenerMensajeDeError() + "\n");
        }
    }
}
