using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Domain.Data;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Infrastructure.Repositories
{
    public class MontadoraRepository : IMontadoraRepository
    {
        private readonly Soluction4FleetContext _context;

        public MontadoraRepository(Soluction4FleetContext context)
        {
            _context = context;
        }

        public async Task<List<Montadora>> InsertMontadoraAsync(List<Montadora> montadora)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Montadoras.AddRangeAsync(montadora);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (montadora);
            }
            catch (Exception ex)
            {
                var erroCompleto = $"{ex.Message} | Inner: {ex.InnerException?.Message}";
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Montadora>> GetAllMontadorasAsync()
        {
            return await _context.Montadoras.ToListAsync();
        }

        public async Task<Montadora> GetMontadoraByIdAsync(Guid id)
        {
            return await _context.Montadoras.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Montadora> UpdadeMontadoraAsync(Montadora montadora)
        {
            _context.Montadoras.Update(montadora);
            await _context.SaveChangesAsync();
            return montadora;
        }

        public async Task<bool> DeleteMontadoraAsync(Guid montadoraId)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var montadora = await _context.Montadoras.FindAsync(montadoraId);
                montadora.Ativo = false;

                _context.Montadoras.Update(montadora);
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
