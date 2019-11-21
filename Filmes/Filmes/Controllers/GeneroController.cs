using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Domains;
using Filmes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(generoRepository.Listar());
        }

        [HttpGet ("{id}")]
        public IActionResult ListarId(int id)
        {
            return Ok(generoRepository.BuscarId(id));
        }
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            generoRepository.Cadastrar(generoDomain);
            return Ok();
        }
    }
}