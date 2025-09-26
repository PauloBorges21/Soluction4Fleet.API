using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs.Locadora;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;


namespace Soluction4Fleet.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocadoraController : ControllerBase
    {
        private readonly ILocadoraService _locadoraService;
        public LocadoraController(ILocadoraService locadoraService)
        {
            _locadoraService = locadoraService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var locadoraDba = await _locadoraService.GetAllLocadorasAsync();
            return Ok(locadoraDba);
        }

        [HttpGet("{id}/busca-por-id")]
        public async Task<IActionResult> GetLocadoraByIdAsync(Guid id)
        {
            var locadoraDba = await _locadoraService.GetLocadoraByIdAsync(id);
            if (locadoraDba != null)
            {
                return Ok(locadoraDba);
            }
            else
            {
                return NotFound($"Locadora não foi encontrado.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLocadoraDTO locadoraDTO)
        {
            if (locadoraDTO == null)
            {
                return BadRequest("locadora data is null.");
            }
            var locadoraDba = await _locadoraService.InsertLocadoraAsync(locadoraDTO);
            return Ok(locadoraDba);

        }

        [HttpPut("{locadoraId}")]
        public async Task<IActionResult> Update(Guid locadoraId, [FromBody] UpdateLocadoraDTO updateLocadoraDTO)
        {

            if (updateLocadoraDTO == null)
            {
                return BadRequest("O objeto não pode ser nulo.");
            }

            var existelocadora = await _locadoraService.GetLocadoraByIdAsync(locadoraId);

            if (existelocadora == null)
            {
                return NotFound("Não encontrado");
            }

            await _locadoraService.UpdadeLocadoraAsync(locadoraId, updateLocadoraDTO);

            return NoContent();
        }

        [HttpDelete("{locadoraId}")]
        public async Task<IActionResult> Delete(Guid locadoraId)
        {
            var existelocadora = await _locadoraService.GetLocadoraByIdAsync(locadoraId);
            if (existelocadora == null)
            {
                return NotFound("Não encontrado");
            }
            await _locadoraService.DeleteLocadoraAsync(locadoraId);

            return NoContent();
        }

    }
}
