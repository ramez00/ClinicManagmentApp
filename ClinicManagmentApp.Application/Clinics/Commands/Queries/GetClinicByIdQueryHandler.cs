namespace ClinicManagmentApp.Application.Clinics.Commands.Queries;
public class GetClinicByIdQueryHandler(IRepository<Clinic> clinicRepository) 
    : IRequestHandler<GetClinicByIdQuery,ClinicDto>
{
    private readonly IRepository<Clinic> _clinicRepository = clinicRepository;
    public async Task<ClinicDto> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetByIdAsync(request.Id);

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
