using AppCovid.Server.DTOs.Pais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.DTOs {
    public class ProvinciaDTO : ProvinciaCreacionDTO {
        public int Id { get; set; }
        public virtual PaisDTO Pais { get; set; }
    }
}
