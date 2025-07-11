using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagmentApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClinicsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClinicDto>>> GetAll()
    {
        var clinics = await _mediator.Send(new GetAllClinicsQuery());
        return Ok(clinics);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClinicDto>> GetById(int id)
    {
        var clinic = await _mediator.Send(new GetClinicByIdQuery(id));
        
        if (clinic is null)
            return NotFound();
        
        return Ok(clinic);
    }

    [HttpPost]
    public async Task<ActionResult<ClinicDto>> Create([FromBody] CreateClinicCommand command)
    {
        var clinic = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = clinic.Id }, clinic);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClinicCommand command)
    {
        var result = await _mediator.Send(command);

        if (result is null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteClinicCommand(id));
        return NoContent();
    }
}
