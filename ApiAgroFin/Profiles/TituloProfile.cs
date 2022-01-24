using ApiAgroFin.Data.Dtos;
using ApiAgroFin.Models;
using AutoMapper;

namespace ApiAgroFin.Profiles {
    public class TituloProfile : Profile {

        public TituloProfile() {

            CreateMap<Titulo, TituloDto>().ReverseMap();
            CreateMap<Recebedor, RecebedorDto>().ReverseMap();
            CreateMap<Pagador, PagadorDto>().ReverseMap();
        }


    }
}
