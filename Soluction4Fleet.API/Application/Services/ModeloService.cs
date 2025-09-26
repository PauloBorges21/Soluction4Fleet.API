using AutoMapper;
using RT.Comb;
using Soluction4Fleet.API.Application.DTOs.Modelo;
using Soluction4Fleet.API.Application.DTOs.Montadora;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Infrastructure.Repositories;


namespace Soluction4Fleet.API.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;
        private readonly ICombProvider _combProvider = Provider.Sql;
        public ModeloService(IModeloRepository modeloRepository, IMapper mapper, ICombProvider combProvider)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
            _combProvider = combProvider;
        }

        public async Task<List<ModeloDTO>> GetAllModelosAsync()
        {
            var modelos = await _modeloRepository.GetAllModelosAsync();
            return _mapper.Map<List<ModeloDTO>>(modelos);

        }
        public async Task<ModeloDTO> GetModeloByIdAsync(Guid modeloId)
        {
            var modelo = await _modeloRepository.GetModeloByIdAsync(modeloId);
            return _mapper.Map<ModeloDTO>(modelo);
        }

        public async Task<ModeloDTO> InsertModeloAsync(CreateModeloDTO modeloDTO)
        {
            var modeloDBA = CriaModeloObj(modeloDTO);

            var modelo = await _modeloRepository.InsertModeloAsync(modeloDBA);
            return _mapper.Map<ModeloDTO>(modelo);
        }

        public async Task<ModeloDTO> UpdadeModeloAsync(Guid modeloId, UpdateModeloDTO updateModeloDTO)
        {
            try
            {
                var modeloDBA = await _modeloRepository.GetModeloByIdAsync(modeloId);
                UpdadeModeloObj(modeloDBA, updateModeloDTO);

                await _modeloRepository.UpdadeModeloAsync(modeloDBA);
                return _mapper.Map<ModeloDTO>(modeloDBA);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> DeleteModeloAsync(Guid modeloId)
        {
            try
            {
                return await _modeloRepository.DeleteModeloAsync(modeloId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Modelo CriaModeloObj(CreateModeloDTO modeloDTO)
        {
            var modeloDba = new Modelo
            {
                Id = _combProvider.Create(),
                MontadoraId = modeloDTO.MontadoraId,
                Nome = modeloDTO.Nome,
                Ativo = true
            };
            return (modeloDba);
        }

        private void UpdadeModeloObj(Modelo modelo, UpdateModeloDTO dto)
        {
            modelo.Nome = dto.Nome ?? modelo.Nome;
        }
    }
}
