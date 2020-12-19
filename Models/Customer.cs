﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorWeb.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required,StringLength(10,MinimumLength =2)]
        public string Name { get; set; }
    }
}
