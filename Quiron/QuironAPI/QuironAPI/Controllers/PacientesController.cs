using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuironAPI.Repositories;

namespace QuironAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        PacientesRepository pacientesRepository = new PacientesRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(pacientesRepository.Listar());
        }
    }
}