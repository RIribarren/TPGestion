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
			RETURN
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
				WHERE Username = @Username
			
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
 *							ObtenerRoles
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerRoles
AS
	SELECT Id_Rol, Rol_Nombre, Habilitado
		FROM Rol
GO


/****************************************************************
 *							obtenerRolesDeUsuario
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerRolesDeUsuario
	@Id_Usuario int
AS
	SELECT R.Id_Rol, Rol_Nombre, Habilitado
		FROM Rol R, Usuario_Rol UR
		WHERE UR.Id_Usuario = @Id_Usuario
			AND UR.Id_Rol = R.Id_Rol
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
	SELECT top 1 *
		FROM Usuario u, Clientes c
		WHERE u.Id_Usuario = @Id_Usuario
			AND u.Id_Usuario = c.Id_Usuario
GO



/****************************************************************
 *					crearClienteYUsuario
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].crearClienteYUsuario
	@Username varchar(255), @Password varchar(255), @PreguntaSecreta varchar(255),
	@RespuestaSecreta varchar(255),
	@Nombre varchar(255), @Apellido varchar(255), @NroDocumento numeric(18,0),
	@Id_TipoDocumento int, @Mail varchar(255), @Id_Pais int, @Dom_Nro int,
	@Dom_Calle varchar(255), @Dom_Piso int = NULL, @Dom_Depto varchar(255) = NULL,
	@Dom_Localidad varchar(255), @Id_Nacionalidad int, @Fecha_Nac DateTime
AS
BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO [LA_MAQUINA_DE_HUMO].Usuario([Cantidad_Intentos_Fallidos], [Username],
				[Password],[Habilitado],[Fecha_Creacion],[Fecha_Ultima_Modificacion],
				[Pregunta_Secreta],[Respuesta_Secreta])
			VALUES (0, @Username, @Password, 's',
				LA_MAQUINA_DE_HUMO.obtenerFecha(), LA_MAQUINA_DE_HUMO.obtenerFecha(),
				@PreguntaSecreta, @RespuestaSecreta)
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
	
	SELECT TOP 1 Id_Cliente, Id_Usuario
		FROM Clientes
		ORDER BY Id_Cliente DESC
COMMIT
GO


/****************************************************************
 *					agregarRolAUsuario
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].agregarRolAUsuario
	@Id_Usuario int,
	@Id_Rol int
AS
BEGIN TRANSACTION
	INSERT INTO LA_MAQUINA_DE_HUMO.Usuario_Rol(Id_Usuario, Id_Rol) VALUES (@Id_Usuario, @Id_Rol)
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
 *							guardarCliente
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].guardarCliente
	@Id_Cliente int, @Nombre varchar(255), @Apellido varchar(255), @NroDocumento numeric(18,0),
	@Id_TipoDocumento int, @Mail varchar(255), @Id_Pais int, @Dom_Nro int,
	@Dom_Calle varchar(255), @Dom_Piso int = NULL, @Dom_Depto varchar(255) = NULL,
	@Dom_Localidad varchar(255), @Id_Nacionalidad int, @Fecha_Nac DateTime,
	@Habilitado char(1)
AS
	BEGIN TRY
		UPDATE [LA_MAQUINA_DE_HUMO].Clientes
			SET	Cli_Nombre = @Nombre, Cli_Apellido = @Apellido, Cli_Nro_Doc = @NroDocumento,
				Cli_Tipo_Doc_Cod = @Id_TipoDocumento, Cli_Mail = @Mail, Cli_Pais_Codigo = @Id_Pais,
				Cli_Dom_Nro = @Dom_Nro, Cli_Dom_Calle = @Dom_Calle, Cli_Dom_Piso = @Dom_Piso,
				Cli_Dom_Depto = @Dom_Depto, Cli_Dom_Localidad = @Dom_Localidad,
				Cli_Nacionalidad_Codigo = @Id_Nacionalidad, Cli_Fecha_Nac = @Fecha_Nac,
				Cli_Habilitado = @Habilitado
			WHERE Id_Cliente = @Id_Cliente
	END TRY
	BEGIN CATCH
		RAISERROR('Ya existe un cliente con esa identificacion y/o email', 16, 1)
	END CATCH
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



/****************************************************************
 *					obtenerTiposCuenta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerTiposCuenta
AS
	SELECT Id_Tipo_Cuenta, Descripcion FROM LA_MAQUINA_DE_HUMO.Tipo_Cuenta
GO



/****************************************************************
 *					obtenerMonedas
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerMonedas
AS
	SELECT * FROM LA_MAQUINA_DE_HUMO.Moneda
GO



/****************************************************************
 *					obtenerTarjetasHabilitadasDeCliente
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerTarjetasHabilitadasDeCliente
	@Id_Cliente int
AS
	SELECT * FROM LA_MAQUINA_DE_HUMO.Tarjeta
		WHERE Id_Cliente = @Id_Cliente
			AND Habilitado = 's'
GO



/****************************************************************
 *					bajaTarjeta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].bajaTarjeta
	@Id_Tarjeta int
AS
	UPDATE LA_MAQUINA_DE_HUMO.Tarjeta
		SET Habilitado = 'n'
		WHERE Id_Tarjeta = @Id_Tarjeta
GO





/****************************************************************
 *					actualizarEstadoCuenta
 ****************************************************************/
CREATE PROCEDURE LA_MAQUINA_DE_HUMO.actualizarEstadoCuenta
	@Cuenta_Numero numeric(18,0)
AS
BEGIN TRANSACTION
	DECLARE @Transferencias_No_Pagas int
	SET @Transferencias_No_Pagas = (SELECT COUNT(*)
			FROM LA_MAQUINA_DE_HUMO.Transaccion, LA_MAQUINA_DE_HUMO.Transferencia
			WHERE Id_Evento = Id_Transferencia
				AND Factura_Numero IS NULL
				AND Tranf_Cuenta_Origen_Numero = @Cuenta_Numero)

	DECLARE @Altas_No_Pagas int
	SET @Altas_No_Pagas = (SELECT COUNT(*)
			FROM LA_MAQUINA_DE_HUMO.Transaccion, LA_MAQUINA_DE_HUMO.Alta_Cuenta
			WHERE Id_Evento = Id_Alta_Cuenta
				AND Factura_Numero IS NULL
				AND Cuenta_Numero = @Cuenta_Numero)
				
	DECLARE @Modificaciones_No_Pagas int
	SET @Modificaciones_No_Pagas = (SELECT COUNT(*)
			FROM LA_MAQUINA_DE_HUMO.Transaccion, LA_MAQUINA_DE_HUMO.Modificacion_Cuenta
			WHERE Id_Evento = Id_Modificacion_Cuenta
				AND Factura_Numero IS NULL
				AND Cuenta_Numero = @Cuenta_Numero)
				
	IF @Transferencias_No_Pagas + @Altas_No_Pagas + @Modificaciones_No_Pagas > 5
	BEGIN
		UPDATE LA_MAQUINA_DE_HUMO.Cuenta
			SET Estado_ID = 3
			WHERE Cuenta_Numero = @Cuenta_Numero
			
		INSERT INTO LA_MAQUINA_DE_HUMO.Inhabilitaciones(
			Fecha_Inhabilitacion,
			Cuenta_Numero
		) VALUES (
			LA_MAQUINA_DE_HUMO.obtenerFecha(),
			@Cuenta_Numero
		)
	END
COMMIT
GO







