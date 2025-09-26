using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Domain.Data;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Infrastructure.Repositories
{
    public class LocadoraRepository : ILocadoraRepository
    {
        private readonly Soluction4FleetContext _context;

        public LocadoraRepository(Soluction4FleetContext context)
        {
            _context = context;
        }

        public async Task<Locadora> InsertLocadoraAsync(Locadora locadora)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Locadoras.AddAsync(locadora);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (locadora);
            }
            catch (Exception ex)
            {
                var erroCompleto = $"{ex.Message} | Inner: {ex.InnerException?.Message}";
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Locadora>> GetAllLocadorasAsync()
        {
            try
            {
                return await _context.Locadoras.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Locadora> GetLocadoraByIdAsync(Guid locadoraId)
        {
            try
            {
                return await _context.Locadoras.SingleOrDefaultAsync(l => l.Id == locadoraId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Locadora> UpdadeLocadoraAsync(Locadora locadora)
        {
            _context.Locadoras.Update(locadora);
            await _context.SaveChangesAsync();
            return locadora;
        }

        public async Task<bool> DeleteLocadoraAsync(Guid locadoraId)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var locadora = await _context.Locadoras.FindAsync(locadoraId);
                locadora.Ativo = false;

                _context.Locadoras.Update(locadora);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
