using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Domain.Data;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Soluction4FleetContext _context;

        public UsuarioRepository(Soluction4FleetContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> BuscaPorId(Guid id)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
        }

    }
}
