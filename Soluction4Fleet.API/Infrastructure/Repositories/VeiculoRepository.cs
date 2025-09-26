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
                return await _context.Veiculos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
