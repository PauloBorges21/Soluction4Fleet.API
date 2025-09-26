using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs.Montadora;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontadoraController : ControllerBase
    {
        private readonly IMontadoraService _montadoraService;

        public MontadoraController(IMontadoraService montadoraService)
        {
            _montadoraService = montadoraService;
        }
        // GET: api/Locadora
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var montadoraDba = await _montadoraService.GetAllMontadorasAsync();
            return Ok(montadoraDba);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMontadoraDTO montadoraDTO)
        {
            if (montadoraDTO == null)
            {
                return BadRequest("Montadora data is null.");
            }
            var montadoraDba = await _montadoraService.InsertMontadoraAsync(montadoraDTO);
            return Ok(montadoraDba);

        }

        [HttpPut("{montadoraId}")]
        public async Task<IActionResult> Update(Guid montadoraId, [FromBody] UpdateMontadoraDTO updateMontadoraDTO)
        {

            if (updateMontadoraDTO == null)
            {
                return BadRequest("O objeto não pode ser nulo.");
            }

            var existeMontadora = await _montadoraService.GetMontadoraByIdAsync(montadoraId);

            if (existeMontadora == null)
            {
                return NotFound("Não encontrado");
            }

            await _montadoraService.UpdadeMontadoraAsync(montadoraId, updateMontadoraDTO);

            return NoContent();
        }

        [HttpDelete("{montadoraId}")]
        public async Task<IActionResult> Delete(Guid montadoraId)
        {
            var existeMontadora = await _montadoraService.GetMontadoraByIdAsync(montadoraId);
            if (existeMontadora == null)
            {
                return NotFound("Não encontrado");
            }
            await _montadoraService.DeleteMontadoraAsync(montadoraId);

            return NoContent();
        }
    }
}
