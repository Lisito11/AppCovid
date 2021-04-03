using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.DTOs.Pais {
    public class PaisDTO : PaisCreacionDTO {
        public int Id { get; set; }
        public virtual ICollection<ProvinciaDTO> Provincia { get; set; }
    }
}
