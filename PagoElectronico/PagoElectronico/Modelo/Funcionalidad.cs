using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Funcionalidad
    {
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
