using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roman.Domains;
using Roman.Repositories;

namespace Roman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepositorio usuarioRepository = new UsuarioRepositorio();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuarios)
        {
            usuarioRepository.Cadastrar(usuarios);
            return Ok();
        }
    }
}