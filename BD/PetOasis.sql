Use master
go

if exists(Select * from sys.databases  Where name='PetOasis')
Begin
	Drop Database PetOasis
End
go

create database PetOasis
go

use PetOasis
go

-- -----------------------------------------------------
-- Tabla Tipo Usuario
-- -----------------------------------------------------

create table tb_tipoUsuario(
	codTipusu int primary key,
	nomTipusu varchar(13) not null 
)
go

insert into tb_tipoUsuario values(1,'Cliente')
insert into tb_tipoUsuario values(2,'Admin')
go


-- -----------------------------------------------------
-- Tabla Usuario
-- -----------------------------------------------------

create table tb_usuario(
	codUsu char(80) primary key,
	pwdUsu varchar(50) not null,
	nomUsu varchar(80) not null,
	apeUsu varchar(80) not null,
	telUsu varchar(9),
	emailUsu varchar(50) not null,
	codTipusu int references tb_tipoUsuario default 1
)
go

insert into tb_usuario values('Diego777','123','Diego','Ramirez','123456879','Diego@gmail.com',default)
insert into tb_usuario values('JhostinJs','123','Jhostin','Jurado','956211665','Jhostin@gmail.com',2)
insert into tb_usuario values('Alfredo10','123','Alfredo','Morales','987654321','Alfredo@gmail.com',default)
go


create table tb_login
(
	idlogin char(80) references tb_usuario UNIQUE,
	clave varchar(50) not null
)
go




Create table tb_pedido_header(
	npedido varchar(7) primary key,
	fpedido datetime default(getdate()),
	codUsu char(80) references tb_usuario,
	estpedido varchar(20) default('Pendiente')
)
go

create table tb_pedido_deta(
	npedido varchar(7) references tb_pedido_header,
	idproducto int,
	precio decimal,
	cantidad int
)
go

create table tb_solicitud(
	nroSol varchar(7) primary key,
	fechaSol datetime default(getdate()),
	codUsu char(80) references tb_usuario,
	codAni int references tb_animal,
	estadoSol varchar(20) default('Pendiente')
)
go

select dbo.autogenera()
go

select*from tb_solicitud

create function dbo.autogenera() returns varchar(7)
As
Begin
	Declare @n varchar(7), @c int
	Select @c=count(*)+1 from tb_pedido_header
	Set @n=cast(@c as varchar(7))
	Set @n=REPLICATE('0',7-len(@n))+@n
	return @n
End
go

create function dbo.autogeneraSol() returns varchar(7)
As
Begin
	Declare @n varchar(7), @c int
	Select @c=count(*)+1 from tb_solicitud
	Set @n=cast(@c as varchar(7))
	Set @n=REPLICATE('0',7-len(@n))+@n
	return @n
End
go

select dbo.autogeneraSol()
go
-- -----------------------------------------------------
-- Tabla Tipo Animal
-- -----------------------------------------------------

create table tb_tipoAnimal(
	codTip int primary key,
	nomTip varchar(20) not null
)
go

insert into tb_tipoAnimal values(1,'Perro')
insert into tb_tipoAnimal values(2,'Gato')
go

select*from tb_tipoAnimal
go

-- -----------------------------------------------------
-- Tabla Estado
-- -----------------------------------------------------

create table tb_estado(
	codEst int primary key,
	nomEst varchar(20) not null
)
go

insert into tb_estado values(1,'Cachorro')
insert into tb_estado values(2,'Adulto')
insert into tb_estado values(3,'Anciano')
go

select*from tb_estado
go

create table tb_disponibilidad(
	codDis int primary key,
	desDis varchar(20) not null
)
go

insert into tb_disponibilidad values(1,'Disponible')
insert into tb_disponibilidad values(2,'No Disponible')
go
-- -----------------------------------------------------
-- Tabla Animal
-- -----------------------------------------------------

