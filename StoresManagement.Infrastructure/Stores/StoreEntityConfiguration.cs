using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Models.ValueObjects;

namespace StoresManagement.Infra.Stores;

internal class StoreEntityConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Stores").HasKey(e => e.Id);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.StreetName)
            .HasColumnName(nameof(Address.StreetName))
            .IsRequired(true);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.CityName)
            .HasColumnName(nameof(Address.CityName))
            .IsRequired(true);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.RegionName)
            .HasColumnName(nameof(Address.RegionName))
            .IsRequired(true);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.PostalCode)
            .HasColumnName(nameof(Address.PostalCode))
            .IsRequired(true);

        builder.OwnsOne(e => e.Address)
            .Property(e => e.Country)
            .HasColumnName(nameof(Address.Country))
            .IsRequired(true);
    }
}