/****************************************************************
 *					crearCuenta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].crearCuenta
	@Id_Cliente int,
	@Id_Tipo_Cuenta int,
	@Id_Moneda int,
	@Cuenta_Pais numeric(18,0),
	@Cantidad_Suscripciones int
AS
BEGIN TRANSACTION
	-- Creo la cuenta
	INSERT INTO LA_MAQUINA_DE_HUMO.Cuenta(
		[Cuenta_Pais],
		[Id_Moneda],
		[Fecha_Creacion],
		[Id_Cliente],
		[Id_Tipo_Cuenta],
		[Fecha_Cierre],
		[Estado_Id]
	) VALUES (
		@Cuenta_Pais,
		@Id_Moneda,
		LA_MAQUINA_DE_HUMO.obtenerFecha(),
		@Id_Cliente,
		@Id_Tipo_Cuenta,
		NULL,
		1
	)

	-- Creo las suscripciones
	DECLARE @Cuenta_Numero numeric(18,0)
	SET @Cuenta_Numero = (SELECT top 1 Cuenta_Numero FROM LA_MAQUINA_DE_HUMO.Cuenta order by Cuenta_Numero DESC)

	DECLARE @Duracion_Suscripcion int
	SET @Duracion_Suscripcion = (SELECT Duracion FROM LA_MAQUINA_DE_HUMO.Tipo_Cuenta WHERE Id_Tipo_Cuenta = @Id_Tipo_Cuenta)

	DECLARE @i int
	SET @i = 0
	
	WHILE @i < @Cantidad_Suscripciones
	BEGIN	
		INSERT INTO LA_MAQUINA_DE_HUMO.Alta_Cuenta(
			Alta_Cuenta_Fecha_Inicio,
			Alta_Cuenta_Fecha_Fin,
			Cuenta_Numero
		) VALUES (
			LA_MAQUINA_DE_HUMO.obtenerFecha() + @Duracion_Suscripcion * @i,
			LA_MAQUINA_DE_HUMO.obtenerFecha() + @Duracion_Suscripcion * (@i + 1),
			@Cuenta_Numero
		)
		
		SET @i = @i + 1
	END

	DECLARE @Importe numeric(18,2)
	SET @Importe = (SELECT Costo_Alta FROM LA_MAQUINA_DE_HUMO.Tipo_Cuenta WHERE Id_Tipo_Cuenta = @Id_Tipo_Cuenta)
	
	IF @Importe > 0
	BEGIN
		INSERT INTO LA_MAQUINA_DE_HUMO.Transaccion(
			Id_Item,
			Id_Cliente,
			Importe,
			Id_Tipo_Cuenta,
			Fecha_Transaccion,
			Id_Evento)
			SELECT TOP(@Cantidad_Suscripciones)
					2,
					@Id_Cliente,
					@Importe,
					@Id_Tipo_Cuenta,
					LA_MAQUINA_DE_HUMO.obtenerFecha(),
					Id_Alta_Cuenta
				FROM LA_MAQUINA_DE_HUMO.Alta_Cuenta ORDER BY Id_Alta_Cuenta DESC
	END
COMMIT
GO


/****************************************************************
 *					guardarCuenta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].guardarCuenta
	@Cuenta_Numero numeric(18,0),
	@Id_Tipo_Cuenta int,
	@Id_Moneda int,
	@Cuenta_Pais numeric(18,0)
AS
BEGIN TRANSACTION
	DECLARE @Estado_Cuenta int
	SET @Estado_Cuenta = (SELECT Estado_ID FROM LA_MAQUINA_DE_HUMO.Cuenta WHERE Cuenta_Numero = @Cuenta_Numero)
	
	IF @Estado_Cuenta = 4
	BEGIN
		RAISERROR('No puede modificarse una cuenta cerrada', 16, 1)
		ROLLBACK
		RETURN
	END

	DECLARE @Tipo_Cuenta_Anterior int
	SET @Tipo_Cuenta_Anterior = (SELECT Id_Tipo_Cuenta FROM LA_MAQUINA_DE_HUMO.Cuenta WHERE Cuenta_Numero = @Cuenta_Numero)

	UPDATE LA_MAQUINA_DE_HUMO.Cuenta
		SET Id_Moneda = @Id_Moneda, Cuenta_Pais = @Cuenta_Pais, Id_Tipo_Cuenta = @Id_Tipo_Cuenta
		WHERE Cuenta_Numero = @Cuenta_Numero
		
	INSERT INTO LA_MAQUINA_DE_HUMO.Modificacion_Cuenta(
		[Modificacion_Cuenta_Fecha],
		[Cuenta_Numero])
	VALUES (
		LA_MAQUINA_DE_HUMO.obtenerFecha(),
		@Cuenta_Numero
	)

	IF @Tipo_Cuenta_Anterior < @Id_Tipo_Cuenta
	BEGIN
		DECLARE @Id_Cliente int
		SET @Id_Cliente = (SELECT Id_Cliente FROM LA_MAQUINA_DE_HUMO.Cuenta WHERE Cuenta_Numero = @Cuenta_Numero) 

		DECLARE @Importe numeric(18,2)
		SET @Importe = (SELECT Costo_Modificacion FROM LA_MAQUINA_DE_HUMO.Tipo_Cuenta WHERE Id_Tipo_Cuenta = @Id_Tipo_Cuenta)
		
		INSERT INTO LA_MAQUINA_DE_HUMO.Transaccion(
			Id_Item,
			Id_Cliente,
			Importe,
			Id_Tipo_Cuenta,
			Fecha_Transaccion,
			Id_Evento)
			SELECT TOP(1) 3, @Id_Cliente, @Importe, @Id_Tipo_Cuenta, LA_MAQUINA_DE_HUMO.obtenerFecha(), Id_Modificacion_Cuenta FROM LA_MAQUINA_DE_HUMO.Modificacion_Cuenta
	END
	
	EXEC LA_MAQUINA_DE_HUMO.actualizarEstadoCuenta @Cuenta_Numero
COMMIT
GO


/****************************************************************
 *					obtenerCuentas
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerCuentas
AS
	SELECT DISTINCT * FROM LA_MAQUINA_DE_HUMO.Cuenta
GO



/****************************************************************
 *					obtenerCuentasCliente
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerCuentasCliente
	@Id_Cliente int
AS
     SELECT DISTINCT * FROM LA_MAQUINA_DE_HUMO.Cuenta 
	     WHERE Id_Cliente = @Id_Cliente
GO



/****************************************************************
 *					bajaCuenta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].bajaCuenta
	@Cuenta_Numero numeric(18,0)
AS
BEGIN TRANSACTION
	DECLARE @Transferencias_No_Facturadas int
	SET @Transferencias_No_Facturadas = (SELECT COUNT(*) FROM Transaccion, Transferencia
											WHERE Id_Evento = Id_Transferencia
												AND Tranf_Cuenta_Origen_Numero = @Cuenta_Numero
												AND Factura_Numero IS NULL)
	DECLARE @Altas_No_Facturadas int
	SET @Altas_No_Facturadas = (SELECT COUNT(*) FROM Transaccion, Alta_Cuenta
											WHERE Id_Evento = Id_Alta_Cuenta
												AND Cuenta_Numero = @Cuenta_Numero
												AND Factura_Numero IS NULL)
												
	DECLARE @Modificaciones_No_Facturadas int
	SET @Modificaciones_No_Facturadas = (SELECT COUNT(*) FROM Transaccion, Modificacion_Cuenta
											WHERE Id_Evento = Id_Modificacion_Cuenta
												AND Cuenta_Numero = @Cuenta_Numero
												AND Factura_Numero IS NULL)

	DECLARE @Transacciones_No_Facturadas int
	SET @Transacciones_No_Facturadas = @Transferencias_No_Facturadas + @Altas_No_Facturadas + @Modificaciones_No_Facturadas

	IF @Transacciones_No_Facturadas > 0
	BEGIN
		RAISERROR('La cuenta tiene transacciones no facturadas. No puede darse de baja', 16, 1)
		ROLLBACK
		RETURN
	END
	
	UPDATE LA_MAQUINA_DE_HUMO.Cuenta
		SET Estado_ID = 4, Fecha_Cierre = LA_MAQUINA_DE_HUMO.obtenerFecha()
		WHERE Cuenta_Numero = @Cuenta_Numero
	
COMMIT
GO



/****************************************************************
 *					crearTarjeta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].crearTarjeta
	@Id_Cliente int,
	@Tarjeta_Numero numeric(18,0),
	@Tarjeta_Emisor_Descripcion varchar(255),
	@Tarjeta_Fecha_Emision datetime,
	@Tarjeta_Fecha_Vencimiento datetime,
	@Tarjeta_Codigo_Seg varchar(255)
AS
BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO Tarjeta(
			[Id_Cliente],
			[Tarjeta_Numero],
			[Tarjeta_Emisor_Descripcion],
			[Tarjeta_Fecha_Emision],
			[Tarjeta_Fecha_Vencimiento],
			[Tarjeta_Codigo_Seg],
			[Habilitado]
		) VALUES (
			@Id_Cliente,
			@Tarjeta_Numero,
			@Tarjeta_Emisor_Descripcion,
			@Tarjeta_Fecha_Emision,
			@Tarjeta_Fecha_Vencimiento,
			@Tarjeta_Codigo_Seg,
			's'
		)	
	END TRY
	BEGIN CATCH
		RAISERROR('Ya existe una tarjeta con ese numero', 16, 1)
		ROLLBACK
		RETURN		
	END	CATCH	
COMMIT
GO


/****************************************************************
 *					guardarTarjeta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].guardarTarjeta
	@Id_Tarjeta int,
	@Id_Cliente int,
	@Tarjeta_Numero numeric(18,0),
	@Tarjeta_Emisor_Descripcion varchar(255),
	@Tarjeta_Fecha_Emision datetime,
	@Tarjeta_Fecha_Vencimiento datetime,
	@Tarjeta_Codigo_Seg varchar(255),
	@Habilitado char(1)
AS
BEGIN TRANSACTION
	BEGIN TRY
		UPDATE Tarjeta
			SET Id_Cliente = @Id_Cliente,
			Tarjeta_Numero = @Tarjeta_Numero,
			Tarjeta_Emisor_Descripcion = @Tarjeta_Emisor_Descripcion,
			Tarjeta_Fecha_Emision = @Tarjeta_Fecha_Emision,
			Tarjeta_Fecha_Vencimiento = @Tarjeta_Fecha_Vencimiento,
			Tarjeta_Codigo_Seg = @Tarjeta_Codigo_Seg,
			Habilitado = @Habilitado
		WHERE Id_Tarjeta = @Id_Tarjeta
	END TRY
	BEGIN CATCH
		RAISERROR('Ya existe una tarjeta con ese numero', 16, 1)
		ROLLBACK
		RETURN		
	END	CATCH	
COMMIT
GO



/****************************************************************
 *					depositar
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].depositar
	@Cuenta_Numero numeric(18,0),
	@Importe numeric(18,2),
	@Id_Moneda int,
	@Id_Tarjeta int
AS
BEGIN TRANSACTION
IF (Select Tarjeta_Fecha_Vencimiento from Tarjeta where Id_Tarjeta = @Id_Tarjeta) < LA_MAQUINA_DE_HUMO.obtenerFecha()
BEGIN
	RAISERROR('La tarjeta esta vencida, no es posible depositar',16,1)
	ROLLBACK
	RETURN
END

DECLARE @Estado_Cuenta int
	SET @Estado_Cuenta = (SELECT Estado_ID FROM LA_MAQUINA_DE_HUMO.Cuenta WHERE Cuenta_Numero = @Cuenta_Numero)
	
	IF @Estado_Cuenta != 2
	BEGIN
		RAISERROR('La cuenta destino no se encuentra habilitada', 16, 1)
		ROLLBACK
		RETURN
	END

	INSERT INTO LA_MAQUINA_DE_HUMO.Deposito(
		Numero_Cuenta,
		Deposito_importe,
		Id_Moneda,
		Id_Tarjeta,
		Deposito_Fecha
	) VALUES (
		@Cuenta_Numero,
		@Importe,
		@Id_Moneda,
		@Id_Tarjeta,
		LA_MAQUINA_DE_HUMO.obtenerFecha()
	)
COMMIT
GO



/****************************************************************
 *					retirar
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].retirar
	@Cuenta_Numero numeric(18,0),
	@Importe numeric(18,2),
	@Id_Moneda int,
	@Nro_Doc numeric(18,0),
	@Banco_Codigo numeric(18,0)
AS
BEGIN TRANSACTION
	-- Verificar que el numero de documento coincida con el del cliente
	IF (SELECT Cli_Nro_Doc FROM Clientes cl, Cuenta cu WHERE cl.Id_Cliente = cu.Id_Cliente AND Cuenta_Numero = @Cuenta_Numero) != @Nro_Doc
	BEGIN
		RAISERROR('El numero de documento no es valido', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END

	-- Verificar que la cuenta este habilitada
	DECLARE @Estado_Cuenta int
	SET @Estado_Cuenta = (SELECT Estado_ID FROM LA_MAQUINA_DE_HUMO.Cuenta WHERE Cuenta_Numero = @Cuenta_Numero)
	IF @Estado_Cuenta != 2
	BEGIN
		RAISERROR('La cuenta destino no se encuentra habilitada', 16, 1)
		ROLLBACK
		RETURN
	END
	
	-- Verificar que haya saldo
	IF @Importe > LA_MAQUINA_DE_HUMO.saldoCuenta(@Cuenta_Numero)
	BEGIN
		RAISERROR('El monto a retirar es mayor al saldo de la cuenta', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END
	
	-- Realizar el retiro
	INSERT INTO Retiro(
		Numero_Cuenta,
		Retiro_Fecha,
		Retiro_Importe,
		Id_Moneda
	) VALUES (
		@Cuenta_Numero,
		LA_MAQUINA_DE_HUMO.obtenerFecha(),
		@Importe,
		@Id_Moneda
	)

	-- Crear el cheque
	INSERT INTO Cheque(	
		Retiro_Codigo,
		Banco_Codigo
	) VALUES (
		(SELECT TOP 1 Retiro_Codigo FROM Retiro WHERE Numero_Cuenta = @Cuenta_Numero ORDER BY Retiro_Codigo DESC),
		@Banco_Codigo
	)
	
COMMIT
GO



/****************************************************************
 *					transferir
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].transferir
	@Numero_Cuenta_Origen numeric(18,0),
	@Numero_Cuenta_Destino numeric(18,0),
	@Importe numeric(18,2)
AS
BEGIN TRANSACTION
	DECLARE @Estado_Cuenta int
	SET @Estado_Cuenta = (SELECT Estado_ID FROM LA_MAQUINA_DE_HUMO.Cuenta WHERE Cuenta_Numero = @Numero_Cuenta_Destino)
	IF @Estado_Cuenta != 2 AND @Estado_Cuenta != 3
	BEGIN
		RAISERROR('La cuenta destino debe estar habilitada o inhabilitada ', 16, 1)
		ROLLBACK
		RETURN
	END

	
	IF @Importe > LA_MAQUINA_DE_HUMO.f_obtenerSaldoDeCuenta(@Numero_Cuenta_Origen)
	BEGIN
		RAISERROR('El monto a transferir es mayor al saldo de la cuenta', 16, 1)
		ROLLBACK TRANSACTION
		RETURN
	END
	
	DECLARE @Costo_Transferencia numeric(18,2)
	DECLARE @Cliente_Cuenta_Origen int
	DECLARE @Cliente_Cuenta_Destino int
	
	SET @Cliente_Cuenta_Origen = (SELECT Id_Cliente FROM Cuenta WHERE Cuenta_Numero = @Numero_Cuenta_Origen)
	SET @Cliente_Cuenta_Destino = (SELECT Id_Cliente FROM Cuenta WHERE Cuenta_Numero = @Numero_Cuenta_Destino)
	
	-- Obtengo el costo de transferencia
	IF @Cliente_Cuenta_Origen = @Cliente_Cuenta_Destino
	BEGIN
		SET @Costo_Transferencia = 0
	END
	ELSE
	BEGIN
		SET @Costo_Transferencia = (SELECT Costo_Tranferencia FROM Tipo_Cuenta tc, Cuenta c
										WHERE tc.Id_Tipo_Cuenta = c.Id_Tipo_Cuenta
											AND c.Cuenta_Numero = @Numero_Cuenta_Origen)
	END

	INSERT INTO Transferencia(
		Tranf_Cuenta_Dest_Numero,
		Tranf_Cuenta_Origen_Numero,
		Tranf_Importe,
		Tranf_Fecha,
		Tranf_Estado_Cuenta_Dest
	) VALUES (
		@Numero_Cuenta_Destino,
		@Numero_Cuenta_Origen,
		@Importe,
		LA_MAQUINA_DE_HUMO.obtenerFecha(),
		(SELECT Estado_ID FROM Cuenta WHERE Cuenta_Numero = @Numero_Cuenta_Destino)
	)

	IF @Costo_Transferencia > 0
	BEGIN	
		DECLARE @Id_Transferencia int
		SET @Id_Transferencia = (SELECT TOP 1 Id_Transferencia FROM Transferencia ORDER BY Id_Transferencia DESC)

		DECLARE @Id_Tipo_Cuenta_Origen int
		SET @Id_Tipo_Cuenta_Origen = (SELECT TOP 1 Id_Tipo_Cuenta FROM Cuenta WHERE Cuenta_Numero = @Numero_Cuenta_Origen)
		
		INSERT INTO Transaccion(
			Id_Cliente,
			Id_Evento,
			Id_Item,
			Id_Tipo_Cuenta,
			Importe,
			Fecha_Transaccion
		) VALUES (
			@Cliente_Cuenta_Origen,
			@Id_Transferencia,
			1,
			@Id_Tipo_Cuenta_Origen,		
			@Costo_Transferencia,
			LA_MAQUINA_DE_HUMO.obtenerFecha()
		)
	END
	
	EXEC LA_MAQUINA_DE_HUMO.actualizarEstadoCuenta @Numero_Cuenta_Origen
COMMIT
GO


/****************************************************************
 *					obtenerTransaccionesImpagasDeCliente
 ****************************************************************/
 /* NOTA: este stored tiene que devolver como minimo 2 columnas (en cualquier
	orden) que se llamen: Importe y Descripcion
	
	Algo asi:   	
	select Importe as Importe, Item_Descripcion as Descripcion
		from LA_MAQUINA_DE_HUMO.Transaccion t, LA_MAQUINA_DE_HUMO.Item i
		where t.Id_Item = i.Id_Item
			AND ...
		...
 */
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerTransaccionesImpagasDeCliente
	@Id_Cliente int