create table tb_animal(
	codAni int primary key,
	nomAni varchar(80) not null,
	codTip int references tb_tipoAnimal not null,
	resAni datetime not null, -- Fecha de rescate
	sexAni varchar(40) not null,
	tamAni varchar(40) not null,
	codEst int references tb_estado not null,
	nacAni varchar(40) not null,
	codDis int references tb_disponibilidad not null,
	imgAni varchar(80)
)
go
-- drop table tb_animal
insert into tb_animal values(1,'Almudena',1,'20210119','Hembra','Pequeño',2,'Abril 2015',1,'~/Imagenes/Animales/1.png')
insert into tb_animal values(2,'Bobby',1,'20210321','Macho','Mediano',2,'Enero 2017',1,'~/Imagenes/Animales/2.png')
insert into tb_animal values(3,'Cooper',1,'20210412','Macho','Pequeño',2,'Mayo 2015',1,'~/Imagenes/Animales/3.png')
insert into tb_animal values(4,'Mily',1,'20210220','Hembra','Mediano',2,'Septiembre 2016',1,'~/Imagenes/Animales/4.png')
insert into tb_animal values(5,'Gaston',1,'20210430','Macho','Grande',3,'Noviembre 2011',1,'~/Imagenes/Animales/5.png')
insert into tb_animal values(6,'Garrita',1,'20210404','Hembra','Pequeño',2,'Marzo 2016',1,'~/Imagenes/Animales/6.png')
insert into tb_animal values(7,'Pancho',1,'20210311','Macho','Pequeño',3,'Marzo 2010',1,'~/Imagenes/Animales/7.png')
insert into tb_animal values(8,'Dasso',1,'20210217','Macho','Pequeño',1,'Febrero 2020',1,'~/Imagenes/Animales/8.png')
insert into tb_animal values(9,'Rambito',1,'20210112','Macho','Mediano',2,'Septiembre 2015',1,'~/Imagenes/Animales/9.png')
insert into tb_animal values(10,'Tuki',1,'20210222','Macho','Grande',3,'Octubre 2009',1,'~/Imagenes/Animales/10.png')
insert into tb_animal values(11,'Uvita',1,'20210308','Macho','Pequeño',2,'Noviembre 2017',1,'~/Imagenes/Animales/11.png')
insert into tb_animal values(12,'Ron',1,'20210426','Macho','Grande',2,'Enero 2016',1,'~/Imagenes/Animales/12.png')
insert into tb_animal values(13,'Canela',1,'20210227','Hembra','Grande',3,'Agosto 2011',1,'~/Imagenes/Animales/13.png')
insert into tb_animal values(14,'Layca',1,'20210429','Hembra','Grande',3,'Mayo 2010',1,'~/Imagenes/Animales/14.png')
insert into tb_animal values(15,'Yana',1,'20210412','Hembra','Grande',2,'Febrero 2015',1,'~/Imagenes/Animales/15.png')
insert into tb_animal values(16,'Max',1,'20210315','Macho','Mediano',2,'Diciembre 2014',1,'~/Imagenes/Animales/16.png')
insert into tb_animal values(17,'Draco',1,'20210111','Macho','Grande',2,'Octubre 2016',1,'~/Imagenes/Animales/17.png')
insert into tb_animal values(18,'Bongo',1,'20210218','Macho','Pequeño',1,'Agosto 2020',1,'~/Imagenes/Animales/18.png')
insert into tb_animal values(19,'Scooby',1,'20210107','Macho','Grande',3,'Marzo 2011',1,'~/Imagenes/Animales/19.png')
insert into tb_animal values(20,'Scrappy',1,'20210206','Macho','Pequeño',1,'Junio 2020',1,'~/Imagenes/Animales/20.png')
insert into tb_animal values(21,'Señor gato',2,'20210310','Macho','Mediano',2,'Abril 2017',1,'~/Imagenes/Animales/21.png')
insert into tb_animal values(22,'Kiki',2,'20210219','Hembra','Mediano',2,'Octubre 2016',1,'~/Imagenes/Animales/22.png')
insert into tb_animal values(23,'Lilly',2,'20210416','Hembra','Mediano',3,'Febrero 2012',1,'~/Imagenes/Animales/23.png')
insert into tb_animal values(24,'Enzo',2,'20210129','Macho','Mediano',2,'Julio 2014',1,'~/Imagenes/Animales/24.png')
insert into tb_animal values(25,'Niebla',2,'20210316','Hembra','Mediano',1,'Junio 2020',1,'~/Imagenes/Animales/25.png')
insert into tb_animal values(26,'Tom',2,'20210101','Macho','Mediano',2,'Mayo 2017',1,'~/Imagenes/Animales/26.png')
insert into tb_animal values(27,'Angela',2,'20210225','Macho','Mediano',1,'Abril 2020',1,'~/Imagenes/Animales/27.png')
insert into tb_animal values(28,'Oliver',2,'20210119','Macho','Mediano',1,'Octubre 2020',1,'~/Imagenes/Animales/28.png')
insert into tb_animal values(29,'Normand',2,'20210415','Macho','Mediano',2,'Abril 2018',1,'~/Imagenes/Animales/29.png')
insert into tb_animal values(30,'Corban',2,'20210318','Macho','Mediano',2,'Febrero 2018',1,'~/Imagenes/Animales/30.png')
insert into tb_animal values(31,'Elian',2,'20210226','Hembra','Mediano',3,'Julio 2010',1,'~/Imagenes/Animales/31.png')
insert into tb_animal values(32,'Ozzy',2,'20210214','Macho','Mediano',2,'Noviembre 2017',1,'~/Imagenes/Animales/32.png')
insert into tb_animal values(33,'Adal',2,'20210204','Macho','Mediano',2,'Diciembre 2015',1,'~/Imagenes/Animales/33.png')
insert into tb_animal values(34,'Pax',2,'20210326','Macho','Mediano',2,'Agosto 2017',1,'~/Imagenes/Animales/34.png')
insert into tb_animal values(35,'Colorina',2,'20210409','Hembra','Mediano',3,'Febrero 2012',1,'~/Imagenes/Animales/35.png')
insert into tb_animal values(36,'Miguel',2,'20210405','Macho','Mediano',1,'Junio 2020',2,'~/Imagenes/Animales/36.png')
go

