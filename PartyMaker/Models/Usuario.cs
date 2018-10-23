﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PartyMaker.Models
{
    public class Usuario : IdentityUser
    {

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

    }
}
