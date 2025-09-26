using Soluction4Fleet.API.Application.DTOs.Locadora;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface ILocadoraService
    {
        Task<LocadoraDTO> InsertLocadoraAsync(CreateLocadoraDTO locadoraDTO);
        Task<List<LocadoraDTO>> GetAllLocadorasAsync();
        Task<LocadoraDTO> GetLocadoraByIdAsync(Guid locadoraId);
        Task<LocadoraDTO> UpdadeLocadoraAsync(Guid locadoraId, UpdateLocadoraDTO updateLocadoraDTO);
        Task<bool> DeleteLocadoraAsync(Guid locadoraId);
    }
}
