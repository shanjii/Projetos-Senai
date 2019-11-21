using OpFlixFinal.Domains;
using OpFlixFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpFlixFinal.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuarios> Listar();
        void Cadastrar(Usuarios usuario);
        Usuarios BuscarEmailSenha(LoginViewModel login);
        Usuarios BuscarId(int id);
        void Atualizar(Usuarios usuario);
        void Deletar(int id);
    }
}
