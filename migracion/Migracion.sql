
/****************************************************************/
--						CREAR ESQUEMA
/****************************************************************/

CREATE SCHEMA [LA_MAQUINA_DE_HUMO] AUTHORIZATION [gd]
GO


USE GD1C2015
/****************************************************************/
--							ROL
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Rol](
	[Id_Rol][int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Rol_Nombre] [varchar](255) NOT NULL,
	[Habilitado][char](1) NOT NULL
)

INSERT INTO [LA_MAQUINA_DE_HUMO].Rol Values('Administrador','s')
INSERT INTO [LA_MAQUINA_DE_HUMO].Rol Values('Ciente','s')
GO


/****************************************************************/
--						FUNCIONALIDADES
/****************************************************************/
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Funcionalidad](
	[Id_Funcionalidad][int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Func_Nombre] [varchar](255) NOT NULL
)

INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('ABM de Rol')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('Login y seguridad')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('ABM de Usuario')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('ABM de Cliente')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('ABM de Cuenta')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('Depósitos')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('Retiro de Efectivo')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('Tranferencias entre cuentas')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('Facturación de Costos')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('Consulta de saldos')
INSERT INTO [LA_MAQUINA_DE_HUMO].Funcionalidad Values('Listado Estadístico')
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

INSERT INTO [LA_MAQUINA_DE_HUMO].Rol_Funcionalidad(Id_Rol , Id_Funcionalidad) 
	SELECT 2,Id_Funcionalidad
	FROM [LA_MAQUINA_DE_HUMO].Funcionalidad
	WHERE Id_Funcionalidad IN (1,2,3,4,5,6,7) -- Cargar con las correspondientes funcionalidades

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
	[Username][varchar](255) NOT NULL,
	[Password][varchar](255),
	[Habilitado][char](1) NOT NULL,
	[Fecha_Creacion][datetime] NOT NULL,
	[Fecha_Ultima_Modificacion][datetime] NOT NULL,
	[Pregunta_Secreta][varchar](255),
	[Respuesta_Secreta][varchar](255)
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
)
	SELECT DISTINCT
		0,
		'usuario' + RIGHT(CONVERT(varchar(18),Cli_Nro_Doc),18),
		'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', --SHA256 de "password"
		's',
		GETDATE(),
		GETDATE(),
		null,
		null
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
	[Nro_Intento][int] NOT NULL
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
[Estado][varchar](15),
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
	[Retiro_Importa] [numeric](18,2),
	[Id_Moneda][int]
)

INSERT INTO LA_MAQUINA_DE_HUMO.Retiro(
	[Retiro_Codigo],
	[Numero_Cuenta],
	[Retiro_Fecha],
	[Retiro_Importe],
	[Id_Moneda],
)
Select distinct Retiro_Codigo, Numero_Cuenta,Retiro_Fecha,Retiro_Importe,1 from gd_esquema.maestra
