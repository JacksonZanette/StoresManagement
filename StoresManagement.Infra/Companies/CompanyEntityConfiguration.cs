using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Infra.Companies;

internal sealed class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies")
            .HasKey(e => e.Id);

        builder.HasMany(e => e.Stores)
            .WithOne(e => e.Company);
    }
}