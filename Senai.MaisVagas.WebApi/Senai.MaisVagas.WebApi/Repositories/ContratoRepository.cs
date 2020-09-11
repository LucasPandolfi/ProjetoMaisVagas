using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public void CadastrarContrato(Contrato contrato)
        {
            ctx.Contrato.Add(contrato);
            ctx.SaveChanges();
        }

        public List<Contrato> Get()
        {
            return ctx.Contrato.ToList();
        }
    }
}
