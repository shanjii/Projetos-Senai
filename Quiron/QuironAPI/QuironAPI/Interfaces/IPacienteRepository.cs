using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuironAPI.Domains;

namespace QuironAPI.Interfaces
{
    public interface IPacienteRepository
    {
        List<Pacientes> Listar();
        void Cadastrar(Pacientes pacientes);
        void Deletar(int id);
    }
}