AS
   select T.Importe Importe, I.Item_Descripcion Descripcion, Tranf_Fecha Fecha from LA_MAQUINA_DE_HUMO.Transaccion T, LA_MAQUINA_DE_HUMO.Item I, Transferencia
	where Id_Cliente = @Id_Cliente and Factura_Numero is null 
	and T.Id_Item = I.Id_Item
	and T.Id_Item = 1
	and Id_Transferencia = Id_Evento
	and Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()
   UNION ALL
	select T.Importe Importe, I.Item_Descripcion Descripcion, Alta_Cuenta_Fecha_Inicio Fecha from LA_MAQUINA_DE_HUMO.Transaccion T, LA_MAQUINA_DE_HUMO.Item I, Alta_Cuenta
	where Id_Cliente = @Id_Cliente and Factura_Numero is null 
	and T.Id_Item = I.Id_Item
	and T.Id_Item = 2
	and Id_Alta_Cuenta = Id_Evento
	and Alta_Cuenta_Fecha_Inicio <= LA_MAQUINA_DE_HUMO.obtenerFecha()
   UNION ALL
	select T.Importe Importe, I.Item_Descripcion Descripcion, Modificacion_Cuenta_Fecha Fecha from LA_MAQUINA_DE_HUMO.Transaccion T, LA_MAQUINA_DE_HUMO.Item I, Modificacion_Cuenta
	where Id_Cliente = @Id_Cliente and Factura_Numero is null 
	and T.Id_Item = I.Id_Item
	and T.Id_Item = 3
	and Id_Modificacion_Cuenta = Id_Evento
	and Modificacion_Cuenta_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()
