using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkerTracking.Application.Features.Departments.Create;
using WorkerTracking.Application.Features.Departments.GetAll;
using WorkerTracking.Application.Features.Departments.GetById;
using WorkerTracking.Application.Features.Departments.Update;
using WorkerTracking.Application.Features.Departments.Delete;

namespace WorkerTracking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDepartmentCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetDepartmentsQuery());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetDepartmentByIdQuery(id));
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateDepartmentCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteDepartmentCommand(id));
        return NoContent();
    }
}