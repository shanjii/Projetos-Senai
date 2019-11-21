﻿using System;
using System.Collections.Generic;

namespace Optus2.Domains
{
    public partial class Estilos
    {
        public Estilos()
        {
            Artistas = new HashSet<Artistas>();
        }

        public int IdEstilo { get; set; }
        public string Nome { get; set; }

        public ICollection<Artistas> Artistas { get; set; }
    }
}
