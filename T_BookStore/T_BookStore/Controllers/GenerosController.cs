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
    public class GenerosController : ControllerBase
    {
        GenerosRepository generosRepository = new GenerosRepository();
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(generosRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult Cadastrar(GenerosDomain generosDomain)
        {
            generosRepository.Cadastrar(generosDomain);
            return Ok();
        }
    }
}