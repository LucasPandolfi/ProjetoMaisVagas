using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public void Deletar(int Id)
        {
            Usuario usuario = ctx.Usuario.Find(Id);
            ctx.Usuario.Remove(usuario);
            ctx.SaveChanges();
        }

        public void EditarAdm(int Id, Usuario usuario)
        {
            Usuario usuario1 = ctx.Usuario.Find(Id);

            usuario1.IdTipoUsuario = usuario.IdTipoUsuario;
            usuario1.IdUsuario = usuario.IdUsuario;
            usuario1.Foto = usuario.Foto;
            usuario1.Estado = usuario.Estado;
            usuario1.Email = usuario.Email;
            usuario1.Administrador = usuario.Administrador;

            ctx.Usuario.Update(usuario1);
            ctx.SaveChanges();
        }
    }
}
