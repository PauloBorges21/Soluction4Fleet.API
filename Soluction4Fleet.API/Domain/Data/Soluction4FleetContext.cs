using Microsoft.EntityFrameworkCore;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Domain.Data
{
    public class Soluction4FleetContext : DbContext
    {
        public Soluction4FleetContext(DbContextOptions<Soluction4FleetContext> options)
            : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; } = null!;
        //public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<Montadora> Montadoras { get; set; } = null!;
        public DbSet<Locadora> Locadoras { get; set; } = null!;
        //public DbSet<FrotaLocadora> FrotaLocadoras { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Soluction4FleetContext).Assembly);

            modelBuilder.Entity<Locadora>().HasQueryFilter(l => l.Ativo);
            modelBuilder.Entity<Montadora>().HasQueryFilter(m => m.Ativo);
            modelBuilder.Entity<Modelo>().HasQueryFilter(md => md.Ativo);
            modelBuilder.Entity<Veiculo>().HasQueryFilter(v => v.Ativo);
            modelBuilder.Entity<Usuario>().HasQueryFilter(v => v.Ativo);

            base.OnModelCreating(modelBuilder);
        }
    }
}
