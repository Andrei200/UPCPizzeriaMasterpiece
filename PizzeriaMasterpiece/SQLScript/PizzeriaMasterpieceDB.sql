
USE MASTER
IF EXISTS(select * from sys.databases where name='PizzeriaMasterPiece')
DROP DATABASE PizzeriaMasterPiece
GO
CREATE DATABASE PizzeriaMasterPiece
GO
USE  PizzeriaMasterPiece
GO
CREATE TABLE Changelog
( 
	ChangeLogId          integer IDENTITY ( 1,1 ) ,
	[Key]			     integer NULL ,
	[Action]             nvarchar(50)  NULL ,
	[Table]              nvarchar(50)  NULL ,
	Field                nvarchar(50)  NULL ,
	OldValue             nvarchar(50)  NULL ,
	NewValue             nvarchar(50)  NULL ,
	[Date]               datetime  NULL ,
	UserId               integer  NULL 
)
go



ALTER TABLE Changelog
	ADD  PRIMARY KEY  CLUSTERED (ChangeLogId ASC)
go



CREATE TABLE Company
( 
	CompanyId            integer IDENTITY ( 1,1 ) ,
	[Name]               nvarchar(100)  NOT NULL ,
	RUC                  nvarchar(20)  NOT NULL ,
	[Address]            nvarchar(100)  NULL ,
	PhoneNumber          nvarchar(20)  NULL 
)
go



ALTER TABLE Company
	ADD  PRIMARY KEY  CLUSTERED (CompanyId ASC)
go



CREATE TABLE DocumentType
( 
	DocumentTypeId       integer IDENTITY ( 1,1 ),
	Code                 nvarchar(10)  NOT NULL ,
	[Name]               nvarchar(50)  NOT NULL 
)
go



ALTER TABLE DocumentType
	ADD  PRIMARY KEY  CLUSTERED (DocumentTypeId ASC)
go



CREATE TABLE [Order]
( 
	OrderId              integer IDENTITY ( 1,1 ) ,
	OrderNo              nvarchar(20)  NULL ,
	[Date]               datetime  NULL ,
	[Address]            nvarchar(255)  NULL ,
	Remark               nvarchar(255)  NULL ,
	OrderStatusId        integer  NULL ,
	DocumentTypeId       integer  NULL ,
	CompanyId            integer  NULL ,
	UserId               integer  NULL 
)
go



ALTER TABLE [Order]
	ADD  PRIMARY KEY  CLUSTERED (OrderId ASC)
go



CREATE TABLE OrderDetail
( 
	OrderDetailId        integer IDENTITY ( 1,1 ) ,
	Price                decimal(10,2)  NOT NULL ,
	TotalPrice           decimal(10,2)  NOT NULL ,
	Quantity             integer  NOT NULL ,
	ProductId            integer  NULL ,
	OrderId              integer  NULL 
)
go



ALTER TABLE OrderDetail
	ADD  PRIMARY KEY  CLUSTERED (OrderDetailId ASC)
go



CREATE TABLE OrderStatus
( 
	OrderStatusId        integer IDENTITY ( 1,1 ) ,
	Code                 nvarchar(10)  NOT NULL ,
	[Name]               nvarchar(50)  NOT NULL 
)
go



ALTER TABLE OrderStatus
	ADD  PRIMARY KEY  CLUSTERED (OrderStatusId ASC)
go



CREATE TABLE Product
( 
	ProductId            integer IDENTITY ( 1,1 ) ,
	Code                 nvarchar(10)  NOT NULL ,
	[Name]               nvarchar(100)  NOT NULL ,
	[Description]        nvarchar(255)  NULL ,
	Price                decimal(10,2)  NOT NULL ,
	ImagePath            nvarchar(255)  NULL ,
	IsActive             tinyint  NULL ,
	SizeId               integer  NULL ,
)
go



ALTER TABLE Product
	ADD  PRIMARY KEY  CLUSTERED (ProductId ASC)
go



CREATE TABLE ProductSupply
( 
	ProductSupplyId      integer IDENTITY ( 1,1 ) ,
	Quantity             integer  NULL ,
	ProductId            integer  NULL ,
	SupplyId             integer  NULL 
)
go



ALTER TABLE ProductSupply
	ADD  PRIMARY KEY  CLUSTERED (ProductSupplyId ASC)
go



CREATE TABLE [Role]
( 
	RoleId               integer IDENTITY ( 1,1 ) ,
	Code                 nvarchar(10)  NULL ,
	[Name]               nvarchar(50)  NULL 
)
go



ALTER TABLE [Role]
	ADD  PRIMARY KEY  CLUSTERED (RoleId ASC)
go



CREATE TABLE Size
( 
	SizeId               integer IDENTITY ( 1,1 ) ,
    Code                 nvarchar(10)  NOT NULL ,
	[Name]               nvarchar(50)  NOT NULL 

)
go



ALTER TABLE Size
	ADD  PRIMARY KEY  CLUSTERED (SizeId ASC)
go



CREATE TABLE Supply
( 
	SupplyId             integer IDENTITY ( 1,1 ) ,
	Code                 nvarchar(10)  NULL ,
	[Name]               nvarchar(50)  NULL ,
	[Description]        nvarchar(255)  NULL ,
	Quantity             integer  NULL ,
	IsActive             tinyint  NULL 
)
go



ALTER TABLE Supply
	ADD  PRIMARY KEY  CLUSTERED (SupplyId ASC)
go



CREATE TABLE [User]
( 
	UserId               integer IDENTITY ( 1,1 ) ,
	DocumentNo           nvarchar(20)  NOT NULL ,
	FirstName            nvarchar(100)  NOT NULL ,
	LastName             nvarchar(100)  NOT NULL ,
	Email                nvarchar(100)  NOT NULL ,
	[Password]           nvarchar(100)  NOT NULL ,
	[Address]            nvarchar(255)  NOT NULL ,
	PhoneNumber          nvarchar(20)  NOT NULL ,
	IsActive             tinyint  NULL ,
	RoleId               integer  NULL 
)
go



ALTER TABLE [User]
	ADD  PRIMARY KEY  CLUSTERED (UserId ASC)
go




