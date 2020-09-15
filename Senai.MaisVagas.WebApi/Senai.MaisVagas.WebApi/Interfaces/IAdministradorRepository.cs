using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    interface IAdministradorRepository
    {
        List<Administrador> ListarAdministradores();

        Administrador BuscarPorId(int id);

        void NovoAdministrador(Administrador novoAdministrador);
    }
}
