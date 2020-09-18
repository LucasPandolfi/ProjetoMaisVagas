using Microsoft.EntityFrameworkCore;
using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public List<Candidato> Listar()
        {
            return ctx.Candidato
                .Select(c => new Candidato()
                {
                    IdCandidato = c.IdCandidato,
                    IdUsuario = c.IdUsuario,
                    Cpf = c.Cpf,
                    DataNascimento = c.DataNascimento,
                    Matricula = c.Matricula,
                    AlunoExAluno = c.AlunoExAluno,
                    Curriculo = c.Curriculo,

                    IdUsuarioNavigation = new Usuario()
                    {
                        IdUsuario = c.IdUsuario,
                        Nome = c.IdUsuarioNavigation.Nome,
                        Email = c.IdUsuarioNavigation.Email,
                        Foto = c.IdUsuarioNavigation.Foto,
                        Telefone = c.IdUsuarioNavigation.Telefone,
                        Estado = c.IdUsuarioNavigation.Estado,
                        Cidade = c.IdUsuarioNavigation.Cidade,
                        Bairro = c.IdUsuarioNavigation.Bairro,

                        IdTipoUsuarioNavigation = new TipoUsuario()
                        {
                            IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario,
                            Titulo = c.IdUsuarioNavigation.IdTipoUsuarioNavigation.Titulo
                        }
                    },

                    IdCursoNavigation = new Curso()
                    {
                        IdCurso = c.IdCursoNavigation.IdCurso,
                        Nome = c.IdCursoNavigation.Nome,
                        Termo = c.IdCursoNavigation.Termo,
                        Turno = c.IdCursoNavigation.Turno
                    }

                }).ToList();

        }

        public Candidato BuscarPorId(int id)
        {
            Candidato candidatoBuscado = ctx.Candidato

              .Select(c => new Candidato()
              {
                  IdCandidato = c.IdCandidato,
                  IdUsuario = c.IdUsuario,
                  Cpf = c.Cpf,
                  DataNascimento = c.DataNascimento,
                  Matricula = c.Matricula,
                  AlunoExAluno = c.AlunoExAluno,
                  Curriculo = c.Curriculo,

                  IdUsuarioNavigation = new Usuario()
                  {
                      IdUsuario = c.IdUsuarioNavigation.IdUsuario,
                      Nome = c.IdUsuarioNavigation.Nome,
                      Email = c.IdUsuarioNavigation.Email,
                      Foto = c.IdUsuarioNavigation.Foto,
                      Telefone = c.IdUsuarioNavigation.Telefone,
                      Estado = c.IdUsuarioNavigation.Estado,
                      Cidade = c.IdUsuarioNavigation.Cidade,
                      Bairro = c.IdUsuarioNavigation.Bairro,

                      IdTipoUsuarioNavigation = new TipoUsuario()
                      {
                          IdTipoUsuario = c.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario,
                          Titulo = c.IdUsuarioNavigation.IdTipoUsuarioNavigation.Titulo
                      }
                  },

                  IdCursoNavigation = new Curso()
                  {
                      IdCurso = c.IdCursoNavigation.IdCurso,
                      Nome = c.IdCursoNavigation.Nome,
                      Termo = c.IdCursoNavigation.Termo,
                      Turno = c.IdCursoNavigation.Turno
                  }

              })
              .FirstOrDefault(c => c.IdCandidato == id);

            if (candidatoBuscado != null)
            {
                return candidatoBuscado;
            }

            return null;
        }

        public void Cadastrar(Candidato novoCandidato)
        {
            ctx.Candidato.Add(novoCandidato);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Candidato candidatoAtualizado)
        {
            Candidato candidatoBuscado = ctx.Candidato.FirstOrDefault(e => e.IdCandidato == id);

            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == candidatoBuscado.IdUsuario);

            Curso cursoBuscado = ctx.Curso.FirstOrDefault(c => c.IdCurso == candidatoBuscado.IdCurso);

            candidatoBuscado.IdUsuarioNavigation = usuarioBuscado;

            candidatoBuscado.IdCursoNavigation = cursoBuscado;

            if (candidatoBuscado.Cpf != null)
            {
                candidatoBuscado.Cpf = candidatoAtualizado.Cpf;
            }
            if (candidatoBuscado.DataNascimento != null)
            {
                candidatoBuscado.DataNascimento = candidatoAtualizado.DataNascimento;
            }
            if (candidatoBuscado.Matricula != candidatoAtualizado.Matricula)
            {
                candidatoBuscado.Matricula = candidatoAtualizado.Matricula;
            }
            if (candidatoBuscado.AlunoExAluno != candidatoAtualizado.AlunoExAluno)
            {
                candidatoBuscado.AlunoExAluno = candidatoAtualizado.AlunoExAluno;
            }
            if (candidatoBuscado.Curriculo != null)
            {
                candidatoBuscado.Curriculo = candidatoAtualizado.Curriculo;
            }
            if (candidatoBuscado.IdUsuarioNavigation.Nome != null)
            {
                candidatoBuscado.IdUsuarioNavigation.Nome = candidatoAtualizado.IdUsuarioNavigation.Nome;
            }
            if (candidatoBuscado.IdUsuarioNavigation.Email != null)
            {
                candidatoBuscado.IdUsuarioNavigation.Email = candidatoAtualizado.IdUsuarioNavigation.Email;
            }
            if (candidatoBuscado.IdUsuarioNavigation.Foto != null)
            {
                candidatoBuscado.IdUsuarioNavigation.Foto = candidatoAtualizado.IdUsuarioNavigation.Foto;
            }
            if (candidatoBuscado.IdUsuarioNavigation.Telefone != null)
            {
                candidatoBuscado.IdUsuarioNavigation.Telefone = candidatoAtualizado.IdUsuarioNavigation.Telefone;
            }
            if (candidatoBuscado.IdUsuarioNavigation.Estado != null)
            {
                candidatoBuscado.IdUsuarioNavigation.Estado = candidatoAtualizado.IdUsuarioNavigation.Estado;
            }
            if (candidatoBuscado.IdUsuarioNavigation.Cidade != null)
            {
                candidatoBuscado.IdUsuarioNavigation.Cidade = candidatoAtualizado.IdUsuarioNavigation.Cidade;
            }
            if (candidatoBuscado.IdUsuarioNavigation.Bairro != null)
            {
                candidatoBuscado.IdUsuarioNavigation.Bairro = candidatoAtualizado.IdUsuarioNavigation.Bairro;
            }
            if (candidatoBuscado.IdCurso != candidatoAtualizado.IdCurso)
            {
                candidatoBuscado.IdCurso = candidatoAtualizado.IdCurso;
            }

            ctx.Candidato.Update(candidatoBuscado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Candidato candidatoBuscado = ctx.Candidato.FirstOrDefault(a => a.IdCandidato == id);

            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == candidatoBuscado.IdUsuario);

            if (candidatoBuscado.IdUsuario == usuarioBuscado.IdUsuario)
            {
                ctx.Usuario.Remove(usuarioBuscado);

                ctx.Candidato.Remove(candidatoBuscado);

                ctx.SaveChanges();
            }
        }


    }
}