GO

/****************************************************************
 *					facturar
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].facturar
	@Id_Cliente int
AS
	CREATE TABLE #A_FACTURAR
	(
		Importe numeric(18,0),
		Descripcion varchar(255),
		Fecha datetime
	)
	
	INSERT INTO #A_FACTURAR
		EXEC LA_MAQUINA_DE_HUMO.obtenerTransaccionesImpagasDeCliente @Id_Cliente
		
	IF (SELECT COUNT(*) FROM #A_FACTURAR) = 0
	BEGIN
		RAISERROR('No hay elementos a facturar', 16, 1)
		RETURN
	END

BEGIN TRANSACTION
	INSERT INTO LA_MAQUINA_DE_HUMO.Factura(
		Factura_Fecha
	)VALUES(
		LA_MAQUINA_DE_HUMO.obtenerFecha()
	)
	
	DECLARE @Numero_Factura numeric(18,0)
	SET @Numero_Factura = (SELECT TOP 1 Factura_Numero FROM LA_MAQUINA_DE_HUMO.Factura ORDER BY Factura_Numero DESC)
	
	UPDATE LA_MAQUINA_DE_HUMO.Transaccion
		SET Factura_Numero = @Numero_Factura
		FROM LA_MAQUINA_DE_HUMO.Transaccion 
			JOIN LA_MAQUINA_DE_HUMO.Transferencia ON Id_Evento = Id_Transferencia
		WHERE Factura_Numero IS NULL
			AND Id_Cliente = @Id_Cliente
			AND Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()
			
	UPDATE LA_MAQUINA_DE_HUMO.Transaccion
		SET Factura_Numero = @Numero_Factura
		FROM LA_MAQUINA_DE_HUMO.Transaccion 
			JOIN LA_MAQUINA_DE_HUMO.Alta_Cuenta ON Id_Evento = Id_Alta_Cuenta
		WHERE Factura_Numero IS NULL
			AND Id_Cliente = @Id_Cliente
			AND Alta_Cuenta_Fecha_Inicio <= LA_MAQUINA_DE_HUMO.obtenerFecha()
			
	UPDATE LA_MAQUINA_DE_HUMO.Transaccion
		SET Factura_Numero = @Numero_Factura
		FROM LA_MAQUINA_DE_HUMO.Transaccion 
			JOIN LA_MAQUINA_DE_HUMO.Modificacion_Cuenta ON Id_Evento = Id_Modificacion_Cuenta
		WHERE Factura_Numero IS NULL
			AND Id_Cliente = @Id_Cliente
			AND Modificacion_Cuenta_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()
	
	-- Habilito las cuentas inhabilitadas y pendientes del cliente		
	UPDATE Cuenta
		SET Estado_ID = 2
		WHERE Id_Cliente = @Id_Cliente
			AND Estado_ID = 3
			OR Estado_ID = 1
	
COMMIT
GO


/****************************************************************
 *					obtenerMontoDepositos
 ****************************************************************/
