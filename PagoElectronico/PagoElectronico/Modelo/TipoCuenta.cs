using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class TipoCuenta
    {
        public int id;
        public String nombre;
        public String totalFacturado;

        public TipoCuenta(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public TipoCuenta(String nombre, String totalFacturado)
        {
            this.nombre = nombre;
            this.totalFacturado = totalFacturado;
        }

    }
}
