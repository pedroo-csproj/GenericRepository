using GenericRepository.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Example.Data.Schemas;

public static class WaifuSchema
{
    public static void ConfigureWaifuSchema(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Waifu>(builder =>
        {
            builder.HasKey(w => w.Id);

            builder.HasIndex(w => w.Id);

            builder.Property(w => w.Id)
                .IsRequired();

            builder.Property(w => w.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(w => w.URL)
                .HasMaxLength(60)
                .IsRequired();
        });
    }
}