using ClinicManagementApp.Domain.Entities;
using ClinicManagementApp.Domain.Interfaces;
using ClinicManagementApp.Infrastructure.Persistence.Data;
using ClinicManagementApp.Infrastructure.Persistence.Repositories;
using ClinicManagmentApp.API.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Clinic>, Repository<Clinic>>();

builder.Services.AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(CreateClinicCommand).Assembly));
builder.Services.AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(GetAllClinicsQuery).Assembly));
builder.Services.AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(GetClinicByIdQuery).Assembly));
builder.Services.AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(UpdateClinicCommand).Assembly));
builder.Services.AddMediatR(confg => confg.RegisterServicesFromAssembly(typeof(DeleteClinicCommand).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();