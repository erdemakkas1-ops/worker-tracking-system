using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkerTracking.Application.Common.Interfaces;
using WorkerTracking.Infrastructure.Persistence.Seed;

namespace WorkerTracking.Infrastructure.Persistence;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();

        await context.Database.MigrateAsync();

        if (!await context.Roles.AnyAsync())
        {
            logger.LogInformation("Seeding roles...");
            context.Roles.AddRange(SeedData.GetRoles());
            await context.SaveChangesAsync();
        }

        if (!await context.Priorities.AnyAsync())
        {
            logger.LogInformation("Seeding priorities...");
            context.Priorities.AddRange(SeedData.GetPriorities());
            await context.SaveChangesAsync();
        }
        else
        {
            await SyncPriorityNamesAsync(context, logger);
        }

        if (!await context.Users.AnyAsync(u => u.Email == "admin@workertracking.local"))
        {
            logger.LogInformation("Seeding default administrator...");
            var admin = SeedData.GetDefaultAdministrator(passwordHasher.Hash("Admin123!"));
            context.Users.Add(admin);
            await context.SaveChangesAsync();
        }
        else
        {
            await SyncDefaultAdministratorAsync(context, logger);
        }
    }

    private static async Task SyncPriorityNamesAsync(
        ApplicationDbContext context,
        ILogger logger)
    {
        var expectedPriorities = SeedData.GetPriorities().ToDictionary(p => p.Id);

        var priorities = await context.Priorities.ToListAsync();
        var updated = false;

        foreach (var priority in priorities)
        {
            if (!expectedPriorities.TryGetValue(priority.Id, out var expected))
            {
                continue;
            }

            if (priority.Name == expected.Name &&
                priority.SortOrder == expected.SortOrder &&
                priority.ColorHex == expected.ColorHex)
            {
                continue;
            }

            priority.Name = expected.Name;
            priority.SortOrder = expected.SortOrder;
            priority.ColorHex = expected.ColorHex;
            updated = true;
        }

        if (updated)
        {
            logger.LogInformation("Synchronizing priority seed values...");
            await context.SaveChangesAsync();
        }
    }

    private static async Task SyncDefaultAdministratorAsync(
        ApplicationDbContext context,
        ILogger logger)
    {
        var admin = await context.Users
            .FirstOrDefaultAsync(u => u.Email == "admin@workertracking.local");

        if (admin is null)
        {
            return;
        }

        var expected = SeedData.GetDefaultAdministrator(admin.PasswordHash);
        var updated = false;

        if (admin.FirstName != expected.FirstName)
        {
            admin.FirstName = expected.FirstName;
            updated = true;
        }

        if (admin.LastName != expected.LastName)
        {
            admin.LastName = expected.LastName;
            updated = true;
        }

        if (updated)
        {
            logger.LogInformation("Synchronizing default administrator profile fields...");
            await context.SaveChangesAsync();
        }
    }
}
