using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface IEmpresaRepository
    {
        List<Empresa> ListarEmpresas();

        List<Empresa> ListarEmpresasCadastradas(bool status);

        Empresa ListarPorId(int id);

        void AprovarEmpresa(int id);

        void CadastrarEmpresa(Empresa novaEmpresa);

        void Atualizar(int id, Empresa empresaAtualizada);

        void DeletarEmpresa(int id);
    }
}
