using QuironAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuironAPI.Interfaces
{
    public interface IDoutorRepository
    {
        List<Doutores> Listar();
        void Cadastrar(Doutores doutores);
        void Deletar(int id);
    }
}
