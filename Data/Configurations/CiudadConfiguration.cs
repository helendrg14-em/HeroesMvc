using HeroesMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesMvc.Data.Configurations;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudades", "dbo");

        builder.HasKey(ciudad => ciudad.Id);

        builder.Property(ciudad => ciudad.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ciudad => ciudad.Pais)
            .IsRequired()
            .HasMaxLength(60);

        builder.HasIndex(ciudad => ciudad.Nombre)
            .IsUnique()
            .HasDatabaseName("UQ_Ciudades_Nombre");
    }
}
