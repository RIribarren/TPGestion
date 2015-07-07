using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Banco
    {
        public String nombre;
        public Decimal id;

        public Banco(Decimal id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
