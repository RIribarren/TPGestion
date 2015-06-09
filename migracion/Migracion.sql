/****************************************************************/
--						CREAR ESQUEMA
/****************************************************************/

CREATE SCHEMA [LA_MAQUINA_DE_HUMO] AUTHORIZATION [gd]
GO


/***********************************************************************
 *
 *						STORED PROCEDURES y FUNCIONES
 *
 ***********************************************************************/
/****************************************************************
 *							FECHA
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].SetFecha
	@Fecha DateTime
AS
	TRUNCATE TABLE [LA_MAQUINA_DE_HUMO].FECHA_DEL_SISTEMA
	INSERT INTO [LA_MAQUINA_DE_HUMO].FECHA_DEL_SISTEMA ([Fecha]) VALUES (@Fecha)
GO

CREATE FUNCTION [LA_MAQUINA_DE_HUMO].obtenerFecha () RETURNS DateTime
AS
BEGIN
	RETURN(SELECT TOP(1) * FROM [LA_MAQUINA_DE_HUMO].FECHA_DEL_SISTEMA)
END
GO



/****************************************************************
 *							LOGIN
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].Login
	@Username varchar(255),
	@Password varchar(255)
AS
	-- Verifico si las credenciales son correctas
	IF (SELECT COUNT(*) FROM Usuario WHERE Username = @Username AND Password = @Password) = 1
	BEGIN
		-- Verifico si el usuario esta lockeado
		IF (SELECT Cantidad_Intentos_Fallidos FROM Usuario WHERE Username = @Username) >= 3
		BEGIN
			-- Logueo el evento
			INSERT INTO Auditoria ([Id_Usuario], [Fecha], [Resultado], [Nro_Intento])
				(SELECT Id_Usuario, GETDATE(), 'Credenciales correctas. No se autoriza login por cantidad de intentos fallidos',
						NULL
					FROM Usuario
					WHERE Username = @Username)
			RAISERROR('El usuario se encuentra bloqueado por acumulacion de intentos fallidos', 16, 1)
		END
		-- Logueo login satisfactorio
		INSERT INTO Auditoria ([Id_Usuario], [Fecha], [Resultado], [Nro_Intento])
			(SELECT Id_Usuario, GETDATE(), 'Login satisfactorio', NULL
				FROM Usuario
				WHERE Username = @Username)
		
		-- Borro intentos fallidos
			UPDATE Usuario SET Cantidad_Intentos_Fallidos = 0
				FROM Usuario u
				WHERE u.Username = @Username

		-- Devuelvo los datos del usuario
		SELECT *
			FROM Usuario
			WHERE Username = @Username AND Password = @Password
	END
	ELSE
	BEGIN
		-- Verifico si existe el usuario
		IF (SELECT COUNT(*) FROM Usuario WHERE Username = @Username) = 1
		BEGIN
			-- Si existe incremento intentos fallidos
			UPDATE Usuario 
				SET Cantidad_Intentos_Fallidos=
					(SELECT Cantidad_Intentos_Fallidos + 1
						FROM Usuario u
						WHERE u.Username = @Username)
			
			-- Logueo el evento
			INSERT INTO Auditoria ([Id_Usuario], [Fecha], [Resultado], [Nro_Intento])
				(SELECT Id_Usuario, GETDATE(), 'Password incorrecto', Cantidad_Intentos_Fallidos
					FROM Usuario
					WHERE Username = @Username)
		END
		RAISERROR('Username y/o password incorrectos', 16, 1)
	END
GO




/****************************************************************
 *							ObtenerRol
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerRoles
AS
	SELECT Id_Rol, Rol_Nombre, Habilitado
		FROM Rol
GO



/****************************************************************
 *					obtenerFuncionalides
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerFuncionalides
AS
	SELECT * FROM LA_MAQUINA_DE_HUMO.Funcionalidad
GO



/****************************************************************
 *					obtenerFuncionalidadesDeRol
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerFuncionalidadesDeRol
	@Id_Rol int
AS
	SELECT f.Id_Funcionalidad as Id_Funcionalidad, Func_Nombre
		FROM Funcionalidad f, Rol_Funcionalidad rf, Rol r
		WHERE f.Id_Funcionalidad = rf.Id_Funcionalidad
			AND rf.Id_Rol = r.Id_Rol
			AND r.Id_Rol = @Id_Rol
GO



/****************************************************************
 *						crearRol
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].crearRol
	@Nombre varchar(255),
	@Habilitado char(1)
AS
	BEGIN TRY
		INSERT INTO LA_MAQUINA_DE_HUMO.Rol (Rol_Nombre, Habilitado) VALUES (@Nombre, @Habilitado)
		-- Devuelvo el id del rol
		SELECT Id_Rol FROM LA_MAQUINA_DE_HUMO.Rol WHERE Rol_Nombre = @Nombre
	END TRY
	BEGIN CATCH
		DECLARE @MensajeError varchar(255)
		SET @MensajeError = 'El nombre "' + @Nombre + '" ya esta en uso'
		RAISERROR(@MensajeError, 16, 1)
	END CATCH
GO



/****************************************************************
 *						agregarFuncionalidadARol
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].agregarFuncionalidadARol
	@Id_Rol int,
	@Id_Funcionalidad int
AS
	INSERT INTO LA_MAQUINA_DE_HUMO.Rol_Funcionalidad (Id_Rol, Id_Funcionalidad)
		VALUES (@Id_Rol, @Id_Funcionalidad)
GO



/****************************************************************
 *							bajaRol
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].bajaRol
	@Id_Rol int
AS
	UPDATE LA_MAQUINA_DE_HUMO.Rol
		SET Habilitado = 'n'
		WHERE Id_Rol = @Id_Rol
GO



/****************************************************************
 *				actualizarYBorrarFuncionalidadesRol
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].actualizarYBorrarFuncionalidadesRol
	@Id_Rol int,
    @Nombre varchar(255),
    @Habilitado char(1)
AS
	UPDATE LA_MAQUINA_DE_HUMO.Rol
		SET Rol_Nombre = @Nombre, Habilitado = @Habilitado
		WHERE Id_Rol = @Id_Rol
		
	DELETE LA_MAQUINA_DE_HUMO.Rol_Funcionalidad
		WHERE Id_Rol = @Id_Rol
GO




/****************************************************************
 *					obtenerClienteDeUsuario
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerClienteDeUsuario
	@Id_Usuario int
AS
	SELECT top 1 Id_Cliente,Cli_Nombre,Cli_Apellido,Cli_Nro_Doc,Cli_Tipo_Doc_Cod,Cli_Mail,Cli_Dom_Nro,
			Cli_Dom_Calle,Cli_Dom_Piso,Cli_Dom_Depto,Cli_Dom_Localidad,Cli_Nacionalidad_Codigo,Cli_Fecha_Nac,
			Cli_Habilitado
		FROM Usuario u, Clientes c
		WHERE u.Id_Usuario = @Id_Usuario
			AND u.Id_Usuario = c.Id_Usuario
GO



/****************************************************************
 *					crearClienteYUsuario
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].crearClienteYUsuario
	@Username varchar(255), @Password varchar(255), @PreguntaSecreta varchar(255),
	@RespuestaSecreta varchar(255), @Id_Rol int,
	@Nombre varchar(255), @Apellido varchar(255), @NroDocumento numeric(18,0),
	@Id_TipoDocumento int, @Mail varchar(255), @Id_Pais int, @Dom_Nro int,
	@Dom_Calle varchar(255), @Dom_Piso int = NULL, @Dom_Depto varchar(255) = NULL,
	@Dom_Localidad varchar(255), @Id_Nacionalidad int, @Fecha_Nac DateTime
AS
BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO [LA_MAQUINA_DE_HUMO].Usuario([Cantidad_Intentos_Fallidos], [Username],
				[Password],[Habilitado],[Fecha_Creacion],[Fecha_Ultima_Modificacion],
				[Pregunta_Secreta],[Respuesta_Secreta],[Id_Rol])
			VALUES (0, @Username, @Password, 's',
				LA_MAQUINA_DE_HUMO.obtenerFecha(), LA_MAQUINA_DE_HUMO.obtenerFecha(),
				@PreguntaSecreta, @RespuestaSecreta, @Id_Rol)
	END TRY
	BEGIN CATCH
		ROLLBACK
		RAISERROR('El username ya se encuentra en uso', 16, 1)
		RETURN
	END CATCH
	
	BEGIN TRY
		DECLARE @Id_Usuario int;
		SET @Id_Usuario = (SELECT Id_Usuario FROM LA_MAQUINA_DE_HUMO.Usuario WHERE Username = @Username)
		INSERT INTO [LA_MAQUINA_DE_HUMO].Clientes(
				[Cli_Nombre], [Cli_Apellido], [Cli_Nro_Doc], [Cli_Tipo_Doc_Cod], 
				[Cli_Mail], [Cli_Pais_Codigo], [Cli_Dom_Nro],[Cli_Dom_Calle], 
				[Cli_Dom_Piso], [Cli_Dom_Depto], [Cli_Dom_Localidad],
				[Cli_Nacionalidad_Codigo],[Cli_Fecha_Nac],[Cli_Habilitado],	[Id_Usuario])
			VALUES (@Nombre, @Apellido, @NroDocumento, @Id_TipoDocumento,
				@Mail, @Id_Pais, @Dom_Nro, @Dom_Calle,
				@Dom_Piso, @Dom_Depto, @Dom_Localidad,
				@Id_Nacionalidad, @Fecha_Nac, 's', @Id_Usuario)
	END TRY
	BEGIN CATCH
		ROLLBACK
		RAISERROR('Ya existe un cliente con esa identificacion y/o email', 16, 1)
		RETURN
	END CATCH
COMMIT
GO



/****************************************************************
 *							bajaCliente
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].bajaCliente
	@Id_Cliente int
AS
	UPDATE LA_MAQUINA_DE_HUMO.Clientes
		SET Cli_Habilitado = 'n'
		WHERE Id_Cliente = @Id_Cliente
GO


/****************************************************************
 *					obtenerTiposIdentificacion
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerClientes
AS
	SELECT * FROM LA_MAQUINA_DE_HUMO.Clientes
		--ORDER BY Cli_Nombre, Cli_Apellido
GO


/****************************************************************
 *					obtenerTiposIdentificacion
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerTiposIdentificacion
AS
	SELECT * FROM LA_MAQUINA_DE_HUMO.Documento
		ORDER BY Doc_Desc
GO



/****************************************************************
 *					obtenerPaises
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerPaises
AS
	SELECT * FROM LA_MAQUINA_DE_HUMO.Pais
		ORDER BY Pais_Desc
GO








/***********************************************************************
 *
 *						MIGRACION DE DATOS
 *
 ***********************************************************************/


