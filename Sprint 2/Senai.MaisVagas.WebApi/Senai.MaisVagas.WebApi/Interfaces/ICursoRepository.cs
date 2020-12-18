using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface ICursoRepository
    {
        List<Curso> ListarCursos();

        void DeletarCurso(int id);

        Curso ListarPorId(int id);

        void CadastrarCurso(Curso novoCurso);
    }
}
