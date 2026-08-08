using MediatR;
using WorkerTracking.Application.Features.Departments.GetAll;

namespace WorkerTracking.Application.Features.Departments.GetById;

public sealed record GetDepartmentByIdQuery(Guid Id)
    : IRequest<DepartmentDto>;