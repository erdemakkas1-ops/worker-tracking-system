using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkerTracking.Application.Features.Employees.Create;

namespace WorkerTracking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}