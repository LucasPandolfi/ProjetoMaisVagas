﻿using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Vaga = new HashSet<Vaga>();
            Verificacao = false;
        }

        public int IdEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string Cnae { get; set; }
        public string NumeroEmpregados { get; set; }
        public string NomeParaContato { get; set; }
        public bool? Verificacao { get; set; }
        public string ImagemCarimboCnpj { get; set; }
        public string ImagemCarimboAssinaturaDoResponsavel { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
