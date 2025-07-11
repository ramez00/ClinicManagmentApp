using ClinicManagementApp.Domain.Interfaces;
using System.Linq;

namespace ClinicManagmentApp.Application.Clinics.Commands.Queries;
public class GetAllClinicsQueryHandler(IRepository<Clinic> clinicRepository) : 
    IRequestHandler<GetAllClinicsQuery, IEnumerable<ClinicDto>>

{
    private readonly IRepository<Clinic> _clinicRepository = clinicRepository;

    public async Task<IEnumerable<ClinicDto>> Handle(GetAllClinicsQuery request, CancellationToken cancellationToken)
    {
        var clinics = await _clinicRepository.GetAllAsync();

        return clinics.Select(c => new ClinicDto
        {
            Id = c.Id,
            Name = c.Name,
            Address = c.Address,
            PhoneNumber = c.PhoneNumber,
            Email = c.Email
        });
    }
}
