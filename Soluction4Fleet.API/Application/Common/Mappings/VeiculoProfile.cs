using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Veiculo;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Common.Mappings
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, VeiculoDTO>()
           .ForMember(dest => dest.NomeModelo, opt => opt.MapFrom(src => src.Modelo.Nome))
           .ForMember(dest => dest.NomeMontadora, opt => opt.MapFrom(src => src.Modelo.Montadora.Nome));
        }
    }
}
