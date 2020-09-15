using Microsoft.EntityFrameworkCore;
using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public List<Empresa> ListarEmpresas()
        {
            return ctx.Empresa.ToList();
        }

        public List<Empresa> ListarEmpresasCadastradas(bool status)
        {
            return ctx.Empresa.ToList().FindAll(e => e.Verificacao == status);
        }

        public void CadastrarEmpresa(Empresa novaEmpresa)
        {

            ctx.Empresa.Add(novaEmpresa);

            ctx.SaveChanges();
        }

    }
}
