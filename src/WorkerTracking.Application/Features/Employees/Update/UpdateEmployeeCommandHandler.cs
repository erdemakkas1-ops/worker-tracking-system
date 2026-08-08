using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Application.Features.Employees.Update;

public sealed class UpdateEmployeeCommandHandler
    : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(
        UpdateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(
                x => x.Id == request.Id,
                cancellationToken);

        if (employee is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        employee.EmployeeNumber = request.EmployeeNumber;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Email = request.Email;
        employee.PhoneNumber = request.PhoneNumber;
        employee.DepartmentId = request.DepartmentId;
        employee.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
    }
}