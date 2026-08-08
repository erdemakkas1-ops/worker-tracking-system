using MediatR;
using WorkerTracking.Application.Common.Interfaces;
using WorkerTracking.Domain.Entities;

namespace WorkerTracking.Application.Features.Employees.Create;

public sealed class CreateEmployeeCommandHandler
    : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            EmployeeNumber = request.EmployeeNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            DepartmentId = request.DepartmentId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Employees.Add(employee);

        await _context.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}