﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [StringLength(200)]
        public string Senha { get; set; }
    }
}
