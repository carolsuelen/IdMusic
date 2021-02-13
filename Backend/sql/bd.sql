CREATE DATABASE Instagama;
USE Instagama;
--Criação do Database


--Criação das tabelas
CREATE TABLE dbo.Genero (
   Id int IDENTITY(1,1) NOT NULL,
   Descricao varchar(50) NOT NULL,
   CONSTRAINT PK_Genero_Id PRIMARY KEY CLUSTERED (Id)
)

CREATE TABLE dbo.Usuario (
	Id int IDENTITY(1,1) NOT NULL,
	GeneroId int NOT NULL,
	Nome varchar(250) NOT NULL,
	Email varchar(100) NOT NULL,
	Senha varchar(200) NOT NULL,
	DataNascimento DateTime NOT NULL,
	Foto varchar(max) NOT NULL,
	FotoCapa varchar (max) NOT NULL,
	Biografia varchar (500) NOT NULL,
	Banda varchar (max) NOT NULL 
	CONSTRAINT PK_Usuario_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Usuario
   ADD CONSTRAINT FK_Usuario_Genero FOREIGN KEY (GeneroId)
      REFERENCES dbo.Genero (Id)


CREATE TABLE dbo.Postagem (
   Id int IDENTITY(1,1) NOT NULL,
   UsuarioId int NOT NULL,
   Texto varchar(250) NOT NULL,
   Criacao DateTime NOT NULL,
   CONSTRAINT PK_Postagem_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Postagem
   ADD CONSTRAINT FK_Postagem_Usuario FOREIGN KEY (UsuarioId)
      REFERENCES dbo.Usuario (Id)
	  
	  
CREATE TABLE dbo.Comentario (
   Id int IDENTITY(1,1) NOT NULL,
   UsuarioId int NOT NULL,
   PostagemId int NOT NULL,
   Texto varchar(250) NOT NULL,
   Criacao DateTime NOT NULL,
   CONSTRAINT PK_Comentario_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Comentario
   ADD CONSTRAINT FK_Comentario_Usuario FOREIGN KEY (UsuarioId)
      REFERENCES dbo.Usuario (Id)
	  
ALTER TABLE dbo.Comentario
   ADD CONSTRAINT FK_Comentario_Postagem FOREIGN KEY (PostagemId)
      REFERENCES dbo.Postagem (Id)
	  
CREATE TABLE dbo.Curtidas (
   Id int IDENTITY(1,1) NOT NULL,
   UsuarioId int NOT NULL,
   PostagemId int NOT NULL,
   CONSTRAINT PK_Curtidas_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Curtidas
   ADD CONSTRAINT FK_Curtidas_Usuario FOREIGN KEY (UsuarioId)
      REFERENCES dbo.Usuario (Id)
	  
ALTER TABLE dbo.Curtidas
   ADD CONSTRAINT FK_Curtidas_Postagem FOREIGN KEY (PostagemId)
      REFERENCES dbo.Postagem (Id)

CREATE TABLE dbo.Amigos (
   Id int IDENTITY(1,1) NOT NULL,
   UsuarioId int NOT NULL,
   AmigoId int NOT NULL,
   CONSTRAINT PK_Amigos_Id PRIMARY KEY CLUSTERED (Id)
)

ALTER TABLE dbo.Amigos
   Id int IDENTITY(1,1) NOT NULL,
   UsuarioId int NOT NULL,
   UsuarioAmigoId int NOT NULL,
   CONSTRAINT PK_Amigos_Id PRIMARY KEY CLUSTERED(Id),
	CONSTRAINT FK_Amigos_Usuario_Amigo FOREIGN KEY(UsuarioAmigoId)
		REFERENCES dbo.Usuario(Id),
	CONSTRAINT FK_Amigos_Usuario FOREIGN KEY(UsuarioId)
		REFERENCES dbo.Usuario (Id)










