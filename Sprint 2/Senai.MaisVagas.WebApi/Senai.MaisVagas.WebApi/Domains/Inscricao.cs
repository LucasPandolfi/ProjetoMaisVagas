using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Inscricao
    {
        public int IdInscricao { get; set; }
        public bool? Selecionado { get; set; }
        public int? IdVaga { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
