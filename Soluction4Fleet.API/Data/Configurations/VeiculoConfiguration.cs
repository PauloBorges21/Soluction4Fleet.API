using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Infrastructure.Data;

namespace Soluction4Fleet.API.Data.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                   .HasValueGenerator<CombGuidValueGenerator>()
                   .ValueGeneratedOnAdd();

            builder.Property(v => v.NumeroPortas)
                   .IsRequired();

            builder.Property(v => v.Cor)
                   .HasMaxLength(50);

            builder.Property(v => v.Fabricante)
                   .HasMaxLength(100);

            builder.Property(v => v.AnoModelo)
                   .IsRequired();

            builder.Property(v => v.AnoFabricacao)
                   .IsRequired();

            builder.Property(v => v.Placa)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(v => v.Chassi)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.DataCriacao)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(m => m.Ativo)
                   .HasDefaultValue(true);

            // Restrição única: Placa + Chassi
            builder.HasIndex(v => new { v.Placa, v.Chassi })
                   .IsUnique();

            // Relacionamento com Modelo
            builder.HasOne(v => v.Modelo)
                   .WithMany(md => md.Veiculos)
                   .HasForeignKey(v => v.ModeloId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
