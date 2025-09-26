using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Locadora;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Common.Mappings
{
    public class LocadoraProfile : Profile
    {
        public LocadoraProfile()
        {
            // De Entidade → DTO
            CreateMap<Locadora, LocadoraDTO>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Endereco.Cep))
                .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Endereco.Rua))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Endereco.Bairro))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Endereco.Estado))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Cidade));

            // De DTO → Entidade
            CreateMap<LocadoraDTO, Locadora>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => new Endereco
                {
                    Cep = src.Cep,
                    Rua = src.Rua,
                    Numero = src.Numero,
                    Bairro = src.Bairro,
                    Estado = src.Estado,
                    Cidade = src.Cidade
                }));
        }
    }

}
