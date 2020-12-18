using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public void CadastrarCurso(Curso novoCurso)
        {
            ctx.Curso.Add(novoCurso);

            ctx.SaveChanges();
        }


        public void DeletarCurso(int id)
        {
            Curso cursoBuscado = ctx.Curso.Find(id);

            ctx.Curso.Remove(cursoBuscado);


            ctx.SaveChanges();
        }

        public List<Curso> ListarCursos()
        {
            return ctx.Curso.ToList();
        }

        public Curso ListarPorId(int id)
        {
            Curso cursoBuscado = ctx.Curso.FirstOrDefault(v => v.IdCurso == id);

            if (cursoBuscado != null)
            {
                return cursoBuscado;
            }

            return null;
        }
    }
}
