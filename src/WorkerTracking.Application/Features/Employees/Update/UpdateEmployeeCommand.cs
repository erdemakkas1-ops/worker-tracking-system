using MediatR;

namespace WorkerTracking.Application.Features.Employees.Update;

public sealed record UpdateEmployeeCommand(
    Guid Id,
    string EmployeeNumber,
    string FirstName,
    string LastName,
    string Email,
    string? PhoneNumber,
    Guid? DepartmentId
) : IRequest;