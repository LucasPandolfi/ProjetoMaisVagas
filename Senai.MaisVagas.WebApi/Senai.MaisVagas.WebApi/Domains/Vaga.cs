using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            Contrato = new HashSet<Contrato>();
            Inscricao = new HashSet<Inscricao>();
            VagasFavoritas = new HashSet<VagasFavoritas>();
        }

        public int IdVaga { get; set; }
        public string NomeVaga { get; set; }
        public string LogoEmpresa { get; set; }
        public string DescricaoVaga { get; set; }
        public string SoftSkills { get; set; }
        public string HardSkills { get; set; }
        public string QualificacaoProfissional { get; set; }
        public int NumeroVagaDisponiveis { get; set; }
        public string NivelExperiencia { get; set; }
        public string Jornada { get; set; }
        public string Setor { get; set; }
        public long Salario { get; set; }
        public string Beneficios { get; set; }
        public bool? Verificacao { get; set; }
        public int? IdTipoContrato { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual TipoContrato IdTipoContratoNavigation { get; set; }
        public virtual ICollection<Contrato> Contrato { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
        public virtual ICollection<VagasFavoritas> VagasFavoritas { get; set; }
    }
}
