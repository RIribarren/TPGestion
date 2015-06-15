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
                {
                    paises.Add(new Pais(
                        int.Parse(reader["Pais_Codigo"].ToString()),
                        reader["Pais_Desc"].ToString()));
                }

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

        public override List<Cliente> obtenerClientes()
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerClientes");
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                {
                    Pais nacionalidad;
                    try
                    {
                        nacionalidad = getPaises().Find(p => p.id == int.Parse(reader["Cli_Nacionalidad_Codigo"].ToString()));
                    }
                    catch (Exception)
                    {
                        nacionalidad = null;
                    }

                    clientes.Add(new Cliente(
                        int.Parse(reader["Id_Cliente"].ToString()),
                        reader["Cli_Nombre"].ToString(),
                        reader["Cli_Apellido"].ToString(),
                        reader["Cli_Nro_Doc"].ToString(),
                        getTiposIdentificacion().Find(i => i.id == int.Parse(reader["Cli_Tipo_Doc_Cod"].ToString())),
                        reader["Cli_Mail"].ToString(),
                        getPaises().Find(p => p.id == int.Parse(reader["Cli_Pais_Codigo"].ToString())),
                        reader["Cli_Dom_Nro"].ToString(),
                        reader["Cli_Dom_Calle"].ToString(),
                        reader["Cli_Dom_Piso"].ToString(),
                        reader["Cli_Dom_Depto"].ToString(),
                        reader["Cli_Dom_Localidad"].ToString(),
                        nacionalidad,
                        DateTime.Parse(reader["Cli_Fecha_Nac"].ToString()),
                        reader["Cli_Habilitado"].ToString() == "s"));
                }
                sp.Connection.Close();

                return clientes;
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override void bajaCliente(Cliente clienteABorrar)
        {
            SqlCommand sp = obtenerStoredProcedure("bajaCliente");
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = clienteABorrar.id;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override void guardarCliente(Cliente cliente)
        {
            SqlCommand sp = obtenerStoredProcedure("guardarCliente");

            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = cliente.id;
            sp.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = cliente.nombre;
            sp.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = cliente.Apellido;
            sp.Parameters.Add("@NroDocumento", SqlDbType.Decimal).Value = Convert.ToDecimal(cliente.nroIdentificacion);
            sp.Parameters.Add("@Id_TipoDocumento", SqlDbType.Int).Value = cliente.tipoIdentificacion.id;
            sp.Parameters.Add("@Mail", SqlDbType.VarChar).Value = cliente.email;
            sp.Parameters.Add("@Id_Pais", SqlDbType.Int).Value = cliente.pais.id;
            sp.Parameters.Add("@Dom_Nro", SqlDbType.Int).Value = int.Parse(cliente.altura);
            sp.Parameters.Add("@Dom_Calle", SqlDbType.VarChar).Value = cliente.calle;
            if (cliente.piso != "") sp.Parameters.Add("@Dom_Piso", SqlDbType.Int).Value = int.Parse(cliente.piso);
            if (cliente.depto != "") sp.Parameters.Add("@Dom_Depto", SqlDbType.VarChar).Value = cliente.depto;
            sp.Parameters.Add("@Dom_Localidad", SqlDbType.VarChar).Value = cliente.localidad;
            sp.Parameters.Add("@Id_Nacionalidad", SqlDbType.Int).Value = cliente.nacionalidad.id;
            sp.Parameters.Add("@Fecha_Nac", SqlDbType.DateTime).Value = cliente.fechaNacimiento;
            sp.Parameters.Add("@Habilitado", SqlDbType.Char).Value = cliente.habilitado ? 's' : 'n';

            try
            {
                var reader = sp.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override List<Tarjeta> obtenerTarjetasHabilitadasDeCliente(Cliente cliente)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerTarjetasHabilitadasDeCliente");
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = cliente.id;
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    tarjetas.Add(new Tarjeta(
                        int.Parse(reader["Id_Tarjeta"].ToString()),
                        cliente,
                        decimal.Parse(reader["Tarjeta_Numero"].ToString()),
                        DateTime.Parse(reader["Tarjeta_Fecha_Emision"].ToString()),
                        DateTime.Parse(reader["Tarjeta_Fecha_Vencimiento"].ToString()),
                        reader["Tarjeta_Codigo_Seg"].ToString(),
                        reader["Tarjeta_Emisor_Descripcion"].ToString(),
                        reader["Habilitado"].ToString() == "s"));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return tarjetas;
        }

        public override void bajaTarjeta(Tarjeta tarjeta)
        {
            SqlCommand sp = obtenerStoredProcedure("bajaTarjeta");
            sp.Parameters.Add("@Id_Tarjeta", SqlDbType.Int).Value = tarjeta.id;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
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
                        getPaises().Find(p => p.id == int.Parse(reader["Cli_Pais_Codigo"].ToString())),
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
            SqlCommand sp = obtenerStoredProcedure("obtenerMonedas");
            List<Moneda> monedas = new List<Moneda>();

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                {
                    monedas.Add(new Moneda(
                        int.Parse(reader["Id_Moneda"].ToString()),
                        reader["Descripcion"].ToString()));
                }
                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return monedas;
        }

        public override List<TipoCuenta> obtenerTiposCuenta()
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerTiposCuenta");
            List<TipoCuenta> tiposCuenta = new List<TipoCuenta>();
            
            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                {
                    tiposCuenta.Add(new TipoCuenta(
                        int.Parse(reader["Id_Tipo_Cuenta"].ToString()),
                        reader["Descripcion"].ToString()));
                }
                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return tiposCuenta;
        }

        public override void crearCuenta(Cuenta nuevaCuenta)
        {
            SqlCommand sp = obtenerStoredProcedure("crearCuenta");
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = nuevaCuenta.cliente.id;
            sp.Parameters.Add("@Id_Tipo_Cuenta", SqlDbType.Int).Value = nuevaCuenta.tipoCuenta.id;
            sp.Parameters.Add("@Id_Moneda", SqlDbType.Int).Value = nuevaCuenta.moneda.id;
            sp.Parameters.Add("@Cuenta_Pais", SqlDbType.Int).Value = nuevaCuenta.pais.id;
            sp.Parameters.Add("@Cantidad_Suscripciones", SqlDbType.Int).Value = nuevaCuenta.cantidadSuscripciones;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override List<Cuenta> obtenerCuentasDeCliente(Cliente cliente)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerCuentasCliente");
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = cliente.id;
            List<Cuenta> cuentas = new List<Cuenta>();
            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                {
                    cuentas.Add(new Cuenta(
                        decimal.Parse(reader["Cuenta_Numero"].ToString()),
                        getPaises().Find(p => p.id == int.Parse(reader["Cuenta_Pais"].ToString())),
                        obtenerMonedas().Find(m => m.id == int.Parse(reader["Id_Moneda"].ToString())),
                        DateTime.Parse(reader["Fecha_Creacion"].ToString()),
                        cliente,
                        obtenerTiposCuenta().Find(tc => tc.id == int.Parse(reader["Id_Tipo_Cuenta"].ToString())),
                        reader["Estado"].ToString()));
                }

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return cuentas;
        }

        public override void bajaCuenta(Cuenta cuenta)
        {
            SqlCommand sp = obtenerStoredProcedure("bajaCuenta");
            sp.Parameters.Add("@Cuenta_Numero", SqlDbType.Decimal).Value = cuenta.Numero;
            
            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override void guardarCuenta(Cuenta cuentaModificada)
        {
            throw new NotImplementedException();
        }

        public override void depositar(Cuenta cuenta, decimal p, Moneda moneda, Tarjeta tarjeta)
        {
            SqlCommand sp = obtenerStoredProcedure("depositar");
            sp.Parameters.Add("@Cuenta_Numero", SqlDbType.Decimal).Value = cuenta.Numero;
            sp.Parameters.Add("@Importe", SqlDbType.Decimal).Value = p;
            sp.Parameters.Add("@Id_Moneda", SqlDbType.Decimal).Value = moneda.id;
            sp.Parameters.Add("@Id_Tarjeta", SqlDbType.Decimal).Value = tarjeta.id;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override void retirar(Cuenta cuenta, decimal p, Moneda moneda)
        {
            SqlCommand sp = obtenerStoredProcedure("retirar");
            sp.Parameters.Add("@Cuenta_Numero", SqlDbType.Decimal).Value = cuenta.Numero;
            sp.Parameters.Add("@Importe", SqlDbType.Decimal).Value = p;
            sp.Parameters.Add("@Id_Moneda", SqlDbType.Decimal).Value = moneda.id;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override List<Cuenta> obtenerCuentas()
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerCuentas");
            List<Cuenta> cuentas = new List<Cuenta>();
            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                {
                    cuentas.Add(new Cuenta(
                        decimal.Parse(reader["Cuenta_Numero"].ToString()),
                        getPaises().Find(p => p.id == int.Parse(reader["Cuenta_Pais"].ToString())),
                        obtenerMonedas().Find(m => m.id == int.Parse(reader["Id_Moneda"].ToString())),
                        DateTime.Parse(reader["Fecha_Creacion"].ToString()),
                        null,
                        obtenerTiposCuenta().Find(tc => tc.id == int.Parse(reader["Id_Tipo_Cuenta"].ToString())),
                        reader["Estado"].ToString()));
                }

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return cuentas;
        }

        public override void transferir(Cuenta cuentaOrigen, Cuenta cuentaDestino, decimal p)
        {
            SqlCommand sp = obtenerStoredProcedure("transferir");
            sp.Parameters.Add("@Numero_Cuenta_Origen", SqlDbType.Decimal).Value = cuentaOrigen.Numero;
            sp.Parameters.Add("@Numero_Cuenta_Destino", SqlDbType.Decimal).Value = cuentaDestino.Numero;
            sp.Parameters.Add("@Importe", SqlDbType.Decimal).Value = p;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override List<Transaccion> obtenerTransaccionesImpagasDeCliente(Cliente cliente)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerTransaccionesImpagasDeCliente");
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = cliente.id;
            List<Transaccion> transacciones = new List<Transaccion>();
            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    transacciones.Add(new Transaccion(
                        reader["Descripcion"].ToString(),
                        decimal.Parse(reader["Importe"].ToString())));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return transacciones;
        }

        public override void facturar(Cliente cliente)
        {
            SqlCommand sp = obtenerStoredProcedure("facturar");
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = cliente.id;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override List<Transferencia> obtenerUltimas10Transferencias(Cuenta cuenta)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerUltimas10Transferencias");
            sp.Parameters.Add("@Cuenta_Numero", SqlDbType.Decimal).Value = cuenta.Numero;
            List<Transferencia> transferencias = new List<Transferencia>();

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    transferencias.Add(new Transferencia(
                        decimal.Parse(reader["Tranf_Importe"].ToString()),
                        DateTime.Parse(reader["Tranf_Fecha"].ToString()),
                        new Cuenta(decimal.Parse(reader["Tranf_Cuenta_Dest_Numero"].ToString()), null,null, new DateTime()
                            ,null,null,null)));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return transferencias;
        }

        public override List<Retiro> obtenerUltimos5Retiros(Cuenta cuenta)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerUltimos5Retiros");
            sp.Parameters.Add("@Cuenta_Numero", SqlDbType.Decimal).Value = cuenta.Numero;
            List<Retiro> retiros = new List<Retiro>();

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    retiros.Add(new Retiro(
                        decimal.Parse(reader["Retiro_importe"].ToString()),
                        DateTime.Parse(reader["Retiro_Fecha"].ToString())));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return retiros;
        }

        public override List<Deposito> obtenerUltimos5Depositos(Cuenta cuenta)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerUltimos5Depositos");
            sp.Parameters.Add("@Cuenta_Numero", SqlDbType.Decimal).Value = cuenta.Numero;
            List<Deposito> depositos = new List<Deposito>();

            try
            {
                var reader = sp.ExecuteReader();
                while (reader.Read())
                    depositos.Add(new Deposito(
                        decimal.Parse(reader["Deposito_importe"].ToString()),
                        DateTime.Parse(reader["Deposito_Fecha"].ToString())));

                sp.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return depositos;
        }

        public override decimal obtenerSaldoDeCuenta(Cuenta cuenta)
        {
            SqlCommand sp = obtenerStoredProcedure("obtenerSaldoDeCuenta");
            sp.Parameters.Add("@Cuenta_Numero", SqlDbType.Decimal).Value = cuenta.Numero;
            decimal saldo;

            try
            {
                var reader = sp.ExecuteReader();
                reader.Read();
                saldo = decimal.Parse(reader[0].ToString());
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }

            return saldo;
        }

        public override void guardarRol(Rol rolModificado)
        {
            SqlCommand spCrear = obtenerStoredProcedure("actualizarYBorrarFuncionalidadesRol");
            spCrear.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = rolModificado.id;
            spCrear.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = rolModificado.nombre;
            spCrear.Parameters.Add("@Habilitado", SqlDbType.Char).Value = rolModificado.estaActivo ? 's' : 'n';
            try
            {
                var reader = spCrear.ExecuteReader();
                reader.Read();
                foreach (Funcionalidad f in rolModificado.funcionalidades)
                {
                    SqlCommand sp = obtenerStoredProcedure("agregarFuncionalidadARol");
                    sp.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = rolModificado.id;
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

        public override void crearCliente(Cliente nuevoCliente, Usuario nuevoUsuario)
        {
            SqlCommand spCrearClienteYUsuario = obtenerStoredProcedure("crearClienteYUsuario");
            spCrearClienteYUsuario.Parameters.Add("@Username", SqlDbType.VarChar).Value = nuevoUsuario.username;
            spCrearClienteYUsuario.Parameters.Add("@Password", SqlDbType.VarChar).Value = nuevoUsuario.password;
            spCrearClienteYUsuario.Parameters.Add("@PreguntaSecreta", SqlDbType.VarChar).Value = nuevoUsuario.preguntaSecreta;
            spCrearClienteYUsuario.Parameters.Add("@RespuestaSecreta", SqlDbType.VarChar).Value = nuevoUsuario.respuestaSecreta;
            spCrearClienteYUsuario.Parameters.Add("@Id_Rol", SqlDbType.Int).Value = nuevoUsuario.rol.id;
            spCrearClienteYUsuario.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = nuevoCliente.nombre;
            spCrearClienteYUsuario.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = nuevoCliente.Apellido;
            spCrearClienteYUsuario.Parameters.Add("@NroDocumento", SqlDbType.Decimal).Value = Convert.ToDecimal(nuevoCliente.nroIdentificacion);
            spCrearClienteYUsuario.Parameters.Add("@Id_TipoDocumento", SqlDbType.Int).Value = nuevoCliente.tipoIdentificacion.id;
            spCrearClienteYUsuario.Parameters.Add("@Mail", SqlDbType.VarChar).Value = nuevoCliente.email;
            spCrearClienteYUsuario.Parameters.Add("@Id_Pais", SqlDbType.Int).Value = nuevoCliente.pais.id;
            spCrearClienteYUsuario.Parameters.Add("@Dom_Nro", SqlDbType.Int).Value = int.Parse(nuevoCliente.altura);
            spCrearClienteYUsuario.Parameters.Add("@Dom_Calle", SqlDbType.VarChar).Value = nuevoCliente.calle;
            if (nuevoCliente.piso != "") spCrearClienteYUsuario.Parameters.Add("@Dom_Piso", SqlDbType.Int).Value = int.Parse(nuevoCliente.piso);
            if (nuevoCliente.depto != "") spCrearClienteYUsuario.Parameters.Add("@Dom_Depto", SqlDbType.VarChar).Value = nuevoCliente.depto;
            spCrearClienteYUsuario.Parameters.Add("@Dom_Localidad", SqlDbType.VarChar).Value = nuevoCliente.localidad;
            spCrearClienteYUsuario.Parameters.Add("@Id_Nacionalidad", SqlDbType.Int).Value = nuevoCliente.nacionalidad.id;
            spCrearClienteYUsuario.Parameters.Add("@Fecha_Nac", SqlDbType.DateTime).Value = nuevoCliente.fechaNacimiento;

            try
            {
                var reader = spCrearClienteYUsuario.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override void crearTarjeta(Tarjeta nuevaTarjeta)
        {
            SqlCommand sp = obtenerStoredProcedure("crearTarjeta");
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = nuevaTarjeta.cliente.id;
            sp.Parameters.Add("@Tarjeta_Numero", SqlDbType.Decimal).Value = nuevaTarjeta.numero;
            sp.Parameters.Add("@Tarjeta_Emisor_Descripcion", SqlDbType.VarChar).Value = nuevaTarjeta.emisor;
            sp.Parameters.Add("@Tarjeta_Fecha_Emision", SqlDbType.DateTime).Value = nuevaTarjeta.fechaEmision;
            sp.Parameters.Add("@Tarjeta_Fecha_Vencimiento", SqlDbType.DateTime).Value = nuevaTarjeta.fechaVencimiento;
            sp.Parameters.Add("@Tarjeta_Codigo_Seg", SqlDbType.VarChar).Value = nuevaTarjeta.codigoSeguridad;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                   throw new ErrorEnRepositorioException(ex.Message);
            }
        }

        public override void guardarTarjeta(Tarjeta tarjetaModificada)
        {
            SqlCommand sp = obtenerStoredProcedure("guardarTarjeta");
            sp.Parameters.Add("@Id_Tarjeta", SqlDbType.Int).Value = tarjetaModificada.id;
            sp.Parameters.Add("@Id_Cliente", SqlDbType.Int).Value = tarjetaModificada.cliente.id;
            sp.Parameters.Add("@Tarjeta_Numero", SqlDbType.Decimal).Value = tarjetaModificada.numero;
            sp.Parameters.Add("@Tarjeta_Emisor_Descripcion", SqlDbType.VarChar).Value = tarjetaModificada.emisor;
            sp.Parameters.Add("@Tarjeta_Fecha_Emision", SqlDbType.DateTime).Value = tarjetaModificada.fechaEmision;
            sp.Parameters.Add("@Tarjeta_Fecha_Vencimiento", SqlDbType.DateTime).Value = tarjetaModificada.fechaVencimiento;
            sp.Parameters.Add("@Tarjeta_Codigo_Seg", SqlDbType.VarChar).Value = tarjetaModificada.codigoSeguridad;

            try
            {
                sp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ErrorEnRepositorioException(ex.Message);
            }
        }
    }
}
