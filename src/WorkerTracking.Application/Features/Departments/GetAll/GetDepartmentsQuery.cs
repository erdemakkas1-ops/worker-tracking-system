using MediatR;

namespace WorkerTracking.Application.Features.Departments.GetAll;

public sealed record GetDepartmentsQuery
    : IRequest<List<DepartmentDto>>;