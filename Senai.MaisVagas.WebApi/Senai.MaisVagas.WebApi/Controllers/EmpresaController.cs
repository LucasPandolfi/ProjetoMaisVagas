using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarTodasEmpresas()
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
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarEmpresasCadastradas(bool status)
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

        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Retorna apenas o status code Created</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost]
        public IActionResult CadastrarEmpresa(Empresa novaEmpresa)
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

        /// <summary>
        /// Aprova o cadstro de uma empresa 
        /// </summary>
        /// <param name="id">ID da empresa que será aprovada</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult AprovarEmpresa(int id)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.ListarPorId(id);

                if (empresaBuscada != null)
                {
                    _empresaRepository.AprovarEmpresa(id);

                    return StatusCode(204);
                }

                return NotFound("Nenhuma empresa encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será atualizada</param>
        /// <param name="empresaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// <response code="204">Retorna apenas o status code No Content</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Empresa")]
        public IActionResult AtualizarEmpresa(int id, Empresa empresaAtualizada)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.ListarPorId(id);

                if (empresaBuscada != null)
                {
                    _empresaRepository.Atualizar(id, empresaAtualizada);

                    return StatusCode(204);
                }

                return NotFound("Nenhuma empresa encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <param name="id">ID da empresa que será deletada</param>
        /// <returns>Um status code 202 - Accepted</returns>
        /// <response code="202">Retorna apenas o status code Accepted</response>
        /// <response code="404">Retorna uma mensagem de erro</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult DeletarEmpresa(int id)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.ListarPorId(id);

                if (empresaBuscada != null)
                {
                    _empresaRepository.DeletarEmpresa(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhuma empresa encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
