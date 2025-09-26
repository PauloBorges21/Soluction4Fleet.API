using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Domain.Data;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Infrastructure.Repositories
{
    public class FrotaLocadoraRepository : IFrotaLocadoraRepository
    {
        private readonly Soluction4FleetContext _context;

        public FrotaLocadoraRepository(Soluction4FleetContext context)
        {
            _context = context;
        }

        public async Task<List<FrotaLocadora>> GetVeiculosByIdAsync(Guid veiculoId)
        {

            try
            {
                return await _context.FrotaLocadoras
                .Where(m => m.VeiculoId == veiculoId)
                .Include(v => v.Veiculo)
                .Include(l => l.Locadora)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                var erroCompleto = $"{ex.Message} | Inner: {ex.InnerException?.Message}";
                throw;
            }
        }

        public async Task<FrotaLocadora> UpdateVeiculoAsync(FrotaLocadora veiculo)
        {
            _context.FrotaLocadoras.Update(veiculo);
            await _context.SaveChangesAsync();
            return veiculo;
        }

        public async Task<FrotaLocadora> TransferirVeiculoAsync(FrotaLocadora frotaLocadora)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.FrotaLocadoras.AddAsync(frotaLocadora);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return frotaLocadora;
            }
            catch (Exception ex)
            {
                var erroCompleto = $"{ex.Message} | Inner: {ex.InnerException?.Message}";
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
