create table TipoUser
(TipoUserID INT PRIMARY KEY IDENTITY,
TipoUser VARCHAR (200) NOT NULL UNIQUE
);
create table Categoria
(
CategoriaID INT PRIMARY KEY IDENTITY,
Categoria VARCHAR (200) NOT NULL 
);
create table Tipo
(
TipoID INT PRIMARY KEY IDENTITY,
Tipo VARCHAR (200)  NOT NULL
);
create table Conteudo
(
ConteudoID INT PRIMARY KEY IDENTITY,
CategoriaID INT FOREIGN KEY References Categoria(CategoriaID),
TipoID INT FOREIGN KEY References Tipo(TipoID),
Titulo VARCHAR (200) UNIQUE NOT NULL,
Sinopse VARCHAR (200),
Duração VARCHAR (200)
);
create table Usuario
(
UserID INT PRIMARY KEY IDENTITY,
TipoUserID INT FOREIGN KEY REFERENCES TipoUser(TipoUserID),
NomeUsuario VARCHAR (200) NOT NULL,
Favorito INT FOREIGN KEY REFERENCES Conteudo(ConteudoID)
);