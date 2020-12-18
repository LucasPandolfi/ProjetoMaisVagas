using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface ITipoContratoRepository
    {
        List<TipoContrato> ListarTipoContratos();

        void DeletarTipoContrato(int id);

        TipoContrato ListarPorId(int id);

        void CadastrarTipoContrato(TipoContrato novoTipoContrato);
    }
}
