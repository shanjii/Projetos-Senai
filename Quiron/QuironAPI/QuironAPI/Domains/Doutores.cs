using System;
using System.Collections.Generic;

namespace QuironAPI.Domains
{
    public partial class Doutores
    {
        public int IdDoutor { get; set; }
        public string NomeDoutor { get; set; }
        public int Crm { get; set; }
        public int? Pacientes { get; set; }

        public Pacientes PacientesNavigation { get; set; }
    }
}
