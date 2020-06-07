using System;
using System.Collections.Generic;

namespace pokedex.Models
{
    public partial class Pokemon
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Tipo2 { get; set; }
        public string Ataques { get; set; }
        public string Ataque2 { get; set; }
        public string Ataque3 { get; set; }
        public string Ataque4 { get; set; }
        public string Region { get; set; }
        public string PhotoName { get; set; }

        public virtual Regiones RegionNavigation { get; set; }
        public virtual Tipo Tipo2Navigation { get; set; }
        public virtual Tipo TipoNavigation { get; set; }
    }
}
