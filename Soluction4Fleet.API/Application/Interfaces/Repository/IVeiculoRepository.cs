using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Repository
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> GetAllVeiculosAsync();
    }
}
