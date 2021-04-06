using AppCovid.Server;
using AppCovid.Server.Controllers;
using AppCovid.Server.DTOs.Direccion;
using AppCovid.Shared;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.Controllers {
    [ApiController]
    [Route("api/direcciones")]

    public class DireccionController : CustomBaseController {
        private readonly dajd2mj0ciopa3Context context;
        private readonly IMapper mapper;
        public DireccionController(dajd2mj0ciopa3Context context, IMapper mapper) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<DireccionDTO>>> Get() {
            var direcciones = await context.Direccions.Include(x => x.Pais).Include(x => x.Provincia).Include(x=> x.Personas).ToListAsync();
            return mapper.Map<List<DireccionDTO>>(direcciones);
        }

        //Metodo Get(id)
        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerDireccion")]
        public async Task<ActionResult<DireccionDTO>> Get(int id) {
            return await Get<Direccion, DireccionDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DireccionCreacionDTO direccionCreacionDTO) {
            return await Post<DireccionCreacionDTO, Direccion, DireccionDTO>(direccionCreacionDTO, "obtenerDireccion");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DireccionCreacionDTO direccionCreacionDTO) {
            return await Put<DireccionCreacionDTO, Direccion>(id, direccionCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Patch(int id) {
            return await Patch<Direccion, DireccionDTO>(id);
        }


    }
}
