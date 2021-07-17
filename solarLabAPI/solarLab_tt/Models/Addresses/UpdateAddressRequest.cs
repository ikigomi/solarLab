﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Models
{
    public class UpdateAddressRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Days { get; set; }
    }
}
