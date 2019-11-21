using Optus2.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optus2.Repositories
{
    public class EstiloRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }
        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // insert into categorias (nome) values (@nome);
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscada = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);
                // update categorias set nome = @nome
                EstiloBuscada.Nome = estilo.Nome;
                // insert - add, delete - remove, update - update
                ctx.Estilos.Update(EstiloBuscada);
                // efetivar
                ctx.SaveChanges();
            }
        }
    }
}
