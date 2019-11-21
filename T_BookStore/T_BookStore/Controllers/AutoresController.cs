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
    public class AutoresController : ControllerBase
    {
        AutoresRepository autoresRepository = new AutoresRepository();
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(autoresRepository.ListarTodos());
        }
        [HttpPost]
        public IActionResult Cadastrar(AutoresDomain autoresDomain)
        {
            autoresRepository.Cadastrar(autoresDomain);
            return Ok();
        }
    }
}