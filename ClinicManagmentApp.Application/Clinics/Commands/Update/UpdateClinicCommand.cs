namespace ClinicManagmentApp.Application.Clinics.Commands.Update;
public record UpdateClinicCommand(int Id,
    string Name,
    string Address,
    string PhoneNumber,
    string Email) : IRequest<ClinicDto>;