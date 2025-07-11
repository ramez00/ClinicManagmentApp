using ClinicManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicManagementApp.Infrastructure.Persistence.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    DbSet<Clinic> Clinic { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
        // Additional model configurations can be added here
    }
    // DbSet properties for your entities can be added here
}