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
