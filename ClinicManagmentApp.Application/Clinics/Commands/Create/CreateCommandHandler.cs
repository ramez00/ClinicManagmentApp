namespace ClinicManagmentApp.Application.Clinics.Commands.Create;
public class CreateCommandHandler(IRepository<Clinic> clinicRepository) : IRequestHandler<CreateClinicCommand, ClinicDto>
{
    private readonly IRepository<Clinic> _clinicRepository = clinicRepository;
    public async Task<ClinicDto> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
    {
        var clinic = new Clinic
        {
            Name = request.Name,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email
        };
        await _clinicRepository.AddAsync(clinic);
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