using Soluction4Fleet.API.Application.DTOs.Veiculo;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IVeiculoService
    {
        Task<List<VeiculoDTO>> GetAllVeiculosAsync();
    }
}
