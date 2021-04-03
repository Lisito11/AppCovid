using AppCovid.Server.Helpers;
using System;
using System.Collections.Generic;

#nullable disable

namespace AppCovid.Server
{
    public partial class Persona: IId {

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string TipoSangre { get; set; }
        public int? EstatusCovid { get; set; }
        public string Justifacion { get; set; }
        public int? DireccionId { get; set; }

        public virtual Direccion Direccion { get; set; }
    }
}
