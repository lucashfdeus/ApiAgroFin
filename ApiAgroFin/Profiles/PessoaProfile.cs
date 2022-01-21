using ApiAgroFin.Data.Dtos;
using ApiAgroFin.Models;
using AutoMapper;

namespace ApiAgroFin.Profiles {
    public class PessoaProfile : Profile {

        public PessoaProfile() {

            CreateMap<Pessoa, PessoaDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();

        }

    }
}