CREATE FUNCTION [LA_MAQUINA_DE_HUMO].obtenerMontoDepositos(@Cuenta_Numero numeric(18,0))
	RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @MontoDepositos numeric(18,2)
	SET @MontoDepositos =(SELECT SUM(Deposito_Importe) FROM LA_MAQUINA_DE_HUMO.Deposito
		WHERE Numero_Cuenta = @Cuenta_Numero
			AND Deposito_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha())
	
	IF (@MontoDepositos IS NULL)
	BEGIN
		SET @MontoDepositos= 0
	END
	RETURN @MontoDepositos
END
GO


/****************************************************************
 *					obtenerMontoTransferenciasRecibidas
 ****************************************************************/
CREATE FUNCTION [LA_MAQUINA_DE_HUMO].obtenerMontoTransferenciasRecibidas(@Cuenta_Numero numeric(18,0))
	RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @MontoTranferenciasRecibidaas numeric(18,2)
	SET @MontoTranferenciasRecibidaas= (SELECT SUM(Tranf_Importe) FROM LA_MAQUINA_DE_HUMO.Transferencia
		WHERE Tranf_Cuenta_Dest_Numero = @Cuenta_Numero
			AND Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha())
	IF (@MontoTranferenciasRecibidaas IS NULL)
	BEGIN
		SET @MontoTranferenciasRecibidaas = 0
	END
	RETURN @MontoTranferenciasRecibidaas 
END
GO


/****************************************************************
 *					obtenerMontoTransferenciasRealizadas
 ****************************************************************/
CREATE FUNCTION [LA_MAQUINA_DE_HUMO].obtenerMontoTransferenciasRealizadas(@Cuenta_Numero numeric(18,0))
	RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @MontoTranferenciasRealizadas numeric(18,2)
	SET @MontoTranferenciasRealizadas= (SELECT SUM(Tranf_Importe) FROM LA_MAQUINA_DE_HUMO.Transferencia
		WHERE Tranf_Cuenta_Origen_Numero = @Cuenta_Numero
			AND Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha())
	IF (@MontoTranferenciasRealizadas IS NULL)
	BEGIN
		SET @MontoTranferenciasRealizadas = 0
	END
	RETURN @MontoTranferenciasRealizadas 
END
GO


/****************************************************************
 *					obtenerMontoRetiros
 ****************************************************************/
CREATE FUNCTION [LA_MAQUINA_DE_HUMO].obtenerMontoRetiros(@Cuenta_Numero numeric(18,0))
	RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @MontoRetiros numeric(18,2)
	SET @MontoRetiros=(SELECT SUM(Retiro_Importe) FROM LA_MAQUINA_DE_HUMO.Retiro
		WHERE Numero_Cuenta = @Cuenta_Numero
			AND Retiro_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha())
	
	IF (@MontoRetiros IS NULL)
	BEGIN
		SET @MontoRetiros= 0
	END
	RETURN @MontoRetiros
END
GO

/****************************************************************
 *					f_obtenerSaldoDeCuenta
 ****************************************************************/
CREATE FUNCTION [LA_MAQUINA_DE_HUMO].f_obtenerSaldoDeCuenta (@Cuenta_Numero numeric(18,0))
	RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @saldoCuenta numeric(18,2)
	
	SET @saldoCuenta = LA_MAQUINA_DE_HUMO.obtenerMontoDepositos(@Cuenta_Numero)
		+ LA_MAQUINA_DE_HUMO.obtenerMontoTransferenciasRecibidas(@Cuenta_Numero)
		- LA_MAQUINA_DE_HUMO.obtenerMontoTransferenciasRealizadas(@Cuenta_Numero)
		- LA_MAQUINA_DE_HUMO.obtenerMontoRetiros(@Cuenta_Numero)
		
	RETURN @saldoCuenta
END
GO


/****************************************************************
 *					obtenerMontoFacturaciones
 ****************************************************************/
CREATE FUNCTION[LA_MAQUINA_DE_HUMO].obtenerMontoFacturaciones (@Cuenta_Numero numeric(18,0))
	RETURNS numeric(18,2)
AS
BEGIN
	
	Declare @Importe numeric(18,2)
	Set @Importe = (Select Sum(Importe) from factura F, transaccion T where Numero_Cuenta = @Cuenta_Numero and F.Factura_Numero = T.Factura_Numero 
	and F.Factura_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()) 
	
	IF @importe is null 
	BEGIN
		SET @importe= 0
	END
	
	return @Importe

END
GO



/****************************************************************
 *					obtenerSaldoDeCuenta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerSaldoDeCuenta
	@Cuenta_Numero numeric(18,2)
AS
	SELECT LA_MAQUINA_DE_HUMO.f_obtenerSaldoDeCuenta(@Cuenta_Numero) AS Saldo_Cuenta
GO


/****************************************************************
 *					obtenerUltimos5Depositos
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerUltimos5Depositos
	@Cuenta_Numero numeric(18,0)
AS
	SELECT TOP 5 * FROM Deposito
		WHERE Numero_Cuenta = @Cuenta_Numero
			AND Deposito_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()
		ORDER BY Deposito_Fecha DESC
GO


/****************************************************************
 *					obtenerUltimos5Retiros
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerUltimos5Retiros
	@Cuenta_Numero numeric(18,0)
AS
	SELECT TOP 5 * FROM Retiro
		WHERE Numero_Cuenta = @Cuenta_Numero
			AND Retiro_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()
		ORDER BY Retiro_Fecha DESC
GO


/****************************************************************
 *					obtenerUltimas10Transferencias
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].obtenerUltimas10Transferencias
	@Cuenta_Numero numeric(18,0)
AS
	SELECT TOP 10 * FROM Transferencia
		WHERE Tranf_Cuenta_Origen_Numero = @Cuenta_Numero
			AND Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFecha()
		ORDER BY Tranf_Fecha DESC
GO


/****************************************************************
 *					obtenerFechaInicioTrimestre
 ****************************************************************/
CREATE FUNCTION [LA_MAQUINA_DE_HUMO].obtenerFechaInicioTrimestre (@anio int, @trimestre int)
	RETURNS datetime
AS
BEGIN
	RETURN CAST(
		CAST(@anio AS varchar(4))
		+ RIGHT('0' + CAST((@trimestre - 1) * 3 + 1 AS varchar(2)), 2)
		+ '01'
		AS DATETIME)
END
GO


/****************************************************************
 *					obtenerFechaFinTrimestre
 ****************************************************************/
