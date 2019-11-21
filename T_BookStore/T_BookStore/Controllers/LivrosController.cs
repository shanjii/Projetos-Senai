using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using T_BookStore.Domains;
using T_BookStore.Repositories;

namespace T_BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        LivrosRepository livrosRepository = new LivrosRepository();
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(livrosRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult Cadastrar(LivrosDomain livrosDomain)
        {
            livrosRepository.Cadastrar(livrosDomain);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(livrosRepository.BuscarId(id));
        }
        [HttpPut]
        public IActionResult Atualizar(LivrosDomain livrosDomain)
        {
            livrosRepository.Atualizar(livrosDomain);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            livrosRepository.Deletar(id);
            return Ok();
        }

    }
}