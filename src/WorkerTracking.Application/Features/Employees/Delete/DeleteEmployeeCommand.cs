using MediatR;

namespace WorkerTracking.Application.Features.Employees.Delete;

public sealed record DeleteEmployeeCommand(Guid Id) : IRequest;