/*
use master;
go
Drop database bdEventos;
go
*/

create Database bdEventos
go
use bdEventos
go

-----Tablas----
create table tblTipoDoc(
Codigo int primary key, 
Nombre varchar(50) not null);
go

create table tblGenero(
Codigo int primary key, 
Nombre varchar(20) not null);
go

create table tblInstrum(
Codigo int primary key, 
Nombre varchar(20)not null);
go

create table tblDpto(
Codigo int primary key, 
Nombre varchar(50) not null); 
go

create table tblCiudad(
Codigo int primary key, 
Nombre varchar(50) not null, 
idDpto int not null);
go

create table tblEvento(
Codigo int primary key, 
Nombre varchar(50) not null, 
idCiudad int not null, 
Anio int not null, 
Fecha varchar(30)not null, 
Lugar varchar(80)not null);
go

create table tblBanda(
Codigo int primary key,
Nombre varchar(50) not null,
AnioFund int not null,
idCiudad int not null,
Activo bit default 1 not null);
go

create table tblArtista(
Codigo int primary key, 
Nombre varchar(80)not null, 
idtipoDoc int not null, 
nroDoc int not null,
idGenero int not null, 
idCiudad int not null);
go

create table tblBandaArt(
Codigo int primary key, 
idBanda int not null, 
idArtista int not null, 
idInstrum int not null, 
Activo bit default 1 not null);
go

create table tblInscrip(
Codigo int primary key, 
idEvento int not null, 
idBanda int not null, 
Represenante varchar(80)not null, 
Telefono varchar(25)not null, 
valor int not null);
go

create table tblDetInsc(
Codigo int primary key, 
idNroInsc int not null, 
idBandArt int not null, 
Edad int not null);
go

-----Agregar modelo relacional
alter table tblEvento add foreign key (idCiudad) references tblCiudad (Codigo);
go

alter table tblCiudad add foreign key (idDpto) references tblDpto (Codigo);
go

alter table tblArtista add foreign key (idtipoDoc) references tblTipoDoc (Codigo);
go

alter table tblBanda add foreign key (idCiudad) references tblCiudad (Codigo);
go

alter table tblArtista add foreign key (idGenero) references tblGenero (Codigo); 
go

alter table tblArtista add foreign key (idCiudad) references tblCiudad (Codigo); 
go

alter table tblBandaArt add foreign key (idBanda) references tblBanda (Codigo);
go

alter table tblBandaArt add foreign key (idArtista) references tblArtista (Codigo); 
go

alter table tblBandaArt add foreign key (idInstrum) references tblInstrum (Codigo);
go

alter table tblInscrip add foreign key (idEvento) references tblEvento (Codigo); 
go

alter table tblInscrip add foreign key (idBanda) references tblBanda (Codigo);
go

alter table tblDetInsc add foreign key (idNroInsc) references tblInscrip (Codigo);
go

alter table tblDetInsc add foreign key (idBandArt) references tblBandaArt (Codigo);
go

--Insertar datos en la tablas
insert into tblTipoDoc values (1, 'Cedula Ciudadanía'), (2, 'Pasaporte'), (3, 'Cédula de Extranjeria');
go

insert into tblGenero values (1, 'Masculino'), (2,'Femenino'), (3, 'Transgénero');
go

insert into tblInstrum values (101, 'Batería'), (102, 'Bajo'), (103, 'Guitarra'), (104, 'Sintentizador'), (105, 'Armónica');
go

insert into tblDpto values (110, 'Antioquia'), (120, 'Atlantico'), (130, 'Valle'), (140, 'Cundinamarca');
go

insert into tblCiudad values (1, 'Medellín', 110), (2, 'Envigado', 110), (3, 'Bello', 110),
(4, 'Banrranquilla', 120), (5, 'Soledad', 120), (6, 'Malambo', 120), (7, 'Cali', 130), (8, 'Buenaventura', 130),
(9, 'Buga', 130), (10, 'Bogota', 140), (11, 'Usaquen', 140), (12, 'Soacha', 140);
go

insert into tblEvento values (1, 'FestRick Medellín 2024', 1, 2024, 'Diciembre 14', 'Estadio Atanasio Girardot');
go

insert into tblBanda values (1, 'Overdrive', 2016, 1, 1), (2, 'Anankaia', 2017, 10, 1);
go
--
insert into tblArtista values (1, 'Juan P. Aristizábal', 1, 1234, 1, 1), (2, 'Natalia Castrillón', 1, 5678, 2 ,2),
(3, 'Hans Brady', 2, 9876, 1, 3), (4, 'Mario A. Martínez', 1, 7890, 1, 2), (5, 'Scott Ragun', 3, 1020, 1, 10),
(6, 'Jaz Ragun', 3, 1021, 3, 12), (7, 'Gloria Soto Diaz', 1, 4321, 3, 11);
go

insert into tblBandaArt values (1, 1, 1, 101, 1), (2, 1, 2, 102, 1), (3, 1, 3, 103, 1), (4, 1, 4, 104, 1),
(5, 2, 5, 101, 1), (6, 2, 6, 103, 1), (7, 2, 7, 102, 1);
go

insert into tblInscrip values (1, 1, 1, 'Alejandro Aristizábal', '310203040', 1000000);
go

insert into tblDetInsc values (1, 1, 1, 24), (2, 1, 2, 26), (3, 1, 3, 22), (4, 1, 4, 25);
go

