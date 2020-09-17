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
    public class EmpresaRepository : IEmpresaRepository
    {
        MaisVagasContext ctx = new MaisVagasContext();

        public List<Empresa> ListarEmpresas()
        {
            return ctx.Empresa

                .Select(e => new Empresa()
                {
                    IdEmpresa = e.IdEmpresa,
                    IdUsuario = e.IdUsuario,
                    Cnpj = e.Cnpj,
                    Cnae = e.Cnae,
                    NumeroEmpregados = e.NumeroEmpregados,
                    NomeParaContato = e.NomeParaContato,
                    Verificacao = e.Verificacao,
                    ImagemCarimboCnpj = e.ImagemCarimboCnpj,
                    ImagemCarimboAssinaturaDoResponsavel = e.ImagemCarimboAssinaturaDoResponsavel,

                    IdUsuarioNavigation = new Usuario()
                    {
                        IdUsuario = e.IdUsuarioNavigation.IdUsuario,
                        Nome = e.IdUsuarioNavigation.Nome,
                        Email = e.IdUsuarioNavigation.Email,
                        Foto = e.IdUsuarioNavigation.Foto,
                        Telefone = e.IdUsuarioNavigation.Telefone,
                        Cep = e.IdUsuarioNavigation.Cep,
                        Estado = e.IdUsuarioNavigation.Estado,
                        Cidade = e.IdUsuarioNavigation.Cidade,
                        Bairro = e.IdUsuarioNavigation.Bairro
                    }
                })
                .ToList();
        }

        public List<Empresa> ListarEmpresasCadastradas(bool status)
        {
            return ctx.Empresa
                .Select(e => new Empresa()
                {
                    IdEmpresa = e.IdEmpresa,
                    Cnpj = e.Cnpj,
                    Cnae = e.Cnae,
                    NumeroEmpregados = e.NumeroEmpregados,
                    NomeParaContato = e.NomeParaContato,
                    Verificacao = e.Verificacao,
                    ImagemCarimboCnpj = e.ImagemCarimboCnpj,
                    ImagemCarimboAssinaturaDoResponsavel = e.ImagemCarimboAssinaturaDoResponsavel,

                    IdUsuarioNavigation = new Usuario()
                    {
                        IdUsuario = e.IdUsuarioNavigation.IdUsuario,
                        Nome = e.IdUsuarioNavigation.Nome,
                        Email = e.IdUsuarioNavigation.Email,
                        Foto = e.IdUsuarioNavigation.Foto,
                        Telefone = e.IdUsuarioNavigation.Telefone,
                        Cep = e.IdUsuarioNavigation.Cep,
                        Estado = e.IdUsuarioNavigation.Estado,
                        Cidade = e.IdUsuarioNavigation.Cidade,
                        Bairro = e.IdUsuarioNavigation.Bairro
                    }
                })
                .ToList().FindAll(e => e.Verificacao == status);
        }

        public Empresa ListarPorId(int id)
        {
            return ctx.Empresa.FirstOrDefault(v => v.IdEmpresa == id);
            //Empresa empresaBuscada = ctx.Empresa

            //    .Select(e => new Empresa()
            //    {
            //        IdEmpresa = e.IdEmpresa,
            //        Cnpj = e.Cnpj,
            //        Cnae = e.Cnae,
            //        NumeroEmpregados = e.NumeroEmpregados,
            //        NomeParaContato = e.NomeParaContato,
            //        Verificacao = e.Verificacao,
            //        ImagemCarimboCnpj = e.ImagemCarimboCnpj,
            //        ImagemCarimboAssinaturaDoResponsavel = e.ImagemCarimboAssinaturaDoResponsavel,

            //        IdUsuarioNavigation = new Usuario()
            //        {
            //            IdUsuario = e.IdUsuarioNavigation.IdUsuario,
            //            Nome = e.IdUsuarioNavigation.Nome,
            //            Email = e.IdUsuarioNavigation.Email,
            //            Foto = e.IdUsuarioNavigation.Foto,
            //            Telefone = e.IdUsuarioNavigation.Telefone,
            //            Estado = e.IdUsuarioNavigation.Estado,
            //            Cidade = e.IdUsuarioNavigation.Cidade,
            //            Bairro = e.IdUsuarioNavigation.Bairro
            //        }
            //    })
            //    .FirstOrDefault(c => c.IdEmpresa == id);

            //if (empresaBuscada != null)
            //{
            //    return empresaBuscada;
            //}

            //return null;
        }

        public void CadastrarEmpresa(Empresa novaEmpresa)
        {
            ctx.Empresa.Add(novaEmpresa);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(e => e.IdEmpresa == id);

            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == empresaBuscada.IdUsuario);

            //Gambiarra do matheus
            empresaBuscada.IdUsuarioNavigation = usuarioBuscado;


            if (empresaBuscada.Cnpj != null)
                {
                    empresaBuscada.Cnpj = empresaAtualizada.Cnpj;
                }
                if (empresaBuscada.Cnae != null)
                {
                    empresaBuscada.Cnae = empresaAtualizada.Cnae;
                }
                if (empresaBuscada.NumeroEmpregados != null)
                {
                    empresaBuscada.NumeroEmpregados = empresaAtualizada.NumeroEmpregados;
                }
                if (empresaBuscada.NomeParaContato != null)
                {
                    empresaBuscada.NomeParaContato = empresaAtualizada.NomeParaContato;
                }
                if (empresaBuscada.Verificacao != empresaAtualizada.Verificacao)
                {
                    empresaBuscada.Verificacao = empresaAtualizada.Verificacao;
                }
                if (empresaBuscada.ImagemCarimboCnpj != null)
                {
                    empresaBuscada.ImagemCarimboCnpj = empresaAtualizada.ImagemCarimboCnpj;
                }
                if (empresaBuscada.ImagemCarimboAssinaturaDoResponsavel != null)
                {
                    empresaBuscada.ImagemCarimboAssinaturaDoResponsavel = empresaAtualizada.ImagemCarimboAssinaturaDoResponsavel;
                }
                if (empresaBuscada.IdUsuarioNavigation.Nome != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Nome = empresaAtualizada.IdUsuarioNavigation.Nome;
                }
                if (empresaBuscada.IdUsuarioNavigation.Email != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Email = empresaAtualizada.IdUsuarioNavigation.Email;
                }
                if (empresaBuscada.IdUsuarioNavigation.Senha != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Senha = empresaAtualizada.IdUsuarioNavigation.Senha;
                }
                if (empresaBuscada.IdUsuarioNavigation.Foto != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Foto = empresaAtualizada.IdUsuarioNavigation.Foto;
                }
                if (empresaBuscada.IdUsuarioNavigation.Telefone != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Telefone = empresaAtualizada.IdUsuarioNavigation.Telefone;
                }
                if (empresaBuscada.IdUsuarioNavigation.Cep != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Cep = empresaAtualizada.IdUsuarioNavigation.Cep;
                }
                if (empresaBuscada.IdUsuarioNavigation.Estado != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Estado = empresaAtualizada.IdUsuarioNavigation.Estado;
                }
                if (empresaBuscada.IdUsuarioNavigation.Cidade != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Cidade = empresaAtualizada.IdUsuarioNavigation.Cidade;
                }
                if (empresaBuscada.IdUsuarioNavigation.Bairro != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Bairro = empresaAtualizada.IdUsuarioNavigation.Bairro;
                }

            ctx.Empresa.Update(empresaBuscada);

                ctx.SaveChanges();
        }

        public void DeletarEmpresa(int id)
        {
            Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(e => e.IdEmpresa == id);

            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == empresaBuscada.IdUsuario);

            if (empresaBuscada.IdUsuario == usuarioBuscado.IdUsuario)
            {
                ctx.Usuario.Remove(usuarioBuscado);

                ctx.Empresa.Remove(empresaBuscada);

                ctx.SaveChanges();
            }
        }

        public void AprovarEmpresa(int id)
        {
            Empresa empresaBuscada = ctx.Empresa.Find(id);
         
            if (!empresaBuscada.Verificacao)
            {
                empresaBuscada.Verificacao = !empresaBuscada.Verificacao;

                ctx.Update(empresaBuscada);

                ctx.SaveChanges();
            }

            //!empresaBuscada.Verificacao ?? empresaBuscada.Verificacao = !empresaBuscada.Verificacao
        }
    }
}
