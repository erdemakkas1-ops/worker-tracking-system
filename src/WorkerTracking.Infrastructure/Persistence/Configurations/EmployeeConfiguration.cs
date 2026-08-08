using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkerTracking.Domain.Entities;

namespace WorkerTracking.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasOne(x => x.Department)
           .WithMany(x => x.Employees)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}