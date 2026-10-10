using HeroesMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesMvc.Data.Configurations;

public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("Vehiculos", "dbo");

        builder.HasKey(vehiculo => vehiculo.Id);

        builder.Property(vehiculo => vehiculo.Placa)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("Nro_Placa");

        builder.HasIndex(vehiculo => vehiculo.Placa)
            .IsUnique()
            .HasDatabaseName("UQ_Vehiculos_Placa");

        builder.Property(vehiculo => vehiculo.Modelo)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(vehiculo => vehiculo.CostoMantenimiento)
            .HasPrecision(12, 2);

        builder.Property(vehiculo => vehiculo.FechaAlta)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(vehiculo => vehiculo.Cuartel)
            .WithMany(cuartel => cuartel.Vehiculos)
            .HasForeignKey(vehiculo => vehiculo.CuartelId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
