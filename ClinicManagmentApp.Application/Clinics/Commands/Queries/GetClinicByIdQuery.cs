
namespace ClinicManagmentApp.Application.Clinics.Commands.Queries;
public record GetClinicByIdQuery(int Id) : IRequest<ClinicDto>;