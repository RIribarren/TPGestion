using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PagoElectronico.ConexionDB
{
    class BaseDeDatos: RepositorioDeDatos
    {
        private String parametrosConexionDB;
        private DateTime fechaDeSistema;
        private String esquema;

        public BaseDeDatos()
        {
            parametrosConexionDB = "Server=" + ConfigurationSettings.AppSettings["server"] + ";"
                + "Database=" + ConfigurationSettings.AppSettings["database"] + ";"
                + "User ID=" + ConfigurationSettings.AppSettings["id"] + ";"
                + "Password=" + ConfigurationSettings.AppSettings["password"];

            esquema = ConfigurationSettings.AppSettings["esquema"];

            establecerFechaDeSistema();
        }

        private void establecerFechaDeSistema()
        {
            fechaDeSistema = DateTime.Parse(
                ConfigurationSettings.AppSettings["year"] + "/"
                + ConfigurationSettings.AppSettings["month"] + "/"
                + ConfigurationSettings.AppSettings["day"] + " "
                + ConfigurationSettings.AppSettings["hour"] + ":"
                + ConfigurationSettings.AppSettings["minutes"]);
            
            SqlCommand sp = obtenerStoredProcedure("setFecha");
            sp.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fechaDeSistema;
            sp.ExecuteNonQuery();
        }

        private SqlCommand obtenerStoredProcedure(String nombre)
        {
            SqlConnection conexion = new SqlConnection(parametrosConexionDB);
            conexion.Open();
            SqlCommand sp = new SqlCommand("[" + esquema + "]." + nombre, conexion);
            sp.CommandType = CommandType.StoredProcedure;
            return sp;
        }

        public override void bajaRol(Rol rol)
        {
            SqlCommand sp = obtenerStoredProcedure("bajaRol");
            sp.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = rol.id;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override List<Rol> getRoles()
        {
            var spObtenerRoles = obtenerStoredProcedure("obtenerRoles");
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
            var spObtenerFuncionalidades = obtenerStoredProcedure("obtenerFuncionalidadesDeRol");
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

        public override List<Funcionalidad> getFuncionalidades()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlCommand sp = obtenerStoredProcedure("obtenerFuncionalides");

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    funcionalidades.Add(new Funcionalidad(
                        int.Parse(reader["Id_Funcionalidad"].ToString()),
                        reader["Func_Nombre"].ToString()));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return funcionalidades;
        }

        public override List<Pais> getPaises()
        {
            List<Pais> paises = new List<Pais>();
            SqlCommand sp = obtenerStoredProcedure("obtenerPaises");

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    paises.Add(new Pais(
                        int.Parse(reader["Pais_Codigo"].ToString()),
                        reader["Pais_Desc"].ToString()));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return paises;
        }

        public override List<TipoIdentificacion> getTiposIdentificacion()
        {
            List<TipoIdentificacion> tiposIdentificacion = new List<TipoIdentificacion>();
            SqlCommand sp = obtenerStoredProcedure("obtenerTiposIdentificacion");

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    tiposIdentificacion.Add(new TipoIdentificacion(
                        int.Parse(reader["Doc_Codigo"].ToString()),
                        reader["Doc_Desc"].ToString()));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return tiposIdentificacion;
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
            SqlCommand storedLogin = obtenerStoredProcedure("Login");
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
            SqlCommand sp = obtenerStoredProcedure("obtenerClienteDeUsuario");
            sp.Parameters.Add("@Id_Usuario", SqlDbType.Int).Value = Id_Usuario;

            SqlDataReader reader;
            Cliente cliente;
            try
            {
                reader = sp.ExecuteReader();
                if (reader.Read())
                {
                    Pais nacionalidad;
                    try {
                        nacionalidad = getPaises().Find(p => p.id == int.Parse(reader["Cli_Nacionalidad_Codigo"].ToString()));
                    } catch (Exception) {
                        nacionalidad = null;
                    }

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
                        nacionalidad,
                        DateTime.Parse(reader["Cli_Fecha_Nac"].ToString()),
                        reader["Cli_Habilitado"].ToString() == "s");
                }
                else
                    cliente = null;
              
                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
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

        public override void guardarRol(Rol rolModificado)
        {
            throw new NotImplementedException();
        }

        public override void crearRol(Rol rol)
        {
            SqlCommand spCrear = obtenerStoredProcedure("crearRol");
            spCrear.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = rol.nombre;
            spCrear.Parameters.Add("@Habilitado", SqlDbType.Char).Value = rol.estaActivo ? 's' : 'n';
            try
            {
                var reader = spCrear.ExecuteReader();
                reader.Read();
                foreach (Funcionalidad f in rol.funcionalidades)
                {
                    SqlCommand sp = obtenerStoredProcedure("agregarFuncionalidadARol");
                    sp.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = int.Parse(reader["Id_Rol"].ToString());
                    sp.Parameters.Add("@Id_Funcionalidad", SqlDbType.Int).Value = f.id;
                    sp.ExecuteNonQuery();
                    sp.Connection.Close();
                }
                spCrear.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }
    }
}
