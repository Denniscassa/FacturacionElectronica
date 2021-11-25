/*
* =============================BASE DE DATOS  APP_TOP_NEVEL  ============================
*	fecha:		27/10/2021
*	autor:		Yonder quispe
				Dennis casalipa
*	proyecto:	app_topnevel
*	descripcion:.............
* =======================================================================================
*/


CREATE DATABASE db_topnevel;
USE db_topnevel;


/*****************************	TABLAS Y USUARIO   *************************************/ 
CREATE TABLE T_TIPO_USUARIO
(
	Id_TipoUsuario INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Cargo varchar(50),
	Descripcion varchar(50)
);

CREATE TABLE T_TURNO
(
	Id_Turno INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Turno varchar(30),
	Hora_Inicio time,
	Hora_Fin time
);

CREATE TABLE T_USUARIO
(
	Id_Usuario INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Id_TipoUsuario INT ,
	Id_Turno INT ,
    Id_Sucursal int not null,
	Nombres varchar(60),
	DNI varchar(10),
	Telefono varchar(12),
	Usuario varchar(60),
	Clave varchar(32),
	FOREIGN KEY(Id_TipoUsuario) REFERENCES  T_TIPO_USUARIO(Id_Tipousuario),
	FOREIGN KEY(Id_Turno) REFERENCES T_TURNO(Id_Turno)
);


/****************************************	CLIENTES ***********************************/ 
CREATE TABLE T_CLIENTE
(
	Id_Cliente INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Nombres  varchar(50),
	DNI varchar(10),
    Email varchar(30),
	Telefono varchar(10)
);



/************************************	TABLAS PRODUCTO 	*************************/ 
CREATE TABLE T_CATEGORIA
(
	Id_Categoria INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Categoria VARCHAR(100)
);

CREATE TABLE T_MARCA
(
	Id_Marca INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Marca VARCHAR(100)
);

CREATE TABLE T_TIPO_PRENDA
(
	Id_TipoPrenda INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Categoria VARCHAR(60)
);

CREATE TABLE T_TELA
(
	Id_Tela INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Tela VARCHAR(100)
);

CREATE TABLE T_MODELO
(
	Id_Modelo INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Modelo VARCHAR(100)
);

CREATE TABLE T_TALLA
(
	Id_Talla INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Talla VARCHAR(10)
);
CREATE TABLE T_PRODUCTO
(
	Id_Producto INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Cod_Barra varchar(64),
	Producto varchar(100),
	Codigo varchar(50),
    Id_Categoria int,
	Id_Marca int,
    Id_TipoPrenda int,
	Id_Tela int,
	Id_Modelo int,
	Id_Talla  int,
	Descripcion varchar(200),
	FOREIGN KEY(Id_Categoria ) REFERENCES T_CATEGORIA(Id_Categoria ),
    FOREIGN KEY(Id_Marca) REFERENCES T_MARCA(Id_Marca),
    FOREIGN KEY(Id_TipoPrenda) REFERENCES T_TIPO_PRENDA(Id_TipoPrenda),
	FOREIGN KEY(Id_Tela ) REFERENCES T_TELA(Id_Tela),
    FOREIGN KEY(Id_Modelo) REFERENCES T_MODELO(Id_Modelo),
	FOREIGN KEY(Id_Talla) REFERENCES T_TALLA(Id_Talla)
);


/************************************	ALMACEN Y SUCURSALES	*************************/ 
CREATE TABLE T_SUCURSAL
(
	Id_Sucursal INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Sucursal VARCHAR(60)
);

CREATE TABLE T_CIUDAD
(
	Id_Ciudad INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Ciudad VARCHAR(60)
);


CREATE TABLE T_ALMACEN
(
	Id_Almacen INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	Nomnre varchar(100),
	Id_Ciudad int,
	Id_Sucursal int not null references T_SUCURSAL(Id_Sucursal),
	Direccion varchar(100),
	FOREIGN KEY(Id_Ciudad) REFERENCES T_CIUDAD(Id_Ciudad)
);



/***********************************	INVENTARIO O STOCK	*************************/ 
CREATE TABLE T_INVENTARIO
(
	Id_Inventario INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Id_Producto int,
    Id_Almacen int,
    Cantidad int,
    PrecioVenta numeric,
    PrecioCompra numeric,
    Costo numeric,
    Observacion varchar(50),
	FOREIGN KEY(Id_Producto) REFERENCES T_PRODUCTO(Id_Producto),
    FOREIGN KEY(Id_Almacen) REFERENCES T_ALMACEN(Id_Almacen)
);

CREATE TABLE T_ENTRADA_INVENTARIO 		/*esto no tiene id foranea, para evitar problemas de bucle*/
(
	Id_EntradaInventario INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Id_Inventario int,
    Id_Usuario int not null references T_USUARIO(Id_Usuario),
    Cantidad int,
    Observacion varchar(50),
    fecha date,
    FOREIGN KEY(Id_Inventario) REFERENCES T_INVENTARIO(Id_Inventario)
);



/*************************************	VENTA	***********************************/ 
CREATE TABLE T_TIPO_PAGO
(
	Id_TipoPago INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    TipoPago varchar(20)
);

