using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Inscricao
    {
        public int IdInscricao { get; set; }
        public int? IdVaga { get; set; }
        public int? IdCandidato { get; set; }

        public Candidato IdCandidatoNavigation { get; set; }
        public Vaga IdVagaNavigation { get; set; }
    }
}
