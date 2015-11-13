create table cliente(
id_cliente int primary key identity,
nombre varchar(50),
apellido varchar(50),
direccion varchar(50),
fecha_nacimiento date,
telefono int,
email varchar(50)
)

insert into cliente(nombre, apellido, direccion) values ('Martin','Zenteno','Rivadavia 1052');
insert into cliente(nombre, apellido, direccion) values ('Jesus','Delgado','Monteagudo 800');
insert into cliente(nombre, apellido, direccion) values ('Santiago','Perez','Av Roca 346');
insert into cliente(nombre, apellido, direccion) values ('Silvana','Reinoso','Buenos Aires 201');




CREATE TABLE factura (
	numero INT NOT NULL PRIMARY KEY IDENTITY,
	fecha DATE NOT NULL,
	id_cliente INT NOT NULL,
	CONSTRAINT fk_factura_cliente
		FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente)
);

INSERT INTO factura (fecha, id_cliente) VALUES ('2015-08-27', 1);
INSERT INTO factura (fecha, id_cliente) VALUES ('2015-08-28', 2);
INSERT INTO factura (fecha, id_cliente) VALUES ('2015-08-29', 3);
INSERT INTO factura (fecha, id_cliente) VALUES ('2015-08-30', 1);



CREATE TABLE categoria (
	id_categoria INT PRIMARY KEY IDENTITY,
	nombre VARCHAR(50),
	descripcion VARCHAR(200));


	INSERT INTO categoria(nombre) VALUES('Tablets');
	INSERT INTO categoria(nombre) VALUES('Celulares');
	INSERT INTO categoria(nombre) VALUES('Notebooks');





CREATE TABlE producto(
id_producto INT not null PRIMARY KEY IDENTITY,
nombre VARCHAR(30),
precio FLOAT,
stock INT,
id_categoria INT FOREIGN KEY REFERENCES categoria(id_categoria)  
);
INSERT INTO producto(nombre, precio, id_categoria) VALUES ('TABLET LG ', '5000', 1);
INSERT INTO producto(nombre, precio, id_categoria) VALUES ('NOTEBOOK LENOVO', '12000', 3);
INSERT INTO producto(nombre, precio, id_categoria) VALUES ('LG G3', '10000', 2);



CREATE TABLE [dbo].[Detalle] (

    [num_detalle] INT        NOT NULL IDENTITY,
    [id_factura]  INT        NOT NULL,
    [id_producto] INT        NOT NULL,
    [cantidad]    INT        NULL,
    [precio]      FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([num_detalle] ASC),
    CONSTRAINT [FK_Detalle_id_factura] FOREIGN KEY ([id_factura]) REFERENCES [dbo].[Factura] ([numero]),
    CONSTRAINT [FK_Detalle_id_producto] FOREIGN KEY ([id_producto]) REFERENCES [dbo].[Producto] ([id_producto])

);

INSERT INTO Detalle(id_factura, id_producto, cantidad, precio) VALUES (1,2,'2','15.34');
INSERT INTO Detalle(id_factura, id_producto, cantidad, precio) VALUES (1,2,'2','15.34');
INSERT INTO Detalle(id_factura, id_producto, cantidad, precio) VALUES (2,2,'2','15.34');
INSERT INTO Detalle(id_factura, id_producto, cantidad, precio) VALUES (3,3,'2','15.34');