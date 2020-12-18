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
        List<Inscricao> ListarCandidatoPorVaga(int id);
        Inscricao BuscarPorId(int id);
        Inscricao Candidatura(Inscricao novaInscricao);
        List<Inscricao> ListarInscricoesPorCandidato(int id);
    }
}
