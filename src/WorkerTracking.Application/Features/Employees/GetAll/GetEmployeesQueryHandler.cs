using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Application.Features.Employees.GetAll;

public sealed class GetEmployeesQueryHandler
    : IRequestHandler<GetEmployeesQuery, List<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmployeeDto>> Handle(
        GetEmployeesQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Employees
            .Select(x => new EmployeeDto
            {
                Id = x.Id,
                EmployeeNumber = x.EmployeeNumber,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department != null
                    ? x.Department.Name
                    : null
            })
            .ToListAsync(cancellationToken);
    }
}