using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Models
{
    public class Droid
    {
        public int DroidID { get; set; }

        [Required(ErrorMessage = "De naame is verplicht")]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters bevatten")]
        public string Name { get; set; }
    }
}
