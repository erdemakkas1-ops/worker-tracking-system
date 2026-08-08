using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Application.Features.Departments.Delete;

public sealed class DeleteDepartmentCommandHandler
    : IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(
        DeleteDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var department = await _context.Departments
             .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (department is null)
        {
            throw new KeyNotFoundException("department not found");
        }     

        _context.Departments.Remove(department);

        await _context.SaveChangesAsync(cancellationToken);
    }    
}   