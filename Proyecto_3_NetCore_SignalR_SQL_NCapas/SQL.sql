CREATE DATABASE DemoNetCore21DB
GO
USE DemoNetCore21DB
GO
CREATE TABLE Productos
(
	Id INT IDENTITY(1,1),
	Nombre VARCHAR(100),
	Precio DECIMAL(8,2),
	Stock INT,
	CONSTRAINT pk_Producto PRIMARY KEY(Id),
)
GO
INSERT INTO Productos(Nombre, Precio, Stock) VALUES ('Producto 1','1.00',100)
INSERT INTO Productos(Nombre, Precio, Stock) VALUES ('Producto 2','2.00',200)
INSERT INTO Productos(Nombre, Precio, Stock) VALUES ('Producto 3','3.00',300)
INSERT INTO Productos(Nombre, Precio, Stock) VALUES ('Producto 4','4.00',400)
INSERT INTO Productos(Nombre, Precio, Stock) VALUES ('Producto 5','5.00',500)
INSERT INTO Productos(Nombre, Precio, Stock) VALUES ('Producto 6','6.00',600)
INSERT INTO Productos(Nombre, Precio, Stock) VALUES ('Producto 7','7.00',700)
GO
CREATE PROC uspGetProductos
AS
BEGIN 
	SELECT
		Id,
		Nombre,
		Precio,
		Stock
	FROM dbo.Productos
END