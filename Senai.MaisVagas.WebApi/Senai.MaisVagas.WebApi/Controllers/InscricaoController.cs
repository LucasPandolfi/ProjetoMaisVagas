using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class InscricaoController : ControllerBase
    {
        IInscricaoRepository _inscricaoRepository;

        public InscricaoController()
        {
            _inscricaoRepository = new InscricaoRepository();
        }

        /// <summary>
        /// Lista todas as inscrições
        /// </summary>
        /// <returns>Uma lista de inscrições e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de inscrições</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        [Authorize(Roles = "Administrador, Empresa")]

        public IActionResult ListarTodosCandidato()
        {
            try
            {
                return Ok(_inscricaoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma inscricação através do ID
        /// </summary>
        /// <param name="id">ID da inscrição que será buscada</param>
        /// <returns>Uma inscricao buscada e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a inscricao buscada</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador, Empresa")]
        public IActionResult ListarInscricaoPorId(int id)
        {
            try
            {
                Inscricao inscricaoBuscada = _inscricaoRepository.BuscarPorId(id);

                if (inscricaoBuscada != null)
                {
                    return Ok(inscricaoBuscada);
                }

                return NotFound("Nenhuma inscrição encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova candidatura
        /// </summary>
        /// <param name="novaInscricao">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost]
        [Authorize(Roles = "Candidato")]
        public IActionResult Candidatura(Inscricao novaInscricao)
        {
            try
            {
                _inscricaoRepository.Candidatura(novaInscricao);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
