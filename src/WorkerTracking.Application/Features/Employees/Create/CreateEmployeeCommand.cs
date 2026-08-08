using MediatR;

namespace WorkerTracking.Application.Features.Employees.Create;

public sealed record CreateEmployeeCommand(
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    string? PhoneNumber,
    Guid? DepartmentId
) : IRequest<Guid>;