using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    /*
     * Esta clase solo fue creada para testear la interfaz sin usar la DB. 
     * No se va a usar en la entrega final
     */
    public class RepositorioEnMemoria: RepositorioDeDatos
    {
        private List<Rol> roles = new List<Rol>();
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
        private List<Pais> paises = new List<Pais>();
        private List<TipoIdentificacion> tiposIdentificacion = new List<TipoIdentificacion>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Tarjeta> tarjetas = new List<Tarjeta>();

        public RepositorioEnMemoria()
        {
            // Funcionalidades
            funcionalidades.Add(new Funcionalidad(0, "ABM Roles"));
            funcionalidades.Add(new Funcionalidad(1, "ABM Clientes"));
            funcionalidades.Add(new Funcionalidad(2, "ABM Usuarios"));
            funcionalidades.Add(new Funcionalidad(3, "ABM Cuenta"));
            funcionalidades.Add(new Funcionalidad(4, "Depositos"));
            funcionalidades.Add(new Funcionalidad(5, "Retiro de efectivo"));
            funcionalidades.Add(new Funcionalidad(6, "Transferencias entre cuentas"));
            funcionalidades.Add(new Funcionalidad(7, "Facturacion de costos"));
            funcionalidades.Add(new Funcionalidad(8, "Consulta de saldos"));
            funcionalidades.Add(new Funcionalidad(9, "Listado estadistico"));

            // ROLES
            roles.Add(new Rol(0, "Administrador", new List<Funcionalidad>(), true));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(0));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(1));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(2));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(3));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(4));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(5));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(6));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(7));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(8));
            roles.ElementAt(0).agregarFuncionalidad(funcionalidades.ElementAt(9));

            roles.Add(new Rol(1, "Cliente", new List<Funcionalidad>(), true));
            roles.ElementAt(1).agregarFuncionalidad(funcionalidades.ElementAt(4));
            roles.ElementAt(1).agregarFuncionalidad(funcionalidades.ElementAt(5));
            roles.ElementAt(1).agregarFuncionalidad(funcionalidades.ElementAt(6));
            roles.ElementAt(1).agregarFuncionalidad(funcionalidades.ElementAt(7));
            roles.ElementAt(1).agregarFuncionalidad(funcionalidades.ElementAt(8));
            roles.ElementAt(1).agregarFuncionalidad(funcionalidades.ElementAt(9));

            // Paises
            paises.Add(new Pais(1, "Argentina"));
            paises.Add(new Pais(2, "Uruguay"));
            paises.Add(new Pais(3, "Estados Unidos"));
            paises.Add(new Pais(4, "España"));

            // Tipo identificacion
            tiposIdentificacion.Add(new TipoIdentificacion(1, "DNI"));
            tiposIdentificacion.Add(new TipoIdentificacion(2, "Pasaporte"));
            tiposIdentificacion.Add(new TipoIdentificacion(3, "Cedula"));

            // Usuarios
            usuarios.Add(new Usuario(1, "administrador", "password", "a", "a", roles.ElementAt(0)));
            usuarios.Add(new Usuario(2, "usuario2", "password", "a", "a", roles.ElementAt(1)));
            usuarios.Add(new Usuario(3, "usuario3", "password", "a", "a", roles.ElementAt(1)));
            usuarios.Add(new Usuario(4, "usuario4", "password", "a", "a", roles.ElementAt(1)));

            // Clientes
            clientes.Add(new Cliente(2, "cliente2", "ap2", "1234", tiposIdentificacion.ElementAt(0), "c2@a.com",
                paises.ElementAt(0), "1234", "una calle", "1B", "CABA", paises.ElementAt(0), new DateTime(), true));
            clientes.Add(new Cliente(3, "cliente3", "ap2", "1234", tiposIdentificacion.ElementAt(1), "c3@a.com",
                paises.ElementAt(1), "1234", "una calle", "1B", "CABA", paises.ElementAt(1), new DateTime(), true));
            clientes.Add(new Cliente(4, "cliente4", "ap2", "1234", tiposIdentificacion.ElementAt(2), "c4@a.com",
                paises.ElementAt(2), "1234", "una calle", "1B", "CABA", paises.ElementAt(2), new DateTime(), true));

            // Tarjetas
            tarjetas.Add(new Tarjeta(1, clientes.ElementAt(0), 123456789123456789, new DateTime(), new DateTime(), "123", "Visa", true));
            tarjetas.Add(new Tarjeta(2, clientes.ElementAt(0), 234567891234567891, new DateTime(), new DateTime(), "456", "MasterCard", true));
            tarjetas.Add(new Tarjeta(3, clientes.ElementAt(0), 345678912345678912, new DateTime(), new DateTime(), "789", "Visa", true));
            tarjetas.Add(new Tarjeta(4, clientes.ElementAt(1), 111222333444555666, new DateTime(), new DateTime(), "666", "Tarjeta Naranja", true));
        }

        public override void bajaRol(Rol rol)
        {
            rol.estaActivo = false;
        }

        public override List<Rol> getRoles()
        {
            return roles;
        }

        public override List<Rol> getRolesActivados()
        {
            return roles.FindAll(r => r.estaActivo);
        }

        public override List<Funcionalidad> getFuncionalidades()
        {
            return funcionalidades;
        }

        public override List<Rol> getRolesFiltrados(Predicate<Rol> filtro)
        {
            return roles.FindAll(filtro);
        }

        protected override void guardarRolModificado(Rol rolModificado)
        {
            Rol rol = roles.Find(r => r.id == rolModificado.id);

            roles.Remove(rol);
            roles.Add(rolModificado);
        }
    
        protected override void agregarRol(Rol rol)
        {
            rol.id = roles.OrderBy(r => r.id).Last().id + 1;
            roles.Add(rol);
        }

        public override void validarRol(Rol rol)
        {
            if (roles.Any(r => r.nombre == rol.nombre && r.id != rol.id))
                throw new ErrorEnRepositorioException("El nombre " + rol.nombre + " ya esta en uso");
        }

        public override List<Pais> getPaises()
        {
            return paises;
        }

        public override List<TipoIdentificacion> getTiposIdentificacion()
        {
            return tiposIdentificacion;
        }

        protected override void validarUsuario(Usuario nuevoUsuario)
        {
            if (usuarios.Any(u => u.tieneMismoUsernameQue(nuevoUsuario)))
                throw new ErrorEnRepositorioException("El nombre de usuario ya esta en uso");
        }

        protected override void validarCliente(Cliente nuevoCliente)
        {
            if (clientes.Any(c => c.id != nuevoCliente.id && c.tieneMismaIdentificacionQue(nuevoCliente)))
                throw new ErrorEnRepositorioException("El cliente ya existe");
        }

        protected override void agregarUsuario(Usuario nuevoUsuario)
        {
            if (usuarios.Count > 0)
                nuevoUsuario.id = usuarios.OrderBy(u => u.id).Last().id + 1;
            else
                nuevoUsuario.id = 1;

            usuarios.Add(nuevoUsuario);
        }

        protected override void agregarCliente(Cliente nuevoCliente)
        {
            if (clientes.Count > 0)
                nuevoCliente.id = clientes.OrderBy(c => c.id).Last().id + 1;
            else
                nuevoCliente.id = 1;

            clientes.Add(nuevoCliente); 
        }

        public override List<Cliente> obtenerClientes()
        {
            return clientes;
        }

        public override void bajaCliente(Cliente clienteABorrar)
        {
            Cliente cliente = clientes.Find(c => c.id == clienteABorrar.id);
            cliente.habilitado = false;
        }

        public override List<Cliente> obtenerClientesHabilitados()
        {
            return clientes.FindAll(c => c.habilitado);
        }

        public override void guardarCliente(Cliente cliente)
        {
            validarCliente(cliente);
            Cliente viejo = clientes.Find(c => c.id == cliente.id);
            clientes.Remove(viejo);
            clientes.Add(cliente);
        }

        public override List<Tarjeta> obtenerTarjetasHabilitadasDeCliente(Cliente cliente)
        {
            return tarjetas.FindAll(t => t.cliente.id == cliente.id && t.habilitada);
        }

        protected override void agregarTarjeta(Tarjeta nuevaTarjeta)
        {
            tarjetas.Add(nuevaTarjeta);
        }

        protected override void validarTarjeta(Tarjeta nuevaTarjeta)
        {
            bool hayTarjetaConMismoNumeroYEmisor = 
                tarjetas.Any(t => t.numero == nuevaTarjeta.numero && t.emisor == nuevaTarjeta.emisor && t.id != nuevaTarjeta.id);

            if (hayTarjetaConMismoNumeroYEmisor)
                throw new ErrorEnRepositorioException("Ya existe una tarjeta emitida por " + nuevaTarjeta.emisor +
                    " con el numero " + nuevaTarjeta.numero.ToString());
        }

        protected override void guardarTarjetaModificada(Tarjeta tarjetaModificada)
        {
            Tarjeta tarjetaVieja = tarjetas.Find(t => t.id == tarjetaModificada.id);
            tarjetas.Remove(tarjetaVieja);
            tarjetas.Add(tarjetaModificada);
        }

        public override void bajaTarjeta(Tarjeta tarjeta)
        {
            tarjeta.habilitada = false;
        }
    }
}
