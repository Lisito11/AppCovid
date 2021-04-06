using AppCovid.Server.DTOs.Pais;
using AppCovid.Shared;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.Controllers {
    [ApiController]
    [Route("api/paises")]
    public class PaisController : CustomBaseController {
        public PaisController(dajd2mj0ciopa3Context context, IMapper mapper) : base(context, mapper) { }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<PaisDTO>>> Get() {
            return await Get<Pais, PaisDTO>();
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerPais")]
        public async Task<ActionResult<PaisDTO>> Get(int id) {
            return await Get<Pais, PaisDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PaisCreacionDTO paisCreacionDTO) {
            return await Post<PaisCreacionDTO, Pais, PaisDTO>(paisCreacionDTO, "obtenerPais");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PaisCreacionDTO paisCreacionDTO) {
            return await Put<PaisCreacionDTO, Pais>(id, paisCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Patch(int id) {
            return await Patch<Pais, PaisDTO>(id);
        }


    }
}
