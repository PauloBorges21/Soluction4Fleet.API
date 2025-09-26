using AutoMapper;
using RT.Comb;
using Soluction4Fleet.API.Application.DTOs.Veiculo;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Infrastructure.Repositories;

namespace Soluction4Fleet.API.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ICombProvider _combProvider = Provider.Sql;
        public VeiculoService(IMapper mapper, IVeiculoRepository veiculoRepository, ICombProvider combProvider)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;
            _combProvider = combProvider;
        }

        public async Task<List<VeiculoDTO>> GetAllVeiculosAsync()
        {
            var veiculos = await _veiculoRepository.GetAllVeiculosAsync();
            return _mapper.Map<List<VeiculoDTO>>(veiculos);
        }
    }
}
