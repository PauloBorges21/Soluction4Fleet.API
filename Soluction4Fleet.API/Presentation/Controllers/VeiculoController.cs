using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs.FrotaLocadora;
using Soluction4Fleet.API.Application.DTOs.Veiculo;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Application.Responses;
using Soluction4Fleet.API.Domain.Entities;


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
            if (veiculoDba == null)
                return NotFound(new ApiResponse<string>(null, "Não encontrado", false));

            return Ok(new ApiResponse<List<VeiculoDTO>>(veiculoDba, "Encontrado com sucesso"));

        }

        [HttpGet("{id}/busca-por-id")]
        public async Task<IActionResult> GetVeiculoByIdAsync(Guid id)
        {
            var veiculoDba = await _veiculoService.GetVeiculoByIdAsync(id);
            if (veiculoDba == null)
                return NotFound(new ApiResponse<string>(null, "Não encontrado", false));

            return Ok(new ApiResponse<VeiculoDTO>(veiculoDba, "Encontrado com sucesso"));
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateVeiculoDTO veiculoDTO)
        {
            if (veiculoDTO == null)
            {
                return BadRequest("locadora data is null.");
            }
            var veiculoDba = await _veiculoService.InsertVeiculoFrotaAsync(veiculoDTO);

            if (veiculoDba == null)
                return StatusCode(500, new ApiResponse<string>(null, "Erro ao criar veículo", false));

            return CreatedAtAction(nameof(GetVeiculoByIdAsync), new { id = veiculoDba.Id },
            new ApiResponse<VeiculoDTO>(veiculoDba, "Veículo criado com sucesso"));
        }


        [HttpPatch("troca-status/{veiculoId}")]
        public async Task<IActionResult> PatchStatusVeiculo(Guid veiculoId, [FromBody] StatusVeiculoDTO veiculoDTO)
        {
            if (veiculoDTO == null)
                return BadRequest("Dados do status são obrigatórios.");

            var veiculoAtualizado = await _veiculoService.UpdateStatusVeiculoFrotaAsync(veiculoId, veiculoDTO);

            if (veiculoAtualizado == null)
                return NotFound("Veículo não encontrado.");

            if (veiculoAtualizado == null)
                return NotFound(new ApiResponse<string>(null, "Não encontrado", false));

            //return Ok(new ApiResponse<VeiculoDTO>(veiculoAtualizado, "Encontrado com sucesso"));
            return NoContent(); // 204        
        }

        [HttpPost("transferencia")]
        public async Task<IActionResult> TransferirVeiculo(TransferirFrotaVeiculoDTO veiculoDTO)
        {
            if (veiculoDTO == null)
            {
                return BadRequest("locadora data is null.");
            }
            var veiculoDba = await _veiculoService.TransferirVeiculoAsync(veiculoDTO);

            if (veiculoDba == null)
                return StatusCode(500, new ApiResponse<string>(null, "Erro na transferencia do veículo", false));

            return Ok(new ApiResponse<VeiculoDTO>(veiculoDba, "Veículo Transferido"));

        }
    }
}
