using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Soluction4Fleet.API.Application.DTOs;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;

namespace Soluction4Fleet.API.Application.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(IUsuarioRepository usuarioRepository, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;

        }

        public async Task<LoginFleetResponse> Authenticate(LoginFleetRequest request)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario == null || usuario.Senha != request.Password)
                throw new UnauthorizedAccessException("Credenciais inválidas");

            var token = _tokenService.GerarToken(usuario);
            //return new LoginResponse(user, token);
            var retorno = new LoginFleetResponse(
                token, usuario.Email, usuario.Perfil);
            return retorno;
        }

    }
}
