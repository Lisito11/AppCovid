using AppCovid.Server.Helpers;
using System;
using System.Collections.Generic;

#nullable disable

namespace AppCovid.Server
{
    public partial class Pais: IId {
        public Pais()
        {
            Direccions = new HashSet<Direccion>();
            Provincia = new HashSet<Provincia>();
        }

        public int Id { get; set; }
        public string NombrePais { get; set; }

        public virtual ICollection<Direccion> Direccions { get; set; }
        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}
