using MediatR;
using WorkerTracking.Application.Common.Interfaces;
using WorkerTracking.Domain.Entities;

namespace WorkerTracking.Application.Features.Departments.Create;

public sealed class CreateDepartmentCommandHandler
    : IRequestHandler<CreateDepartmentCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(
        CreateDepartmentCommand request,
        CancellationToken cancellationToken)
        {
            var department = new Department
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Departments.Add(department);

            await _context.SaveChangesAsync(cancellationToken);

            return department.Id;
        }
        
}    