USE GD1C2015
/****************************************************************/
--							FECHA_DEL_SISTEMA
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[FECHA_DEL_SISTEMA](
	[Fecha][DateTime] PRIMARY KEY
)

/* Cargar fecha actual.
 * La app va a actualizar esta fecha de acuerdo al archivo de configuracion
 */
DECLARE @FechaActual DateTime
SET @FechaActual = GETDATE()
EXECUTE [LA_MAQUINA_DE_HUMO].SetFecha @FechaActual


/****************************************************************/
--							ROL
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Rol](
	[Id_Rol][int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Rol_Nombre] [varchar](255) UNIQUE NOT NULL,
	[Habilitado][char](1) NOT NULL
)

INSERT INTO [LA_MAQUINA_DE_HUMO].Rol Values('Administrador','s')
INSERT INTO [LA_MAQUINA_DE_HUMO].Rol Values('Ciente','s')
GO


/****************************************************************/
--						FUNCIONALIDADES
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Funcionalidad](
	[Id_Funcionalidad][int] PRIMARY KEY NOT NULL,
	[Func_Nombre] [varchar](255) NOT NULL
)

INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(1, 'ABM de Rol')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(2, 'Login y seguridad')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(3, 'ABM de Usuario')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(4, 'ABM de Cliente')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(5, 'ABM de Cuenta')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(6, 'Depósitos')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(7, 'Retiro de Efectivo')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(8, 'Tranferencias entre cuentas')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(9, 'Facturación de Costos')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(10, 'Consulta de saldos')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values(11, 'Listado Estadístico')
GO