CREATE FUNCTION [LA_MAQUINA_DE_HUMO].obtenerFechaFinTrimestre (@anio int, @trimestre int) RETURNS datetime
AS
BEGIN
	DECLARE @FechaFin datetime
	IF @trimestre = 4
	BEGIN
		SET @FechaFin = CAST(CAST(@anio as varchar(4)) + '1231' AS datetime)
	END
	ELSE
	BEGIN
		SET @FechaFin = CAST(
			CAST(@anio AS varchar(4))
			+ RIGHT('0' + CAST(@trimestre * 3 + 1 AS varchar(2)), 2)
			+ '01'
			AS DATETIME) - 1
	END
	
	RETURN @FechaFin
END
GO


/****************************************************************
 *					ClientesConMayorCantidadDeTransferenciasPropias
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].ClientesConMayorCantidadDeTransferenciasPropias
	@anio int,
	@trimestre int
AS
	
	IF LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre) > LA_MAQUINA_DE_HUMO.obtenerFecha()
	BEGIN
		RAISERROR('El trimestre seleccionado se encuentra en el futuro', 16, 1)
		RETURN
	END

	SELECT TOP 5 Cli.Id_Cliente, Cli_Nombre, Cli_Apellido, COUNT(Id_Transferencia)
		FROM Clientes Cli, Transferencia T, Cuenta Cu
		WHERE Cli.Id_Cliente = Cu.Id_Cliente
			AND Cu.Cuenta_Numero = T.Tranf_Cuenta_Origen_Numero
			AND Cu.Cuenta_Numero = T.Tranf_Cuenta_Dest_Numero
			AND Tranf_Fecha >= LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre)
			AND Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFechaFinTrimestre(@anio, @trimestre)
		GROUP BY Cli.Id_Cliente, Cli_Nombre, Cli_Apellido
		ORDER BY COUNT(Id_Transferencia) DESC
GO


/****************************************************************
 *					ClientesConMayorCantidadDeComisionesFacturadas
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].ClientesConMayorCantidadDeComisionesFacturadas
	@anio int,
	@trimestre int
AS
	
	IF LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre) > LA_MAQUINA_DE_HUMO.obtenerFecha()
	BEGIN
		RAISERROR('El trimestre seleccionado se encuentra en el futuro', 16, 1)
		RETURN
	END

	SELECT TOP 5 T.Id_Cliente, C.Cli_Nombre, C.Cli_Apellido, D.Doc_Desc, C.Cli_Nro_Doc, COUNT(*) AS Comisiones_Facturadas
		FROM LA_MAQUINA_DE_HUMO.Transaccion T, LA_MAQUINA_DE_HUMO.Clientes C, LA_MAQUINA_DE_HUMO.Factura F, LA_MAQUINA_DE_HUMO.Documento D
		WHERE T.Id_Cliente = C.Id_Cliente
			AND C.Cli_Tipo_Doc_Cod = D.Doc_Codigo
			AND T.Factura_Numero = F.Factura_Numero
			AND Id_Item = 1
			AND F.Factura_Fecha >= LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre)
			AND F.Factura_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFechaFinTrimestre(@anio, @trimestre)
		GROUP BY T.Id_Cliente, C.Cli_Nombre, C.Cli_Apellido, D.Doc_Desc, C.Cli_Nro_Doc
		ORDER BY COUNT(*) DESC
GO


/****************************************************************
 *					PaisesConMayorCantidadDeMovimientos
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].PaisesConMayorCantidadDeMovimientos
	@anio int,
	@trimestre int
AS
	IF LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre) > LA_MAQUINA_DE_HUMO.obtenerFecha()
	BEGIN
		RAISERROR('El trimestre seleccionado se encuentra en el futuro', 16, 1)
		RETURN
	END

	CREATE TABLE #EGRESOS_PAIS(
		Pais_Codigo numeric(18,0) PRIMARY KEY,
		Egresos int	
	)

	INSERT INTO #EGRESOS_PAIS(
		Pais_Codigo,
		Egresos
	)
		SELECT CO.Cuenta_Pais, COUNT(T.Id_Transferencia)
			FROM LA_MAQUINA_DE_HUMO.Transferencia T,
						LA_MAQUINA_DE_HUMO.Cuenta CO,
						LA_MAQUINA_DE_HUMO.Cuenta CD
					WHERE T.Tranf_Cuenta_Origen_Numero = CO.Cuenta_Numero
						AND T.Tranf_Cuenta_Dest_Numero = CD.Cuenta_Numero
						AND CO.Cuenta_Pais != CD.Cuenta_Pais
						AND T.Tranf_Fecha >= LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre)
						AND T.Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFechaFinTrimestre(@anio, @trimestre)
					GROUP BY CO.Cuenta_Pais

	CREATE TABLE #INGRESOS_PAIS(
		Pais_Codigo numeric(18,0) PRIMARY KEY,
		Ingresos int	
	)

	INSERT INTO #INGRESOS_PAIS(
		Pais_Codigo,
		Ingresos
	)
		SELECT CD.Cuenta_Pais, COUNT(T.Id_Transferencia)
			FROM LA_MAQUINA_DE_HUMO.Transferencia T,
						LA_MAQUINA_DE_HUMO.Cuenta CO,
						LA_MAQUINA_DE_HUMO.Cuenta CD
					WHERE T.Tranf_Cuenta_Origen_Numero = CO.Cuenta_Numero
						AND T.Tranf_Cuenta_Dest_Numero = CD.Cuenta_Numero
						AND CO.Cuenta_Pais != CD.Cuenta_Pais
						AND T.Tranf_Fecha >= LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre)
						AND T.Tranf_Fecha <= LA_MAQUINA_DE_HUMO.obtenerFechaFinTrimestre(@anio, @trimestre)
					GROUP BY CD.Cuenta_Pais


	SELECT Pais_Desc, Ingresos, Egresos
		FROM #INGRESOS_PAIS E, #EGRESOS_PAIS I, LA_MAQUINA_DE_HUMO.Pais P
		WHERE E.Pais_Codigo = I.Pais_Codigo
			AND E.Pais_Codigo = P.Pais_Codigo
		ORDER BY Ingresos + Egresos DESC
GO


/****************************************************************
 *					TotalFacturadoTiposCuenta
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].TotalFacturadoTiposCuenta
	@anio int,
	@trimestre int
AS
	SELECT Descripcion,
			(SELECT ISNULL(SUM(Importe), 0)
				FROM LA_MAQUINA_DE_HUMO.Transaccion TR
				WHERE TR.Id_Tipo_Cuenta = TC.Id_Tipo_Cuenta
					AND Fecha_Transaccion >= LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre)
					AND Fecha_Transaccion <= LA_MAQUINA_DE_HUMO.obtenerFechaFinTrimestre(@anio, @trimestre)
					AND Factura_Numero IS NOT NULL) AS Total_Facturado
		FROM LA_MAQUINA_DE_HUMO.Tipo_Cuenta TC
GO


/****************************************************************
 *					InhabilitacionesDeClientes
 ****************************************************************/
CREATE PROCEDURE [LA_MAQUINA_DE_HUMO].InhabilitacionesDeClientes
	@anio int,
	@trimestre int
