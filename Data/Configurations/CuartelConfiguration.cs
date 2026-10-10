using HeroesMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesMvc.Data.Configurations;

public class CuartelConfiguration : IEntityTypeConfiguration<Cuartel>
{
    public void Configure(EntityTypeBuilder<Cuartel> builder)
    {
        builder.ToTable("Cuarteles", "dbo", table =>
            table.HasCheckConstraint(
                "CK_Cuarteles_Capacidad",
                "[Capacidad] > 0"));

        builder.HasKey(cuartel => cuartel.Id);

        builder.Property(cuartel => cuartel.Nombre)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(cuartel => cuartel.Direccion)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(cuartel => cuartel.Nombre)
            .IsUnique()
            .HasDatabaseName("UQ_Cuarteles_Nombre");
    }
}
