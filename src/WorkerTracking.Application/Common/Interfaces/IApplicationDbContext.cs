using Microsoft.EntityFrameworkCore;
using WorkerTracking.Domain.Entities;

namespace WorkerTracking.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Priority> Priorities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
