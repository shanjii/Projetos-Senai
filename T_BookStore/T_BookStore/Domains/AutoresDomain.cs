using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_BookStore.Domains
{
    public class AutoresDomain
    {
        public int IdAutor;
        public string Nome;
        public string Email;
        public int Ativo;
        public string DataNascimento;
    }
}

        // IdAutor             INT PRIMARY KEY IDENTITY
        //  ,Nome VARCHAR(200)
        //  ,Email VARCHAR(255) UNIQUE
        //  ,Ativo BIT DEFAULT(1) -- BIT/CHAR
        //  ,DataNascimento DATE