using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Soluction4Fleet.API.Application.DTOs;
using Soluction4Fleet.API.Application.DTOs.Usuario;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Application.Responses;

namespace Soluction4Fleet.API.Application.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        public AuthService(IUsuarioRepository usuarioRepository, ITokenService tokenService, IMapper mapper, ISecurityService securityService)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _securityService = securityService;            
        }

        public async Task<ApiResponse<LoginFleetResponse>> Authenticate(LoginFleetRequest request)
        {
            try
            {
                var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);
                var senhaCrypto = _securityService.EncryptAsync(request.Password).GetAwaiter().GetResult();
                if (usuario == null || usuario.Senha != senhaCrypto)
                    return ApiResponseFactory.Fail<LoginFleetResponse>("Credenciais inválidas");


                var token = _tokenService.GerarToken(usuario);
                //return new LoginResponse(user, token);
                var retorno = new LoginFleetResponse(
                    token, usuario.Id ,usuario.Email, usuario.Perfil);
                return ApiResponseFactory.Success<LoginFleetResponse>(retorno, "Token criado com sucesso");
            }
            catch (Exception ex)
            {
                return ApiResponseFactory.Fail<LoginFleetResponse>($"Ocorreu um erro: {ex.Message}");
            }

        }

    }
}
