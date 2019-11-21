using Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanApi.Repositories
{
    public class ProjetoRepositorio
    {
        public List<Projetos> Listar()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Projetos.ToList();
            }
        }
        public void Cadastrar(Projetos projetos)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Projetos.Add(projetos);
                ctx.SaveChanges();
            }
        }
    }
}
