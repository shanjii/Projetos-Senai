using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFuncionarios.Domains;
using ProjetoFuncionarios.Repositories;

namespace ProjetoFuncionarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        //using rep
        FuncionariosRepository funcionariosRepository = new FuncionariosRepository();
        //--------------------------------------------------------------------------//

        [HttpGet]
        public IEnumerable<FuncionariosDomain> ListarTudo()
        {
            return funcionariosRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult ListarId(int id)
        {
            FuncionariosDomain funcionariosDomain = funcionariosRepository.BuscarId(id);
            if(funcionariosDomain == null)
            {
                return NotFound();
            }
            return Ok(funcionariosDomain);
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionariosDomain)
        {
            funcionariosRepository.Cadastrar(funcionariosDomain);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionariosRepository.Deletar(id);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Atualizar(FuncionariosDomain funcionariosDomain)
        {
            funcionariosRepository.Atualizar(funcionariosDomain);
            return Ok();
        }

    }
}