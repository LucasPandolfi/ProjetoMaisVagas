using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class TipoContratoRepository : ITipoContratoRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();
        public void CadastrarTipoContrato(TipoContrato novoTipoContrato)
        {
            ctx.TipoContrato.Add(novoTipoContrato);

            ctx.SaveChanges();
        }

        public void DeletarTipoContrato(int id)
        {
            TipoContrato tipoContratoBuscado = ctx.TipoContrato.Find(id);

            ctx.TipoContrato.Remove(tipoContratoBuscado);


            ctx.SaveChanges();
        }

        public TipoContrato ListarPorId(int id)
        {
            TipoContrato tipoContratoBuscado = ctx.TipoContrato.FirstOrDefault(v => v.IdTipoContrato == id);

            if (tipoContratoBuscado != null)
            {
                return tipoContratoBuscado;
            }

            return null;
        }

        public List<TipoContrato> ListarTipoContratos()
        {
            return ctx.TipoContrato.ToList();
        }
    }
}
