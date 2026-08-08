using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Application.Features.Departments.GetAll;

public sealed class GetDepartmentsQueryHandler
    : IRequestHandler<GetDepartmentsQuery, List<DepartmentDto>>
{
    private readonly IApplicationDbContext _context;

    public GetDepartmentsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DepartmentDto>> Handle(
        GetDepartmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Departments
            .Select(x => new DepartmentDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            })
            .ToListAsync(cancellationToken);
    }
}