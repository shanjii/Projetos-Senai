using System;
using System.Collections.Generic;

namespace OpFlixFinal.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
