using System;
using System.Collections.Generic;

#nullable disable

namespace AppCovid.Shared
{
    public partial class Provincia: IId {
    
        public Provincia()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int Id { get; set; }
        public string NombreProvincia { get; set; }
        public int? PaisId { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
