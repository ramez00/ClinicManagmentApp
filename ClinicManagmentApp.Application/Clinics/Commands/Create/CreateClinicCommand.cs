namespace ClinicManagmentApp.Application.Clinics.Commands.Create;
public record CreateClinicCommand(string Name, string Address, string PhoneNumber, string Email)
    : IRequest<ClinicDto>
{
}