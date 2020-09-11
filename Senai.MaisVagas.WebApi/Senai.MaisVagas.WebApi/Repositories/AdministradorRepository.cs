using Microsoft.EntityFrameworkCore;
using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public void EditarAdm(int Id, Administrador administrador)
        {
            Administrador administradorbuscar = ctx.Administrador.Find(Id);
            administradorbuscar.IdUsuario = administrador.IdUsuario;
            administradorbuscar.IdAdministrador = administrador.IdAdministrador;
            administradorbuscar.NivelAcesso = administrador.NivelAcesso;

            ctx.Administrador.Update(administradorbuscar);
            ctx.SaveChanges();
           

        }
    }
}
