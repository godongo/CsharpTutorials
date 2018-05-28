using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcMovie.Models
{
    public class CheckboxModel
    {
        public int Id { get; set; }
        public bool IsFleetWorkshop { get; set; }        
        public bool IsIndependentCrashRepairer { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
