using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Days { get; set; }
    }
}
