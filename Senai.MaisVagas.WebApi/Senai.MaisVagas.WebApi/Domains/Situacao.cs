using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Contrato = new HashSet<Contrato>();
        }

        public int IdSituacao { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
