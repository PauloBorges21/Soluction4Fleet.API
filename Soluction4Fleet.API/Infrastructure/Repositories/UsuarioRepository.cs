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
            try
            {
                return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Usuario> BuscaPorId(Guid id)
        {
            try
            {
                return await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Usuario> InsertUsuario(Usuario usuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
