using System;
using System.Collections.Generic;

namespace pokedex.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            PokemonTipo2Navigation = new HashSet<Pokemon>();
            PokemonTipoNavigation = new HashSet<Pokemon>();
        }

        public string Tipos { get; set; }

        public virtual ICollection<Pokemon> PokemonTipo2Navigation { get; set; }
        public virtual ICollection<Pokemon> PokemonTipoNavigation { get; set; }
    }
}