CREATE TABLE T_VENTA
(
	Id_Venta INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Id_Usuario int,
    Id_Cliente int,
    Id_Sucursal  int not null references T_SUCURSAL(Id_Sucursal),
    fecha datetime,
	NroVenta int,
	SubTotal numeric,
	IGV numeric,
	Total numeric,
	Id_TipoPago int,
	Estado varchar(50),
	FOREIGN KEY(Id_Usuario) REFERENCES T_USUARIO(Id_Usuario),
    FOREIGN KEY(Id_Cliente) REFERENCES T_CLIENTE(Id_Cliente),
	FOREIGN KEY(Id_TipoPago) REFERENCES  T_TIPO_PAGO(Id_TipoPago)
);

CREATE TABLE T_VENTA_DETALLE 
(
	Id_VentaDetalle INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Id_Venta int,
    Id_Producto int,
    Cantidad int,
    Precio numeric,
    Observacion varchar(50),
    FOREIGN KEY(Id_Venta) REFERENCES  T_VENTA(Id_Venta),
    FOREIGN KEY(Id_Producto) REFERENCES  T_PRODUCTO(Id_Producto),
);


/*************************************	CAJA	***********************************/ 
CREATE TABLE T_CAJA
(
	Id_Caja INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Caja varchar(20),
    Estado varchar(20), /* caja abierto o cerrado.*/
    Id_Sucursal int not null references T_SUCURSAL(Id_Sucursal),
);

CREATE TABLE T_ABRIR_CAJA
(
	Id_AbriCaja INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Id_Caja int,
    Id_Usuario int,
    Fecha datetime,
    FOREIGN KEY(Id_Caja) REFERENCES  T_CAJA(Id_Caja),
	FOREIGN KEY(Id_Usuario) REFERENCES  T_USUARIO(Id_Usuario)
);

CREATE TABLE T_CERRAR_CAJA
(
	Id_CerrarCaja INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    Id_Caja int,
    Id_Usuario int,
    Fecha datetime,
    Observacion varchar(100),
    FOREIGN KEY(Id_Caja) REFERENCES  T_CAJA(Id_Caja),
	FOREIGN KEY(Id_Usuario) REFERENCES  T_USUARIO(Id_Usuario)
);







/*
*	DATOS INICIALES PARA LAS TABLAS QUE NO REQUIEREN MANTENIMIENTO
*	TABLAS DE PRIORIDAD CERO(T_TIPO_USUARIO, T_TURNO, T_TALLA, T_CIUDAD, T_TIPO_PAGO)
*	===================================================================================
*/


--TIPO USUARIO
insert into T_TIPO_USUARIO(Id_TipoUsuario) values('ADMINISTRADOR');
insert into T_TIPO_USUARIO(Id_TipoUsuario) values('VENDEDOR');

--TURNO
insert into T_TURNO(Turno,Hora_Inicio, Hora_Fin) values('FULL TIME','08:00:00','18:00:00');
insert into T_TURNO(Turno,Hora_Inicio, Hora_Fin) values('MAÑANA','08:00:00','13:00:00');
insert into T_TURNO(Turno,Hora_Inicio, Hora_Fin) values('FTARDE','13:00:00','18:00:00');

--CIUDAD
insert into T_CIUDAD(Ciudad) values('Amazonas');
insert into T_CIUDAD(Ciudad) values('Áncash');
insert into T_CIUDAD(Ciudad) values('Apurímac');
insert into T_CIUDAD(Ciudad) values('Arequipa');
insert into T_CIUDAD(Ciudad) values('Ayacucho');
insert into T_CIUDAD(Ciudad) values('Cajamarca');
insert into T_CIUDAD(Ciudad) values('Cusco');
insert into T_CIUDAD(Ciudad) values('Huancavelica');
insert into T_CIUDAD(Ciudad) values('huanuco');
insert into T_CIUDAD(Ciudad) values('Ica');
insert into T_CIUDAD(Ciudad) values('junin');
insert into T_CIUDAD(Ciudad) values('LaLibertad');
insert into T_CIUDAD(Ciudad) values('Lambayeque');
insert into T_CIUDAD(Ciudad) values('Lima');
insert into T_CIUDAD(Ciudad) values('Loreto');
insert into T_CIUDAD(Ciudad) values('Madre de Dios');
insert into T_CIUDAD(Ciudad) values('Moquegua');
insert into T_CIUDAD(Ciudad) values('Pasco');
insert into T_CIUDAD(Ciudad) values('Piura');
insert into T_CIUDAD(Ciudad) values('Puno');
insert into T_CIUDAD(Ciudad) values('San Martin');
insert into T_CIUDAD(Ciudad) values('Tacna');
insert into T_CIUDAD(Ciudad) values('tumbes');
insert into T_CIUDAD(Ciudad) values('Ucayali');

--TIPO DE PAGO
insert into T_TIPO_PAGO(TipoPago) values('BOLETA');
insert into T_TIPO_PAGO(TipoPago) values('FACTURA');

--TALLA
insert into T_TALLA(Talla) values('XXL');
insert into T_TALLA(Talla) values('XL');
insert into T_TALLA(Talla) values('M');
insert into T_TALLA(Talla) values('S');
insert into T_TALLA(Talla) values('SM');