using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IFrotaLocadoraService
    {
        Task<List<FrotaLocadora>> GetVeiculosByIdAsync(Guid veiculoId);
        Task<FrotaLocadora> UpdateVeiculoAsync(FrotaLocadora veiculo);
        Task<FrotaLocadora> TransferirVeiculoAsync(FrotaLocadora veiculo);
    }
}
