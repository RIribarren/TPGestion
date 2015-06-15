using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public class Cuenta
    {
        public decimal Numero;
        public Pais pais;
        public Moneda moneda;
        public DateTime fechaCreacion;
        public Cliente cliente;
        public TipoCuenta tipoCuenta;
        public String estado;
        public int cantidadSuscripciones;

        public Cuenta(Cliente cliente, Pais pais, Moneda moneda, TipoCuenta tipo, int cantidadSuscripciones)
        {
            this.cliente = cliente;
            this.pais = pais;
            this.moneda = moneda;
            this.tipoCuenta = tipo;
            this.cantidadSuscripciones = cantidadSuscripciones;
        }

        public Cuenta(
            decimal Numero,
            Pais pais,
            Moneda moneda,
            DateTime fechaCreacion,
            Cliente cliente,
            TipoCuenta tipoCuenta,
            String estado)
        {
            this.Numero = Numero;
            this.pais = pais;
            this.moneda = moneda;
            this.fechaCreacion = fechaCreacion;
            this.cliente = cliente;
            this.tipoCuenta = tipoCuenta;
            this.estado = estado;
        }
    }
}
