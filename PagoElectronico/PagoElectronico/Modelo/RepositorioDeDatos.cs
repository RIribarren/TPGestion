using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Modelo
{
    class RepositorioDeDatos
    {
        static RepositorioDeDatos Instancia;

        private List<Rol> roles = new List<Rol>();
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        private RepositorioDeDatos()
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
        }

        static public RepositorioDeDatos getInstance()
        {
            if (Instancia == null)
                Instancia = new RepositorioDeDatos();

            return Instancia;               
        }

        public void bajaRol(Rol rol)
        {
            rol.estaActivo = false;
        }

        public List<Rol> getRoles()
        {
            return roles;
        }

        public List<Funcionalidad> getFuncionalidades()
        {
            return funcionalidades;
        }

        public List<Rol> getRolesFiltrados(Predicate<Rol> filtro)
        {
            return roles.FindAll(filtro);
        }

        public void guardarRol(Rol rolModificado)
        {
            validarRol(rolModificado);

            Rol rol = roles.Find(r => r.id == rolModificado.id);

            roles.Remove(rol);
            roles.Add(rolModificado);
        }

        public void crearRol(Rol rol)
        {
            validarRol(rol); 

            rol.id = roles.OrderBy(r => r.id).Last().id + 1;
            roles.Add(rol);
        }

        private void validarRol(Rol rol)
        {
            if (roles.Any(r => r.nombre == rol.nombre && r.id != rol.id))
                throw new ErrorEnRepositorioException("El nombre " + rol.nombre + " ya esta en uso");
        }
    }
}
