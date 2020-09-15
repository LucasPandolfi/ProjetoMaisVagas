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

               .Select(u => new Administrador()
               {
                   IdAdministrador = u.IdAdministrador,
                   IdUsuario = u.IdUsuario,
                   NivelAcesso = u.NivelAcesso,

                   IdUsuarioNavigation = new Usuario()
                   {
                       IdUsuario = u.IdUsuario,
                       Nome = u.IdUsuarioNavigation.Nome,
                       Email = u.IdUsuarioNavigation.Email,
                       Foto = u.IdUsuarioNavigation.Foto,
                       Telefone = u.IdUsuarioNavigation.Telefone,
                       Estado = u.IdUsuarioNavigation.Estado,
                       Cidade = u.IdUsuarioNavigation.Cidade,
                       Bairro = u.IdUsuarioNavigation.Bairro
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
                       Estado = a.IdUsuarioNavigation.Estado,
                       Cidade = a.IdUsuarioNavigation.Cidade,
                       Bairro = a.IdUsuarioNavigation.Bairro
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


    }
}
