using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface IInscricaoRepository
    {
        List<Inscricao> Listar();
        Inscricao BuscarPorId(int id);

        void Candidatura(Inscricao novaInscricao);
    }
}
