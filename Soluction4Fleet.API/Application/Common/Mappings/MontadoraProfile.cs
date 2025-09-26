using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Montadora;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Common.Mappings
{
    public class MontadoraProfile : Profile
    {
        public MontadoraProfile()
        {
            CreateMap<Montadora, MontadoraDTO>();
        }
    }
}
