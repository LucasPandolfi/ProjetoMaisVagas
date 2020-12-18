using Microsoft.EntityFrameworkCore;
using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();


        public List<Contrato> ListarContrato()
        {
            return ctx.Contrato
                .Select(c=> new Contrato()
                { 
                    IdContrato = c.IdContrato,
                    DataInicio = c.DataInicio,
                    DataTermino = c.DataTermino,
                    DiasContrato = c.DiasContrato,
                    ResponsavelEstagio = c.ResponsavelEstagio,
                    DescriçaoEstagio = c.DescriçaoEstagio,
                    DescriçãoCancelamento = c.DescriçãoCancelamento,
                  
                    IdVagaNavigation = new Vaga()
                     {
                        IdVaga = c.IdVagaNavigation.IdVaga,
                        NomeVaga = c.IdVagaNavigation.NomeVaga,
                        LogoEmpresa = c.IdVagaNavigation.LogoEmpresa,
                        DescricaoVaga = c.IdVagaNavigation.DescricaoVaga,
                        SoftSkills = c.IdVagaNavigation.SoftSkills,
                        HardSkills = c.IdVagaNavigation.HardSkills,
                        QualificacaoProfissional = c.IdVagaNavigation.QualificacaoProfissional,
                        NumeroVagaDisponiveis = c.IdVagaNavigation.NumeroVagaDisponiveis,
                        NivelExperiencia = c.IdVagaNavigation.NivelExperiencia,
                        Jornada = c.IdVagaNavigation.Jornada,
                        Setor = c.IdVagaNavigation.Setor,
                        Salario = c.IdVagaNavigation.Salario,
                        Beneficios = c.IdVagaNavigation.Beneficios,
                     },

                    IdTipoContratoNavigation = new TipoContrato()
                    {
                        IdTipoContrato = c.IdTipoContratoNavigation.IdTipoContrato,
                        Nome = c.IdTipoContratoNavigation.Nome
                    },

                    IdCandidatoNavigation = new Candidato()
                    {
                        IdCandidato = c.IdCandidatoNavigation.IdCandidato,
                        Cpf = c.IdCandidatoNavigation.Cpf,
                        DataNascimento = c.IdCandidatoNavigation.DataNascimento,
                        Matricula = c.IdCandidatoNavigation.Matricula,
                        AlunoExAluno = c.IdCandidatoNavigation.AlunoExAluno,
                        Curriculo = c.IdCandidatoNavigation.Curriculo,
                        IdCurso = c.IdCandidatoNavigation.IdCurso,
                        IdUsuarioNavigation = new Usuario()
                        {
                            IdUsuario = c.IdCandidatoNavigation.IdUsuarioNavigation.IdUsuario,
                            Nome = c.IdCandidatoNavigation.IdUsuarioNavigation.Nome,
                            Email = c.IdCandidatoNavigation.IdUsuarioNavigation.Email,
                            Foto = c.IdCandidatoNavigation.IdUsuarioNavigation.Foto,
                            Telefone = c.IdCandidatoNavigation.IdUsuarioNavigation.Telefone,
                            Cep = c.IdCandidatoNavigation.IdUsuarioNavigation.Cep,
                            Estado = c.IdCandidatoNavigation.IdUsuarioNavigation.Estado,
                            Cidade = c.IdCandidatoNavigation.IdUsuarioNavigation.Cidade,
                            Bairro = c.IdCandidatoNavigation.IdUsuarioNavigation.Bairro
                        },

                        IdCursoNavigation = new Curso()
                        { 
                            Nome = c.IdCandidatoNavigation.IdCursoNavigation.Nome,
                            Termo = c.IdCandidatoNavigation.IdCursoNavigation.Termo,
                            Turno = c.IdCandidatoNavigation.IdCursoNavigation.Turno
                        }

                    },

                    IdSituacaoNavigation = new Situacao()
                    {
                        IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                        Nome = c.IdSituacaoNavigation.Nome                        
                    }
                })
                .ToList();
        }

        public void CadastrarContrato(Contrato novoContrato)
        {
            ctx.Contrato.Add(novoContrato);

            ctx.SaveChanges();
        }
    }
}
