using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs.Relatorio;
using Soluction4Fleet.API.Application.Interfaces.Services;

namespace Soluction4Fleet.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _service;

        public RelatorioController(IRelatorioService service)
        {
            _service = service;
        }

        [HttpGet("locadoras-veiculos")]
        public async Task<IActionResult> LocadorasVeiculos([FromQuery] LocadoraVeiculoFiltroDTO filtro)
        {
            var csv = await _service.GetLocadorasVeiculosCsvAsync(filtro);
            return File(csv, "text/csv", "Relatorio_LocadorasVeiculos.csv");
        }

        [HttpGet("locadoras-modelos")]
        public async Task<IActionResult> LocadorasModelos()
        {
            var csv = await _service.GetLocadorasModelosCsvAsync();
            return File(csv, "text/csv", "Relatorio_LocadorasModelos.csv");
        }

        [HttpGet("log-veiculos")]
        public async Task<IActionResult> LogVeiculos()
        {
            var csv = await _service.GetLogVeiculosCsvAsync();
            return File(csv, "text/csv", "Relatorio_LogVeiculos.csv");
        }
    }
}

