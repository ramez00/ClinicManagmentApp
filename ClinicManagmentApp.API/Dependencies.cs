using ClinicManagementApp.Domain.Entities;
using ClinicManagementApp.Domain.Interfaces;
using ClinicManagementApp.Infrastructure.Persistence.Data;
using ClinicManagementApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicManagmentApp.API;

public static class Dependencies
{
    public static IServiceCollection AddAllDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();

        services.AddCors(options =>
            options.AddPolicy("AllowMyDomain", builder =>
               builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()  // Specific Method ("POST","PUT","GET")
                    .AllowAnyOrigin() // allow all cors 
            )
        );

        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                                  throw new InvalidOperationException("SQL DataBase Conncetion String..");

        return services.AddDataBaseConfig(connectionString)
                       .AddScoped<IRepository<Clinic>, Repository<Clinic>>()
                       .AddAllMediatRs();
    }

    private static IServiceCollection AddDataBaseConfig(this IServiceCollection services, string connectionString)
        => services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

    private static IServiceCollection AddAllMediatRs(this IServiceCollection services)
    {
        services
            .AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(CreateClinicCommand).Assembly))
            .AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(GetAllClinicsQuery).Assembly))
            .AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(GetClinicByIdQuery).Assembly))
            .AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(UpdateClinicCommand).Assembly))
            .AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(DeleteClinicCommand).Assembly));
        return services;
    }

}