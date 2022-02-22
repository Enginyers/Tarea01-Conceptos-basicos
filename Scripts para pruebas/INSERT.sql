/* Insercion de datos pacientes*/
USE [SISTEMA_SALUD]
GO


INSERT INTO [dbo].[PACIENTES]
           ([CEDULA]
           ,[NOMBRE_PACIENTE]
           ,[SEXO]
           ,[FECHA_NACIMIENTO])
     VALUES
		   ('144174521','CARLOS ROMERO','M','1995-02-06'),
		   ('110706512','PAULA MEJIA','F','1983-18-09'),
           ('31225632','MANUEL DIAZ','M','1995-02-06'),
		   ('41220632','JUANA MARIN','F','1983-18-09'),
		   ('91220642','PEDRO MONTOYA','M','1983-18-09'),
		   ('16520632','JESUS HERNAN MARIN','M','1983-18-09'),
		   ('31489632','DIANA NARVAEZ','F','1983-18-09'),
		   ('36224596','FELIPE ARAUJO','M','1983-18-09'),
		   ('16961254','ANA GUERRA','F','1983-18-09'),
		   ('32226954','JOSE ARMANDO RESTREPO','M','1983-18-09')
GO


/* Insercion de datos especialidad*/
USE [SISTEMA_SALUD]
GO

INSERT INTO [dbo].[ESPECIALIDAD]
           ([CODIGO_ESPECIALIDAD]
           ,[DESCRIPCION])
     VALUES
           ('031','MEDICINA GENERAL'),
		   ('032','ODONTOLOGIA'),
		   ('033','OPTOMETRIA')
GO


/* Insercion de datos Medicos*/
USE [SISTEMA_SALUD]
GO

INSERT INTO [dbo].[MEDICO]
           ([CODIGO_MEDICO]
           ,[NOMBRE_MEDICO]
           ,[CODIGO_ESPECIALIDAD])
     VALUES
           ('161898','JUAN MANUEL PEREZ','031'),
		   ('264823','ANGELA SUAREZ','032'),
		   ('345609','OSCAR RODRIGUEZ','031'),
		   ('456780','ADRIANA GUTIERREZ','033'),
		   ('213452','CARMEN ARIAS','031'),
		   ('436784','CESAR FERNANDEZ','031'),
		   ('843923','JHOANA RUIZ','033')
GO


/* Insercion de datos citas medicas*/

USE [SISTEMA_SALUD]
GO

INSERT INTO [dbo].[CITAS_MEDICAS]
           ([CEDULA]
           ,[CODIGO_MEDICO]
           ,[FECHA_CITA])
     VALUES
           ('144174521','161898','2021-21-09'),
		   ('16520632','264823','2021-25-09'),
		   ('16961254','436784','2021-25-09'),
		   ('36224596','843923','2021-25-09'),
		   ('32226954','843923','2021-28-09')
GO