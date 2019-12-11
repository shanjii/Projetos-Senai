using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuironAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoutoresController : ControllerBase 
    {
        DoutoresRepository doutoresRepository = new DoutoresRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(doutoresRepository.Listar());
        }
    }
}