/****************************************************************/
--						ROL_FUNCIONALIDAD
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Rol_Funcionalidad](
	[Id_Rol][int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Rol(Id_Rol) NOT NULL,
	[Id_Funcionalidad][int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Funcionalidad(Id_Funcionalidad)  NOT NULL,
	CONSTRAINT [PK_Rol_Funcionalidad] PRIMARY KEY CLUSTERED 
	(
		[Id_Rol],
		[Id_Funcionalidad] 
	)
)

INSERT INTO [LA_MAQUINA_DE_HUMO].Rol_Funcionalidad(Id_Rol , Id_Funcionalidad) 
	SELECT 1,Id_Funcionalidad
	FROM [LA_MAQUINA_DE_HUMO].Funcionalidad
	WHERE Id_Funcionalidad IN (1,2,3,4,5,9,11) -- Cargar con las correspondientes funcionalidades

INSERT INTO [LA_MAQUINA_DE_HUMO].Rol_Funcionalidad(Id_Rol , Id_Funcionalidad) 
	SELECT 2,Id_Funcionalidad
	FROM [LA_MAQUINA_DE_HUMO].Funcionalidad
	WHERE Id_Funcionalidad IN (2,5,6,7,8,9,10) -- Cargar con las correspondientes funcionalidades

GO

/****************************************************************/
--							PAIS
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Pais](
	[Pais_Codigo][numeric](18,0) PRIMARY KEY,
	[Pais_Desc][varchar](250) NOT NULL
)

INSERT INTO [LA_MAQUINA_DE_HUMO].[Pais] (
	[Pais_Codigo],
	[Pais_Desc]
)
SELECT DISTINCT Cuenta_Pais_Codigo, Cuenta_Pais_Desc
	FROM gd_esquema.Maestra
UNION
	SELECT DISTINCT Cli_Pais_Codigo, Cli_Pais_Desc
		FROM gd_esquema.Maestra
		WHERE Cli_Pais_Codigo NOT IN (SELECT Cuenta_Pais_Codigo
										FROM gd_esquema.Maestra)

/*
	SELECT DISTINCT Cli_Pais_Codigo, Cli_Pais_Desc
		FROM gd_esquema.Maestra
*/
GO


/****************************************************************/
--						DOCUMENTO
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Documento](
	[Doc_Codigo][numeric](18,0) PRIMARY KEY,
	[Doc_Desc][varchar](255) NOT NULL
)

