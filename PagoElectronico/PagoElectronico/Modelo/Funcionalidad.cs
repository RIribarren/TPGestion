using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Funcionalidad
    {
        public static int ABMROL = 1;
        public static int LOGIN = 2;
        public static int ABMTARJETA = 3;
        public static int ABMCLIENTE = 4;
        public static int ABMCUENTA = 5;
        public static int DEPOSITOS = 6;
        public static int RETIROEFECTIVO = 7;
        public static int TRANSFERENCIA = 8;
        public static int FACTURACION = 9;
        public static int SALDOS = 10;
        public static int LISTADO = 11;

        public String nombre { get; set; }
        public int id { get; set; }

        public Funcionalidad(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public bool esIgualA(Funcionalidad funcionalidad)
        {
            return this.id == funcionalidad.id;
        }
    }
}
