using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class TipoContrato
    {
        public TipoContrato()
        {
            Contrato = new HashSet<Contrato>();
            Vaga = new HashSet<Vaga>();
        }

        public int IdTipoContrato { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Contrato> Contrato { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
