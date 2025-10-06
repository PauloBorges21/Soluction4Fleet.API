using Soluction4Fleet.API.Application.DTOs.Modelo;
using Soluction4Fleet.API.Application.Responses;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IModeloService
    {
        Task<ApiResponse<List<ModeloDTO>>> GetAllModelosAsync();        
        Task<ModeloDTO> InsertModeloAsync(CreateModeloDTO modeloDTO);
        Task<ApiResponse<ModeloDTO>> GetModeloByIdAsync(Guid modeloId);
        Task<ModeloDTO> UpdadeModeloAsync(Guid modeloId, UpdateModeloDTO updateModeloDTO);
        Task<bool> DeleteModeloAsync(Guid modeloId);
    }
}
