using AutoMapper;
using Backend.Application.DTOs.BlocoDeNotasDTOs;
using Backend.Application.DTOs.UsuariosDTOs;
using Backend.Domain.Models.BlocoDeNotas;
using Backend.Domain.Models.Usuarios;

namespace Backend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioInputDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioOutputDTO>().ReverseMap();
            CreateMap<Notas, NotasInputDTO>().ReverseMap();
            CreateMap<Notas, NotasOutputDTO>().ReverseMap();
        }
        
    }
}