using Microsoft.AspNetCore.Mvc;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using Senai.MaisVagas.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        public IContratoRepository _contrato;

        public ContratoController()
        {
            _contrato = new ContratoRepository();
        }
        [HttpPost]
        public IActionResult Post(Contrato contrato)
        {
            _contrato.CadastrarContrato(contrato);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_contrato.Get());
        }
    }
}
