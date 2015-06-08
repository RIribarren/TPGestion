using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Transferencia
    {
        public Decimal monto;
        public DateTime fecha;
        public Cuenta cuentaDestino;


        public Transferencia(Decimal monto, DateTime fecha, Cuenta cuentaDestino)
        {
            this.monto = monto;
            this.fecha = fecha;
            this.cuentaDestino = cuentaDestino;
        }
    }
}
