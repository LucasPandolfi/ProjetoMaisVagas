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
    public class AdministradorController : ControllerBase
    {
        IAdministradorRepository _administradorRepository;

        public AdministradorController()
        {
            _administradorRepository = new AdministradorRepository();
        }

        /// <summary>
        /// Lista todos os administradores
        /// </summary>
        /// <returns>Uma lista de administradores e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de administradores</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarTodosAdministradores()
        {
            try
            {
                return Ok(_administradorRepository.ListarAdministradores());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }

        /// <summary>
        /// Busca um administrador através do ID
        /// </summary>
        /// <param name="id">ID do administrador que será buscado</param>
        /// <returns>Um administrador buscado e um status code 200 - Ok</returns>
        /// <response code="200">Retorna o administrador buscado</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarAdministradorPorId(int id)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.BuscarPorId(id);

                if (administradorBuscado != null)
                {
                    return Ok(administradorBuscado);
                }

                return NotFound("Nenhum administrador encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo administrador
        /// </summary>
        /// <param name="novoAdministrador">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarAdministrador(Administrador novoAdministrador)
        {
            try
            {
                _administradorRepository.NovoAdministrador(novoAdministrador);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }


        /// <summary>
        /// Atualiza um administrador existente
        /// </summary>
        /// <param name="id">ID do administrador que será atualizado</param>
        /// <param name="administradorAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult AtualizarAdministrador(int id, Administrador administradorAtualizado)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.BuscarPorId(id);

                if (administradorBuscado != null)
                {
                    _administradorRepository.Atualizar(id, administradorAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum administrador encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um administrador
        /// </summary>
        /// <param name="id">ID do administrador que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult DeletarAdministrador(int id)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.BuscarPorId(id);

                if (administradorBuscado != null)
                {
                    _administradorRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum administrador encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
