using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Transaccion
    {
        public String descripcion;
        public Decimal importe;

        public Transaccion(String descripcion, Decimal importe)
        {
            this.descripcion = descripcion;
            this.importe = importe;
        }
    }
}
