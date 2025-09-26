using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Infrastructure.Data;

namespace Soluction4Fleet.API.Data.Configurations
{
    public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("Modelo");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .HasValueGenerator<CombGuidValueGenerator>()
                   .ValueGeneratedOnAdd();

            builder.Property(m => m.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(md => new { md.Nome, md.MontadoraId })
                   .IsUnique();

            builder.Property(m => m.Ativo)
           .HasDefaultValue(true);

            // Relacionamento com Montadora
            builder.HasOne(m => m.Montadora)
                   .WithMany(mon => mon.Modelos)
                   .HasForeignKey(m => m.MontadoraId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com Veículo
            builder.HasMany(m => m.Veiculos)
                   .WithOne(v => v.Modelo)
                   .HasForeignKey(v => v.ModeloId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
