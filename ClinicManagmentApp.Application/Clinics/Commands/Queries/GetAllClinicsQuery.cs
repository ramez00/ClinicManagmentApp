namespace ClinicManagmentApp.Application.Clinics.Commands.Queries;
public record GetAllClinicsQuery : IRequest<IEnumerable<ClinicDto>>;