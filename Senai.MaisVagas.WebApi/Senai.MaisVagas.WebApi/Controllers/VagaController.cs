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
    public class VagaController : ControllerBase
    {
        private IVagaRepository _vagaRepository;

        public VagaController()
        {
            _vagaRepository = new VagaRepository();
        }

        /// <summary>
        /// Lista todas as vagas
        /// </summary>
        /// <returns>lista de vagas e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de vagas</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_vagaRepository.ListarVagas());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma vaga através do ID
        /// </summary>
        /// <param name="id">ID da vaga que será buscada</param>
        /// <returns>Uma vaga buscada e um status code 200 - Ok</returns>
        /// <response code="200">Retorna a vaga buscada</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);

                if (vagaBuscada != null)
                {
                    return Ok(vagaBuscada);
                }

                return NotFound("Nenhuma vaga encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova vaga
        /// </summary>
        /// <param name="novaVaga">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost]
        public IActionResult Post(Vaga novaVaga)
        {
            try
            {
                _vagaRepository.Cadastrar(novaVaga);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma vaga
        /// </summary>
        /// <param name="id">ID da vaga que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);

                if (vagaBuscada != null)
                {
                    _vagaRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhuma vaga encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma vaga existente
        /// </summary>
        /// <param name="id">ID da vaga que será atualizada</param>
        /// <param name="vagaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Vaga vagaAtualizada)
        {
            try
            {
                Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);

                if (vagaBuscada != null)
                {
                    _vagaRepository.Atualizar(id, vagaAtualizada);

                    return StatusCode(204);
                }

                return NotFound("Nenhuma vaga encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}
