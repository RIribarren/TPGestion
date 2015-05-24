using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Rol
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public List<Funcionalidad> funcionalidades { get; set; }
        public Boolean estaActivo { get; set; }

        public Rol(int id, String nombre, List<Funcionalidad> funcionalidades, Boolean estaActivo)
        {
            this.id = id;
            this.nombre = nombre;
            this.funcionalidades = funcionalidades;
            this.estaActivo = estaActivo;
        }

        public bool tieneFuncionalidad(Funcionalidad funcionalidad)
        {
            return funcionalidades.Any(f => f.esIgualA(funcionalidad));
        }

        public void agregarFuncionalidad(Funcionalidad funcionalidad)
        {
            funcionalidades.Add(funcionalidad);
        }
    }
}
