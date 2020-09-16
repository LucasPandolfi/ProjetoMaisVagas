using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public bool NivelAcesso { get; set; }
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
