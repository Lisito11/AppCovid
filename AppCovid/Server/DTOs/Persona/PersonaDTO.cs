using AppCovid.Server.DTOs.Direccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.DTOs {
    public class PersonaDTO: PersonaCreacionDTO {
        public int Id { get; set; }
        public virtual DireccionDTO Direccion { get; set; }
    }
}
