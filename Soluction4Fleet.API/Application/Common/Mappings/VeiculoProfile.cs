using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Veiculo;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Domain.Enum;

namespace Soluction4Fleet.API.Application.Common.Mappings
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, VeiculoDTO>()
            .ForMember(dest => dest.NomeModelo,
                opt => opt.MapFrom(src => src.Modelo.Nome))
            .ForMember(dest => dest.NomeMontadora,
                opt => opt.MapFrom(src => src.Modelo.Montadora.Nome))
            .ForMember(dest => dest.LocadoraId,
                opt => opt.MapFrom(src => src.FrotaLocadoras
                    .OrderByDescending(f => f.DataEntrada)
                    .Select(f => f.LocadoraId)
                    .FirstOrDefault()))
            .ForMember(dest => dest.NomeLocadoura,
                opt => opt.MapFrom(src => src.FrotaLocadoras
                    .OrderByDescending(f => f.DataEntrada)
                    .Select(f => f.Locadora.NomeFantasia)
                    .FirstOrDefault()))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => (StatusCarro)src.FrotaLocadoras
                    .OrderByDescending(f => f.DataEntrada)
                    .Select(f => f.Status)
                    .FirstOrDefault()));
        }
    }
}
