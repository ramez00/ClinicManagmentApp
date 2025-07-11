namespace ClinicManagmentApp.Application.Clinics.Commands.Delete;
public record DeleteClinicCommand(int Id) : IRequest<Unit>;