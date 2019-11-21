use T_Gufos

insert into Usuarios (Nome, Email, Senha, Permissao)
values ('Rayssa','rayssa@gmail.com','r123456','ADMINISTRADOR')

insert into Usuarios (Nome, Email, Senha, Permissao)
values ('asdasd','asd@gmail.com','r123456','ALUNO')

select * from Usuarios;

insert into Categorias (Nome)
values ('Jogos'),('Meetup'),('Futebol');

insert into Eventos (Título, Descricao, DataEvento, Localizacao, IdCategoria)
values ('Campeonato de ping pong','asdasd','2019-08-06T18:00:00','Asd',1);

select * from Eventos

insert into Presencas (IdEvento, IdUsuario) values (3,1);

select * from Presencas

