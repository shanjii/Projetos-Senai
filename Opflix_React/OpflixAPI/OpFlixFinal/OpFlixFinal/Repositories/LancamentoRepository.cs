using Microsoft.EntityFrameworkCore;
using OpFlixFinal.Domains;
using OpFlixFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpFlixFinal.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {

        public Lancamentos BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Lancamentos lancamentos)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Lancamentos.Add(lancamentos);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Lancamentos> Listar()
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Lancamentos.Include(x => x.CategoriaNavigation).ToList();
            }
        }
    }
}
