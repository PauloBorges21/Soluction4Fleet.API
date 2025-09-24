using AutoMapper;
using Soluction4Fleet.API.Application.DTOs.Usuario;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _usuarioRepository.ObterPorEmailAsync(email);
            //return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<Usuario> BuscaPorId(Guid id)
        {
            return await _usuarioRepository.BuscaPorId(id);
            //return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}
