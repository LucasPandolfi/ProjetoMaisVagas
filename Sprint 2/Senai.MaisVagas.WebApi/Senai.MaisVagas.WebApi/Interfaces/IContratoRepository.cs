using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface IContratoRepository
    {
        void CadastrarContrato(Contrato novoContrato);
        List<Contrato> ListarContrato();
    }
}