select*from tb_animal
go

-- -----------------------------------------------------
-- Tabla Alimento
-- -----------------------------------------------------

create table tb_alimento(
	codAli int primary key,
	nomAli varchar(80) not null,
	preAli decimal not null,
	canAli int not null,
	codTip int references tb_tipoAnimal not null,
	codDis int references tb_disponibilidad not null,
	imgAli varchar(80) not null
)
go

insert into tb_alimento values(1001,'Dogxtreme Dog Adult Cordero',70.90,26,1,1,'~/Imagenes/Alimentos/1001.jpg')
insert into tb_alimento values(1002,'Canbo Adulto Cordero razas med/gran',85.00,26,1,1,'~/Imagenes/Alimentos/1002.jpg')
insert into tb_alimento values(1003,'Friskies Selección Especial Pollo, carne y mariscos',80.00,26,2,1,'~/Imagenes/Alimentos/1003.jpg')
insert into tb_alimento values(1004,'1St Choice Adulto Hipoalergénico Gato a base de Pato',75.90,26,2,1,'~/Imagenes/Alimentos/1004.jpg')
insert into tb_alimento values(1005,'Salvaje Adulto Cordero 15 Kg',83.00,26,1,1,'~/Imagenes/Alimentos/1005.jpg')
insert into tb_alimento values(1006,'ProPac Libre de Grano Cordero & Papa',97.00,26,1,1,'~/Imagenes/Alimentos/1006.jpg')
insert into tb_alimento values(1007,'ProPlan Cachorro Raza Pequeña',78.00,26,1,1,'~/Imagenes/Alimentos/1007.jpg')
insert into tb_alimento values(1008,'1St Choice Senior Gato Adulto mayor Pollo 2kg',84.00,26,2,1,'~/Imagenes/Alimentos/1008.jpg')
insert into tb_alimento values(1009,'1St Choice Adult Indoor Gato 5.44 Kgs ',102.90,26,2,1,'~/Imagenes/Alimentos/1009.jpg')
insert into tb_alimento values(1010,'Advance Gato Adulto Weight Balance 1,5kg',80.90,26,2,1,'~/Imagenes/Alimentos/1010.jpg')
insert into tb_alimento values(1011,'Hills SD Raza pequeña y toy',86.90,26,1,1,'~/Imagenes/Alimentos/1011.jpg')
insert into tb_alimento values(1012,'1st Choice Adult Indoor Vitality Adulto Vitalidad',72.00,26,2,1,'~/Imagenes/Alimentos/1012.jpg')
insert into tb_alimento values(1013,'Canbo Adulto Cordero razas pequeñas',91.00,26,1,1,'~/Imagenes/Alimentos/1013.jpg')
insert into tb_alimento values(1014,'Advance Gato Adulto Sensitive Salmon 10kg',88.00,26,2,1,'~/Imagenes/Alimentos/1014.jpg')
insert into tb_alimento values(1015,'Salvaje Adulto Pollo 15 Kg',76.00,26,1,1,'~/Imagenes/Alimentos/1015.jpg')
insert into tb_alimento values(1016,'Dogxtreme Dog Salmon',96.00,26,1,1,'~/Imagenes/Alimentos/1016.jpg')
insert into tb_alimento values(1017,'1St Choice Adulto Esterilizado Gato',72.00,26,2,1,'~/Imagenes/Alimentos/1017.jpg')
insert into tb_alimento values(1018,'Canbo Cuidado de Esterilizados',82.90,26,2,1,'~/Imagenes/Alimentos/1018.jpg')
insert into tb_alimento values(1019,'Salvaje Adulto Salmon 15Kg',115.00,26,1,1,'~/Imagenes/Alimentos/1019.jpg')
insert into tb_alimento values(1020,'Canbo Cuidado del Tracto Urinario',99.00,26,2,1,'~/Imagenes/Alimentos/1020.jpg')
go

