using Soluction4Fleet.API.Application.DTOs.Usuario;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> ObterPorEmailAsync(string email);
    }
}
