using Microsoft.AspNetCore.Mvc;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using Senai.MaisVagas.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _usuarioRepository.Deletar(Id);
            return StatusCode(204);
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Usuario usuario)
        {
            _usuarioRepository.EditarAdm(Id, usuario);
            return StatusCode(204);
        }
    }
}
