using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    public abstract class RepositorioDeDatos
    {
        static RepositorioDeDatos Instancia;

        protected RepositorioDeDatos() {}

        static public RepositorioDeDatos getInstance()
        {
            if (Instancia == null)
                Instancia = new RepositorioEnMemoria();

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

        abstract public List<Rol> getRolesActivados();

        abstract public List<Rol> getRolesFiltrados(Predicate<Rol> filtro);

        public void guardarRol(Rol rolModificado)
        {
            validarRol(rolModificado);
            guardarRolModificado(rolModificado);
        }

        public void crearRol(Rol rol)
        {
            validarRol(rol);
            agregarRol(rol);
        }

        abstract protected void guardarRolModificado(Rol rol);

        abstract protected void agregarRol(Rol rol);

        abstract public void validarRol(Rol rol);


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
        public void crearCliente(Cliente nuevoCliente, Usuario nuevoUsuario)
        {
            validarCliente(nuevoCliente);

            validarUsuario(nuevoUsuario);

            agregarCliente(nuevoCliente);

            agregarUsuario(nuevoUsuario);
        }

        abstract protected void validarCliente(Cliente nuevoCliente);

        abstract protected void agregarCliente(Cliente nuevoCliente);

        abstract protected void validarUsuario(Usuario nuevoUsuario);

        abstract protected void agregarUsuario(Usuario nuevoUsuario);

        abstract public List<Cliente> obtenerClientes();

        abstract public void borrarCliente(Cliente clienteABorrar);

        abstract public List<Cliente> obtenerClientesHabilitados();
    }
}
