insert into TipoUser (TipoUser) VALUES ('Administrador'), ('Cliente');
insert into Categoria (Categoria) values ('A��o'), ('Aventura'), ('Suspense');
insert into Tipo (Tipo) values ('Filme'), ('S�rie');
insert into Conteudo (Titulo, CategoriaID, TipoID, Sinopse, Dura��o) values ('Filme 1',1,2,'Sinopse 1','----'),('Filme 2',2,2,'Sinopse 2','----'),('Filme 3',3,1,'Sinopse 3','----');
insert into Usuario (NomeUsuario, TipoUserID, Favorito) values ('Victor',2,1),('Pedro',2,2),('Jo�o',2,3);