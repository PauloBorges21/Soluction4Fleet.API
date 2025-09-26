using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs.Modelo;
using Soluction4Fleet.API.Application.DTOs.Montadora;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Application.Services;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;
        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var montadoraDba = await _modeloService.GetAllModelosAsync();
            return Ok(montadoraDba);
        }

        [HttpGet("{id}/busca-por-id")]
        public async Task<IActionResult> GetModeloByIdAsync(Guid id)
        {
            var modeloDBA = await _modeloService.GetModeloByIdAsync(id);
            if (modeloDBA != null)
            {
                return Ok(modeloDBA);
            }
            else
            {
                return NotFound($"Locadora não foi encontrado.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateModeloDTO modeloDTO)
        {
            if (modeloDTO == null)
            {
                return BadRequest("Montadora data is null.");
            }
            var montadoraDba = await _modeloService.InsertModeloAsync(modeloDTO);
            return Ok(montadoraDba);

        }

        [HttpPut("{modeloId}")]
        public async Task<IActionResult> Update(Guid modeloId, [FromBody] UpdateModeloDTO updateModeloDTO)
        {

            if (updateModeloDTO == null)
            {
                return BadRequest("O objeto não pode ser nulo.");
            }

            var existeModelo = await _modeloService.GetModeloByIdAsync(modeloId);

            if (existeModelo == null)
            {
                return NotFound("Não encontrado");
            }

            await _modeloService.UpdadeModeloAsync(modeloId, updateModeloDTO);

            return NoContent();
        }

        [HttpDelete("{modeloId}")]
        public async Task<IActionResult> Delete(Guid modeloId)
        {
            var existeModelo = await _modeloService.GetModeloByIdAsync(modeloId);
            if (existeModelo == null)
            {
                return NotFound("Não encontrado");
            }
            await _modeloService.DeleteModeloAsync(modeloId);

            return NoContent();
        }
    }
}
