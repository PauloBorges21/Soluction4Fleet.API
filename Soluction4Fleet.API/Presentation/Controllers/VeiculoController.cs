using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs.FrotaLocadora;
using Soluction4Fleet.API.Application.DTOs.Veiculo;
using Soluction4Fleet.API.Application.Interfaces.Services;


namespace Soluction4Fleet.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var veiculoDba = await _veiculoService.GetAllVeiculosAsync();
            return Ok(veiculoDba);
        }
               
        [HttpGet("{id}/busca-por-id")]
        public async Task<IActionResult> GetVeiculoByIdAsync(Guid id)
        {
            var veiculoDba = await _veiculoService.GetVeiculoByIdAsync(id);
            if (veiculoDba != null)
            {
                return Ok(veiculoDba);
            }
            else
            {
                return NotFound($"Locadora não foi encontrado.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateVeiculoDTO veiculoDTO)
        {
            if (veiculoDTO == null)
            {
                return BadRequest("locadora data is null.");
            }
            var veiculoDba = await _veiculoService.InsertVeiculoFrotaAsync(veiculoDTO);
            return Ok(veiculoDba);

        }


        [HttpPatch("troca-status/{veiculoId}")]
        public async Task<IActionResult> PatchStatusVeiculo(Guid veiculoId, [FromBody] StatusVeiculoDTO veiculoDTO)
        {
            if (veiculoDTO == null)
                return BadRequest("Dados do status são obrigatórios.");

            var veiculoAtualizado = await _veiculoService.UpdateStatusVeiculoFrotaAsync(veiculoId, veiculoDTO);

            if (veiculoAtualizado == null)
                return NotFound("Veículo não encontrado.");

            return Ok(veiculoAtualizado);
        }

        [HttpPost("transferencia")]
        public async Task<IActionResult> TransferirVeiculo(TransferirFrotaVeiculoDTO veiculoDTO)
        {
            if (veiculoDTO == null)
            {
                return BadRequest("locadora data is null.");
            }
            var veiculoDba = await _veiculoService.TransferirVeiculoAsync(veiculoDTO);
            return Ok(veiculoDba);

        }
    }
}
