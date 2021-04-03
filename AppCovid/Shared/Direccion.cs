using AppCovid.Server.Helpers;
using System;
using System.Collections.Generic;

#nullable disable

namespace AppCovid.Server
{
    public partial class Direccion : IId {
        public Direccion() {
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Logitud { get; set; }
        public string Calle { get; set; }
        public string Sector { get; set; }
        public int? ProvinciaId { get; set; }
        public int? PaisId { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
