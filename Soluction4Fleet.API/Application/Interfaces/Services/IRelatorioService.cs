using Soluction4Fleet.API.Application.DTOs.Relatorio;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IRelatorioService
    {
        Task<byte[]> GetLocadorasVeiculosCsvAsync(LocadoraVeiculoFiltroDTO filtro);
        Task<byte[]> GetLocadorasModelosCsvAsync();
        Task<byte[]> GetLogVeiculosCsvAsync();

    }
}
