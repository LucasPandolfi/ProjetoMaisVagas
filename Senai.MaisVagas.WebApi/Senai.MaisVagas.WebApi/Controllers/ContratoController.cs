using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MaisVagas.WebApi.Interfaces;
using Senai.MaisVagas.WebApi.Repositories;

namespace Senai.MaisVagas.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class ContratoController : ControllerBase
    {
        private IContratoRepository _contratoRepository;

        public ContratoController()
        {
            _contratoRepository = new ContratoRepository();
        }

        /// <summary>
        /// Lista todos as contrato
        /// </summary>
        /// <returns>Uma lista de instituições e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de contratos</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        public IActionResult ListarTodosContratos()
        {
            try
            {
                return Ok(_contratoRepository.ListarContrato());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
    }
}
