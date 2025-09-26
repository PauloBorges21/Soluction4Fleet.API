using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Application.DTOs.Relatorio;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Domain.Data;
using System;

namespace Soluction4Fleet.API.Infrastructure.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly Soluction4FleetContext _context;

        public RelatorioRepository(Soluction4FleetContext context)
        {
            _context = context;
        }

        public async Task<List<LocadoraVeiculoRelatorioDTO>> GetLocadorasVeiculosAsync(LocadoraVeiculoFiltroDTO filtro)
        {
            var query = _context.FrotaLocadoras
                .Include(f => f.Locadora)
                .Include(f => f.Veiculo)
                    .ThenInclude(v => v.Modelo)
                .AsQueryable();

            if (filtro.LocadoraId.HasValue)
                query = query.Where(f => f.LocadoraId == filtro.LocadoraId);

            if (filtro.DataInicio.HasValue)
            {
                var dataInicioTratada = filtro.DataInicio.Value.Date; // 2025-09-26 00:00:00
                query = query.Where(f => f.DataEntrada >= dataInicioTratada);
                //query = query.Where(f => f.DataEntrada.Value.Date; >= filtro.DataInicio);
            }
            if (filtro.DataFim.HasValue)
            {
                var dataFimTratada = filtro.DataFim.Value.Date.AddDays(1).AddTicks(-1); // 2025-09-26 23:59:59.9999999
                query = query.Where(f => f.DataSaida <= dataFimTratada);
                //query = query.Where(f => f.DataSaida <= filtro.DataFim);
            }
                

            if (filtro.ModeloId.HasValue)

                query = query.Where(f => f.Veiculo.ModeloId == filtro.ModeloId);

            return await query.Select(f => new LocadoraVeiculoRelatorioDTO
            {
                NomeLocadora = f.Locadora.NomeFantasia,
                Modelo = f.Veiculo.Modelo.Nome,
                Placa = f.Veiculo.Placa,
                DataCadastro = f.DataCriacao
            }).ToListAsync();
        }

        public async Task<List<LocadoraModeloRelatorioDTO>> GetLocadorasModelosAsync()
        {
            return await _context.FrotaLocadoras
                .Include(f => f.Locadora)
                .Include(f => f.Veiculo)
                    .ThenInclude(v => v.Modelo)
                .GroupBy(f => new { f.Locadora.NomeFantasia, f.Veiculo.Modelo.Nome })
                .Select(g => new LocadoraModeloRelatorioDTO
                {
                    NomeLocadora = g.Key.NomeFantasia,
                    Modelo = g.Key.Nome,
                    Quantidade = g.Count()
                })
                .ToListAsync();
        }

        public async Task<List<LogVeiculoRelatorioDTO>> GetLogVeiculosAsync()
        {
            return await _context.FrotaLocadoras
                .Include(f => f.Locadora)
                .Include(f => f.Veiculo)
                    .ThenInclude(v => v.Modelo)
                .Select(f => new LogVeiculoRelatorioDTO
                {
                    NomeLocadora = f.Locadora.NomeFantasia,
                    Modelo = f.Veiculo.Modelo.Nome,
                    DataEntrada = f.DataEntrada,
                    DataSaida = f.DataSaida
                })
                .ToListAsync();
        }
    }
}
