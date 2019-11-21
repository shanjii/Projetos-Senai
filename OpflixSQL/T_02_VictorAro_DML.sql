insert into TipoUser (TipoUser) VALUES ('Administrador'), ('Cliente');
insert into Categoria (Categoria) values ('Ação'), ('Aventura'), ('Suspense');
insert into Tipo (Tipo) values ('Filme'), ('Série');
insert into Conteudo (Titulo, CategoriaID, TipoID, Sinopse, Duração) values ('Filme 1',1,2,'Sinopse 1','----'),('Filme 2',2,2,'Sinopse 2','----'),('Filme 3',3,1,'Sinopse 3','----');
insert into Usuario (NomeUsuario, TipoUserID, Favorito) values ('Victor',2,1),('Pedro',2,2),('João',2,3);