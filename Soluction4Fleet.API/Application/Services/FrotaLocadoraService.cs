using AutoMapper;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Services
{
    public class FrotaLocadoraService : IFrotaLocadoraService
    {
        private readonly IFrotaLocadoraRepository _frotaLocadoraRepository;
        private readonly IMapper _mapper;

        public FrotaLocadoraService(IFrotaLocadoraRepository frotaLocadoraRepository, IMapper mapper)
        {
            _frotaLocadoraRepository = frotaLocadoraRepository;
            _mapper = mapper;
        }

        public async Task<List<FrotaLocadora>> GetVeiculosByIdAsync(Guid veiculoId)
        {
            try
            {
                var frota = await _frotaLocadoraRepository.GetVeiculosByIdAsync(veiculoId);
                return frota;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FrotaLocadora> UpdateVeiculoAsync(FrotaLocadora veiculo)
        {
            try
            {
                return await _frotaLocadoraRepository.UpdateVeiculoAsync(veiculo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FrotaLocadora> TransferirVeiculoAsync(FrotaLocadora veiculo)
        {
            try
            {
                var frota = await _frotaLocadoraRepository.TransferirVeiculoAsync(veiculo);
                return frota;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
