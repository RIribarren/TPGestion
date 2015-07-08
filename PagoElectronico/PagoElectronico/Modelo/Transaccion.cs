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
        public DateTime fecha;
        public Decimal cuenta;

        public Transaccion(DateTime fecha, Decimal cuenta, String descripcion, Decimal importe)
        {
            this.fecha = fecha;
            this.cuenta = cuenta;
            this.descripcion = descripcion;
            this.importe = importe;
        }
    }
}
