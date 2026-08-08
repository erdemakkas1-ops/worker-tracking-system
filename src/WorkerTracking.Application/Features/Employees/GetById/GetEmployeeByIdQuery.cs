using MediatR;
using WorkerTracking.Application.Features.Employees.GetAll;

namespace WorkerTracking.Application.Features.Employees.GetById;

public sealed record GetEmployeeByIdQuery(Guid Id)
    : IRequest<EmployeeDto>;