using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Application.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorEmailAsync(string email);
        Task<Usuario> InsertUsuario(Usuario usuario);
        Task<Usuario> BuscaPorId(Guid id);
    }
}
