using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpFlixFinal.Domains;
using OpFlixFinal.Repositories;

namespace OpFlixFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        LancamentoRepository lancamentoRepository = new LancamentoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(lancamentoRepository.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamentos)
        {
            lancamentoRepository.Cadastrar(lancamentos);
            return Ok();
            
        }
    }
}