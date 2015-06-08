using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Modelo;
using System.Data.SqlClient;
using System.Data;

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
            var spObtenerRoles = obtenerStoredProcedure("[LA_MAQUINA_DE_HUMO].obtenerRoles");
            List<Rol> roles = new List<Rol>();
            try {
                var reader = spObtenerRoles.ExecuteReader();

                while (reader.Read())
                    roles.Add(new Rol(
                        int.Parse(reader["Id_Rol"].ToString()),
                        reader["Rol_Nombre"].ToString(),
                        obtenerFuncionalidadesDeRol(int.Parse(reader["Id_Rol"].ToString())),
                        reader["Habilitado"].ToString() == "s"));
                
                spObtenerRoles.Connection.Close();
            }
            catch (SqlException excepcion) {
                throw new ErrorEnRepositorioException(excepcion.Message);
            }

            return roles;
        }

        private List<Funcionalidad> obtenerFuncionalidadesDeRol(int Id_Rol)
        {
            var spObtenerFuncionalidades = obtenerStoredProcedure("[LA_MAQUINA_DE_HUMO].obtenerFuncionalidadesDeRol");
            spObtenerFuncionalidades.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = Id_Rol;
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            try
            {
                var reader = spObtenerFuncionalidades.ExecuteReader();

                while (reader.Read())
                    funcionalidades.Add(new Funcionalidad(
                        int.Parse(reader["Id_Funcionalidad"].ToString()),
                        reader["Func_Nombre"].ToString()));
                
                spObtenerFuncionalidades.Connection.Close();
            }
            catch (SqlException excepcion)
            {
                throw new ErrorEnRepositorioException(excepcion.Message);
            }

            return funcionalidades;
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
            SqlCommand storedLogin = obtenerStoredProcedure("[LA_MAQUINA_DE_HUMO].Login");
            storedLogin.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
            storedLogin.Parameters.Add("@Password", SqlDbType.VarChar).Value = SHA256.GetSHA256(password);


            SqlDataReader reader;
            Usuario usuario;
            try {
                reader = storedLogin.ExecuteReader();
                reader.Read();
                usuario = new Usuario(
                    int.Parse(reader["Id_Usuario"].ToString()),
                    reader["Username"].ToString(),
                    reader["Password"].ToString(),
                    reader["Pregunta_Secreta"].ToString(),
                    reader["Respuesta_Secreta"].ToString(),
                    getRoles().Find(r => r.id == int.Parse(reader["Id_Rol"].ToString())),
                    obtenerClieteDeUsuario(int.Parse(reader["Id_Usuario"].ToString())));
                storedLogin.Connection.Close();
            } catch (SqlException excepcion) {
                throw new ErrorEnRepositorioException(excepcion.Message);
            }

            return usuario;
        }

        private Cliente obtenerClieteDeUsuario(int Id_Usuario)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerClieteDeUsuario");
            sp.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = Id_Usuario;

            SqlDataReader reader;
            Cliente cliente;
            try
            {
                reader = sp.ExecuteReader();
                cliente = new Cliente(
                    int.Parse(reader["Id_Cliente"].ToString()),
                    reader["Cli_Nombre"].ToString(),
                    reader["Cli_Apellido"].ToString(),
                    reader["Cli_Nro_Doc"].ToString(),
                    getTiposIdentificacion().Find(i => i.id == int.Parse(reader["Cli_Tipo_Doc_Cod"].ToString())),
                    reader["Cli_Mail"].ToString(),
                    getPaises().Find(p => p.id == int.Parse(reader["Cli_Tipo_Doc_Cod"].ToString())),
                    reader["Cli_Dom_Nro"].ToString(),
                    reader["Cli_Dom_Calle"].ToString(),
                    reader["Cli_Dom_Piso"].ToString(),
                    reader["Cli_Dom_Depto"].ToString(),
                    reader["Cli_Dom_Localidad"].ToString(),
                    getPaises().Find(p => p.id == int.Parse(reader["Cli_Nacionalidad_Codigo"].ToString())),
                    DateTime.Parse(reader["Cli_Fecha_Nac"].ToString()),
                    reader["Cli_Habilitado"].ToString() == "s");
                sp.Connection.Close();
            }
            catch (SqlException)
            {
                return null;
            }

            return cliente;            
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




        private SqlCommand obtenerStoredProcedure(String nombre)
        {
            SqlConnection conexion = new SqlConnection("Server=localhost\\SQLSERVER2008;Database=GD1C2015;User ID=gd;Password=gd2015");
            conexion.Open();
            SqlCommand stored = new SqlCommand(nombre, conexion);
            stored.CommandType = CommandType.StoredProcedure;
            return stored;
        }
    }
}
