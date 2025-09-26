using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Modelo;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Common.Mappings
{
    public class ModeloProfile : Profile
    {
        public ModeloProfile()
        {
            CreateMap<Modelo, ModeloDTO>();
        }
    }
}
