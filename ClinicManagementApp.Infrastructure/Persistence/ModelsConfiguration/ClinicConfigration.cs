using ClinicManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagementApp.Infrastructure.Persistence.ModelsConfiguration;
public class ClinicConfigration : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}