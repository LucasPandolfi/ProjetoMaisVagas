using Senai.MaisVagas.WebApi.Contexts;
using Senai.MaisVagas.WebApi.Domains;
using Senai.MaisVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public List<Vaga> ListarVagas()
        {
            return ctx.Vaga
                .Select(v => new Vaga()
                {
                    IdVaga = v.IdVaga,
                    IdEmpresa = v.IdEmpresa,
                    NomeVaga = v.NomeVaga,
                    LogoEmpresa = v.LogoEmpresa,
                    DescricaoVaga = v.DescricaoVaga,
                    SoftSkills = v.SoftSkills,
                    HardSkills = v.HardSkills,
                    QualificacaoProfissional = v.QualificacaoProfissional,
                    NumeroVagaDisponiveis = v.NumeroVagaDisponiveis,
                    NivelExperiencia = v.NivelExperiencia,
                    Jornada = v.Jornada,
                    Setor = v.Setor,
                    Salario = v.Salario,
                    Beneficios = v.Beneficios,

                    IdTipoContratoNavigation = new TipoContrato()
                    {
                        IdTipoContrato = v.IdTipoContrato,
                        Nome = v.IdTipoContratoNavigation.Nome
                    }
                })
                .ToList();
                
        }

        public Vaga BuscarPorId(int id)
        {
            Vaga vagaBuscada = ctx.Vaga

                .Select(v => new Vaga()
                {
                    IdVaga = v.IdVaga,
                    IdEmpresa = v.IdEmpresa,
                    NomeVaga = v.NomeVaga,
                    LogoEmpresa = v.LogoEmpresa,
                    DescricaoVaga = v.DescricaoVaga,
                    SoftSkills = v.SoftSkills,
                    HardSkills = v.HardSkills,
                    QualificacaoProfissional = v.QualificacaoProfissional,
                    NumeroVagaDisponiveis = v.NumeroVagaDisponiveis,
                    NivelExperiencia = v.NivelExperiencia,
                    Jornada = v.Jornada,
                    Setor = v.Setor,
                    Salario = v.Salario,
                    Beneficios = v.Beneficios,

                    IdTipoContratoNavigation = new TipoContrato()
                    {
                        IdTipoContrato = v.IdTipoContrato,
                        Nome = v.IdTipoContratoNavigation.Nome
                    }
                })
                .FirstOrDefault(v => v.IdVaga == id);

            if (vagaBuscada != null)
            {
                return vagaBuscada;
            }

                return null;
        }

        //Tenho que arrumar metodo de vaga, preciso do login para identificar quem é a empresa que cadastrou a vaga, fazendo o login tenho q adaptar o metodo vaga
        public void Cadastrar(Vaga novaVaga)
        {
            ctx.Vaga.Add(novaVaga);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Vaga vagaBuscada = ctx.Vaga.Find(id);

            ctx.Vaga.Remove(vagaBuscada);


            ctx.SaveChanges();
        }

        public void Atualizar(int id, Vaga vagaAtualizada)
        {
            Vaga vagaBuscada = ctx.Vaga.FirstOrDefault(e => e.IdVaga == id);

            TipoContrato tipoContratoBuscado = ctx.TipoContrato.FirstOrDefault(u => u.IdTipoContrato == vagaBuscada.IdTipoContrato);

            vagaBuscada.IdTipoContratoNavigation = tipoContratoBuscado;

            if (vagaBuscada.NomeVaga != null)
            {
                vagaBuscada.NomeVaga = vagaAtualizada.NomeVaga;
            }
            if (vagaBuscada.LogoEmpresa != null)
            {
                vagaBuscada.LogoEmpresa = vagaAtualizada.LogoEmpresa;
            }
            if (vagaBuscada.DescricaoVaga != null)
            {
                vagaBuscada.DescricaoVaga = vagaAtualizada.DescricaoVaga;
            }
            if (vagaBuscada.SoftSkills != null)
            {
                vagaBuscada.SoftSkills = vagaAtualizada.SoftSkills;
            }
            if (vagaBuscada.HardSkills != null)
            {
                vagaBuscada.HardSkills = vagaAtualizada.HardSkills;
            }
            if (vagaBuscada.QualificacaoProfissional != null)
            {
                vagaBuscada.QualificacaoProfissional = vagaAtualizada.QualificacaoProfissional;
            }
            if (vagaBuscada.NumeroVagaDisponiveis != vagaAtualizada.NumeroVagaDisponiveis)
            {
                vagaBuscada.NumeroVagaDisponiveis = vagaAtualizada.NumeroVagaDisponiveis;
            }
            if (vagaBuscada.NivelExperiencia != null)
            {
                vagaBuscada.NivelExperiencia = vagaAtualizada.NivelExperiencia;
            }
            if (vagaBuscada.Jornada != null)
            {
                vagaBuscada.Jornada = vagaAtualizada.Jornada;
            }
            if (vagaBuscada.Setor != null)
            {
                vagaBuscada.Setor = vagaAtualizada.Setor;
            }
            if (vagaBuscada.Salario != vagaAtualizada.Salario)
            {
                vagaBuscada.Salario = vagaAtualizada.Salario;
            }
            if (vagaBuscada.Beneficios != null)
            {
                vagaBuscada.Beneficios = vagaAtualizada.Beneficios;
            }
            if (vagaBuscada.IdTipoContrato != vagaAtualizada.IdTipoContrato)
            {
                vagaBuscada.IdTipoContrato = vagaAtualizada.IdTipoContrato;
            }

            ctx.Vaga.Update(vagaBuscada);

            ctx.SaveChanges();
        }

    }
}
