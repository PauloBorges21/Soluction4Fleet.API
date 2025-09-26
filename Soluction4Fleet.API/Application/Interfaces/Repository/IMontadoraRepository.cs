using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Repository
{
    public interface IMontadoraRepository
    {
        Task<List<Montadora>> InsertMontadoraAsync(List<Montadora> montadora);
        Task<List<Montadora>> GetAllMontadorasAsync();
        Task<Montadora> GetMontadoraByIdAsync(Guid id);
        Task<Montadora> UpdadeMontadoraAsync(Montadora montadora);
        Task<bool> DeleteMontadoraAsync(Guid montadoraId);
    }
}
