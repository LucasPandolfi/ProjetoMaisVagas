using Senai.MaisVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MaisVagas.WebApi.Interfaces
{
    public interface IAdministradorRepository
    {
        void EditarAdm(int Id, Administrador administrador);
    }
}