AS
	SELECT TOP 5 CLI.Id_Cliente, Cli_Nombre, Cli_Apellido, COUNT(Id_Inhabilitacion) AS Inhabilitaciones
		FROM LA_MAQUINA_DE_HUMO.Clientes CLI, LA_MAQUINA_DE_HUMO.Inhabilitaciones I, LA_MAQUINA_DE_HUMO.Cuenta CU
		WHERE I.Cuenta_Numero = CU.Cuenta_Numero
			AND CU.Id_Cliente = CLI.Id_Cliente
			AND Fecha_Inhabilitacion >= LA_MAQUINA_DE_HUMO.obtenerFechaInicioTrimestre(@anio, @trimestre)
			AND Fecha_Inhabilitacion <= LA_MAQUINA_DE_HUMO.obtenerFechaFinTrimestre(@anio, @trimestre)
		GROUP BY CLI.Id_Cliente, Cli_Nombre, Cli_Apellido
		ORDER BY COUNT(Id_Inhabilitacion)
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

-- Cargo la fecha en la que inicia el sistema
DECLARE @fecha datetime
SET @fecha = CAST('20170101' AS datetime)
EXEC LA_MAQUINA_DE_HUMO.SetFecha @fecha
GO


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

GO


/****************************************************************/
--						DOCUMENTO
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Documento](
	[Doc_Codigo][numeric](18,0) IDENTITY(1,1) PRIMARY KEY,
	[Doc_Desc][varchar](255) NOT NULL
)

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Documento ON
INSERT INTO [LA_MAQUINA_DE_HUMO].[Documento](
	[Doc_Codigo],
	[Doc_Desc]
)
SELECT DISTINCT Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc
		FROM gd_esquema.Maestra
SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Documento OFF

		
INSERT INTO [LA_MAQUINA_DE_HUMO].[Documento]([Doc_Desc]) VALUES ('DNI')
INSERT INTO [LA_MAQUINA_DE_HUMO].[Documento]([Doc_Desc]) VALUES ('Cedula')

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
	[Respuesta_Secreta][varchar](255)
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
	[Respuesta_Secreta]
) VALUES (
	0, 'admin1',
	'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', --SHA256 de "w23e"
	's', GETDATE(), GETDATE(), 'Pregunta secreta de admin',
	'37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f' --SHA256 de "default"
)

INSERT INTO [LA_MAQUINA_DE_HUMO].Usuario(
	[Cantidad_Intentos_Fallidos],
	[Username],
	[Password],
	[Habilitado],
	[Fecha_Creacion],
	[Fecha_Ultima_Modificacion],
	[Pregunta_Secreta],
	[Respuesta_Secreta]
) VALUES (
	0, 'admin2',
	'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', --SHA256 de "w23e"
	's', GETDATE(), GETDATE(), 'Pregunta secreta de admin',
	'37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f' --SHA256 de "default"
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
	[Respuesta_Secreta]
)
	SELECT DISTINCT
		0,
		'usuario' + RIGHT(CONVERT(varchar(18),Cli_Nro_Doc),18),
		'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', --SHA256 de "password"
		's',
		GETDATE(),
		GETDATE(),
		'Pregunta secreta default',
		'37a8eec1ce19687d132fe29051dca629d164e2c4958ba141d5f4133a33f0688f' --SHA256 de "default"
		FROM gd_esquema.Maestra
GO


