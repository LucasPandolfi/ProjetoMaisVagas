﻿using System;
using System.Collections.Generic;

namespace Senai.MaisVagas.WebApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string Cnae { get; set; }
        public int? NumeroEmpregados { get; set; }
        public string NomeParaContato { get; set; }
        public bool? Verificacao { get; set; }
        public string ImagemCarimboCnpj { get; set; }
        public string ImagemCarimboAssinaturaDoResponsavel { get; set; }
        public int? IdUsuario { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Vaga> Vaga { get; set; }
    }
}
