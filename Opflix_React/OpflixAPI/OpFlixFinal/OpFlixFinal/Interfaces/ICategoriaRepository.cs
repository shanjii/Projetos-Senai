using OpFlixFinal.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpFlixFinal.Interfaces
{
    interface ICategoriaRepository
    {
        List<Categorias> Listar();
        void Cadastrar(Categorias categorias);
        Categorias BuscarId(int id);
        void Deletar(int id);
    }
}
