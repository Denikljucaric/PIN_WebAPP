using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_WebAPP.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Brand Name")]
        [Required]
        public string Name { get; set; }
    }
}
