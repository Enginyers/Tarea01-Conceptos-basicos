CREATE DATABASE BD_FRUTERIA

go

use BD_FRUTERIA
go

/* TABLA PACIENTES */

Create table CLIENTES(
CEDULA VARCHAR(20) primary key,
NOMBRE_CLIENTE VARCHAR(50) not null,
DIRECCION VARCHAR(50),
EMAIL VARCHAR(50),
TELEFONO VARCHAR(50)
);

/* TABLA ESPECIALIDAD */
Create table FACTURA(
NUM_FACTURA VARCHAR(20) primary key,
ID_CLIENTE VARCHAR(20) not null,
FECHA_FACTURA DATETIME,
IVA INT,
TOTAL INT,
FORMA_PAGO VARCHAR(20)
CONSTRAINT fk_Cliente FOREIGN KEY (ID_CLIENTE) REFERENCES CLIENTES (CEDULA)
);

Create table PRODUCTO(
NUM_PRODUCTO VARCHAR(20) primary key,
NOMBRE_PRODUCTO VARCHAR(50) not null,
PRECIO_UNIT INT,
STOCK INT
);

Create table VENDEDOR(
COD_VENDEDOR VARCHAR(20) primary key,
NOMBRE VARCHAR(50) not null,
TURNO VARCHAR(50),
CAJA VARCHAR(50)
);

/* TABLA MEDICO */
Create table DETALLE(
ID_DETALLE VARCHAR(20) primary key,
NUM_FACTURA varchar(20) not null,
NUM_PRODUCTO VARCHAR(20),
COD_VENDEDOR VARCHAR(20),
CANT INT,
SUBTOTAL INT
CONSTRAINT fk_Factura FOREIGN KEY (NUM_FACTURA) REFERENCES FACTURA (NUM_FACTURA),
CONSTRAINT fk_Producto FOREIGN KEY (NUM_PRODUCTO) REFERENCES PRODUCTO (NUM_PRODUCTO),
CONSTRAINT fk_Vendedor FOREIGN KEY (COD_VENDEDOR) REFERENCES VENDEDOR (COD_VENDEDOR),
);




/* TABLA CITAS_MEDICAS */
Create table CITAS_MEDICAS(
CEDULA VARCHAR(20) primary key,
CODIGO_MEDICO varchar(20) not null,
FECHA_CITA DATETIME,
CONSTRAINT fk_Pacientes FOREIGN KEY (CEDULA) REFERENCES PACIENTES (CEDULA),
CONSTRAINT fk_Medico FOREIGN KEY (CODIGO_MEDICO) REFERENCES MEDICO (CODIGO_MEDICO)
);


Create table CONSULTORIOS(
NUMERO_CONSULTORIO VARCHAR(20) primary key,
CODIGO_MEDICO VARCHAR(20) not null,
HORA_INICIO TIME,
HORA_FIN TIME
CONSTRAINT fk_Consultorios FOREIGN KEY (CODIGO_MEDICO) REFERENCES MEDICO (CODIGO_MEDICO),
);

Create table MEDICO_ESPECIALIDADES(
CODIGO VARCHAR(20) primary key,
CODIGO_MEDICO VARCHAR(20) not null,
CODIGO_ESPECIALIDAD VARCHAR(20) not null,

CONSTRAINT fk_MedicoEsp FOREIGN KEY (CODIGO_MEDICO) REFERENCES MEDICO (CODIGO_MEDICO),
CONSTRAINT fk_Especialidades FOREIGN KEY (CODIGO_ESPECIALIDAD) REFERENCES ESPECIALIDAD (CODIGO_ESPECIALIDAD)
);

Create table BENEFICIARIOS(
CEDULA_BENEF VARCHAR(20) primary key,
CEDULA_COTIZ VARCHAR(20),
FECHA_REGISTRO DATETIME

CONSTRAINT fk_BENEFICIARIO FOREIGN KEY (CEDULA_COTIZ) REFERENCES PACIENTES (CEDULA)
);

ALTER TABLE PACIENTES ADD ESTADO_ATENCION VARCHAR(20)

Create table MEDICINA(
NUM_ORDEN VARCHAR(20) primary key,
CEDULA_PACIENTE  VARCHAR(20),
CANTIDAD INT not null,
DOSIS VARCHAR(100),
OBSERVACION VARCHAR(250),
CONSTRAINT fk_Medicina FOREIGN KEY (CEDULA_PACIENTE) REFERENCES PACIENTES (CEDULA)
);