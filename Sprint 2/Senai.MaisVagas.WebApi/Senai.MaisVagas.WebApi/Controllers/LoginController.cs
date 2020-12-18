using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using Senai.MaisVagas.WebApi.Repositories;
using Senai.MaisVagas.WebApi.ViewModels;

namespace Senai.MaisVagas.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        private IEmpresaRepository _empresaRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();

            _empresaRepository = new EmpresaRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// <response code="200">Retorna o token gerado</response>
        /// <response code="400">Retorna o erro gerado com uma mensagem personalizada</response>
        [HttpPost]
        public IActionResult Login([FromBody]LoginViewModel login)
        {
            MaisVagasContext ctx = new MaisVagasContext();


            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);
                //Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(e => e.IdUsuario == usuarioBuscado.IdUsuario);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.Titulo.ToString()),

                    //claim personalizada
                    new Claim("Role", usuarioBuscado.IdTipoUsuarioNavigation.Titulo),
                    new Claim("nomeUsuario", usuarioBuscado.Nome),
                    //new Claim("id", empresaBuscada.IdEmpresa.ToString())
                };


                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("MaisVagas-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Senai.MaisVagas.WebApi",                 
                    audience: "Senai.MaisVagas.WebApi",   
                    claims: claims,                        
                    expires: DateTime.Now.AddMinutes(30),  
                    signingCredentials: creds              
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}
