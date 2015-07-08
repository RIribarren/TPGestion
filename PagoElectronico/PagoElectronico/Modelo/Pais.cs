using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Pais
    {
        public int id;
        public String nombre;
        public String ingresos;
        public String egresos;

        public Pais(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public Pais(String nombre, String ingresos, String egresos)
        {
            this.nombre = nombre;
            this.ingresos = ingresos;
            this.egresos = egresos;
        }
    }
}
