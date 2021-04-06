using AppCovid.Server.DTOs;
using AppCovid.Server.DTOs.Direccion;
using AppCovid.Server.DTOs.Pais;
using AppCovid.Server.DTOs.Persona;
using AppCovid.Server.DTOs.Provincia;
using AppCovid.Shared;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCovid.Server.Helpers {
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles() {
            CreateMap<Persona, PersonaDTO>().ReverseMap();
            CreateMap<Persona, PersonaDireccionDTO>().ReverseMap();
            CreateMap<PersonaCreacionDTO, Persona>();


            CreateMap<Pais, PaisDTO>().ReverseMap();
            CreateMap<Pais, PaisDireccionDTO>().ReverseMap();
            CreateMap<PaisCreacionDTO, Pais>();

            CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
            CreateMap<Provincia, ProvinciaDireccionDTO>().ReverseMap();
            CreateMap<ProvinciaCreacionDTO, Provincia>();

            CreateMap<Direccion, DireccionDTO>().ReverseMap();
            CreateMap<DireccionCreacionDTO, Direccion>();
        }
    }
}