select*from tb_alimento
go

-- -----------------------------------------------------
-- Tabla Categoria
-- -----------------------------------------------------

create table tb_categoria (
	codCat int primary key,
	desCat varchar(30) not null
)
go

insert into tb_categoria values(1,'Juguetes')
insert into tb_categoria values(2,'Ropa')
insert into tb_categoria values(3,'Higiene')
insert into tb_categoria values(4,'Camas y casetas')
insert into tb_categoria values(5,'Comedores y bebederos')
go

select*from tb_categoria
go

-- -----------------------------------------------------
-- Tabla Accesorios
-- -----------------------------------------------------

create table tb_accesorios(
	codAcc int primary key,
	nomAcc varchar(80) not null,
	preAcc decimal not null,
	canAcc int not null,
	codCat int references tb_categoria not null,
	codTip int references tb_tipoAnimal not null,
	codDis int references tb_disponibilidad not null,
	imgAcc varchar(80) not null
)
go


insert into tb_accesorios values(2001,'Fumble Fetch Smallr',30.50,24,1,1,1,'~/Imagenes/Accesorios/2001.jpg')
insert into tb_accesorios values(2002,'Rodillo Hol-Ee Mediano',25.00,21,1,1,1,'~/Imagenes/Accesorios/2002.jpg')
insert into tb_accesorios values(2003,'AirDog® Bone Lg',28.00,19,1,1,1,'~/Imagenes/Accesorios/2003.jpg')
insert into tb_accesorios values(2004,'Cat Playground - Juego Multifunciona',27.00,20,1,2,1,'~/Imagenes/Accesorios/2004.jpg')
insert into tb_accesorios values(2005,'Tiempo de juego natural X3',20.00,15,1,2,1,'~/Imagenes/Accesorios/2005.jpg')
insert into tb_accesorios values(2006,'Classic Eeeks! Flower/ Chic',22.50,29,1,2,1,'~/Imagenes/Accesorios/2006.jpg')
insert into tb_accesorios values(2007,'Chaleco Greg de taslan acolchado',55.00,35,2,1,1,'~/Imagenes/Accesorios/2007.jpg')
insert into tb_accesorios values(2008,'Chaleco de Jean con carnerito hipoalergenico',61.50,24,2,1,1,'~/Imagenes/Accesorios/2008.jpg')
insert into tb_accesorios values(2009,'Chaleco Catalina de taslan acolchado',59.00,38,2,1,1,'~/Imagenes/Accesorios/2009.jpg')
insert into tb_accesorios values(2010,'Chaleco abrazo del oso',53.40,31,2,2,1,'~/Imagenes/Accesorios/2010.jpg')
insert into tb_accesorios values(2011,'Suéter gato ovejero',55.00,28,2,2,1,'~/Imagenes/Accesorios/2011.jpg')
insert into tb_accesorios values(2012,'Urban cat',61.50,26,2,2,1,'~/Imagenes/Accesorios/2012.jpg')
insert into tb_accesorios values(2013,'Bolsas para popo 8x20u',15.00,60,3,1,1,'~/Imagenes/Accesorios/2013.jpg')
insert into tb_accesorios values(2014,'Cepillo de dientes 3 lados',20.40,12,3,1,1,'~/Imagenes/Accesorios/2014.jpg')
insert into tb_accesorios values(2015,'Peine para perros',32.50,15,3,1,1,'~/Imagenes/Accesorios/2015.jpg')
insert into tb_accesorios values(2016,'Guante saca pelo',27.00,16,3,2,1,'~/Imagenes/Accesorios/2016.jpg')
insert into tb_accesorios values(2017,'Pañitos húmedos para gatos',12.50,55,3,2,1,'~/Imagenes/Accesorios/2017.jpg')
insert into tb_accesorios values(2018,'Cortauñas para gatos',34.00,16,3,2,1,'~/Imagenes/Accesorios/2018.jpg')
insert into tb_accesorios values(2019,'Cama donut – habano con negro',70.50,26,4,1,1,'~/Imagenes/Accesorios/2019.jpg')
insert into tb_accesorios values(2020,'Colchoneta grande habano',58.20,23,4,1,1,'~/Imagenes/Accesorios/2020.jpg')
insert into tb_accesorios values(2021,'Cama rectangular – azul marino',64.40,31,4,1,1,'~/Imagenes/Accesorios/2021.jpg')
insert into tb_accesorios values(2022,'Cama para gatos Cubo Nelson',67.20,27,4,2,1,'~/Imagenes/Accesorios/2022.jpg')
insert into tb_accesorios values(2023,'Tunel para gatos cordero crema',75.00,29,4,2,1,'~/Imagenes/Accesorios/2023.jpg')
insert into tb_accesorios values(2024,'Snake Suede Cat Bed Snake white',62.80,18,4,2,1,'~/Imagenes/Accesorios/2024.jpg')
insert into tb_accesorios values(2025,'Plato dog love azul',24.00,12,5,1,1,'~/Imagenes/Accesorios/2025.jpg')
insert into tb_accesorios values(2026,'Plato para perros – huellitas',21.50,26,5,1,1,'~/Imagenes/Accesorios/2026.jpg')
insert into tb_accesorios values(2027,'Programador de comida para perros',60.50,9,5,1,1,'~/Imagenes/Accesorios/2027.jpg')
insert into tb_accesorios values(2028,'Comedero doble de acero – negro',43.00,13,5,2,1,'~/Imagenes/Accesorios/2028.jpg')
insert into tb_accesorios values(2029,'Platos para gatos de TPR naranja',18.50,16,5,2,1,'~/Imagenes/Accesorios/2029.jpg')
insert into tb_accesorios values(2030,'Plato para gatos – pescados rosado',19.00,19,5,2,1,'~/Imagenes/Accesorios/2030.jpg')
insert into tb_accesorios values(2031,'Descontinuado',19.00,19,5,2,2,'~/Imagenes/Accesorios/2010.jpg')
go

