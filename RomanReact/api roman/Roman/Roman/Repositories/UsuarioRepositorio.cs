using Roman.Domains;
using Roman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.Repositories
{

    public class UsuarioRepositorio
    {
        public List<Usuarios> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
        public void Cadastrar(Usuarios usuarios)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }
        public Usuarios BuscarEmailSenha(LoginViewModel login)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                return usuario;
            }

        }

    }

}

