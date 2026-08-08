using MediatR;

namespace WorkerTracking.Application.Features.Departments.Create;

public sealed record CreateDepartmentCommand(
    string Name,
    string? Description
): IRequest<Guid>;