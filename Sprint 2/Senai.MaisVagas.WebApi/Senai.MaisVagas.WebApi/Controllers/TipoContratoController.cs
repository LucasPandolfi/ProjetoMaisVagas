using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TipoContratoController : ControllerBase
    {
        ITipoContratoRepository _tipoContratoRepository;

        public TipoContratoController()
        {
            _tipoContratoRepository = new TipoContratoRepository();
        }

        /// <summary>
        /// Lista todos os tipos contratos
        /// </summary>
        /// <returns>lista de tipo contrato e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de tipo contrato</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        public IActionResult ListarTodosCursos()
        {
            try
            {
                return Ok(_tipoContratoRepository.ListarTipoContratos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTipoContrato(int id)
        {
            try
            {
                TipoContrato tipoContratoBuscado = _tipoContratoRepository.ListarPorId(id);

                if (tipoContratoBuscado != null)
                {
                    _tipoContratoRepository.DeletarTipoContrato(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum tipo contrato encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo contrato
        /// </summary>
        /// <param name="novoTipoContrato">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost]
        public IActionResult CadastrarTipoContrato(TipoContrato novoTipoContrato)
        {
            try
            {
                _tipoContratoRepository.CadastrarTipoContrato(novoTipoContrato);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
