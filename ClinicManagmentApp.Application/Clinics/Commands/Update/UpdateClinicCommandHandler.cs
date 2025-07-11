namespace ClinicManagmentApp.Application.Clinics.Commands.Update;
public class UpdateClinicCommandHandler(
    IRepository<Clinic> clinicRepository) : IRequestHandler<UpdateClinicCommand, ClinicDto>
{
    private readonly IRepository<Clinic> _clinicRepository = clinicRepository;
    public async Task<ClinicDto> Handle(UpdateClinicCommand request, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetByIdAsync(request.Id);
        clinic.Name = request.Name;
        clinic.Address = request.Address;
        clinic.PhoneNumber = request.PhoneNumber;
        clinic.Email = request.Email;
        _clinicRepository.Update(clinic);
        return new ClinicDto
        {
            Id = clinic.Id,
            Name = clinic.Name,
            Address = clinic.Address,
            PhoneNumber = clinic.PhoneNumber,
            Email = clinic.Email
        };
    }
}