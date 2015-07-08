using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class TransferenciasRealizadas
    {
        public String nombre;
        public String apellido;
        public String documento;
        public String transferencias;

        public TransferenciasRealizadas(
            String nombre,
            String apellido,
            String documento,
            String transacciones)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.transferencias = transacciones;
        }
    }
}
