using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Interfaces;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        public ILocalizacaoRepository LocalizacaoRepository { get; set; }
        public LocalizacaoController()
        {
            LocalizacaoRepository = new LocalizacaoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Localizacoes localizacoes)
        {
            try
            {
                LocalizacaoRepository.Cadastrar(localizacoes);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { mensagem = e.Message });
                throw;
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LocalizacaoRepository.Listar());
        }
    }
}

