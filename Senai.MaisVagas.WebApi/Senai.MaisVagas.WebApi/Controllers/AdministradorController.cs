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
    public class AdministradorController : ControllerBase
    {
        public IAdministradorRepository _administradorRepository;

        public AdministradorController()
        {

            _administradorRepository = new AdministradorRepository();
        }
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Administrador administrador)
        {
            _administradorRepository.EditarAdm(Id, administrador);
            return StatusCode(204);
        }
    }
}
