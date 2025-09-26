using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soluction4Fleet.API.Domain.Entities;

namespace Soluction4Fleet.API.Data.Configurations
{
    public class FrotaLocadoraConfiguration : IEntityTypeConfiguration<FrotaLocadora>
    {
        public void Configure(EntityTypeBuilder<FrotaLocadora> builder)
        {
            builder.ToTable("FrotaLocadora");

            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Veiculo)
                   .WithMany(v => v.FrotaLocadoras)
                   .HasForeignKey(f => f.VeiculoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Locadora)
                   .WithMany(l => l.FrotaLocadoras)
                   .HasForeignKey(f => f.LocadoraId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(f => f.DataEntrada)
                   .IsRequired();

            builder.Property(f => f.DataSaida);

            builder.Property(f => f.Status);

            builder.Property(f => f.DataCriacao)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
