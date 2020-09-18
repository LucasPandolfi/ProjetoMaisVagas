using Microsoft.EntityFrameworkCore;
using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public List<Administrador> ListarAdministradores()
        {

            return ctx.Administrador

               .Select(a => new Administrador()
               {
                   IdAdministrador = a.IdAdministrador,
                   IdUsuario = a.IdUsuario,
                   NivelAcesso = a.NivelAcesso,

                   IdUsuarioNavigation = new Usuario()
                   {
                       IdUsuario = a.IdUsuario,
                       Nome = a.IdUsuarioNavigation.Nome,
                       Email = a.IdUsuarioNavigation.Email,
                       Foto = a.IdUsuarioNavigation.Foto,
                       Telefone = a.IdUsuarioNavigation.Telefone,
                       Cep = a.IdUsuarioNavigation.Cep,
                       Estado = a.IdUsuarioNavigation.Estado,
                       Cidade = a.IdUsuarioNavigation.Cidade,
                       Bairro = a.IdUsuarioNavigation.Bairro,

                       IdTipoUsuarioNavigation = new TipoUsuario()
                       {
                           IdTipoUsuario = a.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario,
                           Titulo = a.IdUsuarioNavigation.IdTipoUsuarioNavigation.Titulo
                       }
                   }
               })
               .ToList();
        }

        public Administrador BuscarPorId(int id)
        {
            Administrador adminitradorBuscado = ctx.Administrador

               .Select(a => new Administrador()
               {
                   IdAdministrador = a.IdAdministrador,
                   IdUsuario = a.IdUsuario,
                   NivelAcesso = a.NivelAcesso,

                   IdUsuarioNavigation = new Usuario()
                   {
                       IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                       Nome = a.IdUsuarioNavigation.Nome,
                       Email = a.IdUsuarioNavigation.Email,
                       Foto = a.IdUsuarioNavigation.Foto,
                       Telefone = a.IdUsuarioNavigation.Telefone,
                       Cep = a.IdUsuarioNavigation.Cep,
                       Estado = a.IdUsuarioNavigation.Estado,
                       Cidade = a.IdUsuarioNavigation.Cidade,
                       Bairro = a.IdUsuarioNavigation.Bairro,

                       IdTipoUsuarioNavigation = new TipoUsuario()
                       {
                           IdTipoUsuario = a.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario,
                           Titulo = a.IdUsuarioNavigation.IdTipoUsuarioNavigation.Titulo
                       }
                   }

               })
               .FirstOrDefault(a => a.IdAdministrador == id);

            if (adminitradorBuscado != null)
            {
                return adminitradorBuscado;
            }

            return null;
        }


        public void NovoAdministrador(Administrador novoAdministrador)
        {
            ctx.Administrador.Include(a => a.IdUsuarioNavigation);

            ctx.Add(novoAdministrador);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Administrador administradorAtualizado)
        {
            Administrador administradorBuscado = ctx.Administrador.FirstOrDefault(e => e.IdAdministrador == id);

            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == administradorBuscado.IdUsuario);

            //Gambiarra do matheus
            administradorBuscado.IdUsuarioNavigation = usuarioBuscado;


            if (administradorBuscado.NivelAcesso != administradorAtualizado.NivelAcesso)
            {
                administradorBuscado.NivelAcesso = administradorBuscado.NivelAcesso;
            }
            
            if (administradorBuscado.IdUsuarioNavigation.Nome != null)
            {
                administradorBuscado.IdUsuarioNavigation.Nome = administradorAtualizado.IdUsuarioNavigation.Nome;
            }
            if (administradorBuscado.IdUsuarioNavigation.Email != null)
            {
                administradorBuscado.IdUsuarioNavigation.Email = administradorAtualizado.IdUsuarioNavigation.Email;
            }
            if (administradorBuscado.IdUsuarioNavigation.Senha != null)
            {
                administradorBuscado.IdUsuarioNavigation.Senha = administradorAtualizado.IdUsuarioNavigation.Senha;
            }
            if (administradorBuscado.IdUsuarioNavigation.Foto != null)
            {
                administradorBuscado.IdUsuarioNavigation.Foto = administradorAtualizado.IdUsuarioNavigation.Foto;
            }
            if (administradorBuscado.IdUsuarioNavigation.Telefone != null)
            {
                administradorBuscado.IdUsuarioNavigation.Telefone = administradorAtualizado.IdUsuarioNavigation.Telefone;
            }
            if (administradorBuscado.IdUsuarioNavigation.Cep != null)
            {
                administradorBuscado.IdUsuarioNavigation.Cep = administradorAtualizado.IdUsuarioNavigation.Cep;
            }
            if (administradorBuscado.IdUsuarioNavigation.Estado != null)
            {
                administradorBuscado.IdUsuarioNavigation.Estado = administradorAtualizado.IdUsuarioNavigation.Estado;
            }
            if (administradorBuscado.IdUsuarioNavigation.Cidade != null)
            {
                administradorBuscado.IdUsuarioNavigation.Cidade = administradorAtualizado.IdUsuarioNavigation.Cidade;
            }
            if (administradorBuscado.IdUsuarioNavigation.Bairro != null)
            {
                administradorBuscado.IdUsuarioNavigation.Bairro = administradorAtualizado.IdUsuarioNavigation.Bairro;
            }

            ctx.Administrador.Update(administradorBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Administrador administardorBuscado = ctx.Administrador.FirstOrDefault(e => e.IdAdministrador == id);

            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == administardorBuscado.IdUsuario);

            if (administardorBuscado.IdUsuario == usuarioBuscado.IdUsuario)
            {
                ctx.Usuario.Remove(usuarioBuscado);

                ctx.Administrador.Remove(administardorBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
