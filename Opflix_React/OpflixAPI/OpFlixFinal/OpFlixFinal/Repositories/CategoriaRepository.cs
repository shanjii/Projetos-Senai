using OpFlixFinal.Domains;
using OpFlixFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpFlixFinal.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public Categorias BuscarId(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Cadastrar(Categorias categorias)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Categorias.Add(categorias);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Categorias categorias = ctx.Categorias.Find(id);
                ctx.Remove(categorias);
                ctx.SaveChanges();
            }
        }

        public List<Categorias> Listar()
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Categorias.ToList();
            }
        }
    }
}
