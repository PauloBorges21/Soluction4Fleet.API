using AutoMapper;
using RT.Comb;
using Soluction4Fleet.API.Application.DTOs.Locadora;
using Soluction4Fleet.API.Application.DTOs.Montadora;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Infrastructure.Repositories;
using System.Runtime.CompilerServices;

namespace Soluction4Fleet.API.Application.Services
{
    public class LocadoraService : ILocadoraService
    {
        private readonly ILocadoraRepository _locadoraRepository;
        private readonly IMapper _mapper;
        private readonly ICombProvider _combProvider = Provider.Sql;

        public LocadoraService(ILocadoraRepository locadoraRepository, IMapper mapper, ICombProvider combProvider)
        {
            _locadoraRepository = locadoraRepository;
            _mapper = mapper;
            _combProvider = combProvider;
        }

        public async Task<List<LocadoraDTO>> GetAllLocadorasAsync()
        {
            var locadoras = await _locadoraRepository.GetAllLocadorasAsync();
            return _mapper.Map<List<LocadoraDTO>>(locadoras);
        }

        public async Task<LocadoraDTO> InsertLocadoraAsync(CreateLocadoraDTO locadoraDTO)
        {
            try
            {
                var locadorasDBA = CriaLocadoraObj(locadoraDTO);
                await _locadoraRepository.InsertLocadoraAsync(locadorasDBA);
                return _mapper.Map<LocadoraDTO>(locadorasDBA);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<LocadoraDTO> GetLocadoraByIdAsync(Guid locadoraId)
        {
            try
            {
                var locadora = await _locadoraRepository.GetLocadoraByIdAsync(locadoraId);
                return _mapper.Map<LocadoraDTO>(locadora);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LocadoraDTO> UpdadeLocadoraAsync(Guid locadoraId, UpdateLocadoraDTO updateLocadoraDTO)
        {
            try
            {
                var locadoraDBA = await _locadoraRepository.GetLocadoraByIdAsync(locadoraId);
                UpdadeLocadoraObj(locadoraDBA, updateLocadoraDTO);

                await _locadoraRepository.UpdadeLocadoraAsync(locadoraDBA);
                return _mapper.Map<LocadoraDTO>(locadoraDBA);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> DeleteLocadoraAsync(Guid locadoraId)
        {
            try
            {
                return await _locadoraRepository.DeleteLocadoraAsync(locadoraId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Locadora CriaLocadoraObj(CreateLocadoraDTO locadoraDTO)
        {

            var locadoraDba = new Locadora
            {
                Id = _combProvider.Create(),
                NomeFantasia = locadoraDTO.NomeFantasia,
                RazaoSocial = locadoraDTO.RazaoSocial,
                Cnpj = locadoraDTO.Cnpj,
                Email = locadoraDTO.Email,
                Telefone = locadoraDTO.Telefone,
                Endereco = new Endereco
                {
                    Cep = locadoraDTO.Cep,
                    Rua = locadoraDTO.Rua,
                    Numero = locadoraDTO.Numero,
                    Bairro = locadoraDTO.Bairro,
                    Estado = locadoraDTO.Estado,
                    Cidade = locadoraDTO.Cidade
                },
                Ativo = true
            };

            return (locadoraDba);
        }

        private void UpdadeLocadoraObj(Locadora locadora, UpdateLocadoraDTO dto)
        {
            locadora.NomeFantasia = dto.NomeFantasia ?? locadora.NomeFantasia;
            locadora.RazaoSocial = dto.RazaoSocial ?? locadora.RazaoSocial;
            //locadora.Cnpj = dto.Cnpj ?? locadora.Cnpj;
            locadora.Email = dto.Email ?? locadora.Email;
            locadora.Telefone = dto.Telefone ?? locadora.Telefone;
            locadora.Endereco.Cep = dto.Cep ?? locadora.Endereco.Cep;
            locadora.Endereco.Rua = dto.Rua ?? locadora.Endereco.Rua;
            locadora.Endereco.Numero = dto.Numero ?? locadora.Endereco.Numero;
            locadora.Endereco.Bairro = dto.Bairro ?? locadora.Endereco.Bairro;
            locadora.Endereco.Estado = dto.Estado ?? locadora.Endereco.Estado;
            locadora.Endereco.Cidade = dto.Cidade ?? locadora.Endereco.Cidade;
        }
    }
}
