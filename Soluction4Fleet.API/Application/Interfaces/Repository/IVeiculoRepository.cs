using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Repository
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> GetAllVeiculosAsync();
        Task<(Veiculo, FrotaLocadora)> InsertVeiculoFrotaAsync(Veiculo veiculo, FrotaLocadora frotaLocadora);
        Task<Veiculo> GetVeiculoByIdAsync(Guid veiculoId);
    }
}