ALTER TABLE Changelog
	ADD  FOREIGN KEY (UserId) REFERENCES [User](UserId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE [Order]
	ADD  FOREIGN KEY (OrderStatusId) REFERENCES OrderStatus(OrderStatusId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE [Order]
	ADD  FOREIGN KEY (DocumentTypeId) REFERENCES DocumentType(DocumentTypeId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE [Order]
	ADD  FOREIGN KEY (CompanyId) REFERENCES Company(CompanyId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE [Order]
	ADD  FOREIGN KEY (UserId) REFERENCES [User](UserId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE OrderDetail
	ADD  FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE OrderDetail
	ADD  FOREIGN KEY (OrderId) REFERENCES [Order](OrderId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Product
	ADD  FOREIGN KEY (SizeId) REFERENCES Size(SizeId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ProductSupply
	ADD  FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE ProductSupply
	ADD  FOREIGN KEY (SupplyId) REFERENCES Supply(SupplyId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE [User]
	ADD  FOREIGN KEY (RoleId) REFERENCES Role(RoleId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


INSERT INTO[Role] VALUES ('AD','Administrador') ;
INSERT INTO[Role] VALUES ('EM','Empleado') ;
INSERT INTO[Role] VALUES ('CL','Cliente') ;


INSERT INTO[Size] VALUES ('PR','Personal') ;
INSERT INTO[Size] VALUES ('MD','Mediana') ;
INSERT INTO[Size] VALUES ('GR','Grande') ;
INSERT INTO[Size] VALUES ('XL','Extra Grande') ;

INSERT INTO[DocumentType] VALUES ('BL','Boleta') ;
INSERT INTO[DocumentType] VALUES ('FC','Factura') ;

INSERT INTO[OrderStatus] VALUES ('PEN','Pendiente') ;
INSERT INTO[OrderStatus] VALUES ('APR','Aprobado') ;
INSERT INTO[OrderStatus] VALUES ('REJ','Rechazado') ;
INSERT INTO[OrderStatus] VALUES ('CAN','Cancelado') ;
INSERT INTO[OrderStatus] VALUES ('COM','Completado') ;

INSERT INTO[Company] VALUES ('UPC','78487854784','Monterrico 345','2478981') ;
INSERT INTO[Company] VALUES ('Telefonica','41257578978','Miraflores 589','24789789') ;

INSERT INTO[Supply] VALUES ('MSAPR','Masa Personal','',30,1) ;
INSERT INTO[Supply] VALUES ('MSAMD','Masa Mediana','',30,1) ;
INSERT INTO[Supply] VALUES ('MSAGR','Masa Grande','',30,1) ;
INSERT INTO[Supply] VALUES ('MSAXL','Masa Extra Grande','',30,1) ;

INSERT INTO[Supply] VALUES ('PQUMZ','Paquete Queso Mozzarella','',50,1) ;
INSERT INTO[Supply] VALUES ('PJAMI','Paquete Jamonada Inglesa','',30,1) ;
INSERT INTO[Supply] VALUES ('POREG','Paquete Oregano','',50,1) ;
INSERT INTO[Supply] VALUES ('PPINL','Paquete Piña en Lajas','',50,1) ;
INSERT INTO[Supply] VALUES ('PPEPE','Paquete Pepperoni','',50,1) ;
INSERT INTO[Supply] VALUES ('PSTOM','Bolsa de Salsa de Tomate','',50,1) ;
INSERT INTO[Supply] VALUES ('PTOCN','Paquete Tocino','',3,1) ;
INSERT INTO[Supply] VALUES ('PCRES','Paquete Carne de Res','',2,1) ;
INSERT INTO[Supply] VALUES ('PSALC','Paquete Salchichas','',2,1) ;


INSERT INTO[Product] VALUES ('AMEPR','Americana','Pizza con queso y jamón',20.0,'../../Images/Pizza/americana.png',1,1) ;
INSERT INTO[Product] VALUES ('AMEMD','Americana','Pizza con queso y jamón',30.0,'../../Images/Pizza/americana.png',1,2) ;
INSERT INTO[Product] VALUES ('AMEGR','Americana','Pizza con queso y jamón',40.0,'../../Images/Pizza/americana.png',1,3) ;
INSERT INTO[Product] VALUES ('AMEXL','Americana','Pizza con queso y jamón',50.0,'../../Images/Pizza/americana.png',1,4) ;

INSERT INTO[Product] VALUES ('MOZPR','Mozzarella','Pizza con extra queso',19.0,'../../Images/Pizza/mozzarella.png',1,1) ;
INSERT INTO[Product] VALUES ('MOZMD','Mozzarella','Pizza con extra queso',29.0,'../../Images/Pizza/mozzarella.png',1,2) ;
INSERT INTO[Product] VALUES ('MOZGR','Mozzarella','Pizza con extra queso',38.0,'../../Images/Pizza/mozzarella.png',1,3) ;
INSERT INTO[Product] VALUES ('MOZXL','Mozzarella','Pizza con extra queso',48.0,'../../Images/Pizza/mozzarella.png',1,4) ;

INSERT INTO[Product] VALUES ('HAWPR','Hawaiana','Pizza con piña, queso y jamon',24.0,'../../Images/Pizza/hawaiana.png',1,1) ;
INSERT INTO[Product] VALUES ('HAWMD','Hawaiana','Pizza con piña, queso y jamon',34.0,'../../Images/Pizza/hawaiana.png',1,2) ;
INSERT INTO[Product] VALUES ('HAWGR','Hawaiana','Pizza con piña, queso y jamon',44.0,'../../Images/Pizza/hawaiana.png',1,3) ;
INSERT INTO[Product] VALUES ('HAWXL','Hawaiana','Pizza con piña, queso y jamon',54.0,'../../Images/Pizza/hawaiana.png',1,4) ;

INSERT INTO[Product] VALUES ('PEPPR','Pepperoni','Pizza con queso y pepperoni',22.0,'../../Images/Pizza/pepperoni.png',1,1) ;
INSERT INTO[Product] VALUES ('PEPMD','Pepperoni','Pizza con queso y pepperoni',32.0,'../../Images/Pizza/pepperoni.png',1,2) ;
INSERT INTO[Product] VALUES ('PEPGR','Pepperoni','Pizza con queso y pepperoni',42.0,'../../Images/Pizza/pepperoni.png',1,3) ;
INSERT INTO[Product] VALUES ('PEPXL','Pepperoni','Pizza con queso y pepperoni',52.0,'../../Images/Pizza/pepperoni.png',1,4) ;

INSERT INTO[Product] VALUES ('CARPR','Carnivora','Pizza con pepperoni, jamón, tocino, carne de res y queso mozzarella',28.0,'../../Images/Pizza/carnivora.png',1,1) ;
INSERT INTO[Product] VALUES ('CARMD','Carnivora','Pizza con pepperoni, jamón, tocino, carne de res y queso mozzarella',38.0,'../../Images/Pizza/carnivora.png',1,2) ;
INSERT INTO[Product] VALUES ('CARGR','Carnivora','Pizza con pepperoni, jamón, tocino, carne de res y queso mozzarella',48.0,'../../Images/Pizza/carnivora.png',1,3) ;
INSERT INTO[Product] VALUES ('CARXL','Carnivora','Pizza con pepperoni, jamón, tocino, carne de res y queso mozzarella',58.0,'../../Images/Pizza/carnivora.png',1,4) ;

--AMERICANA
INSERT INTO[ProductSupply] VALUES (1,1,1)
INSERT INTO[ProductSupply] VALUES (1,1,5)
INSERT INTO[ProductSupply] VALUES (1,1,6)
INSERT INTO[ProductSupply] VALUES (1,1,7)
INSERT INTO[ProductSupply] VALUES (1,1,10)

INSERT INTO[ProductSupply] VALUES (1,2,2)
INSERT INTO[ProductSupply] VALUES (2,2,5)
INSERT INTO[ProductSupply] VALUES (2,2,6)
INSERT INTO[ProductSupply] VALUES (2,2,7)
INSERT INTO[ProductSupply] VALUES (2,2,10)

INSERT INTO[ProductSupply] VALUES (1,3,3)
INSERT INTO[ProductSupply] VALUES (3,3,5)
INSERT INTO[ProductSupply] VALUES (3,3,6)
INSERT INTO[ProductSupply] VALUES (3,3,7)
INSERT INTO[ProductSupply] VALUES (3,3,10)

INSERT INTO[ProductSupply] VALUES (1,4,4)
INSERT INTO[ProductSupply] VALUES (4,4,5)
INSERT INTO[ProductSupply] VALUES (4,4,6)
INSERT INTO[ProductSupply] VALUES (4,4,7)
INSERT INTO[ProductSupply] VALUES (4,4,10)


--MOZZARELLA
INSERT INTO[ProductSupply] VALUES (1,5,1)
INSERT INTO[ProductSupply] VALUES (2,5,5)
INSERT INTO[ProductSupply] VALUES (1,5,7)
INSERT INTO[ProductSupply] VALUES (1,5,10)

INSERT INTO[ProductSupply] VALUES (1,6,2)
INSERT INTO[ProductSupply] VALUES (4,6,5)
INSERT INTO[ProductSupply] VALUES (2,6,7)
INSERT INTO[ProductSupply] VALUES (2,6,10)

INSERT INTO[ProductSupply] VALUES (1,7,3)
INSERT INTO[ProductSupply] VALUES (6,7,5)
INSERT INTO[ProductSupply] VALUES (3,7,7)
INSERT INTO[ProductSupply] VALUES (3,7,10)

INSERT INTO[ProductSupply] VALUES (1,8,4)
INSERT INTO[ProductSupply] VALUES (8,8,5)
INSERT INTO[ProductSupply] VALUES (4,8,7)
INSERT INTO[ProductSupply] VALUES (4,8,10)


--HAWAINA
INSERT INTO[ProductSupply] VALUES (1,9,1)
INSERT INTO[ProductSupply] VALUES (1,9,5)
INSERT INTO[ProductSupply] VALUES (1,9,6)
INSERT INTO[ProductSupply] VALUES (1,9,7)
INSERT INTO[ProductSupply] VALUES (1,9,8)
INSERT INTO[ProductSupply] VALUES (1,9,10)

INSERT INTO[ProductSupply] VALUES (1,10,2)
INSERT INTO[ProductSupply] VALUES (2,10,5)
INSERT INTO[ProductSupply] VALUES (2,10,6)
INSERT INTO[ProductSupply] VALUES (2,10,7)
INSERT INTO[ProductSupply] VALUES (2,10,8)
INSERT INTO[ProductSupply] VALUES (2,10,10)


INSERT INTO[ProductSupply] VALUES (1,11,3)
INSERT INTO[ProductSupply] VALUES (3,11,5)
INSERT INTO[ProductSupply] VALUES (3,11,6)
INSERT INTO[ProductSupply] VALUES (3,11,7)
INSERT INTO[ProductSupply] VALUES (3,11,8)
INSERT INTO[ProductSupply] VALUES (3,11,10)


INSERT INTO[ProductSupply] VALUES (1,12,4)
INSERT INTO[ProductSupply] VALUES (4,12,5)
INSERT INTO[ProductSupply] VALUES (4,12,6)
INSERT INTO[ProductSupply] VALUES (4,12,7)
INSERT INTO[ProductSupply] VALUES (4,12,8)
INSERT INTO[ProductSupply] VALUES (4,12,10)



--PEPPERONI
INSERT INTO[ProductSupply] VALUES (1,13,1)
INSERT INTO[ProductSupply] VALUES (1,13,5)
INSERT INTO[ProductSupply] VALUES (1,13,7)
INSERT INTO[ProductSupply] VALUES (1,13,9)
INSERT INTO[ProductSupply] VALUES (1,13,10)


INSERT INTO[ProductSupply] VALUES (1,14,2)
INSERT INTO[ProductSupply] VALUES (2,14,5)
INSERT INTO[ProductSupply] VALUES (2,14,7)
INSERT INTO[ProductSupply] VALUES (2,14,9)
INSERT INTO[ProductSupply] VALUES (2,14,10)

INSERT INTO[ProductSupply] VALUES (1,15,3)
INSERT INTO[ProductSupply] VALUES (3,15,5)
INSERT INTO[ProductSupply] VALUES (3,15,7)
INSERT INTO[ProductSupply] VALUES (3,15,9)
INSERT INTO[ProductSupply] VALUES (3,15,10)

INSERT INTO[ProductSupply] VALUES (1,16,4)
INSERT INTO[ProductSupply] VALUES (4,16,5)
INSERT INTO[ProductSupply] VALUES (4,16,7)
INSERT INTO[ProductSupply] VALUES (4,16,9)
INSERT INTO[ProductSupply] VALUES (4,16,10)


--CARNIVORA
INSERT INTO[ProductSupply] VALUES (1,17,1)
INSERT INTO[ProductSupply] VALUES (1,17,5)
INSERT INTO[ProductSupply] VALUES (1,17,6)
INSERT INTO[ProductSupply] VALUES (1,17,7)
INSERT INTO[ProductSupply] VALUES (1,17,10)
INSERT INTO[ProductSupply] VALUES (1,17,11)
INSERT INTO[ProductSupply] VALUES (1,17,12)

INSERT INTO[ProductSupply] VALUES (1,18,2)
INSERT INTO[ProductSupply] VALUES (2,18,5)
INSERT INTO[ProductSupply] VALUES (2,18,6)
INSERT INTO[ProductSupply] VALUES (2,18,7)
INSERT INTO[ProductSupply] VALUES (2,18,10)
INSERT INTO[ProductSupply] VALUES (2,18,11)
INSERT INTO[ProductSupply] VALUES (2,18,12)

INSERT INTO[ProductSupply] VALUES (1,19,3)
INSERT INTO[ProductSupply] VALUES (3,19,5)
INSERT INTO[ProductSupply] VALUES (3,19,6)
INSERT INTO[ProductSupply] VALUES (3,19,7)
INSERT INTO[ProductSupply] VALUES (3,19,10)
INSERT INTO[ProductSupply] VALUES (3,19,11)
INSERT INTO[ProductSupply] VALUES (3,19,12)

INSERT INTO[ProductSupply] VALUES (1,20,4)
INSERT INTO[ProductSupply] VALUES (4,20,5)
INSERT INTO[ProductSupply] VALUES (4,20,6)
INSERT INTO[ProductSupply] VALUES (4,20,7)
INSERT INTO[ProductSupply] VALUES (4,20,10)
INSERT INTO[ProductSupply] VALUES (4,20,11)
INSERT INTO[ProductSupply] VALUES (4,20,12)


INSERT INTO[User] VALUES ('45127845','Juan','Tenorio','j@gmail.com','8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92','Av Miraflores 356','123456789',1,3)
INSERT INTO[User] VALUES ('45127846','Frank','Mamani','f@gmail.com','8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92','Av Miraflores 357','789654123',1,3)
INSERT INTO[User] VALUES ('45127847','Gonzalo','Pazos','g@gmail.com','8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92','Av Miraflores 358','258741369',1,3)
INSERT INTO[User] VALUES ('32345674','Pablo','Perez','correo@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Calle las Desconocidas','45444444',1,2)
INSERT INTO[User] VALUES ('44676567','Carlos','Garcia','cgarcia@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Calle las Desconocidas','45444444',1,2)
INSERT INTO[User] VALUES ('56434567','Manuel','Ponce','mpoonce@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Calle los Geranios','45444444',1,2)
INSERT INTO[User] VALUES ('34311122','Pedro','Chavez','pchavez@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Calle las rosas','44344445',1,3)
INSERT INTO[User] VALUES ('56543456','Deysi','Carrasco','dcarrasco@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Jr. Cahevez 333 ','6765676',1,3)
INSERT INTO[User] VALUES ('56478987','Paula','Alarcon','palarcon@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Jr. Pumachahua 444','5687655',1,3)
INSERT INTO[User] VALUES ('67054567','Jhonathan','Figueroa','jfigueroa@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Jr. Mesa Redonda','6565456',1,2)
INSERT INTO[User] VALUES ('0659456','Aldahir','Mendez','admin@gmail.com','EF797C8118F02DFB649607DD5D3F8C7623048C9C063D532CC95C5ED7A898A64F','Calle Progreso','5456769',1,1)


INSERT INTO[Changelog] VALUES(2,'INSERT','User','FirstName','','Alvaro',GETDATE(),1)
INSERT INTO[Changelog] VALUES(2,'UPDATE','User','FirstName','Alvaro','Frank',GETDATE(),1)
INSERT INTO[Changelog] VALUES(3,'INSERT','User','FirstName','','Gonzalo',GETDATE(),2)
INSERT INTO[Changelog] VALUES(4,'INSERT','User','FirstName','','Carlos',GETDATE(),2)
INSERT INTO[Changelog] VALUES(5,'INSERT','User','FirstName','','Miguel',GETDATE(),1)
INSERT INTO[Changelog] VALUES(4,'UPDATE','User','FirstName','Carlos','Pablo',GETDATE(),2)
INSERT INTO[Changelog] VALUES(6,'INSERT','User','FirstName','','Manuel',GETDATE(),1)
INSERT INTO[Changelog] VALUES(1,'INSERT','Company','Name','','UPC',GETDATE(),1)
INSERT INTO[Changelog] VALUES(1,'INSERT','Company','Name','','Telefonica',GETDATE(),1)


INSERT INTO [Order] VALUES('000001','20170308','Dirección: Av. Tupac Amaru Nº 299','Campo de Marte de Loma',5,1,2,2)
INSERT INTO [Order] VALUES('000002','20170210','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Club el Bosque La molina',1,1,2,2)
INSERT INTO [Order] VALUES('000003','20170201','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Al costado del Parque del Olivar',5,2,2,3)
INSERT INTO [Order] VALUES('000004','20170122','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Frente al parque Kenedy',3,1,1,2)
INSERT INTO [Order] VALUES('000005','20170317','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Club el Bosque La molina',2,2,1,1)
INSERT INTO [Order] VALUES('000006','20170125','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Club el Bosque La molina',5,1,1,1)
INSERT INTO [Order] VALUES('000007','20170210','Dirección: Av. La Marina N° 2941','Campo de Marte de Loma',4,2,2,1)
INSERT INTO [Order] VALUES('000008','20170406','Dirección: Av. Benavides Nº 3751-3757','Altura de la Av Peru cuadra 10',2,2,1,1)
INSERT INTO [Order] VALUES('000009','20170404','Dirección: Av. La Marina N° 2941','Al costado del Parque del Olivar',1,2,1,3)
INSERT INTO [Order] VALUES('000010','20170126','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Dentro del Megaplaza de los olivos',2,1,1,1)
INSERT INTO [Order] VALUES('000011','20170413','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Frente Huaca Melgarejo',3,1,1,2)
INSERT INTO [Order] VALUES('000012','20170306','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Club el Bosque La molina',1,2,2,1)
INSERT INTO [Order] VALUES('000013','20170310','Dirección: Av. Benavides Nº 3751-3757','Cerca al Molicentro ',4,2,1,2)
INSERT INTO [Order] VALUES('000014','20170210','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Club el Bosque La molina',3,1,2,2)
INSERT INTO [Order] VALUES('000015','20170221','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Campo de Marte de Loma',1,1,2,1)
INSERT INTO [Order] VALUES('000016','20170122','Dirección: Calle Primavera Nº200','Dentro del Megaplaza de los olivos',5,2,1,1)
INSERT INTO [Order] VALUES('000017','20170405','Dirección: Calle Primavera Nº200','Frente al parque Kenedy',1,2,2,2)
INSERT INTO [Order] VALUES('000018','20170311','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Al costado del Parque del Olivar',1,2,2,1)
INSERT INTO [Order] VALUES('000019','20170120','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Campo de Marte de Loma',4,2,2,2)
INSERT INTO [Order] VALUES('000020','20170115','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Campo de Marte de Loma',4,2,1,3)
INSERT INTO [Order] VALUES('000021','20170216','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Altura de la Av Peru cuadra 10',2,1,1,3)
INSERT INTO [Order] VALUES('000022','20170218','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Al costado del Jockey Plaza',1,1,1,1)
INSERT INTO [Order] VALUES('000023','20170305','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Frente Huaca Melgarejo',1,2,2,3)
INSERT INTO [Order] VALUES('000024','20170116','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Dentro del Megaplaza de los olivos',4,1,1,2)
INSERT INTO [Order] VALUES('000025','20170213','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Campo de Marte de Loma',3,2,1,1)
INSERT INTO [Order] VALUES('000026','20170221','Dirección: Av. La Marina N° 2941','Frente Huaca Melgarejo',5,1,2,1)
INSERT INTO [Order] VALUES('000027','20170310','Dirección:Av. Petít Thouars N° 4975, Miraflores','Frente Huaca Melgarejo',4,2,1,3)
INSERT INTO [Order] VALUES('000028','20170419','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Cerca al Molicentro ',1,1,1,2)
INSERT INTO [Order] VALUES('000029','20170329','Dirección: Av. Benavides Nº 3751-3757','Club el Bosque La molina',1,2,2,2)
INSERT INTO [Order] VALUES('000030','20170128','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Al costado del Jockey Plaza',4,2,2,3)
INSERT INTO [Order] VALUES('000031','20170126','Dirección: Av. La Marina N° 2941','Al costado del Parque del Olivar',2,1,1,3)
INSERT INTO [Order] VALUES('000032','20170224','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Frente al parque Kenedy',3,2,2,1)
INSERT INTO [Order] VALUES('000033','20170322','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Cerca al Molicentro ',3,1,2,2)
INSERT INTO [Order] VALUES('000034','20170415','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Dentro del Megaplaza de los olivos',4,2,2,2)
INSERT INTO [Order] VALUES('000035','20170312','Dirección:Av. Petít Thouars N° 4975, Miraflores','Frente Huaca Melgarejo',5,1,1,2)
INSERT INTO [Order] VALUES('000036','20170414','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Altura de la Av Peru cuadra 10',2,1,2,2)
INSERT INTO [Order] VALUES('000037','20170305','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Frente Huaca Melgarejo',3,1,2,1)
INSERT INTO [Order] VALUES('000038','20170129','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Dentro del Megaplaza de los olivos',1,1,1,2)
INSERT INTO [Order] VALUES('000039','20170331','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Frente al parque Kenedy',1,1,2,2)
INSERT INTO [Order] VALUES('000040','20170126','Dirección:Av. Javier Prado Este 183 - San Isidro','Frente Huaca Melgarejo',4,2,2,1)
INSERT INTO [Order] VALUES('000041','20170224','Dirección:Av. Petít Thouars N° 4975, Miraflores','Altura de la Av Peru cuadra 10',1,2,1,2)
INSERT INTO [Order] VALUES('000042','20170113','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Frente al parque Kenedy',5,1,2,1)
INSERT INTO [Order] VALUES('000043','20170119','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Club el Bosque La molina',2,2,1,3)
INSERT INTO [Order] VALUES('000044','20170323','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Al costado del Jockey Plaza',5,1,1,3)
INSERT INTO [Order] VALUES('000045','20170220','Dirección: Av. Benavides Nº 3751-3757','Frente Huaca Melgarejo',5,2,2,2)
INSERT INTO [Order] VALUES('000046','20170228','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Dentro del Megaplaza de los olivos',2,1,1,2)
INSERT INTO [Order] VALUES('000047','20170327','Dirección:Av. Petít Thouars N° 4975, Miraflores','Altura de la Av Peru cuadra 10',2,1,1,2)
INSERT INTO [Order] VALUES('000048','20170415','Dirección:Av. Javier Prado Este 183 - San Isidro','Campo de Marte de Loma',4,2,2,2)
INSERT INTO [Order] VALUES('000049','20170406','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Al costado del Parque del Olivar',4,2,2,1)
INSERT INTO [Order] VALUES('000050','20170421','Dirección:Av. Primavera N° 1878, Santiago de Surco','Altura de la Av Peru cuadra 10',2,2,2,2)
INSERT INTO [Order] VALUES('000051','20170302','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Cerca al Molicentro ',3,1,2,3)
INSERT INTO [Order] VALUES('000052','20170128','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Club el Bosque La molina',4,2,2,3)
INSERT INTO [Order] VALUES('000053','20170329','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Frente Huaca Melgarejo',5,2,1,2)
INSERT INTO [Order] VALUES('000054','20170414','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Altura de la Av Peru cuadra 10',1,1,2,2)
INSERT INTO [Order] VALUES('000055','20170224','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Frente Huaca Melgarejo',1,1,1,3)
INSERT INTO [Order] VALUES('000056','20170206','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Al costado del Jockey Plaza',3,2,2,1)
INSERT INTO [Order] VALUES('000057','20170411','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Al costado del Jockey Plaza',2,2,1,3)
INSERT INTO [Order] VALUES('000058','20170317','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Campo de Marte de Loma',2,1,2,2)
INSERT INTO [Order] VALUES('000059','20170406','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Campo de Marte de Loma',5,1,1,1)
INSERT INTO [Order] VALUES('000060','20170201','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Al costado del Parque del Olivar',2,2,1,3)
INSERT INTO [Order] VALUES('000061','20170213','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Dentro del Megaplaza de los olivos',5,2,1,3)
INSERT INTO [Order] VALUES('000062','20170202','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Club el Bosque La molina',2,1,2,3)
INSERT INTO [Order] VALUES('000063','20170224','Dirección: Av. Benavides Nº 3751-3757','Club el Bosque La molina',2,2,1,3)
INSERT INTO [Order] VALUES('000064','20170414','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Campo de Marte de Loma',1,1,1,3)
INSERT INTO [Order] VALUES('000065','20170125','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Campo de Marte de Loma',2,1,1,1)
INSERT INTO [Order] VALUES('000066','20170310','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Club el Bosque La molina',4,2,1,3)
INSERT INTO [Order] VALUES('000067','20170408','Dirección: Av. Tupac Amaru Nº 299','Campo de Marte de Loma',2,2,1,2)
INSERT INTO [Order] VALUES('000068','20170118','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Dentro del Megaplaza de los olivos',1,2,2,3)
INSERT INTO [Order] VALUES('000069','20170422','Dirección: Calle Primavera Nº200','Altura de la Av Peru cuadra 10',1,1,2,1)
INSERT INTO [Order] VALUES('000070','20170203','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Al costado del Parque del Olivar',3,2,1,2)
INSERT INTO [Order] VALUES('000071','20170120','Dirección: Av. La Marina N° 2941','Campo de Marte de Loma',2,2,2,3)
INSERT INTO [Order] VALUES('000072','20170129','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Dentro del Megaplaza de los olivos',5,2,1,3)
INSERT INTO [Order] VALUES('000073','20170213','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Frente al parque Kenedy',3,1,1,1)
INSERT INTO [Order] VALUES('000074','20170204','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Altura de la Av Peru cuadra 10',5,1,1,2)
INSERT INTO [Order] VALUES('000075','20170417','Dirección:Av. Petít Thouars N° 4975, Miraflores','Cerca al Molicentro ',4,2,1,2)
INSERT INTO [Order] VALUES('000076','20170320','Dirección: Av. Tupac Amaru Nº 299','Club el Bosque La molina',4,2,1,1)
INSERT INTO [Order] VALUES('000077','20170413','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Dentro del Megaplaza de los olivos',1,2,2,2)
INSERT INTO [Order] VALUES('000078','20170114','Dirección:Centro Financiero, Nivel 1 , (Mezzanine del Centro de Atención Surcano de la Municipalidad','Al costado del Parque del Olivar',2,2,2,1)
INSERT INTO [Order] VALUES('000079','20170405','Dirección: Av. Benavides Nº 3751-3757','Al costado del Jockey Plaza',5,2,2,1)
INSERT INTO [Order] VALUES('000080','20170220','Dirección:Centro Financiero, Nivel 1 , (Mezzanine del Centro de Atención Surcano de la Municipalidad','Al costado del Parque del Olivar',1,1,2,1)
INSERT INTO [Order] VALUES('000081','20170408','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Campo de Marte de Loma',5,2,2,2)
INSERT INTO [Order] VALUES('000082','20170402','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Campo de Marte de Loma',5,2,1,1)
INSERT INTO [Order] VALUES('000083','20170304','Dirección:Av. Aviación Nº 3326 San Borja','Club el Bosque La molina',3,2,1,2)
INSERT INTO [Order] VALUES('000084','20170326','Dirección: Av. Tupac Amaru Nº 299','Dentro del Megaplaza de los olivos',5,2,2,2)
INSERT INTO [Order] VALUES('000085','20170218','Dirección: Calle Primavera Nº200','Al costado del Jockey Plaza',1,1,2,2)
INSERT INTO [Order] VALUES('000086','20170124','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Campo de Marte de Loma',5,2,1,3)
INSERT INTO [Order] VALUES('000087','20170305','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Campo de Marte de Loma',4,1,1,1)
INSERT INTO [Order] VALUES('000088','20170418','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Dentro del Megaplaza de los olivos',3,1,1,2)
INSERT INTO [Order] VALUES('000089','20170216','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Al costado del Jockey Plaza',4,1,1,3)
INSERT INTO [Order] VALUES('000090','20170317','Dirección:Av. Petít Thouars N° 4975, Miraflores','Frente al parque Kenedy',4,1,1,1)
INSERT INTO [Order] VALUES('000091','20170312','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Al costado del Jockey Plaza',5,2,1,3)
INSERT INTO [Order] VALUES('000092','20170309','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Cerca al Molicentro ',4,1,1,1)
INSERT INTO [Order] VALUES('000093','20170206','Dirección:Av. La Molina 2850','Cerca al Molicentro ',2,2,2,1)
INSERT INTO [Order] VALUES('000094','20170419','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Al costado del Jockey Plaza',3,1,1,2)
INSERT INTO [Order] VALUES('000095','20170301','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Campo de Marte de Loma',3,2,1,2)
INSERT INTO [Order] VALUES('000096','20170125','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Club el Bosque La molina',1,1,1,1)
INSERT INTO [Order] VALUES('000097','20170304','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Dentro del Megaplaza de los olivos',4,1,1,2)
INSERT INTO [Order] VALUES('000098','20170128','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Frente Huaca Melgarejo',5,1,2,2)
INSERT INTO [Order] VALUES('000099','20170114','Dirección: Calle Primavera Nº200','Al costado del Jockey Plaza',3,2,2,3)
INSERT INTO [Order] VALUES('000100','20170120','Dirección:Av. Javier Prado Este 183 - San Isidro','Club el Bosque La molina',2,2,2,1)
INSERT INTO [Order] VALUES('000101','20170323','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Campo de Marte de Loma',3,2,1,1)
INSERT INTO [Order] VALUES('000102','20170409','Dirección:Av. Aviación Nº 3326 San Borja','Al costado del Parque del Olivar',5,2,1,2)
INSERT INTO [Order] VALUES('000103','20170210','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Al costado del Jockey Plaza',2,1,1,3)
INSERT INTO [Order] VALUES('000104','20170310','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Al costado del Parque del Olivar',4,1,1,2)
INSERT INTO [Order] VALUES('000105','20170208','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Campo de Marte de Loma',1,1,2,1)
INSERT INTO [Order] VALUES('000106','20170209','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Dentro del Megaplaza de los olivos',5,1,1,1)
INSERT INTO [Order] VALUES('000107','20170212','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Frente Huaca Melgarejo',1,2,2,3)
INSERT INTO [Order] VALUES('000108','20170304','Dirección: Av. Benavides Nº 3751-3757','Cerca al Molicentro ',1,2,2,1)
INSERT INTO [Order] VALUES('000109','20170312','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Frente al parque Kenedy',5,2,2,2)
INSERT INTO [Order] VALUES('000110','20170318','Dirección: Av. La Marina N° 2941','Al costado del Parque del Olivar',2,2,1,1)
INSERT INTO [Order] VALUES('000111','20170302','Dirección:Av. Aviación Nº 3326 San Borja','Campo de Marte de Loma',3,2,2,3)
INSERT INTO [Order] VALUES('000112','20170119','Dirección: Av. Benavides Nº 3751-3757','Al costado del Jockey Plaza',2,2,1,3)
INSERT INTO [Order] VALUES('000113','20170404','Dirección: Av. Tupac Amaru Nº 299','Club el Bosque La molina',1,1,2,2)
INSERT INTO [Order] VALUES('000114','20170326','Dirección:Av. Javier Prado Este 183 - San Isidro','Al costado del Jockey Plaza',3,2,1,2)
INSERT INTO [Order] VALUES('000115','20170421','Dirección: Av. Tupac Amaru Nº 299','Al costado del Parque del Olivar',4,1,1,1)
INSERT INTO [Order] VALUES('000116','20170129','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Campo de Marte de Loma',3,2,2,2)
INSERT INTO [Order] VALUES('000117','20170321','Dirección:Av. Primavera N° 1878, Santiago de Surco','Cerca al Molicentro ',4,2,2,2)
INSERT INTO [Order] VALUES('000118','20170203','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Frente Huaca Melgarejo',3,1,1,3)
INSERT INTO [Order] VALUES('000119','20170218','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Dentro del Megaplaza de los olivos',2,1,2,1)
INSERT INTO [Order] VALUES('000120','20170306','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Al costado del Jockey Plaza',5,1,1,1)
INSERT INTO [Order] VALUES('000121','20170318','Dirección:Av. La Molina 2850','Cerca al Molicentro ',3,2,2,2)
INSERT INTO [Order] VALUES('000122','20170227','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Club el Bosque La molina',5,2,2,3)
INSERT INTO [Order] VALUES('000123','20170130','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Club el Bosque La molina',5,1,2,2)
INSERT INTO [Order] VALUES('000124','20170324','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Dentro del Megaplaza de los olivos',1,1,1,3)
INSERT INTO [Order] VALUES('000125','20170304','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Altura de la Av Peru cuadra 10',5,1,2,1)
INSERT INTO [Order] VALUES('000126','20170228','Dirección:Av. Primavera N° 1878, Santiago de Surco','Al costado del Parque del Olivar',5,1,2,3)
INSERT INTO [Order] VALUES('000127','20170224','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Cerca al Molicentro ',4,2,2,1)
INSERT INTO [Order] VALUES('000128','20170313','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Altura de la Av Peru cuadra 10',3,2,1,1)
INSERT INTO [Order] VALUES('000129','20170316','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Al costado del Parque del Olivar',1,1,1,1)
INSERT INTO [Order] VALUES('000130','20170228','Dirección:Av. Javier Prado Este 183 - San Isidro','Altura de la Av Peru cuadra 10',1,2,2,2)
INSERT INTO [Order] VALUES('000131','20170331','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Campo de Marte de Loma',5,1,1,1)
INSERT INTO [Order] VALUES('000132','20170115','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Club el Bosque La molina',4,2,1,2)
INSERT INTO [Order] VALUES('000133','20170330','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Al costado del Parque del Olivar',1,1,2,3)
INSERT INTO [Order] VALUES('000134','20170414','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Club el Bosque La molina',4,1,2,2)
INSERT INTO [Order] VALUES('000135','20170131','Dirección: Av. Tupac Amaru Nº 299','Campo de Marte de Loma',2,1,1,3)
INSERT INTO [Order] VALUES('000136','20170220','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Altura de la Av Peru cuadra 10',4,2,1,2)
INSERT INTO [Order] VALUES('000137','20170331','Dirección:Av. Petít Thouars N° 4975, Miraflores','Al costado del Jockey Plaza',4,2,2,2)
INSERT INTO [Order] VALUES('000138','20170120','Dirección: Calle Primavera Nº200','Altura de la Av Peru cuadra 10',1,2,2,1)
INSERT INTO [Order] VALUES('000139','20170417','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Dentro del Megaplaza de los olivos',5,1,1,3)
INSERT INTO [Order] VALUES('000140','20170119','Dirección: Av. Benavides Nº 3751-3757','Al costado del Parque del Olivar',5,1,2,1)
INSERT INTO [Order] VALUES('000141','20170213','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Al costado del Parque del Olivar',4,2,1,3)
INSERT INTO [Order] VALUES('000142','20170222','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Cerca al Molicentro ',3,2,1,1)
INSERT INTO [Order] VALUES('000143','20170206','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Club el Bosque La molina',1,1,1,3)
INSERT INTO [Order] VALUES('000144','20170210','Dirección:Av. Javier Prado Este 183 - San Isidro','Campo de Marte de Loma',2,1,1,3)
INSERT INTO [Order] VALUES('000145','20170325','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Frente al parque Kenedy',1,2,1,3)
INSERT INTO [Order] VALUES('000146','20170214','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Dentro del Megaplaza de los olivos',3,2,2,1)
INSERT INTO [Order] VALUES('000147','20170408','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Club el Bosque La molina',1,1,2,1)
INSERT INTO [Order] VALUES('000148','20170217','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Altura de la Av Peru cuadra 10',3,1,2,3)
INSERT INTO [Order] VALUES('000149','20170304','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Al costado del Jockey Plaza',2,2,1,1)
INSERT INTO [Order] VALUES('000150','20170204','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Altura de la Av Peru cuadra 10',2,1,1,1)
INSERT INTO [Order] VALUES('000151','20170203','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Al costado del Parque del Olivar',5,1,2,2)
INSERT INTO [Order] VALUES('000152','20170212','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Dentro del Megaplaza de los olivos',2,2,2,2)
INSERT INTO [Order] VALUES('000153','20170403','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Al costado del Parque del Olivar',4,2,1,2)
INSERT INTO [Order] VALUES('000154','20170204','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Club el Bosque La molina',5,2,2,1)
INSERT INTO [Order] VALUES('000155','20170208','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Campo de Marte de Loma',3,2,1,2)
INSERT INTO [Order] VALUES('000156','20170320','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Cerca al Molicentro ',3,2,1,1)
INSERT INTO [Order] VALUES('000157','20170416','Dirección:Av. Petít Thouars N° 4975, Miraflores','Al costado del Parque del Olivar',3,1,2,1)
INSERT INTO [Order] VALUES('000158','20170405','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Club el Bosque La molina',1,2,1,2)
INSERT INTO [Order] VALUES('000159','20170209','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Al costado del Parque del Olivar',4,2,1,1)
INSERT INTO [Order] VALUES('000160','20170221','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Campo de Marte de Loma',4,1,2,1)
INSERT INTO [Order] VALUES('000161','20170415','Dirección: Av. Benavides Nº 3751-3757','Campo de Marte de Loma',4,2,1,1)
INSERT INTO [Order] VALUES('000162','20170118','Dirección:Av. Primavera N° 1878, Santiago de Surco','Cerca al Molicentro ',5,2,1,1)
INSERT INTO [Order] VALUES('000163','20170405','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Al costado del Jockey Plaza',1,2,1,3)
INSERT INTO [Order] VALUES('000164','20170216','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Frente Huaca Melgarejo',2,1,2,1)
INSERT INTO [Order] VALUES('000165','20170310','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Frente al parque Kenedy',4,2,1,3)
INSERT INTO [Order] VALUES('000166','20170206','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Frente Huaca Melgarejo',1,2,1,1)
INSERT INTO [Order] VALUES('000167','20170324','Dirección:Av. Primavera N° 1878, Santiago de Surco','Dentro del Megaplaza de los olivos',2,1,2,1)
INSERT INTO [Order] VALUES('000168','20170308','Dirección: Av. La Marina N° 2941','Frente Huaca Melgarejo',4,1,2,1)
INSERT INTO [Order] VALUES('000169','20170405','Dirección:Av. Aviación Nº 3326 San Borja','Frente al parque Kenedy',2,2,1,3)
INSERT INTO [Order] VALUES('000170','20170211','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Frente Huaca Melgarejo',1,2,2,3)
INSERT INTO [Order] VALUES('000171','20170410','Dirección:Av. Aviación Nº 3326 San Borja','Campo de Marte de Loma',2,1,2,3)
INSERT INTO [Order] VALUES('000172','20170313','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Al costado del Parque del Olivar',1,1,2,2)
INSERT INTO [Order] VALUES('000173','20170120','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Altura de la Av Peru cuadra 10',3,1,2,1)
INSERT INTO [Order] VALUES('000174','20170401','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Cerca al Molicentro ',1,2,1,2)
INSERT INTO [Order] VALUES('000175','20170220','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Frente Huaca Melgarejo',5,2,2,3)
INSERT INTO [Order] VALUES('000176','20170305','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Al costado del Jockey Plaza',3,2,2,3)
INSERT INTO [Order] VALUES('000177','20170323','Dirección:Av. Petít Thouars N° 4975, Miraflores','Altura de la Av Peru cuadra 10',5,2,2,1)
INSERT INTO [Order] VALUES('000178','20170408','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Frente al parque Kenedy',5,1,2,3)
INSERT INTO [Order] VALUES('000179','20170122','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Frente Huaca Melgarejo',4,1,1,3)
INSERT INTO [Order] VALUES('000180','20170412','Dirección: Calle Primavera Nº200','Campo de Marte de Loma',1,2,2,2)
INSERT INTO [Order] VALUES('000181','20170215','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Frente Huaca Melgarejo',2,1,2,1)
INSERT INTO [Order] VALUES('000182','20170318','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Dentro del Megaplaza de los olivos',4,1,2,3)
INSERT INTO [Order] VALUES('000183','20170303','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Cerca al Molicentro ',5,1,1,3)
INSERT INTO [Order] VALUES('000184','20170409','Dirección:Av. Javier Prado Este 183 - San Isidro','Cerca al Molicentro ',1,2,2,3)
INSERT INTO [Order] VALUES('000185','20170413','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Al costado del Jockey Plaza',3,1,1,2)
INSERT INTO [Order] VALUES('000186','20170312','Dirección: Av. Tupac Amaru Nº 299','Al costado del Parque del Olivar',2,2,2,1)
INSERT INTO [Order] VALUES('000187','20170215','Dirección:Centro Financiero, Nivel 1 , (Mezzanine del Centro de Atención Surcano de la Municipalidad','Al costado del Parque del Olivar',3,1,2,2)
INSERT INTO [Order] VALUES('000188','20170118','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Club el Bosque La molina',1,1,2,3)
INSERT INTO [Order] VALUES('000189','20170316','Dirección:Av. Aviación Nº 3326 San Borja','Frente al parque Kenedy',3,2,2,3)
INSERT INTO [Order] VALUES('000190','20170409','Dirección:Centro Financiero, Nivel 1 , (Mezzanine del Centro de Atención Surcano de la Municipalidad','Cerca al Molicentro ',2,2,2,1)
INSERT INTO [Order] VALUES('000191','20170422','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Frente Huaca Melgarejo',5,2,1,2)
INSERT INTO [Order] VALUES('000192','20170219','Dirección: Calle Primavera Nº200','Cerca al Molicentro ',5,2,2,3)
INSERT INTO [Order] VALUES('000193','20170202','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Al costado del Jockey Plaza',3,2,2,3)
INSERT INTO [Order] VALUES('000194','20170421','Dirección:Av. Petít Thouars N° 4975, Miraflores','Frente Huaca Melgarejo',5,2,2,2)
INSERT INTO [Order] VALUES('000195','20170211','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Campo de Marte de Loma',2,2,2,1)
INSERT INTO [Order] VALUES('000196','20170123','Dirección:Av. Javier Prado Este 183 - San Isidro','Altura de la Av Peru cuadra 10',1,1,2,2)
INSERT INTO [Order] VALUES('000197','20170412','Dirección: Calle Primavera Nº200','Campo de Marte de Loma',1,2,1,2)
INSERT INTO [Order] VALUES('000198','20170324','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Frente Huaca Melgarejo',5,2,2,2)
INSERT INTO [Order] VALUES('000199','20170122','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Frente al parque Kenedy',3,1,2,3)
INSERT INTO [Order] VALUES('000200','20170417','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Campo de Marte de Loma',3,2,1,3)
INSERT INTO [Order] VALUES('000201','20170217','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Al costado del Parque del Olivar',3,1,1,2)
INSERT INTO [Order] VALUES('000202','20170301','Dirección:Av. La Molina 2850','Dentro del Megaplaza de los olivos',2,2,1,2)
INSERT INTO [Order] VALUES('000203','20170324','Dirección:Av. Petít Thouars N° 4975, Miraflores','Frente Huaca Melgarejo',1,2,1,1)
INSERT INTO [Order] VALUES('000204','20170307','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Cerca al Molicentro ',2,1,2,1)
INSERT INTO [Order] VALUES('000205','20170327','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Al costado del Parque del Olivar',1,2,2,2)
INSERT INTO [Order] VALUES('000206','20170119','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Frente Huaca Melgarejo',2,1,1,3)
INSERT INTO [Order] VALUES('000207','20170321','Dirección:Av. Primavera N° 1878, Santiago de Surco','Al costado del Jockey Plaza',4,1,1,2)
INSERT INTO [Order] VALUES('000208','20170403','Dirección: Av. La Marina N° 2941','Frente al parque Kenedy',3,1,1,2)
INSERT INTO [Order] VALUES('000209','20170411','Dirección: Av. Benavides Nº 3751-3757','Frente al parque Kenedy',4,1,1,2)
INSERT INTO [Order] VALUES('000210','20170304','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Frente al parque Kenedy',1,2,2,1)
INSERT INTO [Order] VALUES('000211','20170403','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Club el Bosque La molina',3,1,2,2)
INSERT INTO [Order] VALUES('000212','20170218','Dirección: Av. Tupac Amaru Nº 299','Al costado del Parque del Olivar',1,1,2,2)
INSERT INTO [Order] VALUES('000213','20170209','Dirección:Av. Petít Thouars N° 4975, Miraflores','Frente Huaca Melgarejo',3,1,2,2)
INSERT INTO [Order] VALUES('000214','20170330','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Cerca al Molicentro ',2,2,1,2)
INSERT INTO [Order] VALUES('000215','20170211','Dirección:Av. La Molina 2850','Altura de la Av Peru cuadra 10',5,1,1,1)
INSERT INTO [Order] VALUES('000216','20170113','Dirección:Av. Aviación Nº 3326 San Borja','Frente Huaca Melgarejo',5,1,1,2)
INSERT INTO [Order] VALUES('000217','20170304','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Al costado del Jockey Plaza',2,1,1,2)
INSERT INTO [Order] VALUES('000218','20170208','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Cerca al Molicentro ',2,1,1,1)
INSERT INTO [Order] VALUES('000219','20170205','Dirección: Av. La Marina N° 2941','Frente Huaca Melgarejo',5,2,2,2)
INSERT INTO [Order] VALUES('000220','20170125','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Club el Bosque La molina',3,2,1,3)
INSERT INTO [Order] VALUES('000221','20170401','Dirección:Mz. P Lt.17 GrupoResd.4, Sector: 6 av. Pastor Sevilla, entre la av. César Vallejo y Juan V','Dentro del Megaplaza de los olivos',3,2,1,1)
INSERT INTO [Order] VALUES('000222','20170314','Dirección:Av. Javier Prado Este 183 - San Isidro','Dentro del Megaplaza de los olivos',1,2,2,2)
INSERT INTO [Order] VALUES('000223','20170313','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Altura de la Av Peru cuadra 10',4,2,1,1)
INSERT INTO [Order] VALUES('000224','20170207','Dirección:Av. Javier Prado Este 183 - San Isidro','Cerca al Molicentro ',3,2,1,2)
INSERT INTO [Order] VALUES('000225','20170218','Dirección:Av. Petit Thouars Nº 4432 (Esquina con Pasaje Payán)','Dentro del Megaplaza de los olivos',4,2,2,2)
INSERT INTO [Order] VALUES('000226','20170214','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Dentro del Megaplaza de los olivos',3,1,2,2)
INSERT INTO [Order] VALUES('000227','20170205','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Campo de Marte de Loma',4,2,2,2)
INSERT INTO [Order] VALUES('000228','20170201','Dirección:Av. Primavera N° 1878, Santiago de Surco','Dentro del Megaplaza de los olivos',3,1,1,2)
INSERT INTO [Order] VALUES('000229','20170420','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Altura de la Av Peru cuadra 10',1,1,2,2)
INSERT INTO [Order] VALUES('000230','20170131','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Al costado del Jockey Plaza',1,2,1,3)
INSERT INTO [Order] VALUES('000231','20170319','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Club el Bosque La molina',5,2,1,2)
INSERT INTO [Order] VALUES('000232','20170422','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Frente Huaca Melgarejo',2,1,2,2)
INSERT INTO [Order] VALUES('000233','20170301','Dirección:Av. Javier Prado Este 183 - San Isidro','Club el Bosque La molina',5,2,1,1)
INSERT INTO [Order] VALUES('000234','20170405','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Al costado del Jockey Plaza',2,1,1,3)
INSERT INTO [Order] VALUES('000235','20170313','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Campo de Marte de Loma',2,2,2,1)
INSERT INTO [Order] VALUES('000236','20170122','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Campo de Marte de Loma',5,1,1,2)
INSERT INTO [Order] VALUES('000237','20170217','Dirección:Av. Aviación Nº 3326 San Borja','Al costado del Jockey Plaza',3,1,1,1)
INSERT INTO [Order] VALUES('000238','20170420','Dirección: Calle Primavera Nº200','Al costado del Jockey Plaza',1,2,1,1)
INSERT INTO [Order] VALUES('000239','20170313','Dirección: Av. La Marina N° 2941','Dentro del Megaplaza de los olivos',1,1,1,2)
INSERT INTO [Order] VALUES('000240','20170221','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Campo de Marte de Loma',5,1,1,1)
INSERT INTO [Order] VALUES('000241','20170410','Dirección:Av. La Molina 2850','Al costado del Jockey Plaza',2,1,1,2)
INSERT INTO [Order] VALUES('000242','20170301','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Frente al parque Kenedy',4,2,2,3)
INSERT INTO [Order] VALUES('000243','20170129','Dirección:Av. Javier Prado Este 183 - San Isidro','Dentro del Megaplaza de los olivos',2,2,2,2)
INSERT INTO [Order] VALUES('000244','20170305','Dirección: Jr. Graú Nº 483 Distrito San Vicente','Cerca al Molicentro ',5,1,1,1)
INSERT INTO [Order] VALUES('000245','20170403','Dirección:Av. La Molina 2850','Al costado del Jockey Plaza',2,2,1,2)
INSERT INTO [Order] VALUES('000246','20170306','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Frente al parque Kenedy',3,1,2,3)
INSERT INTO [Order] VALUES('000247','20170322','Dirección:Av. Aviación Nº 3326 San Borja','Frente Huaca Melgarejo',4,2,2,3)
INSERT INTO [Order] VALUES('000248','20170302','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Frente al parque Kenedy',3,1,1,2)
INSERT INTO [Order] VALUES('000249','20170402','Dirección: Av. La Marina N° 2941','Club el Bosque La molina',5,1,2,1)
INSERT INTO [Order] VALUES('000250','20170119','Dirección:Av. La Molina 2850','Al costado del Jockey Plaza',4,1,2,3)
INSERT INTO [Order] VALUES('000251','20170121','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Altura de la Av Peru cuadra 10',1,2,2,2)
INSERT INTO [Order] VALUES('000252','20170404','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Frente Huaca Melgarejo',2,2,1,3)
INSERT INTO [Order] VALUES('000253','20170124','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Dentro del Megaplaza de los olivos',3,2,2,2)
INSERT INTO [Order] VALUES('000254','20170326','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Frente Huaca Melgarejo',2,2,1,1)
INSERT INTO [Order] VALUES('000255','20170122','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Club el Bosque La molina',5,1,2,2)
INSERT INTO [Order] VALUES('000256','20170126','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Campo de Marte de Loma',3,2,1,3)
INSERT INTO [Order] VALUES('000257','20170119','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Cerca al Molicentro ',2,1,2,1)
INSERT INTO [Order] VALUES('000258','20170412','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Frente Huaca Melgarejo',4,1,2,2)
INSERT INTO [Order] VALUES('000259','20170222','Dirección:Av. Primavera N° 1878, Santiago de Surco','Frente al parque Kenedy',5,1,2,3)
INSERT INTO [Order] VALUES('000260','20170404','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Dentro del Megaplaza de los olivos',2,2,2,2)
INSERT INTO [Order] VALUES('000261','20170202','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Altura de la Av Peru cuadra 10',4,1,1,1)
INSERT INTO [Order] VALUES('000262','20170324','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Al costado del Parque del Olivar',4,2,2,3)
INSERT INTO [Order] VALUES('000263','20170308','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Frente Huaca Melgarejo',4,2,1,2)
INSERT INTO [Order] VALUES('000264','20170113','Dirección:Av. Primavera N° 1878, Santiago de Surco','Altura de la Av Peru cuadra 10',4,2,2,3)
INSERT INTO [Order] VALUES('000265','20170129','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Cerca al Molicentro ',2,2,1,1)
INSERT INTO [Order] VALUES('000266','20170220','Dirección:Av. Petít Thouars N° 4975, Miraflores','Cerca al Molicentro ',5,1,2,1)
INSERT INTO [Order] VALUES('000267','20170413','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Club el Bosque La molina',1,2,2,2)
INSERT INTO [Order] VALUES('000268','20170121','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Al costado del Parque del Olivar',3,1,1,1)
INSERT INTO [Order] VALUES('000269','20170129','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Al costado del Jockey Plaza',3,1,1,1)
INSERT INTO [Order] VALUES('000270','20170212','Dirección: Calle Bernardo Alcedo Nº 415-Lince(lectura y copia de Títulos Archivados )','Cerca al Molicentro ',4,2,2,1)
INSERT INTO [Order] VALUES('000271','20170330','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Club el Bosque La molina',5,1,2,2)
INSERT INTO [Order] VALUES('000272','20170414','Dirección: Calle Primavera Nº200','Altura de la Av Peru cuadra 10',4,2,2,3)
INSERT INTO [Order] VALUES('000273','20170411','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Altura de la Av Peru cuadra 10',1,1,2,2)
INSERT INTO [Order] VALUES('000274','20170121','Dirección:Av. Aviación Nº 3326 San Borja','Campo de Marte de Loma',1,1,1,3)
INSERT INTO [Order] VALUES('000275','20170227','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Club el Bosque La molina',3,2,1,3)
INSERT INTO [Order] VALUES('000276','20170127','Dirección: Av. Benavides Nº 3751-3757','Frente al parque Kenedy',2,2,2,3)
INSERT INTO [Order] VALUES('000277','20170307','Dirección: Av. Tupac Amaru Nº 299','Al costado del Jockey Plaza',5,1,2,3)
INSERT INTO [Order] VALUES('000278','20170422','Dirección:Av. La Molina 2850','Al costado del Jockey Plaza',5,1,1,2)
INSERT INTO [Order] VALUES('000279','20170313','Dirección:Av. Javier Prado Este 183 - San Isidro','Cerca al Molicentro ',1,2,1,3)
INSERT INTO [Order] VALUES('000280','20170323','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Frente Huaca Melgarejo',5,1,1,3)
INSERT INTO [Order] VALUES('000281','20170305','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Al costado del Jockey Plaza',4,2,1,2)
INSERT INTO [Order] VALUES('000282','20170213','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Cerca al Molicentro ',2,2,2,3)
INSERT INTO [Order] VALUES('000283','20170216','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Dentro del Megaplaza de los olivos',4,1,2,3)
INSERT INTO [Order] VALUES('000284','20170123','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Al costado del Jockey Plaza',1,1,1,1)
INSERT INTO [Order] VALUES('000285','20170309','Dirección: Av. La Marina N° 2941','Frente al parque Kenedy',5,2,2,2)
INSERT INTO [Order] VALUES('000286','20170127','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Al costado del Parque del Olivar',4,1,1,1)
INSERT INTO [Order] VALUES('000287','20170120','Dirección:Av. Aviación Nº 3326 San Borja','Frente al parque Kenedy',2,2,1,2)
INSERT INTO [Order] VALUES('000288','20170329','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Al costado del Parque del Olivar',1,1,2,3)
INSERT INTO [Order] VALUES('000289','20170224','Dirección:Av. Aviación Nº 3326 San Borja','Frente Huaca Melgarejo',1,1,2,1)
INSERT INTO [Order] VALUES('000290','20170325','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Dentro del Megaplaza de los olivos',1,2,1,3)
INSERT INTO [Order] VALUES('000291','20170128','Dirección: Av. Tupac Amaru Nº 299','Frente Huaca Melgarejo',3,1,2,3)
INSERT INTO [Order] VALUES('000292','20170305','Dirección:Av. Aviación Nº 3326 San Borja','Club el Bosque La molina',1,1,2,2)
INSERT INTO [Order] VALUES('000293','20170217','Dirección:Av. Primavera N° 1878, Santiago de Surco','Al costado del Jockey Plaza',3,2,2,2)
INSERT INTO [Order] VALUES('000294','20170301','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Frente al parque Kenedy',3,2,2,1)
INSERT INTO [Order] VALUES('000295','20170214','Dirección:Jr. Washington Nº 1537Horarios: De 8:15 am. a 4:45 pm.Teléfono:433-2916 ','Club el Bosque La molina',5,2,1,1)
INSERT INTO [Order] VALUES('000296','20170313','Dirección:Av. La Molina 2850','Al costado del Parque del Olivar',5,2,1,1)
INSERT INTO [Order] VALUES('000297','20170307','Dirección:Av. Javier Prado Oeste Nº 305 esquina con Calle Los OlivosHorarios: De 8:15 am. a 4:45 pm.','Al costado del Parque del Olivar',2,1,2,2)
INSERT INTO [Order] VALUES('000298','20170122','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Frente Huaca Melgarejo',2,1,2,2)
INSERT INTO [Order] VALUES('000299','20170224','Dirección: Calle Primavera Nº200','Al costado del Parque del Olivar',5,1,2,2)
INSERT INTO [Order] VALUES('000300','20170121','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Al costado del Parque del Olivar',2,1,1,2)
INSERT INTO [Order] VALUES('000301','20170331','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Club el Bosque La molina',5,1,1,2)
INSERT INTO [Order] VALUES('000302','20170201','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Club el Bosque La molina',2,1,2,1)
INSERT INTO [Order] VALUES('000303','20170123','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Club el Bosque La molina',3,2,1,1)
INSERT INTO [Order] VALUES('000304','20170212','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Altura de la Av Peru cuadra 10',2,1,1,2)
INSERT INTO [Order] VALUES('000305','20170207','Dirección: Jr. Pardo y Aliaga N° 695, San Isidro','Altura de la Av Peru cuadra 10',4,2,2,3)
INSERT INTO [Order] VALUES('000306','20170216','Dirección: Centro Comercial Plaza Norte (cruce de Panamericana Norte y Av. Tomás Valle), independenc','Al costado del Parque del Olivar',3,1,1,3)
INSERT INTO [Order] VALUES('000307','20170223','Dirección:Urb. Las Virreynas, Mz C Lote 7-A','Campo de Marte de Loma',4,1,1,2)
INSERT INTO [Order] VALUES('000308','20170228','Dirección:Calle Los Quipus N° 225, Urb. Zárate (At. Cdra. 4 de la Av. Gran Chimú)','Altura de la Av Peru cuadra 10',3,2,2,2)
INSERT INTO [Order] VALUES('000309','20170309','Dirección: Av. Tupac Amaru Nº 299','Cerca al Molicentro ',2,1,1,1)
INSERT INTO [Order] VALUES('000310','20170220','Dirección:Av. Primavera N° 1878, Santiago de Surco','Cerca al Molicentro ',2,1,1,2)
INSERT INTO [Order] VALUES('000311','20170208','Dirección:Av. Abancay con Av. ColmenaHorarios:De 8:15 am. a 4:45 pm.Teléfono:311-2360 Axo. 1087 ','Club el Bosque La molina',2,1,2,1)
INSERT INTO [Order] VALUES('000312','20170421','Dirección:Jr. Baltazar Grados N° 701 y Av. Billinghurst N° 1129','Frente Huaca Melgarejo',1,1,1,1)
INSERT INTO [Order] VALUES('000313','20170202','Dirección:Av. Edgardo Rebagliati Nº 561. Jesús María.','Al costado del Jockey Plaza',3,2,1,1)
INSERT INTO [Order] VALUES('000314','20170331','Dirección:Av. Primavera N° 1878, Santiago de Surco','Altura de la Av Peru cuadra 10',3,2,2,3)
INSERT INTO [Order] VALUES('000315','20170310','Dirección:Av. La Molina 2850','Frente Huaca Melgarejo',1,1,2,3)
INSERT INTO [Order] VALUES('000316','20170307','Dirección: Av. Benavides Nº 3751-3757','Frente Huaca Melgarejo',5,1,1,3)
INSERT INTO [Order] VALUES('000317','20170207','Dirección:Av. Los Eucaliptos N°1250, Urb. Los Robles.','Club el Bosque La molina',3,2,1,3)
INSERT INTO [Order] VALUES('000318','20170117','Dirección: Calle Las Cucardas Nº 267, Urb. Residencial Huaral','Dentro del Megaplaza de los olivos',3,1,2,3)
INSERT INTO [Order] VALUES('000319','20170321','Dirección:Plaza de Armas de Ventanilla - entre calle 10 y 11, local Nº 187, mercado particular','Club el Bosque La molina',1,2,2,1)
INSERT INTO [Order] VALUES('000320','20170322','Dirección:Alfredo Mendiola Nº 5297 - Urb. Villa, Panamericana Norte alt. Km 18.5','Campo de Marte de Loma',5,2,1,2)
INSERT INTO [Order] VALUES('000321','20170204','Dirección:Av. Primavera N° 1878, Santiago de Surco','Club el Bosque La molina',5,2,2,1)


 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,1)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,2)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,3)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,4)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,5)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,6)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,7)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,8)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,9)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,10)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,11)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,12)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,13)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,14)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,15)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,16)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,17)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,18)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,19)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,20)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,21)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,22)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,23)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,24)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,25)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,26)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,27)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,28)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,29)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,30)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,31)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,32)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,33)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,34)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,35)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,36)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,37)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,38)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,39)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,40)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,41)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,42)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,43)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,44)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,45)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,46)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,47)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,48)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,49)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,50)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,51)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,52)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,53)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,54)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,55)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,56)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,57)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,58)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,59)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,60)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,61)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,62)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,63)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,64)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,65)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,66)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,67)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,68)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,69)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,70)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,71)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,72)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,73)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,74)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,75)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,76)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,77)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,78)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,79)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,80)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,81)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,82)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,83)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,84)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,85)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,86)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,87)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,88)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,89)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,90)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,91)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,92)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,93)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,94)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,95)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,96)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,97)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,98)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,99)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,100)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,101)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,102)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,103)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,104)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,105)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,106)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,107)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,108)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,109)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,110)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,111)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,112)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,113)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,114)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,115)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,116)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,117)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,118)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,119)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,120)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,121)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,122)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,123)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,124)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,125)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,126)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,127)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,128)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,129)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,130)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,131)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,132)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,133)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,134)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,135)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,136)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,137)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,138)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,139)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,140)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,141)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,142)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,143)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,144)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,145)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,146)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,147)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,148)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,149)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,150)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,151)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,152)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,153)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,154)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,155)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,156)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,157)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,158)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,159)
 INSERT INTO [OrderDetail] VALUES(40.0,40.0,1,3,160)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,161)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,162)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,163)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,164)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,165)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,166)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,167)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,168)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,169)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,170)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,171)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,172)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,173)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,174)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,175)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,176)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,177)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,178)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,179)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,180)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,181)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,182)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,183)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,184)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,185)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,186)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,187)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,188)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,189)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,190)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,191)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,192)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,193)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,194)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,195)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,196)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,197)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,198)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,199)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,200)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,201)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,202)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,203)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,204)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,205)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,206)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,207)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,208)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,209)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,210)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,211)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,212)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,213)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,214)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,215)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,216)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,217)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,218)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,219)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,220)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,221)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,222)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,223)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,224)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,225)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,226)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,227)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,228)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,229)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,230)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,231)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,232)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,233)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,234)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,235)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,236)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,237)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,238)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,239)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,240)
 INSERT INTO [OrderDetail] VALUES(48.0,48.0,1,19,241)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,242)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,243)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,244)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,245)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,246)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,247)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,248)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,249)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,250)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,251)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,252)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,253)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,254)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,255)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,256)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,257)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,258)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,259)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,260)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,261)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,262)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,263)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,264)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,265)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,266)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,267)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,268)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,269)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,270)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,271)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,272)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,273)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,274)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,275)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,276)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,277)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,278)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,279)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,280)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,281)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,282)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,283)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,284)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,285)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,286)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,287)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,288)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,289)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,290)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,291)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,292)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,293)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,294)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,295)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,296)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,297)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,298)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,299)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,300)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,301)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,302)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,303)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,304)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,305)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,306)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,307)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,308)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,309)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,310)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,311)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,312)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,313)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,314)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,315)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,316)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,317)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,318)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,319)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,320)
 INSERT INTO [OrderDetail] VALUES(54.0,54.0,1,12,321)

