using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Comision
    {
        public String nombre;
        public String apellido;
        public String documento;
        public String comisiones;

        public Comision(
            String nombre,
            String apellido,
            String documento,
            String comisiones)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.comisiones = comisiones;
        }
    }
}
