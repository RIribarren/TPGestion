using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Modelo;

namespace PagoElectronico.ConexionDB
{
    class RepositorioDB: RepositorioDeDatos
    {
        public override void bajaRol(Rol rol)
        {
            throw new NotImplementedException();
        }

        public override List<Rol> getRoles()
        {
            throw new NotImplementedException();
        }

        public override List<Rol> getRolesActivados()
        {
            throw new NotImplementedException();
        }

        public override List<Rol> getRolesFiltrados(Predicate<Rol> filtro)
        {
            throw new NotImplementedException();
        }

        protected override void guardarRolModificado(Rol rol)
        {
            throw new NotImplementedException();
        }

        protected override void agregarRol(Rol rol)
        {
            throw new NotImplementedException();
        }

        public override void validarRol(Rol rol)
        {
            throw new NotImplementedException();
        }

        public override List<Funcionalidad> getFuncionalidades()
        {
            throw new NotImplementedException();
        }

        public override List<Pais> getPaises()
        {
            throw new NotImplementedException();
        }

        public override List<TipoIdentificacion> getTiposIdentificacion()
        {
            throw new NotImplementedException();
        }

        protected override void validarCliente(Cliente nuevoCliente)
        {
            throw new NotImplementedException();
        }

        protected override void agregarCliente(Cliente nuevoCliente)
        {
            throw new NotImplementedException();
        }

        protected override void validarUsuario(Usuario nuevoUsuario)
        {
            throw new NotImplementedException();
        }

        protected override void agregarUsuario(Usuario nuevoUsuario)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> obtenerClientes()
        {
            throw new NotImplementedException();
        }

        public override void bajaCliente(Cliente clienteABorrar)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> obtenerClientesHabilitados()
        {
            throw new NotImplementedException();
        }

        public override void guardarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public override List<Tarjeta> obtenerTarjetasHabilitadasDeCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        protected override void agregarTarjeta(Tarjeta nuevaTarjeta)
        {
            throw new NotImplementedException();
        }

        protected override void validarTarjeta(Tarjeta nuevaTarjeta)
        {
            throw new NotImplementedException();
        }

        protected override void guardarTarjetaModificada(Tarjeta tarjetaModificada)
        {
            throw new NotImplementedException();
        }

        public override void bajaTarjeta(Tarjeta tarjeta)
        {
            throw new NotImplementedException();
        }

        public override Usuario login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override List<Moneda> obtenerMonedas()
        {
            throw new NotImplementedException();
        }

        public override List<TipoCuenta> obtenerTiposCuenta()
        {
            throw new NotImplementedException();
        }

        public override void crearCuenta(Cuenta nuevaCuenta)
        {
            throw new NotImplementedException();
        }

        public override List<Cuenta> obtenerCuentasDeCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public override void bajaCuenta(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public override void guardarCuenta(Cuenta cuentaModificada)
        {
            throw new NotImplementedException();
        }

        public override void depositar(Cliente cliente, Cuenta cuenta, decimal p, Moneda moneda)
        {
            throw new NotImplementedException();
        }

        public override void retirar(Cliente cliente, Cuenta cuenta, decimal p, Moneda moneda)
        {
            throw new NotImplementedException();
        }

        public override List<Cuenta> obtenerCuentas()
        {
            throw new NotImplementedException();
        }

        public override void transferir(Cuenta cuenta, Cuenta cuenta_2, decimal p)
        {
            throw new NotImplementedException();
        }

        public override List<Transaccion> obtenerTransaccionesImpagasDeCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public override void facturar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public override List<Transferencia> obtenerUltimas10Transferencias(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public override List<Retiro> obtenerUltimos5Retiros(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public override List<Deposito> obtenerUltimos5Depositos(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }

        public override decimal obtenerSaldoDeCuenta(Cuenta cuenta)
        {
            throw new NotImplementedException();
        }
    }
}
