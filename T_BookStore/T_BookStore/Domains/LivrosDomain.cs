
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_BookStore.Domains
{
    public class LivrosDomain
    {
        public int IdLivro;
        public string Titulo { get; set; }
        public int IdAutor { get; set; }
        public AutoresDomain Autores;
        public int IdGenero { get; set; }
        public GenerosDomain Generos;
    }
}

         //IdLivro INT PRIMARY KEY IDENTITY
         //,Titulo VARCHAR(255) NOT NULL UNIQUE
         //,IdAutor INT FOREIGN KEY REFERENCES Autores(IdAutor)
         //,IdGenero INT FOREIGN KEY REFERENCES Generos(IdGenero)