using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    public interface IContratoRepository
    {
        void CadastrarContrato(Contrato contrato);
        List<Contrato> Get();
    }
}
