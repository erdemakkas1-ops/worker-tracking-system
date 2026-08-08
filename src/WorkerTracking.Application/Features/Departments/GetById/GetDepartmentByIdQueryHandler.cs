using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;
using WorkerTracking.Application.Features.Departments.GetAll;

namespace WorkerTracking.Application.Features.Departments.GetById;

public sealed class GetDepartmentByIdQueryHandler
    : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
{
    private readonly IApplicationDbContext _context;

    public GetDepartmentByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DepartmentDto> Handle(
        GetDepartmentByIdQuery request,
        CancellationToken cancellationToken)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (department is null)
            {
                throw new KeyNotFoundException("Department not found.");
            }    

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description

            };
        }
}    