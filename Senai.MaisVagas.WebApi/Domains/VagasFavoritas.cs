using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class VagasFavoritas
    {
        public int IdVagasFavoritas { get; set; }
        public int? IdVaga { get; set; }

        public Vaga IdVagaNavigation { get; set; }
    }
}
