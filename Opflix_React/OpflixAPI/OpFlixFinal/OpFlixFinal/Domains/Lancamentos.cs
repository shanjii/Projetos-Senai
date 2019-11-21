using System;
using System.Collections.Generic;

namespace OpFlixFinal.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        public string NomeLancamento { get; set; }
        public int? Categoria { get; set; }
        public string Sinopse { get; set; }
        public string Tipo { get; set; }
        public string Duracao { get; set; }
        public DateTime Lancamento { get; set; }
        public string Imagem { get; set; }

        public Categorias CategoriaNavigation { get; set; }
    }
}
