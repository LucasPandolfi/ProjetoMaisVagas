using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface IVagaRepository
    {
        List<Vaga> ListarVagas();

        Vaga BuscarPorId(int id);

        void Cadastrar(Vaga novaVaga);

        void Atualizar(int id, Vaga vagaAtualizada);

        void Deletar(int id);
    }
}
