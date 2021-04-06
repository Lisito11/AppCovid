using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Client.Data
{
  
    public class CedulaApiResponse
    {
        [JsonProperty("Cedula")]
        public string Cedula { get; set; }

        [JsonProperty("Nombres")]
        public string Nombres { get; set; }

        [JsonProperty("Apellido1")]
        public string Apellido1 { get; set; }

        [JsonProperty("Apellido2")]
        public string Apellido2 { get; set; }

        [JsonProperty("FechaNacimiento")]
        public string FechaNacimiento { get; set; }

        [JsonProperty("ok")]
        public bool Ok { get; set; }
    }
    
}
