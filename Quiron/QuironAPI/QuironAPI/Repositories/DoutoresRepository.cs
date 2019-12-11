using Microsoft.EntityFrameworkCore;
using QuironAPI.Domains;
using QuironAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuironAPI
{
    public class DoutoresRepository : IDoutorRepository
    {
        public List<Doutores> Listar()
        {
            using (QuironContext context = new QuironContext())
            {
                return context.Doutores.Include(l => l.PacientesNavigation).ToList();
            }
        }

        public void Cadastrar(Doutores doutores)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

    }
}
