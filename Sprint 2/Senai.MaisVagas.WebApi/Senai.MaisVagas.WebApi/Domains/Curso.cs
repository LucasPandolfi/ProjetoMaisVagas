using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Curso
    {
        public Curso()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public string Termo { get; set; }
        public string Turno { get; set; }

        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
