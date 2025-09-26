using AutoMapper;
using RT.Comb;
using Soluction4Fleet.API.Application.DTOs.FrotaLocadora;
using Soluction4Fleet.API.Application.DTOs.Locadora;
using Soluction4Fleet.API.Application.DTOs.Veiculo;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Infrastructure.Repositories;

namespace Soluction4Fleet.API.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IFrotaLocadoraService _frotaLocadoraService;
        private readonly ICombProvider _combProvider = Provider.Sql;
        public VeiculoService(IMapper mapper, IVeiculoRepository veiculoRepository, ICombProvider combProvider, IFrotaLocadoraService frotaLocadoraService)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;
            _combProvider = combProvider;
            _frotaLocadoraService = frotaLocadoraService;
        }

        public async Task<List<VeiculoDTO>> GetAllVeiculosAsync()
        {
            var veiculos = await _veiculoRepository.GetAllVeiculosAsync();
            return _mapper.Map<List<VeiculoDTO>>(veiculos);
        }

        public async Task<VeiculoDTO> GetVeiculoByIdAsync(Guid veiculoId)
        {
            try
            {
                var veiculo = await _veiculoRepository.GetVeiculoByIdAsync(veiculoId);
                return _mapper.Map<VeiculoDTO>(veiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<VeiculoDTO> InsertVeiculoFrotaAsync(CreateVeiculoDTO veiculoDTO)
        {
            try
            {
                var (veiculo, frota) = CriaVeiculoFrotaObj(veiculoDTO);
                await _veiculoRepository.InsertVeiculoFrotaAsync(veiculo, frota);
                return _mapper.Map<VeiculoDTO>(veiculo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<VeiculoDTO> UpdateStatusVeiculoFrotaAsync(Guid veiculoId, StatusVeiculoDTO veiculoDTO)
        {
            var veiculos = await _frotaLocadoraService.GetVeiculosByIdAsync(veiculoId);

            var veiculo = veiculos.FirstOrDefault(x => x.Status == 1);
            if (veiculo == null)
                return null;

            veiculo.Status = veiculoDTO.Status;
            veiculo.DataSaida = veiculoDTO.DataSaida;

            await _frotaLocadoraService.UpdateVeiculoAsync(veiculo);
            return _mapper.Map<VeiculoDTO>(veiculo);
        }

        public async Task<VeiculoDTO> TransferirVeiculoAsync(TransferirFrotaVeiculoDTO veiculoDTO)
        {
            try
            {
                var frota = CriaTransferirVeiculoObj(veiculoDTO);
                await _frotaLocadoraService.TransferirVeiculoAsync(frota);
                return _mapper.Map<VeiculoDTO>(frota);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private (Veiculo, FrotaLocadora) CriaVeiculoFrotaObj(CreateVeiculoDTO veiculoDTO)
        {

            var veiculoDba = new Veiculo
            {
                Id = _combProvider.Create(),
                NumeroPortas = veiculoDTO.NumeroPortas,
                Cor = veiculoDTO.Cor,
                Fabricante = veiculoDTO.Fabricante,
                AnoModelo = veiculoDTO.AnoModelo,
                AnoFabricacao = veiculoDTO.AnoFabricacao,
                Placa = veiculoDTO.Placa,
                Chassi = veiculoDTO.Chassi,
                DataCriacao = DateTime.Now,
                ModeloId = veiculoDTO.ModeloId,
                Ativo = true
            };

            var frotaDba = new FrotaLocadora
            {
                Id = _combProvider.Create(),
                LocadoraId = veiculoDTO.LocadoraId,
                VeiculoId = veiculoDba.Id,
                DataEntrada = veiculoDTO.DataEntrada,
                Status = veiculoDTO.Status
            };

            return (veiculoDba, frotaDba);
        }

        private FrotaLocadora CriaTransferirVeiculoObj(TransferirFrotaVeiculoDTO veiculoDTO)
        {         

            var frotaDba = new FrotaLocadora
            {
                Id = _combProvider.Create(),
                LocadoraId = veiculoDTO.LocadoraId,
                VeiculoId = veiculoDTO.VeiculoId,
                DataEntrada = veiculoDTO.DataEntrada,
                Status = 1
            };

            return (frotaDba);
        }
    }
}
