use master
drop database evaluacion
go
create database Evaluacion
go
use Evaluacion
go 
create table Usuario(
Id int primary key identity,
NomUs char(10),
Pass varchar(100),
Nombre varchar(100)
)
go
insert into Usuario values 
('usu1', HashBytes('MD5','123'), 'Usuario 1'),
('usu2', HashBytes('MD5','321'), 'Usuario 2')
go 
create table Producto(
Id int primary key identity,
Nombre char(200),
Unidad char(10),
Precio decimal(18,2)
)
go
insert into Producto values
('Mochila','und',50),
('Cartuchera','und',10)
go 
create table Sales(
Id int,
IdProducto int,
Cantidad decimal(18,2),
primary key(Id, IdProducto),
FOREIGN KEY (IdProducto) REFERENCES Producto(Id)
)
insert into Sales values
(1, 1, 2),
(1, 2, 10)


--select * from usuario where clave = HashBytes('MD5','123')

select * from Usuario
select * from Producto
select * from Sales



