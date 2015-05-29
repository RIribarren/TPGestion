using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Tarjeta
    {
        public int id;
        public Cliente cliente;
        public decimal numero;
        public DateTime fechaEmision;
        public DateTime fechaVencimiento;
        public String codigoSeguridad;
        public String emisor;
        public Boolean habilitada;

        public Tarjeta(int id,
            Cliente cliente,
            decimal numero,
            DateTime fechaEmision,
            DateTime fechaVencimiento,
            String codigoSeguridad,
            String emisor,
            Boolean habilitada)
        {
            this.id = id;
            this.cliente = cliente;
            this.numero = numero;
            this.fechaEmision = fechaEmision;
            this.fechaVencimiento = fechaVencimiento;
            this.codigoSeguridad = codigoSeguridad;
            this.emisor = emisor;
            this.habilitada = habilitada;
        }
    }
}
