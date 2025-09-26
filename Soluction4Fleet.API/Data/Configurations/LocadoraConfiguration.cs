using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soluction4Fleet.API.Domain.Entities;
using Soluction4Fleet.API.Infrastructure.Data;

namespace Soluction4Fleet.API.Data.Configurations
{
    public class LocadoraConfiguration : IEntityTypeConfiguration<Locadora>
    {
        public void Configure(EntityTypeBuilder<Locadora> builder)
        {
            builder.ToTable("Locadora");

            builder.HasKey(l => l.Id);

            builder.Property(v => v.Id)
                 .HasValueGenerator<CombGuidValueGenerator>()
                 .ValueGeneratedOnAdd();

            builder.Property(l => l.Cnpj)
                   .IsRequired()
                   .HasMaxLength(14);

            builder.HasIndex(l => l.Cnpj)
                   .IsUnique();

            builder.Property(l => l.NomeFantasia)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(l => l.RazaoSocial)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(m => m.Ativo)
                   .HasDefaultValue(true);

            builder.HasMany(l => l.FrotaLocadoras)
                   .WithOne(fl => fl.Locadora)
                   .HasForeignKey(fl => fl.LocadoraId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Usando OwnsOne para mapear o endereço
            builder.OwnsOne(l => l.Endereco, endereco =>
            {
                endereco.Property(e => e.Cep).HasMaxLength(9);
                endereco.Property(e => e.Rua).HasMaxLength(200);
                endereco.Property(e => e.Numero).HasMaxLength(10);
                endereco.Property(e => e.Bairro).HasMaxLength(100);
                endereco.Property(e => e.Estado).HasMaxLength(2);
                endereco.Property(e => e.Cidade).HasMaxLength(100);

                // define prefixo das colunas (opcional)
                endereco.ToTable("Locadora"); // mantém na mesma tabela da Locadora
            });
        }
    }
}

