using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Optus2.Domains;
using Optus2.Repositories;

namespace Optus2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstiloController : ControllerBase
    {
        EstiloRepository estiloRepository = new EstiloRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepository.Listar());
        }
        [HttpPost]
        public void Cadastrar (Estilos estilo)
        {
            estiloRepository.Cadastrar(estilo);
        }
        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                // pesquisar uma categoria
                Categorias CategoriaBuscada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);
                // caso nao encontre, not found
                if (CategoriaBuscada == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo pq quero
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ah, não. By - Pedro." });
            }
        }
    }
}