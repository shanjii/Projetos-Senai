using System;
using System.Collections.Generic;

namespace QuironAPI.Domains
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Doutores = new HashSet<Doutores>();
        }

        public int IdPaciente { get; set; }
        public string NomePaciente { get; set; }
        public int Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }

        public ICollection<Doutores> Doutores { get; set; }
    }
}
