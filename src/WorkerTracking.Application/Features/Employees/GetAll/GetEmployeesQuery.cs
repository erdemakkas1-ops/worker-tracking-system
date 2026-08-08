using MediatR;

namespace WorkerTracking.Application.Features.Employees.GetAll;

public sealed record GetEmployeesQuery : IRequest<List<EmployeeDto>>;