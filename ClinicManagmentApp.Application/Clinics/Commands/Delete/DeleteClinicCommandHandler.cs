namespace ClinicManagmentApp.Application.Clinics.Commands.Delete;
public class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommand, Unit>
{
    private readonly IRepository<Clinic> _clinicRepository;
    public DeleteClinicCommandHandler(IRepository<Clinic> clinicRepository)
    {
        _clinicRepository = clinicRepository;
    }
    public async Task<Unit> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
    {
        await _clinicRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