select*from tb_accesorios

Create table tb_Operacion(
	codOpe int primary key,
	desOpe varchar(30)
)
go

Insert tb_Operacion values(1,'Entrada'),(2,'Salida'),(3,'Devolucion')
go

Create table tb_KardexAcc(
	codAcc int references tb_accesorios,
	fecReg datetime default getdate(),
	codOpe int references tb_Operacion,
	cantidad int,
	detKardex varchar(255) not null
)
go

Create table tb_KardexAli(
	codAli int references tb_alimento,
	fecReg datetime default getdate(),
	codOpe int references tb_Operacion,
	cantidad int,
	detKardex varchar(255) not null
)
go

-- -----------------------------------------------------
-- Procedures
-- -----------------------------------------------------


create proc sp_TarjetaAcc
@codAcc int
As
	Select fecReg, CONVERT(varchar(10),cantidad) as Entrada,SPACE(0) as Salida,detKardex
	from tb_KardexAcc
	Where codAcc=@codAcc and codOpe=1
	UNION
	Select fecReg, SPACE(0), CONVERT(varchar(10),cantidad),detKardex
	from tb_KardexAcc
	Where codAcc=@codAcc and codOpe<>1
go

create proc sp_TarjetaAli
@codAli int
As
	Select fecReg, CONVERT(varchar(10),cantidad) as Entrada,SPACE(0) as Salida,detKardex
	from tb_KardexAli
	Where codAli=@codAli and codOpe=1
	UNION
	Select fecReg, SPACE(0), CONVERT(varchar(10),cantidad),detKardex
	from tb_KardexAli
	Where codAli=@codAli and codOpe<>1
