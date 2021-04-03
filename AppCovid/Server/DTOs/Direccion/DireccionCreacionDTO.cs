using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.DTOs.Direccion {
    public class DireccionCreacionDTO {
        public decimal? Latitud { get; set; }
        public decimal? Logitud { get; set; }
        public string Calle { get; set; }
        public string Sector { get; set; }
        public int? ProvinciaId { get; set; }
        public int? PaisId { get; set; }
    }
}
