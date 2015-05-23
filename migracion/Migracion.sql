
/****************************************************************/
--						CREAR ESQUEMA
/****************************************************************/

CREATE SCHEMA [LA_MAQUINA_DE_HUMO] AUTHORIZATION [gd]
GO

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Rol](
[Id_Rol][int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[Rol_Nombre] [varchar](255),
[Habilitado][char](1)
)
INSERT INTO LA_MAQUINA_DE_HUMO.Rol Values('Administrador','s')
INSERT INTO LA_MAQUINA_DE_HUMO.Rol Values('Ciente','s')
GO

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Funcionalidad](
[Id_Funcionalidad][int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
[Func_Nombre] [varchar](255),
)
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('ABM de Rol')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('Login y seguridad')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('ABM de Usuario')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('ABM de Cliente')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('ABM de Cuenta')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('Depósitos')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('Retiro de Efectivo')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('Tranferencias entre cuentas')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('Facturación de Costos')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('Consulta de saldos')
INSERT INTO LA_MAQUINA_DE_HUMO.Funcionalidad Values('Listado Estadístico')
GO

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Rol_Funcionalidad](
[Id_Rol][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Rol(Id_Rol) NOT NULL,
[Id_Funcionalidad][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Funcionalidad(Id_Funcionalidad)  NOT NULL,
CONSTRAINT [PK_Rol_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[Id_Rol],
	[Id_Funcionalidad] 
)
)
INSERT INTO LA_MAQUINA_DE_HUMO.Rol_Funcionalidad(Id_Rol , Id_Funcionalidad) 
select 1,Id_Funcionalidad from LA_MAQUINA_DE_HUMO.Funcionalidad

INSERT INTO LA_MAQUINA_DE_HUMO.Rol_Funcionalidad(Id_Rol , Id_Funcionalidad) 
select 2,Id_Funcionalidad from LA_MAQUINA_DE_HUMO.Funcionalidad WHERE Id_Funcionalidad IN (1,2,3,4,5,6,7) /** Cargar con las correspondientes funcionalidades **/


GO
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Pais](
	[Pais_Codigo][numeric](18,0) PRIMARY KEY,
	[Pais_Desc][varchar](250)
)
GO


insert into [LA_MAQUINA_DE_HUMO].[Pais] (
	[Pais_Codigo],
	[Pais_Desc]
)
	select distinct Cli_Pais_Codigo, Cli_Pais_Desc
		from gd_esquema.Maestra
GO
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Documento](
	[Doc_Codigo][numeric](18,0) PRIMARY KEY,
	[Doc_Desc][varchar](255)
)
insert into [LA_MAQUINA_DE_HUMO].[Documento](
[Doc_Codigo],
[Doc_Desc]
)
select distinct Cli_Tipo_Doc_Cod, Cli_Tipo_Doc_Desc
		from gd_esquema.Maestra
GO



CREATE TABLE [LA_MAQUINA_DE_HUMO].[Usuario](
[Id_Usuario][int] IDENTITY (1,1) PRIMARY KEY,
[Cantidad_Intentos_Fallidos][int],
[Username][varchar](255),
[Password][varchar](255),
[Habilitado][char](1),
[Fecha_Creacion][datetime],
[Fecha_Ultima_Modificacion][datetime],
[Pregunta_Secreta][varchar](255),
[Respuesta_Secreta][varchar](255)
)
INSERT INTO LA_MAQUINA_DE_HUMO.Usuario(
[Cantidad_Intentos_Fallidos],
[Username],
[Password],
[Habilitado],
[Fecha_Creacion],
[Fecha_Ultima_Modificacion],
[Pregunta_Secreta],
[Respuesta_Secreta]
)
Select distinct 0,'usuario' + RIGHT(CONVERT(varchar(18),Cli_Nro_Doc),18),'6b3a55e0261b0304143f805a24924d0c1c44524821305f31d9277843b8a10f4e',
's',GETDATE(),GETDATE(),null,null from gd_esquema.Maestra

GO
CREATE TABLE [LA_MAQUINA_DE_HUMO].[Clientes](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Cli_Nombre] [varchar](255),
	[Cli_Apellido] [varchar](255),
	[Cli_Nro_Doc] [numeric](18,0),
	[Cli_Tipo_Doc_Cod] [numeric] (18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Documento(Doc_Codigo),
	[Cli_Mail] [varchar](255),
	[Cli_Pais_Codigo] [numeric] (18,0),
	[Cli_Dom_Nro][numeric](18,0),
	[Cli_Dom_Calle] [varchar](255),
	[Cli_Dom_Piso] [numeric](18,0),
	[Cli_Dom_Depto] [varchar](10),
	[Cli_Dom_Localidad][varchar](255),
	[Cli_Nacionalidad_Codigo][numeric](18,0) FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Pais(Pais_Codigo), /** Es el mismo para [Cli_Pais_Codigo] **/
	[Cli_Fecha_Nac][datetime],
	[Cli_Habilitado][char](1),
	[Id_Usuario][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Usuario(Id_usuario) /** FK a Usuario **/
 )
GO


Insert into LA_MAQUINA_DE_HUMO.Clientes(
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
	select DISTINCT  
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
	(Select Id_usuario from LA_MAQUINA_DE_HUMO.Usuario where username = 'usuario' + RIGHT(CONVERT(varchar(18),Cli_Nro_Doc),18))
	 from gd_esquema.Maestra
GO

CREATE TABLE [LA_MAQUINA_DE_HUMO].[Auditoria](
[Id_Auditoria][int] IDENTITY (1,1) PRIMARY KEY,
[Id_Usuario][int] FOREIGN KEY REFERENCES LA_MAQUINA_DE_HUMO.Usuario(Id_Usuario),
[Fecha][datetime],
[Resultado][varchar](255),
[Nro_Intento][int]
)