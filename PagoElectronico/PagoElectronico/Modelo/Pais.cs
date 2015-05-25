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

        public Pais(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
