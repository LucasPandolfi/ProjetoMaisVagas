using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using Senai.MaisVagas.WebApi.Repositories;

namespace Senai.MaisVagas.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EmpresaController : ControllerBase
    {
        IEmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        /// <summary>
        /// Lista todas as empresas
        /// </summary>
        /// <returns>lista de empresas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de empresas</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_empresaRepository.ListarEmpresas());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        /// <summary>
        /// Lista todas as empresas cadastradas
        /// </summary>
        /// <returns>lista de empresas cadastradas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de empresas cadastradas</response>
        /// <response code="404">Retorna o erro gerado</response>
        [HttpGet("Verificacao/{status}")]
        public IActionResult GetEmpresaCadastrada(bool status)
        {
            try
            {
                return Ok(_empresaRepository.ListarEmpresasCadastradas(status));
            }
            catch (Exception error)
            {
                return NotFound(error);
            }

        }

        [HttpPost]
        public IActionResult Post(Empresa novaEmpresa)
        {
            try
            {
                _empresaRepository.CadastrarEmpresa(novaEmpresa);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
