using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RT.Comb;
using Soluction4Fleet.API.Application.DTOs.Montadora;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Services
{
    public class MontadoraService : IMontadoraService
    {
        private readonly IMontadoraRepository _montadoraRepository;
        private readonly IMapper _mapper;
        private readonly ICombProvider _combProvider = Provider.Sql;

        public MontadoraService(IMontadoraRepository montadoraRepository, IMapper mapper, ICombProvider combProvider)
        {
            _montadoraRepository = montadoraRepository;
            _mapper = mapper;
            _combProvider = combProvider;
        }

        public async Task<List<MontadoraDTO>> InsertMontadoraAsync(CreateMontadoraDTO montadoraDTO)
        {
            //var montadora = _mapper.Map<Montadora>(montadoraDTO);
            var montadorasDBA = CriaMontadoraObj(montadoraDTO);

            await _montadoraRepository.InsertMontadoraAsync(montadorasDBA);
            return _mapper.Map<List<MontadoraDTO>>(montadorasDBA);
        }

        public async Task<List<MontadoraDTO>> GetAllMontadorasAsync()
        {
            var montadoras = await _montadoraRepository.GetAllMontadorasAsync();
            return _mapper.Map<List<MontadoraDTO>>(montadoras);
        }

        public async Task<MontadoraDTO> GetMontadoraByIdAsync(Guid id)
        {
            var montadora = await _montadoraRepository.GetMontadoraByIdAsync(id);
            return _mapper.Map<MontadoraDTO>(montadora);
        }

        public async Task<MontadoraDTO> UpdadeMontadoraAsync(Guid montadoraId, UpdateMontadoraDTO updateMontadoraDTO)
        {
            try
            {
                var montadoraDBA = await _montadoraRepository.GetMontadoraByIdAsync(montadoraId);
                UpdadeMontadoraObj(montadoraDBA, updateMontadoraDTO);

                await _montadoraRepository.UpdadeMontadoraAsync(montadoraDBA);
                return _mapper.Map<MontadoraDTO>(montadoraDBA);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> DeleteMontadoraAsync(Guid montadoraId)
        {
            try
            {
                return await _montadoraRepository.DeleteMontadoraAsync(montadoraId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<Montadora> CriaMontadoraObj(CreateMontadoraDTO montadoraDTO)
        {
            var montadoras = new List<Montadora>();
            foreach (var montadoraDtoItem in montadoraDTO.Montadoras)
            {
                var montadoraDba = new Montadora
                {
                    Id = _combProvider.Create(),
                    Nome = montadoraDtoItem.Nome,
                    PaisOrigem = montadoraDtoItem.PaisOrigem,
                    AnoFundacao = montadoraDtoItem.AnoFundacao,
                    Ativo = true
                };
                montadoras.Add(montadoraDba);
            }
            return (montadoras);
        }

        private void UpdadeMontadoraObj(Montadora montadora, UpdateMontadoraDTO dto)
        {
            montadora.Nome = dto.Nome ?? montadora.Nome;
            montadora.PaisOrigem = dto.PaisOrigem ?? montadora.PaisOrigem;
            montadora.AnoFundacao = dto.AnoFundacao ?? montadora.AnoFundacao;
        }
    }
}


