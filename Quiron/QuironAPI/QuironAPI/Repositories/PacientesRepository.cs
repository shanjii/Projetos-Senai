using QuironAPI.Domains;
using QuironAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuironAPI.Repositories
{
    public class PacientesRepository : IPacienteRepository
    {
        public List<Pacientes> Listar()
        {
            using (QuironContext context = new QuironContext())
            {
                return context.Pacientes.ToList();
            }
        }

        public void Cadastrar(Pacientes pacientes)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

    }
}
