using OpFlixFinal.Domains;
using OpFlixFinal.Interfaces;
using OpFlixFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpFlixFinal.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public void Cadastrar(Usuarios usuario)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using(opflixContext ctx = new opflixContext())
            {
               return ctx.Usuarios.ToList();
            }
        }

        public Usuarios BuscarEmailSenha(LoginViewModel login)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                return usuario;
            }

        }

        public Usuarios BuscarId(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            }
        }

        public void Deletar(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios usuarios = ctx.Usuarios.Find(id);
                ctx.Remove(usuarios);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Usuarios usuario)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios usuarioBuscando = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);
                usuarioBuscando.NomeUsuario = usuario.NomeUsuario;
                ctx.Usuarios.Update(usuarioBuscando);
                ctx.SaveChanges();
            }
        }
    }
}
