using Soluction4Fleet.API.Application.DTOs.FrotaLocadora;
using Soluction4Fleet.API.Application.DTOs.Veiculo;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IVeiculoService
    {
        Task<List<VeiculoDTO>> GetAllVeiculosAsync();
        Task<VeiculoDTO> InsertVeiculoFrotaAsync(CreateVeiculoDTO veiculoDTO);
        Task<VeiculoDTO> GetVeiculoByIdAsync(Guid veiculoId);
        Task<VeiculoDTO> UpdateStatusVeiculoFrotaAsync(Guid veiculoId, StatusVeiculoDTO veiculoDTO);
        Task<VeiculoDTO> TransferirVeiculoAsync(TransferirFrotaVeiculoDTO veiculoDTO);
    }
}
