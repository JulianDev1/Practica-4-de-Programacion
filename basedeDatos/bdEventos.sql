create database bdEventos;
go

use bdEventos;

/*
	use master
	go
	drop DATABASE bdEventos;
	go
*/

--============  Tablas  ============-- 
create table tblTipoDoc ( 
  Codigo int primary key, 
  Nombre varchar(50) Not Null ); 
go 
create table tblGenero ( 
  Codigo int primary key, 
  Nombre varchar(20) Not Null ); 
go 
create table tblInstrum ( 
  Codigo int primary key, 
  Nombre varchar(20) Not Null ); 
go 
create table tblDpto ( 
  Codigo int primary key, 
  Nombre varchar(50) Not Null ); 
go 
create table tblCiudad ( 
  Codigo int primary key, 
  Nombre varchar(50) Not Null, 
  idDpto int  Not Null); 
go 
create table tblEvento ( 
  Codigo int primary key, 
  Nombre varchar(50) Not Null, 
  idCiudad int Not Null, 
  Anio int Not Null, 
  Fecha varchar(30) Not Null, 
  Lugar varchar(80) Not Null ); 
go 
create table tblBanda ( 
  Codigo int primary key, 
  Nombre varchar(50) Not Null, 
  AnioFund int Not Null, 
  idCiudad int Not Null, 
  Activo bit default 1 Not Null ); 
go 
create table tblArtista ( 
  Codigo int primary key, 
  Nombre varchar(80) Not Null, 
  idtipoDoc int Not Null, 
  nroDoc int Not Null, 
  idGenero int Not Null, 
  idCiudad int Not Null ); 
go 
create table tblBandaArt ( 
  Codigo int primary key, 
  idBanda int Not Null, 
  idArtista int Not Null, 
  idInstrum int Not Null, 
  Activo bit default 1 Not Null ); 
go 
create table tblInscrip ( 
  Codigo int primary key, 
  idEvento int Not Null, 
  idBanda int Not Null, 
  Representante varchar(80) Not Null, 
  Telefono varchar(25) Not Null, 
  Valor int Not Null ); 
go 
create table tblDetInsc ( 
  Codigo int primary key, 
  idNroInsc int Not Null, 
  idBandArt int Not Null, 
  Edad int Not Null ); 
go 

ALTER TABLE tblEvento   add Foreign key (idCiudad)  REFERENCES tblCiudad  (Codigo) 
ALTER TABLE tblCiudad   add Foreign key (idDpto)    REFERENCES tblDpto    (Codigo) 
ALTER TABLE tblArtista  add Foreign key (idtipoDoc) REFERENCES tblTipoDoc (Codigo) 
ALTER TABLE tblBanda    add Foreign key (idCiudad)  REFERENCES tblCiudad  (Codigo) 
ALTER TABLE tblArtista  add Foreign key (idGenero)  REFERENCES tblGenero  (Codigo) 
ALTER TABLE tblArtista  add Foreign key (idCiudad)  REFERENCES tblCiudad  (Codigo) 
ALTER TABLE tblBandaArt add Foreign key (idBanda)   REFERENCES tblBanda   (Codigo) 
ALTER TABLE tblBandaArt add Foreign key (idArtista) REFERENCES tblArtista (Codigo) 
ALTER TABLE tblBandaArt add Foreign key (idInstrum) REFERENCES tblInstrum (Codigo) 
ALTER TABLE tblInscrip  add Foreign key (idEvento)  REFERENCES tblEvento  (Codigo) 
ALTER TABLE tblInscrip  add Foreign key (idBanda)   REFERENCES tblBanda   (Codigo) 
ALTER TABLE tblDetInsc  add Foreign key (idNroInsc) REFERENCES tblInscrip (Codigo) 
ALTER TABLE tblDetInsc  add Foreign key (idBandArt) REFERENCES tblBandaArt(Codigo) 
go 

--============  tblTipoDoc  ============ 
insert into tblTipoDoc values  
( 1,'Cédula Ciudadanía'), ( 2,'Pasaporte'), ( 3,'Cédula de Extranjería'); 
go --============  tblGenero  ============ 
insert into tblGenero values  
( 1,'Masculino'), ( 2,'Femenino'), ( 3, 'Transgénero'); 
go --============  tblInstrum  ============ 
insert into tblInstrum values  
( 101,'Batería'), ( 102,'Bajo'), ( 103, 'Guitarra'), ( 104,'Sintetizador'), ( 105, 'Armónica'); 
go --============  tblDpto  ============ 
insert into tblDpto values  
( 110,'Antioquia'), ( 120,'Atlantico'), ( 130, 'Valle'), ( 140, 'Cundinamarca'); 
go --============  tblCiudad  ============ 
insert into tblCiudad values  
( 1,'Medellín',110 ), ( 2,'Envigado',110 ), ( 3,'Bello',110 ),    
( 4,'Barranquilla',120 ), 
( 5,'Soledad',120 ),  ( 6,'Malambo',120 ),  ( 7,'Cali',130 ),     
( 9,'Buga',130 ),     
( 8,'Buenaventura',130 ), 
( 10,'Bogota',140 ),  ( 11,'Usaquen',140 ), ( 12,'Soacha',140 ); 
go --============  tblEvento  ============ 
insert into tblEvento values  
( 1, 'FestRock Medellín 2024', 1, 2024, 'Diciembre 14', 'Estadio Atanasio Girardot' ); 
go --============  tblBanda  ============ 
insert into tblBanda values  
( 1, 'Overdrive', 2016, 1, 1 ), ( 2, 'Anankaia', 2017, 10, 1 ); 
go --============  tblArtista  ============ 
insert into tblArtista values  
( 1, 'Juan P. Aristizábal', 1, 1234, 1, 1 ), (2, 'Natalia Castrillón', 1, 5678, 2, 2),  
( 3, 'Hans Brady', 2, 9876, 1, 3 ), (4, 'Mario A. Martínez', 1, 7890, 1, 2), 
( 5, 'Scott Ragun', 3, 1020, 1, 10 ), (6, 'Jaz Ragun', 3, 1021, 3, 12),  
( 7, 'Gloria Soto Diaz', 1, 4321, 3, 11 ); 
go --============  tblBanda_Artista  ============ 
insert into tblBandaArt values  
( 1, 1, 1, 101, 1),  ( 2, 1, 2, 102, 1 ), ( 3, 1, 3, 103, 1 ), ( 4, 1, 4,104, 1 ),  
( 5, 2, 5, 101, 1 ), ( 6, 2, 6, 103, 1 ), ( 7, 2, 7, 102, 1 ); 
go --============  tblInscrip  ============ 
insert into tblInscrip values  
( 1, 1, 1, 'Alejandro Aristizábal', '310203040', 1000000); 
go --============  tblDetInsc  ============ 
insert into tblDetInsc values  
( 1, 1, 1, 24 ), ( 2, 1, 2, 26 ), ( 3, 1, 3, 22 ), ( 4, 1, 4, 25 ); 
go 