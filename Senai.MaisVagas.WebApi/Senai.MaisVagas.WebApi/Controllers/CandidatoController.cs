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
    public class CandidatoController : ControllerBase
    {
        ICandidatoRepository _candidatoRepository;

        public CandidatoController()
        {
            _candidatoRepository = new CandidatoRepository();
        }

        /// <summary>
        /// Lista todos os candidatos
        /// </summary>
        /// <returns>Uma lista de candidatos e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de candidatos</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        public IActionResult ListarTodosCandidato()
        {
            try
            {
                return Ok(_candidatoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um candidato através do ID
        /// </summary>
        /// <param name="id">ID do candidato que será buscado</param>
        /// <returns>Um candidato buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o candidato buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("{id}")]
        public IActionResult ListarCandidatoPorId(int id)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.BuscarPorId(id);

                if (candidatoBuscado != null)
                {
                    return Ok(candidatoBuscado);
                }

                return NotFound("Nenhum candidato encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo candidato
        /// </summary>
        /// <param name="novoCandidato">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost]
        public IActionResult CadastrarCandidato(Candidato novoCandidato)
        {
            try
            {
                _candidatoRepository.Cadastrar(novoCandidato);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza um candidato existente
        /// </summary>
        /// <param name="id">ID do candidato que será atualizado</param>
        /// <param name="candidatoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult AtualizarCandidato(int id, Candidato candidatoAtualizado)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.BuscarPorId(id);

                if (candidatoBuscado != null)
                {
                    _candidatoRepository.Atualizar(id, candidatoAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum candidato encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um candidato
        /// </summary>
        /// <param name="id">ID do candidato que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpDelete("{id}")]
        public IActionResult DeletarCandidato(int id)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.BuscarPorId(id);

                if (candidatoBuscado != null)
                {
                    _candidatoRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum candidato encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
