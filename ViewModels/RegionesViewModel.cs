using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pokedex.ViewModels
{
    public class RegionesViewModel
    {
        [Required(ErrorMessage ="Este campo es requerido")]
        public string Region { get; set; }
    }
}
