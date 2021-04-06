using AppCovid.Server.DTOs;
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
    [Route("api/provincias")]
    public class ProvinciaController : CustomBaseController {
        private readonly dajd2mj0ciopa3Context context;
        private readonly IMapper mapper;
        public ProvinciaController(dajd2mj0ciopa3Context context, IMapper mapper) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ProvinciaDTO>>> Get() {
            var provinciasPersonas = await context.Provincia.Include(x => x.Direccions).ToListAsync();
            return mapper.Map<List<ProvinciaDTO>>(provinciasPersonas);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerProvincia")]
        public async Task<ActionResult<ProvinciaDTO>> Get(int id) {
            return await Get<Provincia, ProvinciaDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProvinciaCreacionDTO provinciaCreacionDTO) {
            return await Post<ProvinciaCreacionDTO, Provincia, ProvinciaDTO>(provinciaCreacionDTO, "obtenerProvincia");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProvinciaCreacionDTO provinciaCreacionDTO) {
            return await Put<ProvinciaCreacionDTO, Provincia>(id, provinciaCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Patch(int id) {
            return await Patch<Provincia, ProvinciaDTO>(id);
        }


    }
}
