using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Application.Features.Departments.Update;

public sealed class UpdateDepartmentCommandHandler
    : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(
        UpdateDepartmentCommand request,
        CancellationToken cancellationToken)
        {
            var department = await _context.Departments
                 .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if(department is null)
            {
                throw new KeyNotFoundException("Department not found.");
            } 

            department.Name = request.Name;
            department.Description = request.Description;
            department.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);    
        }
}    