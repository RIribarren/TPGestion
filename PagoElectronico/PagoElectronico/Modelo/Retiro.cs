using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Retiro
    {
        public Decimal monto;
        public DateTime fecha;

        public Retiro(Decimal monto, DateTime fecha)
        {
            this.monto = monto;
            this.fecha = fecha;
        }

    }
}
