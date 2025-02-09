﻿using AppCovid.Server.Helpers;
using AppCovid.Shared;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.Controllers {
    public class CustomBaseController : ControllerBase {
        private readonly dajd2mj0ciopa3Context context;
        private readonly IMapper mapper;

        public CustomBaseController(dajd2mj0ciopa3Context context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }


        //Metodo get para listar entidades
        protected async Task<List<TDTO>> Get<TEntidad, TDTO>() where TEntidad : class {
            var entidades = await context.Set<TEntidad>().AsNoTracking().ToListAsync();
            var dtos = mapper.Map<List<TDTO>>(entidades);
            return dtos;
        }

        //Metodo get para obtener una entidad
        protected async Task<ActionResult<TDTO>> Get<TEntidad, TDTO>(int id) where TEntidad : class, IId {
            var entidad = await context.Set<TEntidad>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entidad == null) {
                return NotFound();
            }

            return mapper.Map<TDTO>(entidad);
        }

        //Metodo post para agregar un registro
        protected async Task<ActionResult> Post<TCreacion, TEntidad, TLectura>(TCreacion creacionDTO, string nombreRuta) where TEntidad : class, IId {
            try {
                var entidad = mapper.Map<TEntidad>(creacionDTO);
                context.Add(entidad);
                await context.SaveChangesAsync();
                var dtoLectura = mapper.Map<TLectura>(entidad);

                return new CreatedAtRouteResult(nombreRuta, new { id = entidad.Id }, dtoLectura);
            } catch (Exception e) {
                return Content(e.ToString());
            }


        }

        //Metodo Put para editar un registro completo
        protected async Task<ActionResult> Put<TCreacion, TEntidad>
            (int id, TCreacion creacionDTO) where TEntidad : class, IId {
            var entidad = mapper.Map<TEntidad>(creacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        //Metodo Delete para eliminar un registro (No lo usaremos por ahora)
        protected async Task<ActionResult> Delete<TEntidad>(int id) where TEntidad : class, IId, new() {
            var existe = await context.Set<TEntidad>().AnyAsync(x => x.Id == id);
            if (!existe) {
                return NotFound();
            }

            context.Remove(new TEntidad() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

        // Metodo patch para editar un campo en especifico de un registro
        protected async Task<ActionResult> Patch<TEntidad, TDTO>(int id) where TDTO : class where TEntidad : class, IId {

            var entidadDB = await context.Set<TEntidad>().FirstOrDefaultAsync(x => x.Id == id);

            if (entidadDB == null) {
                return NotFound();
            }

            var dto = mapper.Map<TDTO>(entidadDB);

            var isValid = TryValidateModel(dto);

            if (!isValid) {
                return BadRequest(ModelState);
            }

            mapper.Map(dto, entidadDB);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }

}
