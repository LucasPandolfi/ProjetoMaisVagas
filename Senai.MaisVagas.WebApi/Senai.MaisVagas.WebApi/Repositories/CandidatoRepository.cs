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
                        Bairro = c.IdUsuarioNavigation.Bairro
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
                      Bairro = c.IdUsuarioNavigation.Bairro
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
            ctx.Candidato.Include(a => a.IdUsuarioNavigation);

            ctx.Add(novoCandidato);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Candidato candidatoAtualizado)
        {
            Candidato candidatoBuscado = ctx.Candidato.Find(id);

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
            if (candidatoBuscado.IdCursoNavigation.Nome != null)
            {
                candidatoBuscado.IdCursoNavigation.Nome = candidatoAtualizado.IdCursoNavigation.Nome;
            }
            if (candidatoBuscado.IdCursoNavigation.Termo != null)
            {
                candidatoBuscado.IdCursoNavigation.Termo = candidatoAtualizado.IdCursoNavigation.Termo;
            }
            if (candidatoBuscado.IdCursoNavigation.Turno != null)
            {
                candidatoBuscado.IdCursoNavigation.Turno = candidatoAtualizado.IdCursoNavigation.Turno;
            }
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
