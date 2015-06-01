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
            public String altura;
            public String calle;
            public String piso;
            public String depto;
            public String localidad;
            public Pais nacionalidad;
            public DateTime fechaNacimiento;
            public Boolean habilitado;

        public Cliente(
            int id,
            String nombre ,
            String Apellido,
            String nroIdentificacion,
            TipoIdentificacion tipoIdentificacion,
            String email,
            Pais pais,
            String altura,
            String calle,
            String piso,
            String depto,
            String localidad,
            Pais nacionalidad,
            DateTime fechaNacimiento,
            Boolean habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.Apellido = Apellido;
            this.nroIdentificacion = nroIdentificacion;
            this.tipoIdentificacion = tipoIdentificacion;
            this.email = email;
            this.pais = pais;
            this.altura = altura;
            this.calle = calle;
            this.piso = piso;
            this.depto = depto;
            this.localidad = localidad;
            this.nacionalidad = nacionalidad;
            this.fechaNacimiento = fechaNacimiento;
            this.habilitado = habilitado;
        }

        public bool tieneMismaIdentificacionQue(Cliente nuevoCliente)
        {
            return nuevoCliente.nroIdentificacion == nroIdentificacion &&
                tipoIdentificacion.esIgualA(nuevoCliente.tipoIdentificacion);
        }
    }
}
