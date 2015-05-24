using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    class ErrorEnRepositorioException: Exception
    {
        public String mensaje { get; set; }
        public ErrorEnRepositorioException(String mensaje)
        {
            this.mensaje = mensaje;
        }
    }
}
