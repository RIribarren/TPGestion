using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Inhabilitacion
    {
        public String nombre;
        public String apellido;
        public String documento;
        public String inhabilitaciones;

        public Inhabilitacion(String nombre,
            String apellido,
            String documento,
            String inhabilitaciones)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.inhabilitaciones = inhabilitaciones;
        }
    }
}
