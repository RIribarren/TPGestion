using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Deposito
    {
        public Decimal monto;
        public DateTime fecha;

        public Deposito(Decimal monto, DateTime fecha)
        {
            this.monto = monto;
            this.fecha = fecha;
        }
    }
}
