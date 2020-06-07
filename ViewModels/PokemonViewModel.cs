using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pokedex.ViewModels
{
    public class PokemonViewModel
    {
        [Required(ErrorMessage ="Este campo es requerido")]
        public string Nombre { get; set; }

        
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Ataques { get; set; }

 
        public string Region { get; set; }


        public string Tipo2 { get; set; }


        public string Ataque2 { get; set; }


        public string Ataque3 { get; set; }


        public string Ataque4 { get; set; }


       
    }
}
