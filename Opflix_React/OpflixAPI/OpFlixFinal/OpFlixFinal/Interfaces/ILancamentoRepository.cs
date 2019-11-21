using OpFlixFinal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpFlixFinal.Interfaces
{
    interface ILancamentoRepository
    {
        List<Lancamentos> Listar();
        void Cadastrar(Lancamentos lancamentos);
        Lancamentos BuscarId(int id);
        void Deletar(int id);
    }
}