/****************************************************************
						USUARIO_ROL
*****************************************************************/
CREATE TABLE LA_MAQUINA_DE_HUMO.Usuario_Rol(
	[Id_Usuario][int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Usuario(Id_Usuario)  NOT NULL,
	[Id_Rol][int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].Rol(Id_Rol) NOT NULL
	
	CONSTRAINT [PK_Usuario_Rol] PRIMARY KEY CLUSTERED 
	(
		[Id_Usuario],
		[Id_Rol]
	)
)
	INSERT INTO LA_MAQUINA_DE_HUMO.Usuario_Rol(
		Id_Usuario,
		Id_Rol
	)
		SELECT Id_Usuario, CASE WHEN Id_Usuario <= 2 THEN 1 ELSE 2 END
			FROM LA_MAQUINA_DE_HUMO.Usuario
			

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


/****************************************************************
						TIPO_CUENTA
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta](
	[Id_Tipo_Cuenta][int] PRIMARY KEY,
	[Duracion][int],
	[Costo_Alta][numeric] (18,2),
	[Costo_Modificacion][numeric] (18,2),
	[Costo_Tranferencia][numeric] (18,2),
	[Descripcion][varchar](255)
)

INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (1, 30, 0, 0, 20, 'GRATUITA')
INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (2, 30, 10, 5,15, 'BRONCE')
INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (3, 30, 20, 10, 10, 'PLATA')
INSERT INTO [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta] values (4, 30, 30, 20, 5, 'ORO')


/****************************************************************
						MONEDA
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Moneda](
	[Id_Moneda][int] PRIMARY KEY IDENTITY (1,1),
	[Descripcion][varchar](255)
)
INSERT INTO [LA_MAQUINA_DE_HUMO].[Moneda] values ('DOLAR')


/****************************************************************
						ESTADO_CUENTA
****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[ESTADO_CUENTA](
	[Estado_Cuenta_ID] [int] PRIMARY KEY,
	[Estado_Cuenta_Descripcion] [varchar] (255))

INSERT INTO LA_MAQUINA_DE_HUMO.ESTADO_CUENTA(Estado_Cuenta_ID, Estado_Cuenta_Descripcion)
	VALUES (1, 'Pendiente de activacion')
INSERT INTO LA_MAQUINA_DE_HUMO.ESTADO_CUENTA(Estado_Cuenta_ID, Estado_Cuenta_Descripcion)
	VALUES (2, 'Habilitada')
INSERT INTO LA_MAQUINA_DE_HUMO.ESTADO_CUENTA(Estado_Cuenta_ID, Estado_Cuenta_Descripcion)
	VALUES (3, 'Inhabilitada')
INSERT INTO LA_MAQUINA_DE_HUMO.ESTADO_CUENTA(Estado_Cuenta_ID, Estado_Cuenta_Descripcion)
	VALUES (4, 'Cerrada')
/****************************************************************
						CUENTA
*****************************************************************/

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Cuenta](
	[Cuenta_Numero][numeric] (18,0) PRIMARY KEY IDENTITY(1,1),
	[Cuenta_Pais][numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Pais(Pais_Codigo),
	[Id_Moneda][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Moneda(Id_Moneda),
	[Fecha_Creacion][datetime],
	[Id_Cliente][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Clientes(Id_Cliente),
	[Id_Tipo_Cuenta][int]FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Tipo_Cuenta(Id_Tipo_Cuenta),
	[Fecha_Cierre][datetime],
	[Estado_ID] [int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Estado_Cuenta(Estado_Cuenta_ID),
)
GO

-- Apago el identity mientras cargo las cuentas de los clientes
SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Cuenta ON

-- Cargo cuentas existentes
INSERT INTO LA_MAQUINA_DE_HUMO.Cuenta(
	[Cuenta_Numero],
	[Cuenta_Pais],
	[Id_Moneda],
	[Fecha_Creacion],
	[Id_Cliente],
	[Id_Tipo_Cuenta],
	[Fecha_Cierre],
	[Estado_ID]
)
SELECT DISTINCT
	M.Cuenta_Numero,
	M.Cuenta_Pais_Codigo,
	1,
	M.Cuenta_Fecha_Creacion, 
	(select Id_Cliente
		from LA_MAQUINA_DE_HUMO.Clientes as C 
		where M.Cli_Nro_Doc = C.Cli_Nro_Doc),
	1,
	null,
	2			
 From gd_esquema.Maestra as M

-- Prendo el identity para la creacion de nuevas cuentas
SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Cuenta OFF
GO


/****************************************************************
						TARJETA
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Tarjeta](
	[Id_Tarjeta][int] PRIMARY KEY IDENTITY (1,1),
	[Id_Cliente][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Clientes(Id_Cliente),
	[Tarjeta_Numero] [varchar](16) UNIQUE,
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


/****************************************************************
						DEPOSITO
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Deposito](
	[Deposito_Codigo][numeric] (18,0) PRIMARY KEY IDENTITY (1,1),
	[Numero_Cuenta][numeric](18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero),
	[Deposito_importe] [numeric](18,2),
	[Id_Moneda] [int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Moneda(Id_Moneda),
	[Id_Tarjeta][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Tarjeta(Id_Tarjeta),
	[Deposito_Fecha] [datetime]
)

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Deposito ON
INSERT INTO [LA_MAQUINA_DE_HUMO].[Deposito](
	[Deposito_Codigo],
	[Numero_Cuenta],
	[Deposito_importe],
	[Id_Moneda],
	[Id_Tarjeta],
	[Deposito_Fecha]
	)
	SELECT Deposito_Codigo,Cuenta_Numero,Deposito_Importe,1,
			(SELECT Id_Tarjeta FROM LA_MAQUINA_DE_HUMO.Tarjeta T WHERE M.Tarjeta_Numero = T.Tarjeta_Numero and M.Tarjeta_Emisor_Descripcion = T.Tarjeta_Emisor_Descripcion),
			Deposito_Fecha
		FROM gd_esquema.Maestra M
		WHERE Deposito_Codigo IS NOT NULL
		
SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Deposito OFF

GO


/****************************************************************
						RETIRO
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Retiro](
	[Retiro_Codigo][numeric] (18,0) PRIMARY KEY IDENTITY(1,1),
	[Numero_Cuenta][numeric](18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero),
	[Retiro_Fecha] [datetime],
	[Retiro_Importe] [numeric](18,2),
	[Id_Moneda][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Moneda(Id_Moneda)
)

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Retiro ON

INSERT INTO LA_MAQUINA_DE_HUMO.Retiro(
	[Retiro_Codigo],
	[Numero_Cuenta],
	[Retiro_Fecha],
	[Retiro_Importe],
	[Id_Moneda]
)
Select distinct Retiro_Codigo, Cuenta_Numero,Retiro_Fecha,Retiro_Importe,1 from gd_esquema.maestra where Retiro_Codigo IS NOT NULL

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Retiro OFF



/****************************************************************
						BANCO
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Banco](
	[Banco_Codigo] [numeric] (18,0) PRIMARY KEY IDENTITY(1,1),
	[Banco_Nomber] [varchar](255),
	[Banco_Direccion] [varchar](255)
)

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Banco ON

INSERT INTO LA_MAQUINA_DE_HUMO.Banco(
	[Banco_Codigo],
	[Banco_Nomber],
	[Banco_Direccion]
)
Select distinct Banco_Cogido, Banco_Nombre, Banco_Direccion From gd_esquema.Maestra WHERE Banco_Cogido is not null

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Banco OFF


/****************************************************************
						CHEQUE
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Cheque](
	[Cheque_Numero] [numeric] (18,0) PRIMARY KEY IDENTITY(1,1),
	[Retiro_Codigo] [numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Retiro(Retiro_Codigo),
	[Banco_Codigo]  [numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Banco(Banco_Codigo),
)

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Cheque ON

INSERT INTO LA_MAQUINA_DE_HUMO.Cheque(
	[Cheque_Numero],
	[Retiro_Codigo],
	[Banco_Codigo]  
)
Select distinct Cheque_Numero, Retiro_Codigo, Banco_Cogido From gd_esquema.Maestra WHERE Cheque_Numero is not null

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Cheque OFF


/****************************************************************
						TRANSFERENCIA
*****************************************************************/
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
		Trans_Importe,
		Transf_Fecha,
		Cuenta_Dest_Estado
	FROM gd_esquema.Maestra
	WHERE Cuenta_Dest_Numero IS NOT NULL
		AND Cuenta_Numero IS NOT NULL
		AND Factura_Numero IS NOT NULL
		

/****************************************************************
						ALTA CUENTA
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Alta_Cuenta](
	[Id_Alta_Cuenta] [int] PRIMARY KEY IDENTITY (1,1),
	[Alta_Cuenta_Fecha_Inicio] [datetime],
	[Alta_Cuenta_Fecha_Fin] [datetime],
	[Cuenta_Numero][numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero)
)


/****************************************************************
						MODIFICACION CUENTA
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Modificacion_Cuenta](
	[Id_Modificacion_Cuenta] [int] PRIMARY KEY IDENTITY (1,1),
	[Modificacion_Cuenta_Fecha] [datetime],
	[Cuenta_Numero][numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero)
)


/****************************************************************
						ITEM
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Item](
	[Id_Item] [int] PRIMARY KEY IDENTITY (1,1),
	[Item_Descripcion] [varchar](255)
)

INSERT INTO LA_MAQUINA_DE_HUMO.Item values ('Comisión por transferencia.')
INSERT INTO LA_MAQUINA_DE_HUMO.Item values ('Comisión por alta de cuenta.')
INSERT INTO LA_MAQUINA_DE_HUMO.Item values ('Comisión por modificacion de cuenta.')



/****************************************************************
						FACTURA
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Factura] (
	[Factura_Numero] [numeric](18,0) PRIMARY KEY IDENTITY(1,1),
	[Factura_Fecha] [datetime]
)

SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Factura ON
INSERT INTO  [LA_MAQUINA_DE_HUMO].[Factura] (
	[Factura_Numero],
	[Factura_Fecha]
)
SELECT DISTINCT Factura_Numero, Factura_Fecha
	FROM gd_esquema.Maestra m
	WHERE Factura_Numero IS NOT NULL
SET IDENTITY_INSERT LA_MAQUINA_DE_HUMO.Factura OFF


/****************************************************************
						Transaccion
*****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Transaccion] (
	[Id_Transaccion] [int] PRIMARY KEY IDENTITY (1,1),
	[Factura_Numero] [numeric](18,0),
	[Id_Item] [int] FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].[Item](Id_Item),
	[Id_Cliente] [int]  FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].[Clientes](Id_Cliente),
	[Id_Tipo_Cuenta] [int]  FOREIGN KEY REFERENCES [LA_MAQUINA_DE_HUMO].[Tipo_Cuenta](Id_Tipo_Cuenta),
	[Importe] [numeric](18,2),
	[Fecha_Transaccion] [datetime],
	[Id_Evento] [int]
)

INSERT INTO  [LA_MAQUINA_DE_HUMO].[Transaccion] (
	[Factura_Numero],
	[Id_Item],
	[Id_Cliente],
	[Id_Tipo_Cuenta],
	[Importe],
	[Fecha_Transaccion],
	[Id_Evento]
)
SELECT DISTINCT
	Factura_Numero,
	1,
	(Select Id_Cliente
		FROM LA_MAQUINA_DE_HUMO.Clientes as C
		WHERE C.Cli_Nro_Doc = M.Cli_Nro_Doc),
	1,
	Item_Factura_Importe,
	Transf_Fecha,
	1
	FROM gd_esquema.Maestra as M
	WHERE Factura_Numero IS NOT NULL

/****************************************************************
						Inhabilitaciones
*****************************************************************/
CREATE TABLE LA_MAQUINA_DE_HUMO.Inhabilitaciones(
	Id_Inhabilitacion int IDENTITY(1,1) PRIMARY KEY,
	Fecha_Inhabilitacion datetime,
	Cuenta_Numero numeric(18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Cuenta(Cuenta_Numero)
)