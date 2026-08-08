using MediatR;

namespace WorkerTracking.Application.Features.Departments.Delete;

public sealed record DeleteDepartmentCommand(Guid Id) : IRequest;