using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.ConexionDB;

namespace PagoElectronico.Modelo
{
    public abstract class RepositorioDeDatos
    {
        static RepositorioDeDatos Instancia;

        protected RepositorioDeDatos() {}

        static public RepositorioDeDatos getInstance()
        {
            if (Instancia == null)
                Instancia = new RepositorioDummy();

            return Instancia;               
        }

        static public void setInstance(RepositorioDeDatos repositorio)
        {
            Instancia = repositorio;
        }


        /*
         * ROLES 
         */
        abstract public void bajaRol(Rol rol);

        abstract public List<Rol> getRoles();

        public List<Rol> getRolesFiltrados(Predicate<Rol> filtro)
        {
            return getRoles().FindAll(filtro);
        }

        public abstract void guardarRol(Rol rolModificado);

        public abstract void crearRol(Rol rol);

        /*
         * FUNCIONALIDADES
         */

        abstract public List<Funcionalidad> getFuncionalidades();


        /*
         * PAISES
         */
        abstract public List<Pais> getPaises();


        /*
         * TIPOS IDENTIFICACION
         */
        abstract public List<TipoIdentificacion> getTiposIdentificacion();


        /*
         * CLIENTES
         */
        public abstract void crearCliente(Cliente nuevoCliente, Usuario nuevoUsuario);

        abstract public List<Cliente> obtenerClientes();

        abstract public void bajaCliente(Cliente clienteABorrar);

        public List<Cliente> obtenerClientesFiltrados(Predicate<Cliente> filtro)
        {
            return obtenerClientes().FindAll(filtro);
        }

        abstract public void guardarCliente(Cliente cliente);

        abstract public List<Tarjeta> obtenerTarjetasHabilitadasDeCliente(Cliente cliente);


        
        /*
         * TARJETAS
         */

        abstract public void crearTarjeta(Tarjeta nuevaTarjeta);

        abstract public void guardarTarjeta(Tarjeta tarjetaModificada);

        public abstract void bajaTarjeta(Tarjeta tarjeta);


        /*
         * USUARIOS
         */ 

        public abstract Usuario login(String username, String password);

        /*
         * MONEDAS
         */
        public abstract List<Moneda> obtenerMonedas();


        /*
         * TIPOS CUENTA
         */
        public abstract List<TipoCuenta> obtenerTiposCuenta();


        /*
         * CUENTAS
         */
        public abstract void crearCuenta(Cuenta nuevaCuenta);

        public abstract List<Cuenta> obtenerCuentasDeCliente(Cliente cliente);

        public abstract void bajaCuenta(Cuenta cuenta);

        public abstract void guardarCuenta(Cuenta cuentaModificada);

        public abstract void depositar(Cuenta cuenta, decimal p, Moneda moneda, Tarjeta tarjeta);

        public abstract void retirar(Cliente cliente, Cuenta cuenta, decimal p, Moneda moneda);

        public abstract List<Cuenta> obtenerCuentas();

        public abstract void transferir(Cuenta cuenta, Cuenta cuenta_2, decimal p);

        public abstract List<Transaccion> obtenerTransaccionesImpagasDeCliente(Cliente cliente);

        public abstract void facturar(Cliente cliente);

        public abstract List<Transferencia> obtenerUltimas10Transferencias(Cuenta cuenta);

        public abstract List<Retiro> obtenerUltimos5Retiros(Cuenta cuenta);

        public abstract List<Deposito> obtenerUltimos5Depositos(Cuenta cuenta);

        public abstract Decimal obtenerSaldoDeCuenta(Cuenta cuenta);
    }
}
