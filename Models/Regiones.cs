using System;
using System.Collections.Generic;

namespace pokedex.Models
{
    public partial class Regiones
    {
        public Regiones()
        {
            Pokemon = new HashSet<Pokemon>();
        }

        public string Region { get; set; }

        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
