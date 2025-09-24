using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuario;
        public UsuarioController(IMapper mapper, IUsuarioService usuario)
        {
            _usuario = usuario;
            _mapper = mapper;
        }

        [HttpGet("{id}/busca-por-id")]
        public async Task<IActionResult> BuscaPorId(Guid id)
        {
            var usuarioDba = await _usuario.BuscaPorId(id);
            if (usuarioDba != null)
            {
                return Ok(usuarioDba);
            }
            else
            {
                return NotFound($"Usuário com o ID {id} não foi encontrado.");
            }
        }
    }
}
