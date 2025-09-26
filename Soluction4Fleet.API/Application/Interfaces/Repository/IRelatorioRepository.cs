using Soluction4Fleet.API.Application.DTOs.Relatorio;

namespace Soluction4Fleet.API.Application.Interfaces.Repository
{
    public interface IRelatorioRepository
    {
        Task<List<LocadoraVeiculoRelatorioDTO>> GetLocadorasVeiculosAsync(LocadoraVeiculoFiltroDTO filtro);
        Task<List<LocadoraModeloRelatorioDTO>> GetLocadorasModelosAsync();
        Task<List<LogVeiculoRelatorioDTO>> GetLogVeiculosAsync();
    }
}
