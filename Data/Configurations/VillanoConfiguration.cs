using HeroesMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeroesMvc.Data.Configurations;

public class VillanoConfiguration : IEntityTypeConfiguration<Villano>
{
    public void Configure(EntityTypeBuilder<Villano> builder)
    {
        builder.ToTable("Villanos", "dbo", table =>
            table.HasCheckConstraint(
                "CK_Villanos_NivelAmenaza",
                "[Nivel_Amenaza] BETWEEN 1 AND 5"));

        builder.HasKey(villano => villano.Id);

        builder.Property(villano => villano.Alias)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(villano => villano.NivelAmenaza)
            .HasColumnName("Nivel_Amenaza");

        builder.Property(villano => villano.Recompensa)
            .HasPrecision(10, 2);

        builder.Property(villano => villano.FechaRegistro)
            .HasDefaultValueSql("GETDATE()");

        builder.HasOne(villano => villano.Ciudad)
            .WithMany(ciudad => ciudad.Villanos)
            .HasForeignKey(villano => villano.CiudadId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
