using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class TipoIdentificacion
    {
        public int id;
        public String nombre;

        public TipoIdentificacion(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
