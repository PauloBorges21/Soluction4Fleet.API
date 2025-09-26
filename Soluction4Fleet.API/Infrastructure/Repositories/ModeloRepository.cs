using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Domain.Data;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Infrastructure.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly Soluction4FleetContext _context;

        public ModeloRepository(Soluction4FleetContext context)
        {
            _context = context;
        }

        public async Task<List<Modelo>> GetAllModelosAsync()
        {
            return await _context.Modelos.ToListAsync();
        }

        public async Task<Modelo> GetModeloByIdAsync(Guid id)
        {
            return await _context.Modelos.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Modelo> InsertModeloAsync(Modelo modelo)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Modelos.AddAsync(modelo);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (modelo);
            }
            catch (Exception ex)
            {
                var erroCompleto = $"{ex.Message} | Inner: {ex.InnerException?.Message}";
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Modelo> UpdadeModeloAsync(Modelo modelo)
        {
            _context.Modelos.Update(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> DeleteModeloAsync(Guid modeloId)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var modelo = await _context.Modelos.FindAsync(modeloId);
                modelo.Ativo = false;

                _context.Modelos.Update(modelo);
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
