using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Cliente
    {
            public int id;
            public String nombre;
            public String Apellido;
            public String nroIdentificacion;
            public TipoIdentificacion tipoIdentificacion;
            public String email;
            public Pais pais;
            public String domicilio;
            public String calle;
            public String depto;
            public String localidad;
            public Pais nacionalidad;
            public String fechaNacimiento;

        public Cliente(
            int id,
            String nombre ,
            String Apellido,
            String nroIdentificacion,
            TipoIdentificacion tipoIdentificacion,
            String email,
            Pais pais,
            String domicilio,
            String calle,
            String depto,
            String localidad,
            Pais nacionalidad,
            String fechaNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.Apellido = Apellido;
            this.nroIdentificacion = nroIdentificacion;
            this.tipoIdentificacion = tipoIdentificacion;
            this.email = email;
            this.pais = pais;
            this.domicilio = domicilio;
            this.calle = calle;
            this.depto = depto;
            this.localidad = localidad;
            this.nacionalidad = nacionalidad;
            this.fechaNacimiento = fechaNacimiento;
        }

        public bool tieneMismaIdentificacionQue(Cliente nuevoCliente)
        {
            return nuevoCliente.nroIdentificacion == nroIdentificacion &&
                tipoIdentificacion.esIgualA(nuevoCliente.tipoIdentificacion);
        }
    }
}
