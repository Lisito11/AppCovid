
using AppCovid.Server.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.Controllers {
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : CustomBaseController {
        private readonly dajd2mj0ciopa3Context context;
        private readonly IMapper mapper;
        public PersonaController(dajd2mj0ciopa3Context context, IMapper mapper) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<PersonaDTO>>> GetVacunados() {
            var vacunados = await context.Personas
                .Include(x => x.Direccion)
                .ThenInclude(x => x.Provincia)
                .ThenInclude(x => x.Pais)
                .ToListAsync();
            return mapper.Map<List<PersonaDTO>>(vacunados);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerPersona")]
        public async Task<ActionResult<PersonaDTO>> Get(int id) {
            var vacunados = await context.Personas
                 .Include(x => x.Direccion)
                 .ThenInclude(x => x.Provincia)
                 .ThenInclude(x => x.Pais)
                 .FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<PersonaDTO>(vacunados);
        }


        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonaCreacionDTO personaCreacionDTO) {
            return await Post<PersonaCreacionDTO, Persona, PersonaDTO>(personaCreacionDTO, "obtenerPersona");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonaCreacionDTO personaCreacionDTO) {
            return await Put<PersonaCreacionDTO, Persona>(id, personaCreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{cedula}")]
        public async Task<ActionResult> Patch(string cedula, [FromBody] JsonPatchDocument<Persona> patchDoc) {
            if (patchDoc == null) {
                return BadRequest();
            }

            var personaEdit = await context.Personas.FirstOrDefaultAsync(x => x.Cedula == cedula);

            if (personaEdit == null) {
                return NotFound();
            }

            patchDoc.ApplyTo(personaEdit, ModelState);

            var isValid = TryValidateModel(personaEdit);

            if (!isValid) {
                return BadRequest(ModelState);
            }

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}