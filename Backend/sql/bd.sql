CREATE DATABASE IdMusic;
USE IdMusic;
--Criação do Database


--Criação das tabelas
CREATE TABLE dbo.Genre (
   Id int IDENTITY(1,1) NOT NULL,
   Description varchar(50) NOT NULL,
   CONSTRAINT PK_Genre_Id PRIMARY KEY CLUSTERED (Id)
)

CREATE TABLE dbo.Client (
	Id int IDENTITY(1,1) NOT NULL,
	GenreId int NOT NULL,
	Name varchar(250) NOT NULL,
	Email varchar(100) NOT NULL,
	Password varchar(200) NOT NULL,
	Birthday DateTime NOT NULL,
	Photo varchar(max) NOT NULL,
	PhotoCapa varchar (max) NOT NULL,
	Biografy varchar (500) NOT NULL,
	Band varchar (max) NOT NULL 
	CONSTRAINT PK_Client_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Client
   ADD CONSTRAINT FK_Client_Genre FOREIGN KEY (GenreId)
      REFERENCES dbo.Genre (Id)


CREATE TABLE dbo.Postage (
   Id int IDENTITY(1,1) NOT NULL,
   ClientId int NOT NULL,
   Text varchar(250) NOT NULL,
   Photo varchar(1000) NULL,
   Video varchar (1000) NULL,
   Creation DateTime NOT NULL,
   CONSTRAINT PK_Postage_Id PRIMARY KEY CLUSTERED (Id)
)
ALTER TABLE dbo.Postage
   ADD CONSTRAINT FK_Postage_Client FOREIGN KEY (ClientId)
      REFERENCES dbo.Client (Id)
	  
CREATE TABLE dbo.Commentary (
   Id int IDENTITY(1,1) NOT NULL,
   ClientId int NOT NULL,
   PostageId int NOT NULL,
   Text varchar(250) NOT NULL,
   Creation DateTime NOT NULL,
   CONSTRAINT PK_Commentary_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Commentary
   ADD CONSTRAINT FK_Commentary_Client FOREIGN KEY (ClientId)
      REFERENCES dbo.Client (Id)
	  
ALTER TABLE dbo.Commentary
   ADD CONSTRAINT FK_Commentary_Postage FOREIGN KEY (PostageId)
      REFERENCES dbo.Postage (Id)
	  
CREATE TABLE dbo.Likes (
   Id int IDENTITY(1,1) NOT NULL,
   ClientId int NOT NULL,
   PostageId int NOT NULL,
   CONSTRAINT PK_Likes_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Likes
   ADD CONSTRAINT FK_Likes_Client FOREIGN KEY (ClientId)
      REFERENCES dbo.Client (Id)
	  
ALTER TABLE dbo.Likes
   ADD CONSTRAINT FK_Likes_Postage FOREIGN KEY (PostageId)
      REFERENCES dbo.Postage (Id)

CREATE TABLE dbo.Friends (
   Id int IDENTITY(1,1) NOT NULL,
   ClientId int NOT NULL,
   FriendId int NOT NULL,
   CONSTRAINT PK_Friends_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Friends
   Id int IDENTITY(1,1) NOT NULL,
   ClientId int NOT NULL,
   ClientFriendId int NOT NULL,
   CONSTRAINT PK_Friends_Id PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT FK_Friends_Client_Friend FOREIGN KEY(ClientFriendId)
		REFERENCES dbo.Client(Id),
	CONSTRAINT FK_Friends_Client FOREIGN KEY(ClientId)
		REFERENCES dbo.Client (Id)