INSERT INTO [LA_MAQUINA_DE_HUMO].[Documento](
	[Doc_Codigo],
	[Doc_Desc]
)
SELECT DISTINCT Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc
		FROM gd_esquema.Maestra
GO


/****************************************************************/
--						USUARIO
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Usuario](
	[Id_Usuario][int] IDENTITY (1,1) PRIMARY KEY,
	[Cantidad_Intentos_Fallidos][int] NOT NULL,
	[Username][varchar](255) NOT NULL UNIQUE,
	[Password][varchar](255),
	[Habilitado][char](1) NOT NULL,
	[Fecha_Creacion][datetime] NOT NULL,
	[Fecha_Ultima_Modificacion][datetime] NOT NULL,
	[Pregunta_Secreta][varchar](255),
	[Respuesta_Secreta][varchar](255),
	[Id_Rol][int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Rol(Id_Rol) 
)

/* Creacion de 2 usuarios administradores pedidos por el enunciado */
INSERT INTO [LA_MAQUINA_DE_HUMO].Usuario(
	[Cantidad_Intentos_Fallidos],
	[Username],
	[Password],
	[Habilitado],
	[Fecha_Creacion],
	[Fecha_Ultima_Modificacion],
	[Pregunta_Secreta],
	[Respuesta_Secreta],
	[Id_Rol]
) VALUES (
	0, 'admin1',
	'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', --SHA256 de "w23e"
	's', GETDATE(), GETDATE(), 'Pregunta secreta de admin',
	'37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f', --SHA256 de "default"
	1
)

INSERT INTO [LA_MAQUINA_DE_HUMO].Usuario(
	[Cantidad_Intentos_Fallidos],
	[Username],
	[Password],
	[Habilitado],
	[Fecha_Creacion],
	[Fecha_Ultima_Modificacion],
	[Pregunta_Secreta],
	[Respuesta_Secreta],
	[Id_Rol]
) VALUES (
	0, 'admin2',
	'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', --SHA256 de "w23e"
	's', GETDATE(), GETDATE(), 'Pregunta secreta de admin',
	'37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f', --SHA256 de "default"
	1
)

/* Creacion de usuarios de los clientes de la tabla maestra */
INSERT INTO [LA_MAQUINA_DE_HUMO].Usuario(
	[Cantidad_Intentos_Fallidos],
	[Username],
	[Password],
	[Habilitado],
	[Fecha_Creacion],
	[Fecha_Ultima_Modificacion],
	[Pregunta_Secreta],
	[Respuesta_Secreta],
	[Id_Rol]
)
	SELECT DISTINCT
		0,
		'usuario' + RIGHT(CONVERT(varchar(18),Cli_Nro_Doc),18),
		'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', --SHA256 de "password"
		's',
		GETDATE(),
		GETDATE(),
		'Pregunta secreta default',
		'37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f', --SHA256 de "default"
		2
		FROM gd_esquema.Maestra
GO


/****************************************************************/
--						CLIENTES
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Clientes](
	[Id_Cliente] [int] IDENTITY(1,1) PRIMARY KEY,
	[Cli_Nombre] [varchar](255) NOT NULL,
	[Cli_Apellido] [varchar](255) NOT NULL,
	[Cli_Nro_Doc] [numeric](18,0) UNIQUE NOT NULL,
	[Cli_Tipo_Doc_Cod] [numeric] (18,0) FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Documento(Doc_Codigo),
	[Cli_Mail] [varchar](255) UNIQUE NOT NULL,
	[Cli_Pais_Codigo] [numeric] (18,0) FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Pais(Pais_Codigo),
	[Cli_Dom_Nro][numeric](18,0) NOT NULL,
	[Cli_Dom_Calle] [varchar](255) NOT NULL,
	[Cli_Dom_Piso] [numeric](18,0),
	[Cli_Dom_Depto] [varchar](10),
	[Cli_Dom_Localidad][varchar](255),
	[Cli_Nacionalidad_Codigo][numeric](18,0) FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Pais(Pais_Codigo), /** Es el mismo para [Cli_Pais_Codigo] **/
	[Cli_Fecha_Nac][datetime] NOT NULL,
	[Cli_Habilitado][char](1) NOT NULL,
	[Id_Usuario][int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Usuario(Id_usuario) /** FK a Usuario **/
 )
GO

INSERT INTO [LA_MAQUINA_DE_HUMO].Clientes(
	[Cli_Nombre], 
	[Cli_Apellido], 
	[Cli_Nro_Doc], 
	[Cli_Tipo_Doc_Cod], 
	[Cli_Mail], 
	[Cli_Pais_Codigo], 
	[Cli_Dom_Nro],
	[Cli_Dom_Calle], 
	[Cli_Dom_Piso], 
	[Cli_Dom_Depto], 
	[Cli_Dom_Localidad],
	[Cli_Nacionalidad_Codigo],
	[Cli_Fecha_Nac],
	[Cli_Habilitado],
	[Id_Usuario]
	)
	SELECT DISTINCT  
		[Cli_Nombre] ,
		[Cli_Apellido],
		[Cli_Nro_Doc],
		[Cli_Tipo_Doc_Cod], 
		[Cli_Mail],
		[Cli_Pais_Codigo], 
		[Cli_Dom_Nro],
		[Cli_Dom_Calle], 
		[Cli_Dom_Piso], 
		[Cli_Dom_Depto], 
		NULL,
		NULL,
		[Cli_Fecha_Nac],
		's',
		(SELECT Id_usuario
			FROM [LA_MAQUINA_DE_HUMO].Usuario
			WHERE username = 'usuario' + RIGHT(CONVERT(varchar(18),Cli_Nro_Doc),18))
		FROM gd_esquema.Maestra
GO


/****************************************************************/
--						AUDITORIA
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Auditoria](
	[Id_Auditoria][int] IDENTITY (1,1) PRIMARY KEY,
	[Id_Usuario][int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Usuario(Id_Usuario),
	[Fecha][datetime] NOT NULL,
	[Resultado][varchar](255) NOT NULL,
	[Nro_Intento][int]
)

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta](
[Id_Tipo_Cuenta][int] PRIMARY KEY IDENTITY (1,1),
[Duracion][int],
[Costo_Apertura][numeric] (18,2),
[Costo_Tranferencia][numeric] (18,2),
[Descripcion][varchar](255)
)

INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (90,100,8,'ORO')
INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (60,70,10,'PLATA')
INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (30,50,12,'BRONCE')
INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (15,0,20,'GRATUITA')

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Moneda](
[Id_Moneda][int] PRIMARY KEY IDENTITY (1,1),
[Descripcion][varchar](255)
)
INSERT INTO [LA_MAQUINA_DE_HUMO].[Moneda] values ('DOLAR')

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Cuenta](
[Cuenta_Numero][numeric] (18,0) PRIMARY KEY,
[Cuenta_Pais][numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Pais(Pais_Codigo),
[Id_Moneda][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Moneda(Id_Moneda),
[Fecha_Creacion][datetime],
[Id_Cliente][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Clientes(Id_Cliente),
[Id_Tipo_Cuenta][int]FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Tipo_Cuenta(Id_Tipo_Cuenta),
[Estado][varchar](255),
[Fecha_Cierre][datetime],
)

INSERT INTO LA_MAQUINA_DE_HUMO.Cuenta(
[Cuenta_Numero],
[Cuenta_Pais],
[Id_Moneda],
[Fecha_Creacion],
[Id_Cliente],
[Id_Tipo_Cuenta],
[Estado],
[Fecha_Cierre]
)
select distinct
	M.Cuenta_Numero,
	M.Cuenta_Pais_Codigo,
	1,
	M.Cuenta_Fecha_Creacion, 
	(select Id_Cliente
		from LA_MAQUINA_DE_HUMO.Clientes as C 
		where M.Cli_Nro_Doc = C.Cli_Nro_Doc),
	4,
	'habilitado',
	null			
 From gd_esquema.Maestra as M





CREATE TABLE [LA_MAQUINA_DE_HUMO].[Tarjeta](
	[Id_Tarjeta][int] PRIMARY KEY IDENTITY (1,1),
	[Id_Cliente][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Clientes(Id_Cliente),
	[Tarjeta_Numero] [varchar](16),
	[Tarjeta_Emisor_Descripcion] [varchar](35),
	[Tarjeta_Fecha_Emision] [datetime],
	[Tarjeta_Fecha_Vencimiento] [datetime],
	[Tarjeta_Codigo_Seg] [varchar](3),
	[Habilitado] [char](1)
)
INSERT INTO [LA_MAQUINA_DE_HUMO].[Tarjeta] (
	[Id_Cliente],
	[Tarjeta_Numero],
	[Tarjeta_Emisor_Descripcion],
	[Tarjeta_Fecha_Emision],
	[Tarjeta_Fecha_Vencimiento],
	[Tarjeta_Codigo_Seg],
	[Habilitado]
)
	SELECT DISTINCT
			(select Id_Cliente
				from LA_MAQUINA_DE_HUMO.Clientes as C 
				where M.Cli_Nro_Doc = C.Cli_Nro_Doc),
			M.Tarjeta_Numero,
			M.Tarjeta_Emisor_Descripcion,
			M.Tarjeta_Fecha_Emision,
			M.Tarjeta_Fecha_Vencimiento,
			M.Tarjeta_Codigo_Seg,
			's'
		FROM gd_esquema.Maestra as M
		WHERE M.Tarjeta_Numero IS NOT NULL


CREATE TABLE [LA_MAQUINA_DE_HUMO].[Deposito](
	[Deposito_Codigo][numeric] (18,0) PRIMARY KEY ,
	[Numero_Cuenta][numeric](18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero),
	[Deposito_importe] [numeric](18,2),
	[Id_Moneda] [int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Moneda(Id_Moneda),
	[Id_Tarjeta][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Tarjeta(Id_Tarjeta),
	[Deposito_Fecha] [datetime],
)

INSERT INTO [LA_MAQUINA_DE_HUMO].[Deposito](
	[Deposito_Codigo],
	[Numero_Cuenta],
	[Deposito_importe],
	[Id_Moneda],
	[Id_Tarjeta],
	[Deposito_Fecha]
	)

select Deposito_Codigo,Cuenta_Numero,Deposito_Importe,1,
( select Id_Tarjeta from LA_MAQUINA_DE_HUMO.Tarjeta as T where M.Tarjeta_Numero = T.Tarjeta_Numero and M.Tarjeta_Emisor_Descripcion = T.Tarjeta_Emisor_Descripcion),
Deposito_Fecha
from gd_esquema.Maestra as M where Deposito_Codigo IS NOT NULL

GO

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Retiro](
	[Retiro_Codigo][numeric] (18,0) PRIMARY KEY ,
	[Numero_Cuenta][numeric](18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero),
	[Retiro_Fecha] [datetime],
	[Retiro_Importe] [numeric](18,2),
	[Id_Moneda][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Moneda(Id_Moneda)
)

INSERT INTO LA_MAQUINA_DE_HUMO.Retiro(
	[Retiro_Codigo],
	[Numero_Cuenta],
	[Retiro_Fecha],
	[Retiro_Importe],
	[Id_Moneda]
)
Select distinct Retiro_Codigo, Cuenta_Numero,Retiro_Fecha,Retiro_Importe,1 from gd_esquema.maestra where Retiro_Codigo IS NOT NULL






CREATE TABLE [LA_MAQUINA_DE_HUMO].[Banco](
	[Banco_Codigo] [numeric] (18,0) PRIMARY KEY ,
	[Banco_Nomber] [varchar](255),
	[Banco_Direccion] [varchar](255)
)

INSERT INTO LA_MAQUINA_DE_HUMO.Banco(
	[Banco_Codigo],
	[Banco_Nomber],
	[Banco_Direccion]
)
Select distinct Banco_Cogido, Banco_Nombre, Banco_Direccion From gd_esquema.Maestra WHERE Banco_Cogido is not null






CREATE TABLE [LA_MAQUINA_DE_HUMO].[Cheque](
	[Cheque_Numero] [numeric] (18,0) PRIMARY KEY ,
	[Retiro_Codigo] [numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Retiro(Retiro_Codigo),
	[Banco_Codigo]  [numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Banco(Banco_Codigo),
)

INSERT INTO LA_MAQUINA_DE_HUMO.Cheque(
	[Cheque_Numero],
	[Retiro_Codigo],
	[Banco_Codigo]  
)
Select distinct Cheque_Numero, Retiro_Codigo, Banco_Cogido From gd_esquema.Maestra WHERE Cheque_Numero is not null





CREATE TABLE [LA_MAQUINA_DE_HUMO].[Transferencia](
	[Id_Transferencia] [int] PRIMARY KEY IDENTITY (1,1),
	[Tranf_Cuenta_Dest_Numero] [numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero),
	[Tranf_Cuenta_Origen_Numero] [numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero),
	[Tranf_Importe] [numeric] (18,2),
	[Tranf_Fecha] [datetime],
	[Tranf_Estado_Cuenta_Dest] [varchar](255)
)

INSERT INTO LA_MAQUINA_DE_HUMO.Transferencia(
	[Tranf_Cuenta_Dest_Numero],
	[Tranf_Cuenta_Origen_Numero],
	[Tranf_Importe],
	[Tranf_Fecha],
	[Tranf_Estado_Cuenta_Dest]
)
SELECT Cuenta_Dest_Numero,
		Cuenta_Numero,
		0,
		Transf_Fecha,
		Cuenta_Dest_Estado
	FROM gd_esquema.Maestra
	WHERE Cuenta_Dest_Numero IS NOT NULL
		AND Cuenta_Numero IS NOT NULL
		
		



CREATE TABLE [LA_MAQUINA_DE_HUMO].[Item](
	[Id_Item] [int] PRIMARY KEY IDENTITY (1,1),
	[Item_Descripcion] [varchar](255)
)

INSERT INTO LA_MAQUINA_DE_HUMO.Item values ('Comisión por transferencia.')
INSERT INTO LA_MAQUINA_DE_HUMO.Item values ('Comisión por alta de cuenta.')
INSERT INTO LA_MAQUINA_DE_HUMO.Item values ('Comisión por modificacion de cuenta.')




CREATE TABLE [LA_MAQUINA_DE_HUMO].[Factura] (
	[Factura_Numero] [numeric](18,0) PRIMARY KEY,
	[Factura_Fecha] [datetime]
)

INSERT INTO  [LA_MAQUINA_DE_HUMO].[Factura] (
	[Factura_Numero],
	[Factura_Fecha]
)
SELECT DISTINCT Factura_Numero, Factura_Fecha
	FROM gd_esquema.Maestra
	WHERE Factura_Numero IS NOT NULL








CREATE TABLE [LA_MAQUINA_DE_HUMO].[Transaccion] (
	[Id_Transaccion] [int] PRIMARY KEY IDENTITY (1,1),
	[Factura_Numero] [numeric](18,0) FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].[Factura](Factura_Numero), 
	[Id_Item] [int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].[Item](Id_Item),
	[Id_Cliente] [int]  FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].[Clientes](Id_Cliente),
	[Importe] [numeric](18,2)
)

INSERT INTO  [LA_MAQUINA_DE_HUMO].[Transaccion] (
	[Factura_Numero],
	[Id_Item],
	[Id_Cliente],
	[Importe]
)
SELECT DISTINCT
	Factura_Numero,
	1,
	(Select Id_Cliente
		FROM LA_MAQUINA_DE_HUMO.Clientes as C
		WHERE C.Cli_Nro_Doc = M.Cli_Nro_Doc),
	Trans_Importe
	FROM gd_esquema.Maestra as M
	WHERE Factura_Numero IS NOT NULL
	
