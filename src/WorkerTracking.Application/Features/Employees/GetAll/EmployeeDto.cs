namespace WorkerTracking.Application.Features.Employees.GetAll;

public sealed class EmployeeDto
{
    public Guid Id { get; set; }

    public string EmployeeNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public Guid? DepartmentId { get; set; }

    public string? DepartmentName { get; set; }
}