using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Application.Features.Employees.Delete;

public sealed class DeleteEmployeeCommandHandler
    : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(
        DeleteEmployeeCommand request,
        CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (employee is null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync(cancellationToken);
    }
}