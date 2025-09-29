using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Domain.Data;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Infrastructure.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly Soluction4FleetContext _context;
        public VeiculoRepository(Soluction4FleetContext context)
        {
            _context = context;
        }

        public async Task<List<Veiculo>> GetAllVeiculosAsync()
        {
            try
            {
                return await _context.Veiculos
                 .Include(v => v.Modelo)
                 .ThenInclude(m => m.Montadora)
                 .Include(v => v.FrotaLocadoras)
                 .ThenInclude(fl => fl.Locadora)
             .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(Guid veiculoId)
        {
            try
            {
                return await _context.Veiculos
                 .Include(v => v.Modelo)
                 .ThenInclude(m => m.Montadora)
                 .Include(v => v.FrotaLocadoras)
                 .ThenInclude(fl => fl.Locadora)
                    .SingleAsync(m => m.Id == veiculoId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(Veiculo, FrotaLocadora)> InsertVeiculoFrotaAsync(Veiculo veiculo, FrotaLocadora frotaLocadora)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Veiculos.AddAsync(veiculo);
                await _context.FrotaLocadoras.AddAsync(frotaLocadora);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return (veiculo, frotaLocadora);
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
