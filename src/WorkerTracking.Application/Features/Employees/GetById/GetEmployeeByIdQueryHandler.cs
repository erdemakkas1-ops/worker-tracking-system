using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;
using WorkerTracking.Application.Features.Employees.GetAll;

namespace WorkerTracking.Application.Features.Employees.GetById;

public sealed class GetEmployeeByIdQueryHandler
    : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeeByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> Handle(
        GetEmployeeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (employee is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        return new EmployeeDto
        {
            Id = employee.Id,
            EmployeeNumber = employee.EmployeeNumber,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        };
    }
}