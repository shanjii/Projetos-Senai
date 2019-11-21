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
    public class UsuarioController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            usuarioRepository.Cadastrar(usuario);
            return Ok();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(usuarioRepository.BuscarId(id));
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Deletar(int id)
        {
            usuarioRepository.Deletar(id);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Atualizar(Usuarios usuarios)
        {
            usuarioRepository.Atualizar(usuarios);
            return Ok();
        }
    }
}