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
    public class CursoController : ControllerBase
    {
        ICursoRepository _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        /// <summary>
        /// Lista todas os cursos
        /// </summary>
        /// <returns>lista de cursos e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de cursos</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        public IActionResult ListarTodosCursos()
        {
            try
            {
                return Ok(_cursoRepository.ListarCursos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCurso(int id)
        {
            try
            {
                Curso cursoBuscado = _cursoRepository.ListarPorId(id);

                if (cursoBuscado != null)
                {
                    _cursoRepository.DeletarCurso(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum curso encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo curso
        /// </summary>
        /// <param name="novoCurso">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost]
        public IActionResult CadastrarCurso(Curso novoCurso)
        {
            try
            {
                _cursoRepository.CadastrarCurso(novoCurso);

                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
