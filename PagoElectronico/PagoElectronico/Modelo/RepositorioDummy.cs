using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    class RepositorioDummy: RepositorioDeDatos
    {
        public override List<Transferencia> obtenerUltimas10TransferenciasRecibidas(Cuenta cuenta)
        {
            return new List<Transferencia>();
        }

        public override List<Banco> obtenerBancos()
        {
            return new List<Banco>();
        }

        public override void bajaRol(Rol rol)
        {
        }

        public override List<Rol> getRoles()
        {
            return new List<Rol>();
        }

        public override void guardarRol(Rol rolModificado)
        {
        }

        public override void crearRol(Rol rol)
        {
        }

        public override List<Funcionalidad> getFuncionalidades()
        {
            return new List<Funcionalidad>();
        }

        public override List<Pais> getPaises()
        {
            return new List<Pais>();
        }

        public override List<TipoIdentificacion> getTiposIdentificacion()
        {
            return new List<TipoIdentificacion>();
        }

        public override void crearCliente(Cliente nuevoCliente, Usuario nuevoUsuario)
        {
        }

        public override List<Cliente> obtenerClientes()
        {
            return new List<Cliente>();
        }

        public override void bajaCliente(Cliente clienteABorrar)
        {
        }

        public override void guardarCliente(Cliente cliente)
        {
        }

        public override List<Tarjeta> obtenerTarjetasHabilitadasDeCliente(Cliente cliente)
        {
            return new List<Tarjeta>();
        }

        public override void bajaTarjeta(Tarjeta tarjeta)
        {
        }

        public override Usuario login(string username, string password)
        {
            return null;
        }

        public override List<Moneda> obtenerMonedas()
        {
            return new List<Moneda>();
        }

        public override List<TipoCuenta> obtenerTiposCuenta()
        {
            return new List<TipoCuenta>();
        }

        public override void crearCuenta(Cuenta nuevaCuenta)
        {
        }

        public override List<Cuenta> obtenerCuentasDeCliente(Cliente cliente)
        {
            return new List<Cuenta>();
        }

        public override void bajaCuenta(Cuenta cuenta)
        {
        }

        public override void guardarCuenta(Cuenta cuentaModificada)
        {
        }

        public override void depositar(Cuenta cuenta, decimal p, Moneda moneda, Tarjeta tarjeta)
        {
        }

        public override void retirar(Cuenta cuenta, decimal p, Moneda moneda, Decimal nroDocumento, Decimal bancoCodigo)
        {
        }

        public override List<Cuenta> obtenerCuentas()
        {
            return new List<Cuenta>();
        }

        public override void transferir(Cuenta cuenta, Cuenta cuenta_2, decimal p)
        {
        }

        public override List<Transaccion> obtenerTransaccionesImpagasDeCliente(Cliente cliente)
        {
            return new List<Transaccion>();
        }

        public override void facturar(Cliente cliente)
        {
        }

        public override List<Transferencia> obtenerUltimas10Transferencias(Cuenta cuenta)
        {
            return new List<Transferencia>();
        }

        public override List<Retiro> obtenerUltimos5Retiros(Cuenta cuenta)
        {
            return new List<Retiro>();
        }

        public override List<Deposito> obtenerUltimos5Depositos(Cuenta cuenta)
        {
            return new List<Deposito>();
        }

        public override decimal obtenerSaldoDeCuenta(Cuenta cuenta)
        {
            return 0;
        }

        public override void crearTarjeta(Tarjeta nuevaTarjeta)
        {
            throw new NotImplementedException();
        }

        public override void guardarTarjeta(Tarjeta tarjetaModificada)
        {
            throw new NotImplementedException();
        }
    }
}
