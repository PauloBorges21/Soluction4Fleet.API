using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Repository
{
    public interface ILocadoraRepository
    {
        Task<Locadora> InsertLocadoraAsync(Locadora locadora);
        Task<List<Locadora>> GetAllLocadorasAsync();
        Task<Locadora> GetLocadoraByIdAsync(Guid locadoraId);
        Task<Locadora> UpdadeLocadoraAsync(Locadora locadora);
        Task<bool> DeleteLocadoraAsync(Guid locadoraId);
    }
}
