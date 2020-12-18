using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Candidato
    {
        public Candidato()
        {
            Contrato = new HashSet<Contrato>();
            Inscricao = new HashSet<Inscricao>();
            VagasFavoritas = new HashSet<VagasFavoritas>();
        }

        public int IdCandidato { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Matricula { get; set; }
        public bool AlunoExAluno { get; set; }
        public string Curriculo { get; set; }
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Contrato> Contrato { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
        public virtual ICollection<VagasFavoritas> VagasFavoritas { get; set; }
    }
}
