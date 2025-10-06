using Soluction4Fleet.API.Application.DTOs.Montadora;
using Soluction4Fleet.API.Application.Responses;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IMontadoraService
    {
        Task<List<MontadoraDTO>> InsertMontadoraAsync(CreateMontadoraDTO montadoraDTO);
        Task<ApiResponse<List<MontadoraDTO>>> GetAllMontadorasAsync();
        Task<ApiResponse<MontadoraDTO>> GetMontadoraByIdAsync(Guid id);
        Task<MontadoraDTO> UpdadeMontadoraAsync(Guid montadoraId, UpdateMontadoraDTO updateMontadoraDTO);
        Task<bool> DeleteMontadoraAsync(Guid montadoraId);
    }
}
