using Soluction4Fleet.API.Application.DTOs.Modelo;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Repository
{
    public interface IModeloRepository
    {
        Task<List<Modelo>> GetAllModelosAsync();
        Task<Modelo> GetModeloByIdAsync(Guid modeloId);
        Task<Modelo> InsertModeloAsync(Modelo modelo);
        Task<Modelo> UpdadeModeloAsync(Modelo modelo);
        Task<bool> DeleteModeloAsync(Guid modeloId);
    }
}
