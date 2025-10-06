using AutoMapper;
using RT.Comb;
using Soluction4Fleet.API.Application.DTOs;
using Soluction4Fleet.API.Application.DTOs.Usuario;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Application.Responses;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ICombProvider _combProvider = Provider.Sql;
        private readonly ISecurityService _securityService;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, ICombProvider combProvider, ISecurityService securityService)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _combProvider = combProvider;
            _securityService = securityService;
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _usuarioRepository.ObterPorEmailAsync(email);
            //return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<ApiResponse<UsuarioDTO>> BuscaPorId(Guid id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscaPorId(id);
                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
                return ApiResponseFactory.Success<UsuarioDTO>(usuarioDTO, "Usuário encontrado com sucesso!");
            }
            catch (Exception ex)
            {
                return ApiResponseFactory.Fail<UsuarioDTO>($"Ocorreu um erro: {ex.Message}");
            }

        }

        public async Task<ApiResponse<UsuarioDTO>> InsertUsuario(CreateUsuarioDTO usuarioDTO)
        {
            try
            {
                var usuarioExiste = await _usuarioRepository.ObterPorEmailAsync(usuarioDTO.Email);
                if (usuarioExiste != null)
                {
                    return ApiResponseFactory.Fail<UsuarioDTO>("Usuário já está cadastrado no sistema.");
                }



                if (usuarioDTO.Perfil != "ADMIN" && usuarioDTO.Perfil != "USUARIO")
                {

                    return ApiResponseFactory.Fail<UsuarioDTO>("Tipo de perfil Inválido. Cadastro permitido apenas para os perfis ADMIN ou USUARIO");
                }

                var usuarioDBA = ObjUsuario(usuarioDTO);
                var usuario = await _usuarioRepository.InsertUsuario(usuarioDBA);
                var usuarioDTOResponse = _mapper.Map<UsuarioDTO>(usuario);
                return ApiResponseFactory.Success<UsuarioDTO>(usuarioDTOResponse, "Usuário criado com sucesso!");
            }
            catch (Exception ex)
            {
                return ApiResponseFactory.Fail<UsuarioDTO>($"Ocorreu um erro: {ex.Message}");
            }

        }

        private Usuario ObjUsuario(CreateUsuarioDTO usuarioDTO)
        {
            try
            {
                //criptografando senha
                var senhaCrypto = _securityService.EncryptAsync(usuarioDTO.Senha).GetAwaiter().GetResult();

                var usuarioDba = new Usuario
                {
                    Id = _combProvider.Create(),
                    Email = usuarioDTO.Email,
                    Senha = senhaCrypto,
                    Perfil = usuarioDTO.Perfil,
                    Ativo = true
                };

                return usuarioDba;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
