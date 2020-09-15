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
        public IActionResult Get()
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
        public IActionResult GetPorId(int id)
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
        public IActionResult Post(Administrador novoAdministrador)
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


    }
}
