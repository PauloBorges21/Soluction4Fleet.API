using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Veiculo;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Common.Mappings
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, VeiculoDTO>();
        }
    }
}
