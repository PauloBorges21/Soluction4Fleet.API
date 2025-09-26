using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Infrastructure.Data;

namespace Soluction4Fleet.API.Data.Configurations
{
    public class MontadoraConfiguration : IEntityTypeConfiguration<Montadora>
    {
        public void Configure(EntityTypeBuilder<Montadora> builder)
        {
            builder.ToTable("Montadora");

            // Chave primária com Guid sequencial
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                 .HasValueGenerator<CombGuidValueGenerator>()
                 .ValueGeneratedOnAdd();

            builder.Property(m => m.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(m => m.Nome)
                   .IsUnique();

            builder.Property(m => m.Ativo)
                   .HasDefaultValue(true);

            // Relacionamento com Modelo
            builder.HasMany(m => m.Modelos)
                   .WithOne(md => md.Montadora)
                   .HasForeignKey(md => md.MontadoraId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
