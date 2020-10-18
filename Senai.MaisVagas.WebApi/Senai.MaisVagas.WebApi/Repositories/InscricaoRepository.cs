using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class InscricaoRepository : IInscricaoRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public Inscricao BuscarPorId(int id)
        {
            Inscricao inscricaoBuscadoa = ctx.Inscricao

               .Select(i => new Inscricao()
               {
                   IdInscricao = i.IdInscricao,
                   IdVaga = i.IdVaga,
                   IdCandidato = i.IdCandidato,

                   IdCandidatoNavigation = new Candidato()
                   {
                       IdCandidato = i.IdCandidatoNavigation.IdCandidato,
                       Cpf = i.IdCandidatoNavigation.Cpf,
                       DataNascimento = i.IdCandidatoNavigation.DataNascimento,
                       Matricula = i.IdCandidatoNavigation.Matricula,
                       Curriculo = i.IdCandidatoNavigation.Curriculo,

                   },

                   IdVagaNavigation = new Vaga()
                   {
                       IdVaga = i.IdVagaNavigation.IdVaga,
                       NomeVaga = i.IdVagaNavigation.NomeVaga,
                       LogoEmpresa = i.IdVagaNavigation.LogoEmpresa,
                       DescricaoVaga = i.IdVagaNavigation.DescricaoVaga,
                       SoftSkills = i.IdVagaNavigation.SoftSkills,
                       HardSkills = i.IdVagaNavigation.HardSkills,
                       QualificacaoProfissional = i.IdVagaNavigation.QualificacaoProfissional,
                       NumeroVagaDisponiveis = i.IdVagaNavigation.NumeroVagaDisponiveis,
                       NivelExperiencia = i.IdVagaNavigation.NivelExperiencia,
                       Jornada = i.IdVagaNavigation.Jornada,
                       Setor = i.IdVagaNavigation.Setor,
                       Salario = i.IdVagaNavigation.Salario,
                       Beneficios = i.IdVagaNavigation.Beneficios,


                       IdTipoContratoNavigation = new TipoContrato()
                       {
                           IdTipoContrato = i.IdVagaNavigation.IdTipoContratoNavigation.IdTipoContrato,
                           Nome = i.IdVagaNavigation.IdTipoContratoNavigation.Nome
                       },

                       IdEmpresaNavigation = new Empresa()
                       {
                           IdEmpresa = i.IdVagaNavigation.IdEmpresaNavigation.IdEmpresa,
                           Cnpj = i.IdVagaNavigation.IdEmpresaNavigation.Cnpj,
                           NomeParaContato = i.IdVagaNavigation.IdEmpresaNavigation.NomeParaContato,

                           IdUsuarioNavigation = new Usuario()
                           { 
                                IdUsuario = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.IdUsuario,
                                Nome = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Nome,
                                Email = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Email,
                                Telefone = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Telefone                               
                           }

                       }
                   }

               })

               .FirstOrDefault(I => I.IdInscricao == id);

            if (inscricaoBuscadoa != null)
            {
                return inscricaoBuscadoa;
            }

            return null;

        }

        public void Candidatura(Inscricao novaInscricao)
        {
            ctx.Inscricao.Add(novaInscricao);

            ctx.SaveChanges();
        }

        public List<Inscricao> Listar()
        {
            return ctx.Inscricao
                .Select(i => new Inscricao()
                {
                    IdInscricao = i.IdInscricao,
                    IdVaga = i.IdVaga,
                    IdCandidato = i.IdCandidato,

                    IdCandidatoNavigation = new Candidato()
                    {
                        IdCandidato = i.IdCandidatoNavigation.IdCandidato,
                        Cpf = i.IdCandidatoNavigation.Cpf,
                        DataNascimento = i.IdCandidatoNavigation.DataNascimento,
                        Matricula = i.IdCandidatoNavigation.Matricula,
                        Curriculo = i.IdCandidatoNavigation.Curriculo,

                    },

                    IdVagaNavigation = new Vaga()
                    {
                        IdVaga = i.IdVagaNavigation.IdVaga,
                        NomeVaga = i.IdVagaNavigation.NomeVaga,
                        LogoEmpresa = i.IdVagaNavigation.LogoEmpresa,
                        DescricaoVaga = i.IdVagaNavigation.DescricaoVaga,
                        SoftSkills = i.IdVagaNavigation.SoftSkills,
                        HardSkills = i.IdVagaNavigation.HardSkills,
                        QualificacaoProfissional = i.IdVagaNavigation.QualificacaoProfissional,
                        NumeroVagaDisponiveis = i.IdVagaNavigation.NumeroVagaDisponiveis,
                        NivelExperiencia = i.IdVagaNavigation.NivelExperiencia,
                        Jornada = i.IdVagaNavigation.Jornada,
                        Setor = i.IdVagaNavigation.Setor,
                        Salario = i.IdVagaNavigation.Salario,
                        Beneficios = i.IdVagaNavigation.Beneficios,

                        IdTipoContratoNavigation = new TipoContrato()
                        {
                            IdTipoContrato = i.IdVagaNavigation.IdTipoContratoNavigation.IdTipoContrato,
                            Nome = i.IdVagaNavigation.IdTipoContratoNavigation.Nome
                        },

                        IdEmpresaNavigation = new Empresa()
                        {
                            IdEmpresa = i.IdVagaNavigation.IdEmpresaNavigation.IdEmpresa,
                            Cnpj = i.IdVagaNavigation.IdEmpresaNavigation.Cnpj,
                            NomeParaContato = i.IdVagaNavigation.IdEmpresaNavigation.NomeParaContato,

                            IdUsuarioNavigation = new Usuario()
                            {
                                IdUsuario = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.IdUsuario,
                                Nome = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Nome,
                                Email = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Email,
                                Telefone = i.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Telefone
                            }

                        }                       
                    }

                })
                .ToList();
        }
    }
}
