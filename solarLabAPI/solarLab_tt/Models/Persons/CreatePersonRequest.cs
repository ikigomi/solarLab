using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace solarLab_tt.Models
{
    public class CreatePersonRequest
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
}
