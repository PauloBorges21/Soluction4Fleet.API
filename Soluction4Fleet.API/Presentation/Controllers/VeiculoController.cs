using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.DTOs.Locadora;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Application.Services;

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

        //[HttpPost]
        //public async Task<IActionResult> Post(CreateVeiculoDTO veiculoDTO)
        //{
        //    if (veiculoDTO == null)
        //    {
        //        return BadRequest("locadora data is null.");
        //    }
        //    var veiculoDba = await _veiculoService.InsertLocadoraAsync(veiculoDTO);
        //    return Ok(veiculoDba);
                
        //}

    }
}