go

create trigger tri_accesorio on tb_accesorios
for insert
as
begin
	declare @cod int
	set @cod =(select codAcc from inserted)
	declare @cant int
	set @cant=(select canAcc from inserted)
	
	insert tb_KardexAcc values(@cod,default,1,@cant,'Stock inicial')
end
go

create trigger tri_alimento on tb_alimento
for insert
as
begin
	declare @cod int
	set @cod =(select codAli from inserted)
	declare @cant int
	set @cant=(select canAli from inserted)
	
	insert tb_KardexAli values(@cod,default,1,@cant,'Stock inicial')
end
go

create procedure sp_filtroAnimal
@tipo int,
@sexo varchar(40)
as
if(@tipo = 0 and @sexo != '' )
	begin
	select*from tb_animal where sexAni = @sexo and codDis = 1
end
else if(@sexo='' and @tipo != 0 )
begin
	select*from tb_animal where codTip = @tipo and codDis = 1
end
else if(@tipo=0 and @sexo='')
begin
	select*from tb_animal where codDis = 1
end
else if(@tipo != 0 and @sexo != '')
begin 
	select*from tb_animal where  codTip = @tipo and sexAni = @sexo and codDis = 1
end
go

exec sp_filtroAnimal 1,'Macho'
go


create procedure sp_filtroAccesorio
@tipo int,
@cat int
as
if(@tipo = 0 and @cat != 0 )
	begin
	select*from tb_accesorios where codCat = @cat and codDis = 1
end
else if(@cat=0 and @tipo != 0 )
begin
	select*from tb_accesorios where codTip = @tipo and codDis = 1
end
else if(@tipo=0 and @cat=0)
begin
	select*from tb_accesorios where codDis = 1
end
else if(@tipo != 0 and @cat != 0)
begin 
	select*from tb_accesorios where  codTip = @tipo and codCat = @cat and codDis = 1
end
go

create procedure sp_filtroAlimento
@tipo int
as
if(@tipo = 0)
	begin
	select*from tb_alimento where codDis = 1
end
else if(@tipo !=0 )
begin
	select*from tb_alimento where  codTip = @tipo and codDis = 1 
end
go

exec sp_filtroAlimento 2


/*create function dbo.autogenAni() returns int
As
Begin
	Declare @c int
	Select @c=count(*)+1 from tb_animal
	return @c
End
go

select dbo.autogenAni()
*/

