using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roman.Domains;
using RomanApi.Repositories;

namespace RomanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {

        ProjetoRepositorio projetoRepository = new ProjetoRepositorio();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(projetoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Projetos projetos)
        {
            projetoRepository.Cadastrar(projetos);
            return Ok();
        }
    }
}