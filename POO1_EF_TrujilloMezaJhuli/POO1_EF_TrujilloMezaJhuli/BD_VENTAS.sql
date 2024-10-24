CREATE DATABASE BD_VENTAS
GO

USE BD_VENTAS
GO

--*************** creacion de tabla ***********************
CREATE TABLE TRANSPORTES
	(
	id         INT  NOT NULL,
	ruc        CHAR (11) NOT NULL,
	proveedor  VARCHAR (50) NOT NULL,
	direccion  VARCHAR (150) NOT NULL,
	direccion2 VARCHAR (150) NULL,
	telefono   vARCHAR (12) NULL,
	correo     VARCHAR (80) NOT NULL,
	contacto   VARCHAR (80) NOT NULL,
	CONSTRAINT PK_TRANSPORTES PRIMARY KEY (id)
	)
GO
--**************** Inserciones ********************
INSERT INTO TRANSPORTES (id, ruc, proveedor, direccion, direccion2, telefono, correo, contacto)
VALUES 
	(1, '20345678901', 'Transportes Lima S.A.', 'Av. La Marina 1234', 'Oficina 305', '0123456789', 'contacto@tlima.com', 'Juan Pérez'),
	(2, '20567891234', 'Logística Global EIRL', 'Calle Los Olivos 567', 'Dpto 203', '0198765432', 'info@logglobal.com', 'María García'),
	(3, '20456789123', 'Transportes Andes SAC', 'Jr. Amazonas 879', 'Oficina 406', '0145671234', 'ventas@andestrans.com', 'Carlos Mendoza'),
	(4, '20678912345', 'Servicios de Carga del Sur', 'Av. Arequipa 654', '', '0134567890', 'info@scsur.com', 'Ana Ruiz'),
	(5, '20789123456', 'Transporte Expreso S.A.', 'Av. Javier Prado 123', 'Torre A', '0192345678', 'contacto@expresotrans.com', 'Luis Fernández'),
	(6, '20123456789', 'Distribuciones Norte SAC', 'Jr. Los Pinos 456', '', '0167890123', 'logistica@nortesac.com', 'Pedro López'),
	(7, '20891234567', 'Fletes Rápidos EIRL', 'Av. Angamos 987', 'Oficina 201', '0123459876', 'servicio@fletesrapidos.com', 'Rosa Martínez'),
	(8, '20912345678', 'Transporte Nacional SAC', 'Calle Comercio 345', '', '0154321098', 'atencion@transnacional.com', 'Jorge Salazar'),
	(9, '20234567890', 'Transportes Económicos', 'Av. Universitaria 543', 'Dpto 102', '0178901234', 'economicos@transporte.com', 'Elena Torres'),
	(10, '20356789012', 'Cargas Rápidas SAC', 'Jr. Las Flores 234', '', '0123098765', 'soporte@cargasrapidas.com', 'Roberto Chávez'),
	(11, '12345678901', 'Transporte Lima', 'Av. Principal 123', 'Av. Secundaria 456', '1234567890', 'contacto@transportelima.com', 'Juan Perez'),
	(12,'10987654321', 'Transportes Perú', 'Calle Falsa 123', 'Calle Real 456', '0987654321', 'info@transportesperu.com', 'Maria Ramirez'),
	(13,'10293847560', 'Transporte Rápido', 'Jr. Velocidad 789', 'Jr. Acelere 012', '1029384756', 'soporte@transporterapido.com', 'Carlos Lopez'),
	(14,'11223344556', 'Logística Total', 'Av. Logistica 345', 'Av. Total 678', '1122334455', 'ventas@logisticatotal.com', 'Ana Fernandez'),
	(15,'12131415161', 'Transporte Seguro', 'Jr. Seguro 111', 'Jr. Confiable 222', '1213141516', 'seguridad@transporteseguro.com', 'Pedro Sanchez')
go

SELECT * FROM TRANSPORTES
go

--***************** Procedimientos de Transporte ************************
CREATE OR ALTER PROCEDURE usp_Transporte_crud
@indicador varchar(40),
@id_transporte         INT,
@ruc        VARCHAR (11),
@proveedor  NVARCHAR (50),
@direccion  NVARCHAR (150),
@direccion2 NVARCHAR (150),
@telefono   VARCHAR (12),
@correo     NVARCHAR (80),
@contacto   NVARCHAR (80)
as
begin
	If @indicador ='Insertar'
	Begin
		INSERT INTO dbo.TRANSPORTES (id, ruc, proveedor, direccion, direccion2, telefono, correo, contacto)
		VALUES (@id_transporte,@ruc, @proveedor, @direccion, @direccion2, @telefono, @correo, @contacto)
	End

	If @indicador ='Eliminar'
	Begin
		Delete from TRANSPORTES where id = @id_transporte
	End

 	If @indicador ='Actualizar'
	Begin
		UPDATE dbo.TRANSPORTES
			SET id = @id_transporte,
				ruc = @ruc,
				proveedor = @proveedor,
				direccion = @direccion,
				direccion2 = @direccion2,
				telefono = @telefono,
				correo = @correo,
				contacto = @contacto
		WHERE 
			id = @id_transporte
	End

	If @indicador ='ConsultarXId'
	Begin
		SELECT id, ruc, proveedor, direccion, direccion2, telefono, correo, contacto
		FROM TRANSPORTES

		WHERE 
			id = @id_transporte
	End

	If @indicador ='ConsultarTodo'
	Begin
		SELECT id, ruc, proveedor, direccion, direccion2, telefono, correo, contacto  from TRANSPORTES
	End
	
END
GO
