using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpFlixFinal.Domains;
using OpFlixFinal.Repositories;

namespace OpFlixFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        CategoriaRepository categoriaRepository = new CategoriaRepository();

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(categoriaRepository.Listar());
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categorias)
        {
            categoriaRepository.Cadastrar(categorias);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(categoriaRepository.BuscarId(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Deletar(int id)
        {
            categoriaRepository.Deletar(id);
            return Ok();
        }
    }
}