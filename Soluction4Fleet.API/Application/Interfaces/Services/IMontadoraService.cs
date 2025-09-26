using Soluction4Fleet.API.Application.DTOs.Montadora;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IMontadoraService
    {
        Task<List<MontadoraDTO>> InsertMontadoraAsync(CreateMontadoraDTO montadoraDTO);
        Task<List<MontadoraDTO>> GetAllMontadorasAsync();
        Task<MontadoraDTO> GetMontadoraByIdAsync(Guid id);
        Task<MontadoraDTO> UpdadeMontadoraAsync(Guid montadoraId, UpdateMontadoraDTO updateMontadoraDTO);
        Task<bool> DeleteMontadoraAsync(Guid montadoraId);
    }
}
