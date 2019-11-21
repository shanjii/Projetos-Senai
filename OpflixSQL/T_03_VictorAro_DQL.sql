select * from Usuario
select * from Conteudo
select * from Tipo
select * from Categoria
select * from TipoUser
select Conteudo.Titulo, Categoria.Categoria, Tipo.Tipo, Conteudo.Sinopse, Conteudo.Duração from Conteudo JOIN  Categoria ON Categoria.CategoriaID = Conteudo.CategoriaID
 join  Tipo ON Tipo.TipoID = Conteudo.TipoID
 select Usuario.NomeUsuario as Usuario, TipoUser.TipoUser as Tipo, Conteudo.Titulo as Favorito from Usuario join TipoUser on TipoUser.TipoUserID = Usuario.TipoUserID
 join Conteudo on Conteudo.ConteudoID = Usuario.Favorito;