using MediatR;
 
namespace WorkerTracking.Application.Features.Departments.Update;

public sealed record UpdateDepartmentCommand(
    Guid Id,
    string Name,
    string? Description
) : IRequest;