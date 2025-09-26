using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Usuario;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Common.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
