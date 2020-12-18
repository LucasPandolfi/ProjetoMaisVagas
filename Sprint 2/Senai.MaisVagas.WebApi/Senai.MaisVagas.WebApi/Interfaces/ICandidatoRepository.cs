using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface ICandidatoRepository
    {
        List<Candidato> Listar();

        Candidato ListarCandidatoPorUsuario(int id);

        Candidato BuscarPorId(int id);

        void Cadastrar(Candidato novoCandidato);

        void Atualizar(int id, Candidato candidatoAtualizado);

        void Deletar(int id);
    }
}
