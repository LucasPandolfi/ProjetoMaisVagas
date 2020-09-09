using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Contrato
    {
        public int IdContrato { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int? DiasContrato { get; set; }
        public string ResponsavelEstagio { get; set; }
        public string DescriçaoEstagio { get; set; }
        public string DescriçãoCancelamento { get; set; }
        public int? IdTipoContrato { get; set; }
        public int? IdSituacao { get; set; }
        public int? IdVaga { get; set; }
        public int? IdCandidato { get; set; }

        public Candidato IdCandidatoNavigation { get; set; }
        public Situacao IdSituacaoNavigation { get; set; }
        public TipoContrato IdTipoContratoNavigation { get; set; }
        public Vaga IdVagaNavigation { get; set; }
    }
}
