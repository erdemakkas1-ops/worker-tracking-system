using WorkerTracking.Domain.Constants;
using WorkerTracking.Domain.Entities;

namespace WorkerTracking.Infrastructure.Persistence.Seed;

public static class SeedData
{
    public static readonly Guid AdministratorRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid WorkerRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid DefaultAdminUserId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

    public static readonly Guid LowPriorityId = Guid.Parse("33333333-3333-3333-3333-333333333331");
    public static readonly Guid MediumPriorityId = Guid.Parse("33333333-3333-3333-3333-333333333332");
    public static readonly Guid HighPriorityId = Guid.Parse("33333333-3333-3333-3333-333333333333");
    public static readonly Guid CriticalPriorityId = Guid.Parse("33333333-3333-3333-3333-333333333334");

    public static Role[] GetRoles() =>
    [
        new Role { Id = AdministratorRoleId, Name = RoleNames.Administrator },
        new Role { Id = WorkerRoleId, Name = RoleNames.Worker }
    ];

    public static Priority[] GetPriorities() =>
    [
        new Priority { Id = LowPriorityId, Name = "Low", SortOrder = 1, ColorHex = "#6B7280" },
        new Priority { Id = MediumPriorityId, Name = "Medium", SortOrder = 2, ColorHex = "#3B82F6" },
        new Priority { Id = HighPriorityId, Name = "High", SortOrder = 3, ColorHex = "#F59E0B" },
        new Priority { Id = CriticalPriorityId, Name = "Critical", SortOrder = 4, ColorHex = "#EF4444" }
    ];

    public static User GetDefaultAdministrator(string passwordHash) => new()
    {
        Id = DefaultAdminUserId,
        Email = "admin@workertracking.local",
        PasswordHash = passwordHash,
        FirstName = "System",
        LastName = "Administrator",
        PhoneNumber = null,
        ProfilePhotoPath = null,
        RoleId = AdministratorRoleId,
        IsActive = true
    };
}
