using Soluction4Fleet.API.Application.DTOs.Modelo;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IModeloService
    {
        Task<List<ModeloDTO>> GetAllModelosAsync();
        Task<ModeloDTO> InsertModeloAsync(CreateModeloDTO modeloDTO);
        Task<ModeloDTO> GetModeloByIdAsync(Guid modeloId);
        Task<ModeloDTO> UpdadeModeloAsync(Guid modeloId, UpdateModeloDTO updateModeloDTO);
        Task<bool> DeleteModeloAsync(Guid modeloId);
    }
}