create procedure sp_agregarAni
@cod int,
@nom varchar(40),
@tip int,
@resc datetime,
@sex varchar(40),
@tam varchar(40),
@est int,
@nac varchar(40),
@dis int,
@img varchar(80)
as
	insert tb_animal values(@cod,@nom,@tip,@resc,@sex,@tam,@est,@nac,@dis,@img);
go 

create procedure sp_agregarAli
@cod int,
@nom varchar(80),
@pre decimal,
@can int,
@tip int,
@dis int,
@img varchar(80)
as
	insert tb_alimento values(@cod,@nom,@pre,@can,@tip,@dis,@img);
go 
select*from tb_accesorios
go 

create procedure sp_agregarAcc
@cod int,
@nom varchar(80),
@pre decimal,
@can int,
@cat int,
@tip int,
@dis int,
@img varchar(80)
as
	insert tb_accesorios values(@cod,@nom,@pre,@can,@cat,@tip,@dis,@img);
go 


create proc sp_updateAni
@cod int,
@nom varchar(40),
@tip int,
@resc datetime,
@sex varchar(40),
@tam varchar(40),
@est int,
@nac varchar(40),
@dis int,
@img varchar(80)
As
Update tb_animal 
Set nomAni=@nom, codTip=@tip, resAni=@resc, sexAni=@sex, tamAni=@tam, codEst=@est, nacAni=@nac, codDis=@dis, imgAni=@img 
where codAni = @cod
go

select*from tb_animal
delete from tb_animal where codAni = 50

create proc sp_updateAli
@cod int,
@nom varchar(80),
@pre decimal,
@can int,
@tip int,
@dis int,
@img varchar(80)
As
Update tb_alimento 
Set nomAli=@nom, preAli=@pre, canAli=@can, codTip=@tip, codDis=@dis, imgAli=@img
where codAli = @cod
go

delete from tb_alimento where codAli=1050
delete from tb_KardexAli where codAli=1050
select*from tb_alimento


create proc sp_updateAcc
@cod int,
@nom varchar(80),
@pre decimal,
@can int,
@cat int,
@tip int,
@dis int,
@img varchar(80)
As
Update tb_accesorios
Set nomAcc=@nom, preAcc=@pre, canAcc=@can, codCat=@cat, codTip=@tip, codDis=@dis, imgAcc=@img
where codAcc = @cod
go

create procedure sp_pedidodetaAli
@nro varchar(7)
as
	select p.idproducto, a.nomAli,p.precio,p.cantidad from tb_pedido_deta p inner join tb_alimento a on p.idproducto=a.codAli where npedido=@nro
go


create procedure sp_pedidodetaAcc
@nro varchar(7)
as
	select p.idproducto,a.nomAcc,p.precio,p.cantidad from tb_pedido_deta p inner join tb_accesorios a on p.idproducto=a.codAcc where npedido=@nro
go

create proc sp_pedHed
@usu char(80)
as
select * from tb_pedido_header where codUsu=@usu
go

create proc sp_solicitud
@usu char(80)
as
select * from tb_solicitud where codUsu=@usu
go


create trigger tri_login on tb_usuario
for insert
as
begin
	declare @cod char(80)
	set @cod =(select codUsu from inserted)
	declare @pwd varchar(50)
	set @pwd=(select pwdUsu from inserted)
	
	insert tb_login values(@cod,@pwd)
end
go

create proc sp_logueo
@id char(80),
@clave varchar(80)
As
Select Top 1 u.* from tb_usuario u
Where codUsu=(Select idlogin from tb_login 
Where idlogin=@id AND clave=@clave)
go

create proc sp_logueoadmin
@id char(80),
@clave varchar(80)
As
Select Top 1 u.* from tb_usuario u
Where codUsu=(Select idlogin from tb_login 
Where idlogin=@id AND clave=@clave and codTipusu=2)
go

delete from tb_accesorios where codAcc=2050
delete from tb_KardexAcc where codAcc=2050