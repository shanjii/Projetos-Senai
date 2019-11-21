using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        FilmesRepository filmesRepository = new FilmesRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(filmesRepository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult ListarId(int id)
        {
            return Ok(filmesRepository.BuscarId(id));
        }
    }
}